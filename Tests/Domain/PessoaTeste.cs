

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
    [Collection(nameof(TerceiroSetorCollectionPessoa))]
    public class PessoaTeste
    {
        private readonly PessoaFixture _fixtures;
        public PessoaTeste(PessoaFixture fixtures) => _fixtures = fixtures;


        [Trait("Categoria", "Pessoa Válido")]
        [Fact]
        public void Criar_Pessoa_Valido()
        {
            // Arrange
            var pessoa = _fixtures.Gerar_Pessoa_Valido();
            // Act
            var isValid = pessoa.IsValid();
            var validationResult = pessoa.ValidationResult;
            // Assert
            isValid.Should().BeTrue("Pessoa foi gerada com dados válidos");
            validationResult.Errors.Should().BeEmpty("não deve haver erros de validação para um responsável válido");
        }

        [Trait("Categoria", "Pessoa Inválido")]
        [Fact]
        public void Criar_Pessoa_NomeEmprty_Invalido()
        {
            // Arrange
            var pessoa = _fixtures.Gerar_Pessoa_NameEmpty_Invalido();
            // Act
            var isValid = pessoa.IsValid();
            var validationResult = pessoa.ValidationResult;
            // Assert
            isValid.Should().BeFalse("Pessoa não foi gerada");
            validationResult.Errors.Should().ContainSingle(error => error.ErrorMessage == "O campo NomeCompleto precisa ser fornecido");
        }

        [Trait("Categoria", "Pessoa Inválido")]
        [Fact]
        public void Criar_Pessoa_CpfEmpty_Invalido()
        {
            // Arrange
            var pessoa = _fixtures. Gerar_Pessoa_CpfEmpty_Invalido();
            // Act
            var isValid = pessoa.IsValid();
            var validationResult = pessoa.ValidationResult;
            // Assert
            isValid.Should().BeFalse("Pessoa não foi gerado");
            validationResult.Errors.Should().ContainSingle(error => error.ErrorMessage == "CPF inválido");
        }

        [Trait("Categoria", "Pessoa Inválido")]
        [Fact]
        public void Criar_Pessoa_EmailPessoalEmpty_Invalido()
        {
            // Arrange
            var pessoa = _fixtures.Gerar_Pessoa_Email_PessoalEmpty_Invalido();
            // Act
            var isValid = pessoa.IsValid();
            var validationResult = pessoa.ValidationResult;
            // Assert
            isValid.Should().BeFalse("Pessoa não foi gerado");
            validationResult.Errors.Should().ContainSingle(error => error.ErrorMessage == "O campo EmailPessoal precisa ser fornecido");
        }

        [Trait("Categoria", "Pessoa Inválido")]
        [Fact]
        public void Criar_Pessoa_EmailPessoalInvalido_Invalido()
        {
            // Arrange
            var pessoa = _fixtures.Gerar_Responsave_EmailPessoal_Invalido();
            // Act
            var isValid = pessoa.IsValid();
            var validationResult = pessoa.ValidationResult;
            // Assert
            isValid.Should().BeFalse("Pessoa não foi gerado");
            validationResult.Errors.Should().ContainSingle(error => error.ErrorMessage == "EmailPessoal em formato inválido");
        }

        [Trait("Categoria", "Pessoa Inválido")]
        [Fact]
        public void Criar_Pessoa_CpfInvalido_Invalido()
        {
            // Arrange
            var pessoa = _fixtures.Gerar_Pessoa_Cpf_Invalido();
            // Act
            var isValid = pessoa.IsValid();
            var validationResult = pessoa.ValidationResult;
            // Assert
            isValid.Should().BeFalse("Pessoa não foi gerado");
            validationResult.Errors.Should().ContainSingle(error => error.ErrorMessage == "CPF inválido");
        }
   

    }
}