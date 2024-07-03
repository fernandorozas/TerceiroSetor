using FluentAssertions;
using TerceiroSetor.Tests.Config;

namespace TerceiroSetor.Tests
{
    [Collection(nameof(TerceiroSetorCollection))]
    public class OrganizacaoSocialTeste
    {
        private readonly OrganizacaoSocialFixture _fixtures;
        public OrganizacaoSocialTeste(OrganizacaoSocialFixture fixtures) => _fixtures = fixtures;

        [Trait("Categoria", "Organizacao Social Válida")]
        [Fact]
            public void Criar_Organizacao_Social_Valida_DeveSerValido()
            {
                // Arrange
                var organizacaoSocial = _fixtures.GerarOrganizacaoSocialValido();

                // Act
                var isValid = organizacaoSocial.IsValid();
                var validationResult = organizacaoSocial.ValidationResult;

                // Assert
                isValid.Should().BeTrue("a organização social foi gerada com dados válidos");
                validationResult.Errors.Should().BeEmpty("não deve haver erros de validação para uma organização social válida");
        }
        
        [Trait("Categoria", "Organizacao Social Inválida")]
        [Fact]
        public void Criar_Organizacao_Social_DataConstituicao_Null_Invalido()
        {
            // Arrange
            var organizacaoSocial = _fixtures.GerarOrganizacaolInvalida_DataConstituicaoEmpty();

            // Act
            var isValid = organizacaoSocial.IsValid();
            var validationResult = organizacaoSocial.ValidationResult;

            // Assert
            isValid.Should().BeFalse("A organização social não foi gerada");
            validationResult.Errors.Should().ContainSingle(error => error.ErrorMessage == "O campo DataConstituicao precisa ser fornecido");
        }
        
        [Trait("Categoria", "Organizacao Social Inválida")]
        [Fact]
        public void Criar_Organizacao_Social_Nome_Null_Invalido()
        {
            // Arrange
            var organizacaoSocial = _fixtures.GerarOrganizacaolInvalida_NomeEmpty();

            // Act
            var isValid = organizacaoSocial.IsValid();
            var validationResult = organizacaoSocial.ValidationResult;

            // Assert
            isValid.Should().BeFalse("A organização social não foi gerada");
            validationResult.Errors.Should().ContainSingle(error => error.ErrorMessage == "O campo NomeCompleto precisa ser fornecido");
        }

        [Trait("Categoria", "Organizacao Social Inválida")]
        [Fact]
        public void Criar_Organizacao_Social_Telefone_Null_Invalido()
        {
            // Arrange
            var organizacaoSocial = _fixtures.GerarOrganizacaolInvalida_TelefoneEmpty();

            // Act
            var isValid = organizacaoSocial.IsValid();
            var validationResult = organizacaoSocial.ValidationResult;

            // Assert
            isValid.Should().BeFalse("A organização social não foi gerada");
            validationResult.Errors.Count.Should().Be(2);
            //validationResult.Errors.Should().ContainSingle(error => error.ErrorMessage == "O campo Telefone precisa ser fornecido");
        }

        [Trait("Categoria", "Organizacao Social Inválida")]
        [Fact]
        public void Criar_Organizacao_Social_Telefone_Maior14_caracteres_Invalido()
        {
            // Arrange
            var organizacaoSocial = _fixtures.GerarOrganizacaolInvalida_TelefoneInvalidoM14();

            // Act
            var isValid = organizacaoSocial.IsValid();
            var validationResult = organizacaoSocial.ValidationResult;

            // Assert
            isValid.Should().BeFalse("A organização social não foi gerada");
            validationResult.Errors.Should().ContainSingle(error => error.ErrorMessage == "O campo Telefone pode ter no máximo 14 caracteres");
        }

        [Trait("Categoria", "Organizacao Social Inválida")]
        [Fact]
        public void Criar_Organizacao_Social_Cnpj_Invalido()
        {
            // Arrange
            var organizacaoSocial = _fixtures.GerarOrganizacaolInvalida_Cnpj_Invalido();
            // Act
            var isValid = organizacaoSocial.IsValid();
            var validationResult = organizacaoSocial.ValidationResult;
            // Assert
            isValid.Should().BeFalse("A organização social não foi gerada");
            validationResult.Errors.Should().ContainSingle(error => error.ErrorMessage == "CNPJ inválido");
        }
    }
}
