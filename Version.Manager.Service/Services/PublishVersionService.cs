using SqlSugar;
using Version.Manager.Model.Entitys;
using Version.Manager.Model.Models.InDto;
using Version.Manager.Model.Models.OutDto;
using Version.Manager.Service.IServices;

namespace Version.Manager.Service.Services
{
    public class PublishVersionService : IPublishVersionService
    {
        public void PublishVersion(PublishVersionInDto InDto)
        {
            VersionManagerEntity verEntity = new();
            FileManagerEntity fileEntity = new();

            fileEntity.Id = Guid.NewGuid().ToString();
            fileEntity.CreateTime = DateTime.Now;
            fileEntity.UpdateTime = DateTime.Now;
            fileEntity.CreateUser = "001";
            fileEntity.UpdateUser = "001";
            fileEntity.FileName = InDto.FileName;
            fileEntity.FileSize = InDto.FileSize;

            verEntity.Id = Guid.NewGuid().ToString();
            verEntity.CreateTime = DateTime.Now;
            verEntity.UpdateTime = DateTime.Now;
            verEntity.CreateUser = "001";
            verEntity.UpdateUser = "001";
            verEntity.Version = InDto.Version;
            verEntity.IsNew = 2;//最新
            verEntity.FileId = fileEntity.Id;
            verEntity.SystemId = InDto.SystemId;

            try
            {
                //增加事务，防止保存一半出错
                DBContext.GetContext().Ado.BeginTran();

                var entity = DBContext.GetContext()
                                        .Queryable<VersionManagerEntity>()
                                        .First(d => d.SystemId == InDto.SystemId && d.IsNew == 2);

                //将原先的最先版本修改为不是最新
                if (entity != null)
                {
                    entity.IsNew = 1;
                    DBContext.GetContext().Updateable<VersionManagerEntity>(entity).ExecuteCommand();
                }

                DBContext.GetContext().Insertable<FileManagerEntity>(fileEntity).ExecuteCommand();
                DBContext.GetContext().Insertable<VersionManagerEntity>(verEntity).ExecuteCommand();
                DBContext.GetContext().Ado.CommitTran();
                //还需将文件上传到远程服务器

            }
            catch (Exception)
            {
                //回滚数据
                DBContext.GetContext().Ado.RollbackTran();
                throw;
            }

        }

        public List<PublishVersionOutDto> QueryPublishVersionList(QueryPublishVersionInDto InDto)
        {
            Expressionable<VersionManagerEntity, SystemEntity, FileManagerEntity> expression = new();
            //expression.AndIF(InDto. != 0, (ver, sys) => ver.IsNew == InDto.IsNew);
            //expression.AndIF(InDto.SystemType != 0, (ver, sys) => sys.SystemType == InDto.SystemType);
            //expression.AndIF(string.IsNullOrEmpty(InDto.SystemName), (ver, sys) => sys.SystemName == InDto.SystemName);
            //expression.AndIF(InDto.IsAddVersionManager != null, (ver, sys) => sys.IsAddVersionManager == InDto.IsAddVersionManager);

            return DBContext.GetContext()
                        .Queryable<VersionManagerEntity>()
                        .LeftJoin<SystemEntity>((ver, sys) => ver.SystemId == sys.Id)
                        .LeftJoin<FileManagerEntity>((ver, sys, file) => ver.FileId == file.Id)
                        .Where(expression.ToExpression())
                        .Select((ver, sys, file) => new PublishVersionOutDto()
                        {
                            Id = ver.Id,
                            IsNew = ver.IsNew,
                            SystemName = sys.SystemName,
                            //SystemType = sys.SystemType,
                            IsAddVersionManager = sys.IsAddVersionManager,
                            FileName = file.FileName,
                            FilePath = file.FilePath,
                            CreateTime = ver.CreateTime,
                            UpdateTime = ver.UpdateTime,
                            CreateUser = ver.CreateUser,
                            UpdateUser = ver.UpdateUser,
                            Remark = ver.Remark,

                        }).ToList();
        }

        public PublishVersionOutDto GetVersionAndFileBySystemId(string SystemId)
        {
            return DBContext.GetContext()
                        .Queryable<VersionManagerEntity>()
                        .LeftJoin<SystemEntity>((ver, sys) => ver.SystemId == sys.Id)
                        .LeftJoin<FileManagerEntity>((ver, sys, file) => ver.FileId == file.Id)
                        .Where((ver, sys, file) => ver.SystemId == SystemId && ver.IsNew == 2)
                        .Select((ver, sys, file) => new PublishVersionOutDto()
                        {
                            Id = ver.Id,
                            IsNew = ver.IsNew,
                            Version = ver.Version,
                            CreateTime = ver.CreateTime,
                            UpdateTime = ver.UpdateTime,
                            CreateUser = ver.CreateUser,
                            UpdateUser = ver.UpdateUser,
                            Remark = ver.Remark,
                            SystemName = sys.SystemName,
                            //SystemType = sys.SystemType,
                            IsAddVersionManager = sys.IsAddVersionManager,
                            FileName = file.FileName,
                            FilePath = file.FilePath,
                            FileSize = file.FileSize,

                        }).First();
        }

        public void UpdateVersionIsNew(string id)
        {
            //将指定的版本修改为最新版本
            DBContext.GetContext().Ado.BeginTran();
            var entity = DBContext.GetContext()
                                    .Queryable<VersionManagerEntity>()
                                    .First(d => d.Id == id);
            entity.IsNew = 2;

            //将原本的最新版本的标志删除掉
            var entityIsNew = DBContext.GetContext()
                                    .Queryable<VersionManagerEntity>()
                                    .First(d => d.SystemId == entity.SystemId && d.IsNew == 2);
            entityIsNew.IsNew = 1;
            try
            {
                DBContext.GetContext().Ado.BeginTran();//事务
                DBContext.GetContext().Updateable<VersionManagerEntity>(entity).ExecuteCommand();
                DBContext.GetContext().Updateable<VersionManagerEntity>(entityIsNew).ExecuteCommand();
                DBContext.GetContext().Ado.CommitTran();
            }
            catch (Exception)
            {
                //回滚数据
                DBContext.GetContext().Ado.RollbackTran();
                throw;
            }
        }
    }
}
