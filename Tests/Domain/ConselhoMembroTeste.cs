using FluentAssertions;
using TerceiroSetor.Tests.Config;

namespace Tests.Domain
{
    [Collection(nameof(TerceiroSetorCollectionConselhoMembro))]
    public class ConselhoMembroTeste
    {
        private readonly ConselhoMembroFixture _fixtures;
        public ConselhoMembroTeste(ConselhoMembroFixture fixtures) => _fixtures = fixtures;


        [Trait("Categoria", "Conselho Membro Válido")]
        [Fact]
        public void Criar_ConselhoMembro_Valido()
        {
            // Arrange
            var conselhom = _fixtures.Gerar_ConselhoMembro_Valido();
            // Act
            var isValid = conselhom.IsValid();
            var validationResult = conselhom.ValidationResult;
            // Assert
            isValid.Should().BeTrue("o responsável foi gerado com dados válidos");
            validationResult.Errors.Should().BeEmpty("não deve haver erros de validação para um responsável válido");
        }

        /*[Trait("Categoria", "Conselho Membro Inválido")]
        [Fact]
        public void Criar_ConselhoMembro_PessoaEmpty_Invalido()
        {
            // Arrange
            var cmembro = _fixtures.Gerar_ConselhoMembrol_PessoaEmpty_Invalido();
            // Act
            var isValid = cmembro.IsValid();
            var validationResult = cmembro.ValidationResult;
            // Assert
            isValid.Should().BeFalse("O Conselho Membro não foi gerado");
            validationResult.Errors.Should().ContainSingle(error => error.ErrorMessage == "Entidade Pessoa precisa ser fornecida");
        }*/

        [Trait("Categoria", "Responsável Inválido")]
        [Fact]
        public void Criar_ConselhoMembrol_IniVigenciaMaior_Invalido()
        {
            // Arrange
            var cmembro = _fixtures.Gerar_ConselhoMembrol_IniVigenciaMaior_Invalido();
            // Act
            var isValid = cmembro.IsValid();
            var validationResult = cmembro.ValidationResult;
            // Assert
            isValid.Should().BeFalse("Conselho Membro não foi gerado");
            validationResult.Errors.Should().ContainSingle(error => error.ErrorMessage == "A data de fim de vigência deve ser maior que a data de início.");
        }

    }
}