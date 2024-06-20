using System.ComponentModel.DataAnnotations;

namespace TerceiroSetor.DTOs.Attributes
{
    public class CpfAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) =>
            ValidarCpf(value?.ToString()) ? ValidationResult.Success : new ValidationResult("CPF em formato inválido");

        private bool ValidarCpf(string cpf)
        {
            if(string.IsNullOrEmpty(cpf)) return false;

            cpf = cpf.NumbersOnly();
            
            if (cpf.Length > 11)
                return false;

            while (cpf.Length != 11)
                cpf = '0' + cpf;

            var igual = true;
            for (var i = 1; i < 11 && igual; i++)
                if (cpf[i] != cpf[0])
                    igual = false;

            if (igual || cpf == "12345678909")
                return false;

            var numeros = new int[11];

            for (var i = 0; i < 11; i++)
                numeros[i] = int.Parse(cpf[i].ToString());

            var soma = 0;
            for (var i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            var resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;
            for (var i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else if (numeros[10] != 11 - resultado)
                return false;

            return true;
        }
    }

    public static class StringUtils
    {
        public static string NumbersOnly(this string str) =>
            new string(str.Where(char.IsDigit).ToArray());
        
    }
}
