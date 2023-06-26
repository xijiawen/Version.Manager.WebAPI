using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Version.Manager.Model.Entitys;
using Version.Manager.Model.Models;
using Version.Manager.Model.Models.InDto;
using Version.Manager.Model.Models.OutDto;
using Version.Manager.Service.IServices;

namespace Version.Manager.Service.Services
{
    public class SystemService : ISystemService
    {
        public void DeleteById(string Id)
        {
            DBContext.GetContext().Deleteable<SystemEntity>().Where(d => d.Id == Id).ExecuteCommand(); ;
        }

        public void DeleteByIdList(List<string> Ids)
        {
            foreach (var item in Ids) 
            {
                DeleteById(item);
            }
        }

        public SystemOutDto QueryById(string Id)
        {
            return DBContext.GetContext()
                            .Queryable<SystemEntity>()
                            .First(d => d.Id == Id)
                            .MapTo<SystemEntity, SystemOutDto>();
        }

        public SystemOutDto QueryByName(string name)
        {
            return DBContext.GetContext()
                            .Queryable<SystemEntity>()
                            .First(d => d.SystemName.Contains(name))
                            .MapTo<SystemEntity, SystemOutDto>();
        }

        public List<SystemOutDto> QueryList(SystemInDto InDto)
        {
            Expressionable<SystemEntity> expression = new();
            expression.AndIF(!string.IsNullOrEmpty(InDto.SystemName),d=>d.SystemName==InDto.SystemName);
            expression.AndIF(InDto.IsAddVersionManager!=null, d=>d.IsAddVersionManager==InDto.IsAddVersionManager);
            return AutoMapperHelper
                    .MapToList<SystemEntity,SystemOutDto>(
                        DBContext.GetContext()
                                 .Queryable<SystemEntity>()
                                 .Where(expression.ToExpression()).ToList()).ToList();
        }

        public void SaveEntity(SystemInDto InDto)
        {
            //新增
            if (string.IsNullOrEmpty(InDto.Id))
            {
                var entity = AutoMapperHelper.MapTo<SystemInDto, SystemEntity>(InDto);
                entity.Id = Guid.NewGuid().ToString();
                entity.CreateTime = DateTime.Now;
                entity.UpdateTime = DateTime.Now;
                entity.CreateUser = "001";
                entity.UpdateUser = "001";

                DBContext.GetContext().Insertable<SystemEntity>(entity).ExecuteCommand();
            }
            else //更新
            {
                var entity = DBContext.GetContext().Queryable<SystemEntity>().First(d => d.Id == InDto.Id);
                AutoMapperHelper.MapTo<SystemInDto, SystemEntity>(InDto, entity);

                entity.UpdateTime = DateTime.Now;
                entity.UpdateUser = "001";

                DBContext.GetContext().Updateable<SystemEntity>(entity).ExecuteCommand();
            }
        }
    }
}
