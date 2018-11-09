using ProjectDDD.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ProjectDDD.Infrasructure.EntityConfig
{
    public class ProductConfigurarion : EntityTypeConfiguration<Produto>
    {
        public ProductConfigurarion()
        {
            HasKey(p => p.ProdutoId);

            Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(250);

            Property(p => p.Valor)
                .IsRequired();

            HasRequired(p => p.Cliente)
                .WithMany()
                .HasForeignKey(p => p.ClienteId);


        }
    }
}
