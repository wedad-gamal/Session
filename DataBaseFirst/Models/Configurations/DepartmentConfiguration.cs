﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using DataBaseFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace DataBaseFirst.Models.Configurations
{
    public partial class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> entity)
        {
            entity.HasIndex(e => e.ManagerId, "IX_Departments_ManagerId");

            entity.Property(e => e.ManagerId).HasDefaultValue(2);
            entity.Property(e => e.Name).IsRequired();

            entity.HasOne(d => d.Manager).WithMany(p => p.Departments)
                .HasForeignKey(d => d.ManagerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Department> entity);
    }
}
