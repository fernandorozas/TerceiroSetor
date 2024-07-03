
using System.Text.RegularExpressions;
using TerceiroSetor.Domain.Entities.OrganizacoesSociais;
using Bogus;
using TerceiroSetor.Domain.ValueObjects;
using Bogus.Extensions.Brazil;

namespace TerceiroSetor.Tests.Config
{
    [CollectionDefinition(nameof(TerceiroSetorCollection))]

    public class TerceiroSetorCollection : ICollectionFixture<OrganizacaoSocialFixture> { }
    public class OrganizacaoSocialFixture
    {

        public Cnpj GerarCnpjValido()
        {
            var faker = new Faker("pt_BR");
            var numeroCnpj = faker.Company.Cnpj();
            Regex regexObj = new Regex(@"[^\d]");
            numeroCnpj = regexObj.Replace(numeroCnpj, "");
            return new Cnpj(numeroCnpj);
        }

        public Cnpj GerarCnpjInvalido()
        {
            return new Cnpj("12345678912345");
        }

        private Cpf GerarCpfInvalido()
        {
            return new Cpf("12345678901");
        }

        private static string RemoverCaracteresNaoNumericos(string input)
        {
            Regex regexObj = new Regex(@"[^\d]");
            return regexObj.Replace(input, "");
        }

        public static string GerarTelefoneValido()
        {
            var faker = new Faker("pt_BR");
            var numeroTelefone = faker.Person.Phone;
            return RemoverCaracteresNaoNumericos(numeroTelefone);
        }

        public static string GerarTelefoneInvalidoNaoNumerico()
        {
            // Gerando um telefone inválido com caracteres especiais e letras
            var numeroTelefoneInvalido = "123-abc-!@#";
            return numeroTelefoneInvalido;
        }

        public static string GerarTelefoneInvalidoMaior14()
        {
            // Gerando um telefone inválido com caracteres especiais e letras
            var numeroTelefoneInvalido = "123456789012345";
            return numeroTelefoneInvalido;
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
        public OrganizacaoSocial GerarOrganizacaoSocialValido() => GerarOrganizacaoSocialValidos(1).FirstOrDefault();
        public OrganizacaoSocial GerarOrganizacaolInvalida_DataConstituicaoEmpty() => GerarOrganizacaoSocialInvalidas_DataConstituicaoEmpty(1).FirstOrDefault();
        public OrganizacaoSocial GerarOrganizacaolInvalida_NomeEmpty() => GerarOrganizacaoSocialInvalidas_NomeEmpty(1).FirstOrDefault();

        public IEnumerable<OrganizacaoSocial> GerarOrganizacaoSocialValidos(int quantidade)
        {
            var faker = new Faker("pt_BR");
            var organizacaoSocial = new Faker<OrganizacaoSocial>("pt_BR")
                .CustomInstantiator(f =>
                    new OrganizacaoSocial(

                        /*Nome 				   */f.Name.FirstName() + " " + f.Name.LastName(),
                        /*TipoOrganizacaoSocial*/ (int)TipoOrganizacaoSocial.OSCIP,
                        /*DataConstituicao 	   */ faker.Date.Past(5),
                        /*Endereco 			   */ GerarEnderecoValido(),
                        /*Telefone 		 	   */ GerarTelefoneValido(),
                        /*Cnpj 				   */ GerarCnpjValido().NumeroCnpj,
                        /*ArtigoReferencia 	   */ f.Random.String2(10),
                        /*FinalidadeResumida   */ f.Lorem.Sentence(),
                        /*Finalidade 		   */ Finalidade.AssistenciaSocial
                    ));
            return organizacaoSocial.Generate(quantidade);
        }
        public IEnumerable<OrganizacaoSocial> GerarOrganizacaoSocialInvalidas_NomeEmpty(int quantidade)
        {

            var faker = new Faker("pt_BR");

            var organizacaoSocial = new Faker<OrganizacaoSocial>("pt_BR")
                .CustomInstantiator(f =>
                    new OrganizacaoSocial(
                        /*Nome 				   */"",
                        /*TipoOrganizacaoSocial*/ (int)TipoOrganizacaoSocial.OSCIP,
                        /*DataConstituicao 	   */ faker.Date.Past(5),
                        /*Endereco 			   */ GerarEnderecoValido(),
                        /*Telefone 		 	   */ GerarTelefoneValido(),
                        /*Cnpj 				   */ GerarCnpjValido().NumeroCnpj,
                        /*ArtigoReferencia 	   */ f.Random.String2(10),
                        /*FinalidadeResumida   */ f.Lorem.Sentence(),
                        /*Finalidade 		   */ Finalidade.AssistenciaSocial
                    ));
            return organizacaoSocial.Generate(quantidade);
        }
        public IEnumerable<OrganizacaoSocial> GerarOrganizacaoSocialInvalidas_DataConstituicaoEmpty(int quantidade)
        {
            var faker = new Faker("pt_BR");
            var organizacaoSocial = new Faker<OrganizacaoSocial>("pt_BR")
                .CustomInstantiator(f =>
                    new OrganizacaoSocial(
                        /*Nome 				   */f.Name.FirstName() + " " + f.Name.LastName(), 
                        /*TipoOrganizacaoSocial*/ (int)TipoOrganizacaoSocial.OSCIP,
                        /*DataConstituicao 	   */ null,
                        /*Endereco 			   */ GerarEnderecoValido(),
                        /*Telefone 		 	   */ GerarTelefoneValido(),
                        /*Cnpj 				   */ GerarCnpjValido().NumeroCnpj,
                        /*ArtigoReferencia 	   */ f.Random.String2(10),
                        /*FinalidadeResumida   */ f.Lorem.Sentence(),
                        /*Finalidade 		   */ Finalidade.AssistenciaSocial
                    ));
            return organizacaoSocial.Generate(quantidade);
        }
        public OrganizacaoSocial GerarOrganizacaolInvalida_TelefoneEmpty()
        {
            var organizacaoSocial = new Faker<OrganizacaoSocial>("pt_BR")
                .CustomInstantiator(f =>
                    new OrganizacaoSocial(
                        /*Nome 				   */f.Name.FirstName() + " " + f.Name.LastName(),
                        /*TipoOrganizacaoSocial*/ (int)TipoOrganizacaoSocial.OSCIP,
                        /*DataConstituicao 	   */ f.Date.Past(5),
                        /*Endereco 			   */ GerarEnderecoValido(),
                        /*Telefone 		 	   */ null,
                        /*Cnpj 				   */ GerarCnpjValido().NumeroCnpj,
                        /*ArtigoReferencia 	   */ f.Random.String2(10),
                        /*FinalidadeResumida   */ f.Lorem.Sentence(),
                        /*Finalidade 		   */ Finalidade.AssistenciaSocial
                    ));
            return organizacaoSocial.Generate();
        }
        public OrganizacaoSocial GerarOrganizacaolInvalida_TelefoneInvalidoM14()
        {
            var organizacaoSocial = new Faker<OrganizacaoSocial>("pt_BR")
                .CustomInstantiator(f =>
                    new OrganizacaoSocial(
                        /*Nome 				   */f.Name.FirstName() + " " + f.Name.LastName(),
                        /*TipoOrganizacaoSocial*/ (int)TipoOrganizacaoSocial.OSCIP,
                        /*DataConstituicao 	   */ f.Date.Past(5),
                        /*Endereco 			   */ GerarEnderecoValido(),
                        /*Telefone 		 	   */ GerarTelefoneInvalidoMaior14(),
                        /*Cnpj 				   */ GerarCnpjValido().NumeroCnpj,
                        /*ArtigoReferencia 	   */ f.Random.String2(10),
                        /*FinalidadeResumida   */ f.Lorem.Sentence(),
                        /*Finalidade 		   */ Finalidade.AssistenciaSocial
                    ));
            return organizacaoSocial.Generate();
        }
        public OrganizacaoSocial GerarOrganizacaolInvalida_TelefoneInvalidoNaoNumerico()
        {
            var organizacaoSocial = new Faker<OrganizacaoSocial>("pt_BR")
                .CustomInstantiator(f =>
                    new OrganizacaoSocial(
                        /*Nome 				   */f.Name.FirstName() + " " + f.Name.LastName(),
                        /*TipoOrganizacaoSocial*/ (int)TipoOrganizacaoSocial.OSCIP,
                        /*DataConstituicao 	   */ f.Date.Past(5),
                        /*Endereco 			   */ GerarEnderecoValido(),
                        /*Telefone 		 	   */ GerarTelefoneInvalidoNaoNumerico(),
                        /*Cnpj 				   */ GerarCnpjValido().NumeroCnpj,
                        /*ArtigoReferencia 	   */ f.Random.String2(10),
                        /*FinalidadeResumida   */ f.Lorem.Sentence(),
                        /*Finalidade 		   */ Finalidade.AssistenciaSocial
                    ));
            return organizacaoSocial.Generate();
        }

        public OrganizacaoSocial GerarOrganizacaolInvalida_Cnpj_Invalido()
        {
            var organizacaoSocial = new Faker<OrganizacaoSocial>("pt_BR")
                .CustomInstantiator(f =>
                    new OrganizacaoSocial(
                        /*Nome 				   */f.Name.FirstName() + " " + f.Name.LastName(),
                        /*TipoOrganizacaoSocial*/ (int)TipoOrganizacaoSocial.OSCIP,
                        /*DataConstituicao 	   */ f.Date.Past(5),
                        /*Endereco 			   */ GerarEnderecoValido(),
                        /*Telefone 		 	   */ GerarTelefoneValido(),
                        /*Cnpj 				   */ GerarCnpjInvalido().NumeroCnpj,
                        /*ArtigoReferencia 	   */ f.Random.String2(10),
                        /*FinalidadeResumida   */ f.Lorem.Sentence(),
                        /*Finalidade 		   */ Finalidade.AssistenciaSocial
                    ));
            return organizacaoSocial.Generate();
        }

    }
}
