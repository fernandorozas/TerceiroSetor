
using System.Text.RegularExpressions;
using TerceiroSetor.Domain.Entities.OrganizacoesSociais;
using Bogus;
using TerceiroSetor.Domain.ValueObjects;
using Bogus.Extensions.Brazil;
using Bogus.DataSets;
using TerceiroSetor.Domain.Entities.Shared;

namespace TerceiroSetor.Tests.Config
{
    [CollectionDefinition(nameof(TerceiroSetorCollectionPessoa))]

    public class TerceiroSetorCollectionPessoa : ICollectionFixture<PessoaFixture> { }
    public class PessoaFixture
    {

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
                                    /*NomeCompleto      */f.Name.FirstName() + " " + f.Name.LastName(),
                                    /*Cpf               */GerarCpfValido(),
                                    /*EmailPessoal      */f.Internet.Email(),
                                    /*EmailInstitucional*/f.Internet.Email(),
                                    /*Endereco*/        GerarEnderecoValido()
                    ));
            return pessoa.Generate();
        }

        public Pessoa Gerar_Pessoa_NameEmpty_Invalido()
        {
            var pessoa = new Faker<Pessoa>("pt_BR")
                .CustomInstantiator(f =>
                    new Pessoa(
                                    /*NomeCompleto      */null,
                                    /*Cpf               */GerarCpfValido(),
                                    /*EmailPessoal      */f.Internet.Email(),
                                    /*EmailInstitucional*/f.Internet.Email(),
                                    /*Endereco*/        GerarEnderecoValido()
                    ));
            return pessoa.Generate();
        }

        public Pessoa Gerar_Pessoa_CpfEmpty_Invalido()
        {
            var pessoa = new Faker<Pessoa>("pt_BR")
                .CustomInstantiator(f =>
                    new Pessoa(
                                    /*NomeCompleto      */f.Name.FirstName() + " " + f.Name.LastName(),
                                    /*Cpf               */GerarCpfInvalido(),
                                    /*EmailPessoal      */f.Internet.Email(),
                                    /*EmailInstitucional*/f.Internet.Email(),
                                    /*Endereco*/        GerarEnderecoValido()
                    ));
            return pessoa.Generate();
        }
        public Pessoa Gerar_Pessoa_Cpf_Invalido()
        {
            
            var pessoa = new Faker<Pessoa>("pt_BR")
                    .CustomInstantiator(f =>
                        new Pessoa(
                                        /*NomeCompleto      */f.Name.FirstName() + " " + f.Name.LastName(),
                                        /*Cpf               */GerarCpfInvalido(),
                                        /*EmailPessoal      */f.Internet.Email(),
                                        /*EmailInstitucional*/f.Internet.Email(),
                                        /*Endereco*/        GerarEnderecoValido()
                        ));
            return pessoa.Generate();
            
        }

        public Pessoa Gerar_Pessoa_Email_PessoalEmpty_Invalido()
        {
            var pessoa = new Faker<Pessoa>("pt_BR")
                .CustomInstantiator(f =>
                    new Pessoa(
                                    /*NomeCompleto      */f.Name.FirstName() + " " + f.Name.LastName(),
                                    /*Cpf               */GerarCpfValido(),
                                    /*EmailPessoal      */null,
                                    /*EmailInstitucional*/f.Internet.Email(),
                                    /*Endereco*/        GerarEnderecoValido()
                    ));
            return pessoa.Generate();
        }

        public Pessoa Gerar_Responsave_EmailPessoal_Invalido()
        {
            var pessoa = new Faker<Pessoa>("pt_BR")
                .CustomInstantiator(f =>
                    new Pessoa(
                                 /*NomeCompleto      */f.Name.FirstName() + " " + f.Name.LastName(),
                                 /*Cpf               */GerarCpfValido(),
                                 /*EmailPessoal      */"email invalido",
                                 /*EmailInstitucional*/f.Internet.Email(),
                                 /*Endereco*/        GerarEnderecoValido()
                    ));
            return pessoa.Generate();
        }

    }
}

