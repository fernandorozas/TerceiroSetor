using System.Text.RegularExpressions;

namespace TerceiroSetor.WebApp.Client.Helpers
{
    public static class StringHelper
    {
        public static string FormatPhoneNumber(string phone)
        {
            Regex regex = new Regex(@"[^\d]");
            phone = regex.Replace(phone, "");
            phone = Regex.Replace(phone, @"(\d{2})(\d{4})(\d{4})", "($1) $2-$3");
            return phone;
        }

        public static string FormatCNPJ(string cnpj)
        {
            return Convert.ToUInt64(cnpj).ToString(@"00\.000\.000\/0000\-00");
        }

        public static string FormatStatus(bool status)
        {
            if (status == true) return "Ativo";
            else return "Inativo";
        }
    }
}
