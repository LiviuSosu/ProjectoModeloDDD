﻿using ProjectDDD.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ProjectDDD.Infrasructure.EntityConfig
{
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            HasKey(c => c.ClienteId);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Sobrenome)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Sobrenome)
               .IsRequired()
               .HasMaxLength(150);

        }
    }
}
