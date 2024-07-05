using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TerceiroSetor.Domain.Entities.OrganizacoesSociais;

namespace TerceiroSetor.Data.OrmConfiguration
{
    public class OrganizacaoSocialConfig : IEntityTypeConfiguration<OrganizacaoSocial>
    {
        public void Configure(EntityTypeBuilder<OrganizacaoSocial> builder)
        {
            builder.HasNoDiscriminator()
                .HasPartitionKey(x => x.Cnpj)
                .HasKey(x => x.Id);

            builder.Ignore(x => x.ValidationResult);

            builder.ToContainer("OrganizacoesSociais");
        }
    }

    /*
    public class ResponsavelConfig : IEntityTypeConfiguration<Responsavel>
    {
        public void Configure(EntityTypeBuilder<Responsavel> builder)
        {
            builder.Ignore(x => x.ValidationResult);
            builder.ToContainer("Responsavel");
            
        }
    }
    */
}
