//// -----------------------------------------------------------------------
//// <copyright file="ForumMap.cs" company="Fluent.Infrastructure">
////     Copyright © Fluent.Infrastructure. All rights reserved.
//// </copyright>
////-----------------------------------------------------------------------
/// This is a test file created by Fluent Infrastructure in order to 
/// illustrate its operation.
/// See more at: https://github.com/dn32/Fluent.Infrastructure/wiki
////-----------------------------------------------------------------------

using SIMPLEAPI_Demo_VB.Models;
using AutoMapper;
using Fluent.Infrastructure;
using System;

namespace SIMPLEAPI_Demo_VB.Mapper
{
    public class ForumMap : IFluentMap
    {
        public void Setup(IMapperConfiguration configure)
        {
            configure.CreateMap<ForumForm, Forum>()
                 .ForMember(x => x.Description, opt => opt.MapFrom(src => src.Name))
                 .ForMember(x => x.UpdateDate, opt => opt.MapFrom(src => DateTime.Now));

            configure.CreateMap<Forum, ForumForm>()
               .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Description));
        }
    }
}