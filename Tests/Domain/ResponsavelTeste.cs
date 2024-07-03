using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerceiroSetor.Domain.Entities.OrganizacoesSociais;
using TerceiroSetor.Tests.Config;

namespace TerceiroSetor.tests
{
    [Collection(nameof(TerceiroSetorCollectionResp))]
    public class ResponsavelTeste
    {
        private readonly ResponsavelFixture _fixtures;
        public ResponsavelTeste(ResponsavelFixture fixtures) => _fixtures = fixtures;


        [Trait("Categoria", "Responsável Válido")]
        [Fact]
        public void Criar_Responsavel_Valido_DeveSerValido()
        {
            // Arrange
            var responsavel = _fixtures.GerarResponsavelValido();
            // Act
            var isValid = responsavel.IsValid();
            var validationResult = responsavel.ValidationResult;
            // Assert
            isValid.Should().BeTrue("o responsável foi gerado com dados válidos");
            validationResult.Errors.Should().BeEmpty("não deve haver erros de validação para um responsável válido");
        }

        [Trait("Categoria", "Responsável Inválido")]
        [Fact]
        public void Criar_Responsavel_NomeEmprty_DeveSerInvalido()
        {
            // Arrange
            var responsavel = _fixtures.GerarResponsavelInvalido_NameEmpty();
            // Act
            var isValid = responsavel.IsValid();
            var validationResult = responsavel.ValidationResult;
            // Assert
            isValid.Should().BeFalse("O Responsável não foi gerado");
            validationResult.Errors.Should().ContainSingle(error => error.ErrorMessage == "O campo NomeCompleto precisa ser fornecido");
        }

        [Trait("Categoria", "Responsável Inválido")]
        [Fact]
        public void Criar_Responsavel_CpfEmpty_DeveSerInvalido()
        {
            // Arrange
            var responsavel = _fixtures.GerarResponsavelInvalido_CpfEmpty();
            // Act
            var isValid = responsavel.IsValid();
            var validationResult = responsavel.ValidationResult;
            // Assert
            isValid.Should().BeFalse("o responsável não foi gerado");
            validationResult.Errors.Should().ContainSingle(error => error.ErrorMessage == "O campo Cpf precisa ser fornecido");
        }
        
        [Trait("Categoria", "Responsável Inválido")]
        [Fact]
        public void Criar_Responsavel_EmailPessoalEmpty_DeveSerInvalido()
        {
            // Arrange
            var responsavel = _fixtures.GerarResponsavelInvalido_EmailPessoalEmpty();
            // Act
            var isValid = responsavel.IsValid();
            var validationResult = responsavel.ValidationResult;
            // Assert
            isValid.Should().BeFalse("o responsável não foi gerado");
            validationResult.Errors.Should().ContainSingle(error => error.ErrorMessage == "O campo EmailPessoal precisa ser fornecido");
        }

        [Trait("Categoria", "Responsável Inválido")]
        [Fact]
        public void Criar_Responsavel_EmailPessoalInvalido_DeveSerInvalido()
        {
            // Arrange
            var responsavel = _fixtures.GerarResponsavelInvalido_EmailPessoalInvalido();
            // Act
            var isValid = responsavel.IsValid();
            var validationResult = responsavel.ValidationResult;
            // Assert
            isValid.Should().BeFalse("o responsável não foi gerado");
            validationResult.Errors.Should().ContainSingle(error => error.ErrorMessage == "EmailPessoal em formato inválido");
        }

        [Trait("Categoria", "Responsável Inválido")]
        [Fact]
        public void Criar_Responsavel_CpfInvalido_DeveSerInvalido()
        {
            // Arrange
            var responsavel = _fixtures.GerarResponsavelInvalido_CpfInvalido();
            // Act
            var isValid = responsavel.IsValid();
            var validationResult = responsavel.ValidationResult;
            // Assert
            isValid.Should().BeFalse("o responsável não foi gerado");
            validationResult.Errors.Should().ContainSingle(error => error.ErrorMessage == "CPF inválido");
        }

        [Trait("Categoria", "Responsável Inválido")]
        [Fact]
        public void Criar_Responsavel_FimVigenciaMaiorQueInicioVigencia_DeveSerInvalido()
        {
            // Arrange
            var responsavel = _fixtures.GerarResponsavelInvalido_FimVigenciaMaiorQueInicioVigencia();
            // Act
            var isValid = responsavel.IsValid();
            var validationResult = responsavel.ValidationResult;
            // Assert
            isValid.Should().BeFalse("o responsável não foi gerado");
            validationResult.Errors.Should().ContainSingle(error => error.ErrorMessage == "A data de fim de vigência deve ser maior que a data de início.");
        }

    }
}