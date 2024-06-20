namespace TerceiroSetor.Domain.Entities.Ajustes
{
    public class Convenio : EntidadeBase
    {
        protected Convenio() { }
        public Convenio(Ajuste ajuste, int ano, string numero, string numeroETCESP, string relator)
        {
            Ajuste = ajuste;
            Ano = ano;
            Numero = numero;
            NumeroETCESP = numeroETCESP;
            Relator = relator;
        }

        public Ajuste Ajuste { get; private set; }
        public int Ano { get; private set; }
        public string Numero { get; private set; }
        public string NumeroETCESP { get; private set; }
        public string Relator { get; private set; }
    }
}
