using System.Text.RegularExpressions;
using TerceiroSetor.Domain.Entities.OrganizacoesSociais;
using Bogus;
using TerceiroSetor.Domain.ValueObjects;
using Bogus.Extensions.Brazil;

namespace TerceiroSetor.Tests.Config
{
    [CollectionDefinition(nameof(TerceiroSetorCollectionConselho))]
    public class TerceiroSetorCollectionConselho : ICollectionFixture<ConselhoFixture> { }

    public class ConselhoFixture
    {
       /* public Conselho GerarConselhoValido()
        {
            var conselho = new Faker<Conselho>("pt_BR")
                .CustomInstantiator(f =>
                    new Conselho(
                        1, 
                        f.Date.Past(2),
                        f.Date.Future(2)
                    ));
            return conselho.Generate();
        }

        public Conselho GerarConselhoInvalido_NomeEmpty()
        {
            var conselho = new Faker<Conselho>("pt_BR")
                .CustomInstantiator(f =>
                    new Conselho(
                        null,
                        f.Date.Past(2),
                        f.Date.Future(1),
                        f.Lorem.Sentence(),
                        Guid.NewGuid()
                    ));
            return conselho.Generate();
        }

        public Conselho GerarConselhoInvalido_DataCriacaoEmpty()
        {
            var conselho = new Faker<Conselho>("pt_BR")
                .CustomInstantiator(f =>
                    new Conselho(
                        f.Company.CompanyName(),
                        DateTime.MinValue,
                        f.Date.Future(1),
                        f.Lorem.Sentence(),
                        Guid.NewGuid()
                    ));
            return conselho.Generate();
        }

        public Conselho GerarConselhoInvalido_DataFimMaiorQueInicio()
        {
            var conselho = new Faker<Conselho>("pt_BR")
                .CustomInstantiator(f =>
                    new Conselho(
                        f.Company.CompanyName(),
                        f.Date.Future(1),
                        f.Date.Past(1),
                        f.Lorem.Sentence(),
                        Guid.NewGuid()
                    ));
            return conselho.Generate();
        }*/
    }
}
