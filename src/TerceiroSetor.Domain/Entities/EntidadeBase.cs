using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TerceiroSetor.Domain.Entities
{
    public abstract class EntidadeBase
    {
        protected EntidadeBase() {}

        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public bool Ativo { get; set; }

        [NotMapped]
        public ValidationResult ValidationResult { get; set; }
        public bool IsValid() 
        {
            Validate();
            return ValidationResult.IsValid;
        }
        protected virtual void Validate()
        {
            throw new NotImplementedException();
        }

    }
}
