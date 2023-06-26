﻿using AutoMapper;

namespace Version.Manager.Service.Services
{
    public static class AutoMapperHelper
    {
        /// <summary>
        ///  类型映射,默认字段名字一一对应
        /// </summary>
        /// <typeparam name="TDestination">转化之后的实体</typeparam>
        /// <typeparam name="TSource">要被转化的实体，Entity</typeparam>
        /// <param name="source">可以使用这个扩展方法的类型，任何引用类型</param>
        /// <returns>转化之后的实体</returns>
        public static TDestination MapTo<TSource, TDestination>(this TSource source)
            where TDestination : class
            where TSource : class
        {
            if (source == null)
            {
                return default(TDestination);
            }
            //创建映射关系
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDestination>());
            //基于config生成mapper
            var mapper = config.CreateMapper();
            mapper.Map<TSource, TDestination>(source);
            //执行转换
            return mapper.Map<TDestination>(source);
        }

        /// <summary>
        /// 集合列表类型映射,默认字段名字一一对应
        /// </summary>
        /// <typeparam name="TDestination">转化之后的实体</typeparam>
        /// <typeparam name="TSource">要被转化的实体，Entity</typeparam>
        /// <param name="source">可以使用这个扩展方法的类型，任何引用类型</param>
        /// <returns>转化之后的实体列表</returns>
        public static IEnumerable<TDestination> MapToList<TSource, TDestination>(this IEnumerable<TSource> source)
            where TDestination : class
            where TSource : class
        {
            if (source == null)
            {
                return new List<TDestination>();
            }
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDestination>());
            var mapper = config.CreateMapper();
            return mapper.Map<List<TDestination>>(source);
        }

        public static TDestination MapTo<TSource, TDestination>(this TSource source,TDestination des)
            where TDestination : class
            where TSource : class
        {
            if (source == null)
            {
                return des;
            }
            //创建映射关系
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDestination>());
            //基于config生成mapper
            var mapper = config.CreateMapper();
            //执行转换
            mapper.Map<TSource, TDestination>(source, des);
            return des;
        }
    }
}
