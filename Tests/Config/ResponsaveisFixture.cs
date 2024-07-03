
using System.Text.RegularExpressions;
using TerceiroSetor.Domain.Entities.OrganizacoesSociais;
using Bogus;
using TerceiroSetor.Domain.ValueObjects;
using Bogus.Extensions.Brazil;
using Bogus.DataSets;

namespace TerceiroSetor.Tests.Config
{
    [CollectionDefinition(nameof(TerceiroSetorCollectionResp))]

    public class TerceiroSetorCollectionResp : ICollectionFixture<ResponsavelFixture> { }
    public class ResponsavelFixture
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
        public Responsavel GerarResponsavelValido()
        {
            var responsavel = new Faker<Responsavel>("pt_BR")
                .CustomInstantiator(f =>
                    new Responsavel(
                                    /*NomeCompleto      */f.Name.FirstName() + " " + f.Name.LastName(),
                                    /*Cpf               */GerarCpfValido(),
                                    /*EmailPessoal      */f.Internet.Email(),
                                    /*EmailInstitucional*/f.Internet.Email(),
                                    /*VinculoTrabalhista*/VinculoTrabalhista.CLT,
                                    /*InicioVigencia    */f.Date.Past(5),
                                    /*FinalVigencia     */f.Date.Past(6),
                                    /*UsuarioId         */Guid.NewGuid()
                    ));
            return responsavel.Generate();
        }

        public Responsavel GerarResponsavelInvalido_NameEmpty()
        {
            var responsavel = new Faker<Responsavel>("pt_BR")
                .CustomInstantiator(f =>
                    new Responsavel(
                                    /*NomeCompleto      */null,
                                    /*Cpf               */GerarCpfValido(),
                                    /*EmailPessoal      */f.Internet.Email(),
                                    /*EmailInstitucional*/f.Internet.Email(),
                                    /*VinculoTrabalhista*/VinculoTrabalhista.CLT,
                                    /*InicioVigencia    */f.Date.Past(5),
                                    /*FinalVigencia     */f.Date.Past(6),
                                    /*UsuarioId         */Guid.NewGuid()
                    ));
            return responsavel.Generate();
        }

        public Responsavel GerarResponsavelInvalido_CpfEmpty()
        {
            var responsavel = new Faker<Responsavel>("pt_BR")
                .CustomInstantiator(f =>
                    new Responsavel(
                                    /*NomeCompleto      */f.Name.FirstName() + " " + f.Name.LastName(),
                                    /*Cpf               */null,
                                    /*EmailPessoal      */f.Internet.Email(),
                                    /*EmailInstitucional*/f.Internet.Email(),
                                    /*VinculoTrabalhista*/VinculoTrabalhista.CLT,
                                    /*InicioVigencia    */f.Date.Past(5),
                                    /*FinalVigencia     */f.Date.Past(6),
                                    /*UsuarioId         */Guid.NewGuid()
                    ));
            return responsavel.Generate();
        }
        public Responsavel GerarResponsavelInvalido_CpfInvalido()
        {
            var responsavel = new Faker<Responsavel>("pt_BR")
                .CustomInstantiator(f =>
                    new Responsavel(
                                    /*NomeCompleto      */f.Name.FirstName() + " " + f.Name.LastName(),
                                    /*Cpf               */GerarCpfInvalido(),
                                    /*EmailPessoal      */f.Internet.Email(),
                                    /*EmailInstitucional*/f.Internet.Email(),
                                    /*VinculoTrabalhista*/VinculoTrabalhista.CLT,
                                    /*InicioVigencia    */f.Date.Past(5),
                                    /*FinalVigencia     */f.Date.Past(6),
                                    /*UsuarioId         */Guid.NewGuid()
                    ));
            return responsavel.Generate();
        }

        public Responsavel GerarResponsavelInvalido_EmailPessoalEmpty()
        {
            var responsavel = new Faker<Responsavel>("pt_BR")
                .CustomInstantiator(f =>
                    new Responsavel(
                                    /*NomeCompleto      */f.Name.FirstName() + " " + f.Name.LastName(),
                                    /*Cpf               */GerarCpfValido(),
                                    /*EmailPessoal      */null,
                                    /*EmailInstitucional*/f.Internet.Email(),
                                    /*VinculoTrabalhista*/VinculoTrabalhista.CLT,
                                    /*InicioVigencia    */f.Date.Past(5),
                                    /*FinalVigencia     */f.Date.Past(6),
                                    /*UsuarioId         */Guid.NewGuid()
                    ));
            return responsavel.Generate();
        }

        public Responsavel GerarResponsavelInvalido_EmailPessoalInvalido()
        {
            var responsavel = new Faker<Responsavel>("pt_BR")
                .CustomInstantiator(f =>
                    new Responsavel(
                                    /*NomeCompleto      */f.Name.FirstName() + " " + f.Name.LastName(),
                                    /*Cpf               */GerarCpfValido(),
                                    /*EmailPessoal      */"email_invalido",
                                    /*EmailInstitucional*/f.Internet.Email(),
                                    /*VinculoTrabalhista*/VinculoTrabalhista.CLT,
                                    /*InicioVigencia    */f.Date.Past(5),
                                    /*FinalVigencia     */f.Date.Past(6),
                                    /*UsuarioId         */Guid.NewGuid()
                    ));
            return responsavel.Generate();
        }

        public Responsavel GerarResponsavelInvalido_EmailInstitucionalEmpty()
        {
            var responsavel = new Faker<Responsavel>("pt_BR")
                .CustomInstantiator(f =>
                    new Responsavel(
                                    /*NomeCompleto      */f.Name.FirstName() + " " + f.Name.LastName(),
                                    /*Cpf               */GerarCpfValido(),
                                    /*EmailPessoal      */f.Internet.Email(),
                                    /*EmailInstitucional*/null,
                                    /*VinculoTrabalhista*/VinculoTrabalhista.CLT,
                                    /*InicioVigencia    */f.Date.Past(5),
                                    /*FinalVigencia     */f.Date.Past(6),
                                    /*UsuarioId         */Guid.NewGuid()
                    ));
            return responsavel.Generate();
        }

        public Responsavel GerarResponsavelInvalido_FimVigenciaMaiorQueInicioVigencia()
        {
            var responsavel = new Faker<Responsavel>("pt_BR")
                .CustomInstantiator(f =>
                    new Responsavel(
                                    /*NomeCompleto      */f.Name.FirstName() + " " + f.Name.LastName(),
                                    /*Cpf               */GerarCpfValido(),
                                    /*EmailPessoal      */f.Internet.Email(),
                                    /*EmailInstitucional*/f.Internet.Email(),
                                    /*VinculoTrabalhista*/VinculoTrabalhista.CLT,
                                    /*InicioVigencia    */f.Date.Past(4),
                                    /*FinalVigencia     */f.Date.Past(5),
                                    /*UsuarioId         */Guid.NewGuid()
                    ));
            return responsavel.Generate();
        }

    }
}

