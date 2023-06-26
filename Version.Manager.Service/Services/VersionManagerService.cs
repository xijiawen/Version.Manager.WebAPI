using SqlSugar;
using System;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using Version.Manager.Model;
using Version.Manager.Model.Entitys;
using Version.Manager.Model.Models;
using Version.Manager.Model.Models.InDto;
using Version.Manager.Model.Models.OutDto;
using Version.Manager.Service.IServices;

namespace Version.Manager.Service.Services
{
    public class VersionManagerService : IVersionManagerService
    {
        public FileManagerModel QueryById(string Id)
        {
            FileManagerModel viewModelB = DBContext.GetContext().Queryable<FileManagerEntity>().First(d => d.Id == Id).MapTo<FileManagerEntity, FileManagerModel>();
            return viewModelB;
        }

        public List<VersionManagerOutDto> QueryList(VersionManagerInDto InDto)
        {
            Expressionable<VersionManagerEntity, SystemEntity> expression = new();
            expression.AndIF(InDto.IsNew!=0, (ver, sys)=>ver.IsNew==InDto.IsNew);
            //expression.AndIF(InDto.SystemType!=0, (ver, sys)=>sys.SystemType==InDto.SystemType);
            expression.AndIF(string.IsNullOrEmpty(InDto.SystemName), (ver, sys)=>sys.SystemName==InDto.SystemName);
            expression.AndIF(InDto.IsAddVersionManager!=null, (ver, sys)=>sys.IsAddVersionManager==InDto.IsAddVersionManager);
            
            return DBContext.GetContext()
                        .Queryable<VersionManagerEntity>()
                        .LeftJoin<SystemEntity>((ver, sys) => ver.SystemId == sys.Id)
                        .Where(expression.ToExpression())
                        .Select((ver, sys) => new VersionManagerOutDto()
                        {
                            Id = ver.Id,
                            IsNew = ver.IsNew,
                            SystemName = sys.SystemName,
                            //SystemType = sys.SystemType,
                            IsAddVersionManager = sys.IsAddVersionManager
                        }).ToList();
        }

        public void SaveVersion(List<FileManagerModel> lists)
        {
        }

        ///<summary> 
        ///获取表达式调用的字段名称 
        ///</summary> 
        ///<typeparam name="T"></typeparam>
        ///<param name="expr"></param> 
        ///<returns></returns> 
        private static string GetPropertyName<T>(Expression<Func<T, object>> expr)
        {
            switch (expr.Body)
            {
                case MemberExpression memberExpression:
                    return memberExpression.Member.Name;
                case UnaryExpression unaryExpression:
                    if (unaryExpression.Operand is MemberExpression expression)
                    {
                        return expression.Member.Name;
                    }
                    break;
                default: break;
            }
            return "";
        }

        public void SaveEntity(VersionManagerUpdateInDto InDto)
        {
            //新增
            if (string.IsNullOrEmpty(InDto.Id)) 
            {
                var entity = AutoMapperHelper.MapTo<VersionManagerUpdateInDto, VersionManagerEntity>(InDto);
                entity.Id = Guid.NewGuid().ToString();
                entity.CreateTime=DateTime.Now;
                entity.UpdateTime=DateTime.Now;
                entity.CreateUser = "001";
                entity.UpdateUser = "001"; entity.FileId = "001";entity.Remark = "";

                DBContext.GetContext().Insertable<VersionManagerEntity>(entity).ExecuteCommand();
            }
            else //更新
            {
                var entity = DBContext.GetContext().Queryable<VersionManagerEntity>().First(d=>d.Id==InDto.Id);
                AutoMapperHelper.MapTo<VersionManagerUpdateInDto, VersionManagerEntity>(InDto, entity);

                entity.UpdateTime = DateTime.Now;
                entity.UpdateUser = "001";

                DBContext.GetContext().Updateable<VersionManagerEntity>(entity).ExecuteCommand();
            }
        }

        public void DeleteById(string Id)
        {
            DBContext.GetContext().Deleteable<VersionManagerEntity>().Where(d=>d.Id==Id).ExecuteCommand(); ;
        }

        public void DeleteByIdList(List<string> Id)
        {
            throw new NotImplementedException();
        }

        public VersionManagerOutDto QueryVersionBySystemId(string systemId)
        {
            VersionManagerOutDto outDto = new();
            var entity = DBContext.GetContext().Queryable<VersionManagerEntity>().First(d => d.SystemId == systemId && d.IsNew == 1);
            if (entity!=null)
            {
                outDto.Version = entity.Version;
                outDto.IsNew = entity.IsNew;
                outDto.Id = entity.Id;
                outDto.SystemId = entity.SystemId;
            }
            return outDto;
        }

    }
}
