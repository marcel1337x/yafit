﻿using FluentNHibernate.Mapping;
using YAFIT.Databases.Entities;

namespace YAFIT.Databases.Mapping;

public class UserMapping : ClassMap<UserEntity>
{
    public UserMapping()
    {
        Id(x => x.Id).GeneratedBy.Increment();
        Map(x => x.Name).Not.Nullable().Unique();
        Map(x => x.IsAdmin);
        Map(x => x.Password).Not.Nullable();
    }
}