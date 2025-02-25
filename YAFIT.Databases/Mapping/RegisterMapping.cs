﻿using FluentNHibernate.Mapping;
using YAFIT.Databases.Entities;

namespace YAFIT.Databases.Mapping;

public class RegisterMapping : ClassMap<RegisterEntity>
{
    public RegisterMapping()
    {
        Id(x => x.Id);
        Map(x => x.Code);
    }
}