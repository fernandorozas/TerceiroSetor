
using System.Text.RegularExpressions;
using TerceiroSetor.Domain.Entities.OrganizacoesSociais;
using Bogus;
using TerceiroSetor.Domain.ValueObjects;
using Bogus.Extensions.Brazil;
using Bogus.DataSets;
using TerceiroSetor;
using TerceiroSetor.Domain.Entities.Shared;

namespace TerceiroSetor.Tests.Config
{
    [CollectionDefinition(nameof(TerceiroSetorCollectionConselhoMembro))]

    public class TerceiroSetorCollectionConselhoMembro : ICollectionFixture<ConselhoMembroFixture> { }

    public class ConselhoMembroFixture
    {
        private readonly PessoaFixture _pessoaFixture;


        public ConselhoMembroFixture()
        {
            _pessoaFixture = new PessoaFixture();
        }

        public Pessoa Gerar_Pessoa_Valido()
        {
            return _pessoaFixture.Gerar_Pessoa_Valido();
        }

        /*
        private string GerarCpfValido()
        {
            var faker = new Faker("pt_BR");
            var numeroCpf = faker.Person.Cpf();

            Regex regexObj = new Regex(@"[^\d]");
            numeroCpf = regexObj.Replace(numeroCpf, "");

            return numeroCpf;
        }
        private String GerarCpfInvalido()
        {
            return "12345678901";
        }

        public Endereco GerarEnderecoValido() => GerarEnderecosValidos(1).FirstOrDefault();
        public Endereco GerarEnderecoInvalido() => new Endereco("", "", "", "", "", "", "");

        public IEnumerable<Endereco> GerarEnderecosValidos(int quantidade)
        {
            var endereco = new Faker<Endereco>("pt_BR")
                .CustomInstantiator(f =>
                    new Endereco(
                        f.Address.ZipCode().Replace("-", ""),
                        f.Address.StreetAddress(),
                        f.Address.BuildingNumber(),
                        f.Address.StreetSuffix(),
                        f.Address.StreetName(),
                        f.Address.City(),
                        f.Address.State()
            ));
            return endereco.Generate(quantidade);
        }
        public Pessoa Gerar_Pessoa_Valido()
        {
            var pessoa = new Faker<Pessoa>("pt_BR")
                .CustomInstantiator(f =>
                    new Pessoa(
                                    f.Name.FirstName() + " " + f.Name.LastName(),
                                    GerarCpfValido(),
                                    f.Internet.Email(),
                                    f.Internet.Email(),
                                    GerarEnderecoValido()
                    ));
            return pessoa.Generate();
        }
        */


        public ConselhoMembro Gerar_ConselhoMembro_Valido()
        {

            var conselhoMembro = new Faker<ConselhoMembro>("pt_BR")
                .CustomInstantiator(f =>
                    new ConselhoMembro(
                                    /*Pessoa*/            Gerar_Pessoa_Valido(),
                                    /*InicioVigencia    */f.Date.Past(1),
                                    /*FinalVigencia     */f.Date.Future(6)
                    ));
            return conselhoMembro.Generate();
        }

        /*public ConselhoMembro Gerar_ConselhoMembrol_PessoaEmpty_Invalido()
        {
            var conselhoMembro = new Faker<ConselhoMembro>("pt_BR")
                .CustomInstantiator(f =>
                    new ConselhoMembro(
                                    null,
                                    f.Date.Past(6),
                                    f.Date.Past(5)
                    ));
            return conselhoMembro.Generate();
        }*/

        public ConselhoMembro Gerar_ConselhoMembrol_IniVigenciaMaior_Invalido()
        {

            var conselhoMembro = new Faker<ConselhoMembro>("pt_BR")
                .CustomInstantiator(f =>
                    new ConselhoMembro(
                                    /*Pessoa*/            Gerar_Pessoa_Valido(),
                                    /*InicioVigencia    */f.Date.Future(1),
                                    /*FinalVigencia     */f.Date.Past(1)
                    ));
            return conselhoMembro.Generate();
        }
       

    }
}

