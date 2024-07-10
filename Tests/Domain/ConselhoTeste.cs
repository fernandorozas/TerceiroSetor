

using FluentAssertions;
using System;
using TerceiroSetor.Domain.Entities.OrganizacoesSociais;
using TerceiroSetor.Tests.Config;
using Xunit;

namespace TerceiroSetor.Tests
{
    [Collection(nameof(TerceiroSetorCollectionConselho))]
    public class ConselhoTeste
    {
        private readonly ConselhoFixture _fixtures;
        public ConselhoTeste(ConselhoFixture fixtures) => _fixtures = fixtures;
        /*
        [Trait("Categoria", "Conselho Válido")]
        [Fact]
        public void Criar_Conselho_Valido_DeveSerValido()
        {
            // Arrange
            var conselho = _fixtures.GerarConselhoValido();
            // Act
            var isValid = conselho.IsValid();
            var validationResult = conselho.ValidationResult;
            // Assert
            isValid.Should().BeTrue("o conselho foi gerado com dados válidos");
            validationResult.Errors.Should().BeEmpty("não deve haver erros de validação para um conselho válido");
        }

        [Trait("Categoria", "Conselho Inválido")]
        [Fact]
        public void Criar_Conselho_NomeEmprty_DeveSerInvalido()
        {
            // Arrange
            var conselho = _fixtures.GerarConselhoInvalido_NomeEmpty();
            // Act
            var isValid = conselho.IsValid();
            var validationResult = conselho.ValidationResult;
            // Assert
            isValid.Should().BeFalse("o conselho não foi gerado");
            validationResult.Errors.Should().ContainSingle(error => error.ErrorMessage == "O campo Nome precisa ser fornecido");
        }

        [Trait("Categoria", "Conselho Inválido")]
        [Fact]
        public void Criar_Conselho_DataCriacaoEmpty_DeveSerInvalido()
        {
            // Arrange
            var conselho = _fixtures.GerarConselhoInvalido_DataCriacaoEmpty();
            // Act
            var isValid = conselho.IsValid();
            var validationResult = conselho.ValidationResult;
            // Assert
            isValid.Should().BeFalse("o conselho não foi gerado");
            validationResult.Errors.Should().ContainSingle(error => error.ErrorMessage == "O campo DataCriacao precisa ser fornecido");
        }

        [Trait("Categoria", "Conselho Inválido")]
        [Fact]
        public void Criar_Conselho_DataFimMaiorQueInicio_DeveSerInvalido()
        {
            // Arrange
            var conselho = _fixtures.GerarConselhoInvalido_DataFimMaiorQueInicio();
            // Act
            var isValid = conselho.IsValid();
            var validationResult = conselho.ValidationResult;
            // Assert
            isValid.Should().BeFalse("o conselho não foi gerado");
            validationResult.Errors.Should().ContainSingle(error => error.ErrorMessage == "A data de fim deve ser maior que a data de início.");
        }*/
    }
}
