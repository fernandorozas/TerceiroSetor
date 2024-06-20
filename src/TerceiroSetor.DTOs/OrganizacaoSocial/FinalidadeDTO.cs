using System.ComponentModel;

namespace TerceiroSetor.DTOs.OrganizacoesSociais
{
    public enum FinalidadeDTO
    {
        [Description("I - promoção da assistência social")]
        AssistenciaSocial = 1,

        [Description("II - promoção da cultura, defesa e conservação do patrimônio histórico e artístico")]
        Cultura = 2,

        [Description("III - promoção da educação")]
        Educacao = 3,

        [Description("IV - promoção da saúde")]
        Saude = 4,

        [Description("V - promoção da segurança alimentar e nutricional")]
        SegurancaAlimentar = 5,

        [Description("VI - defesa, preservação e conservação do meio ambiente e promoção do desenvolvimento sustentável")] 
        MeioAmbiente = 6,

        [Description("VII - promoção do voluntariado")] 
        Voluntariado = 7,

        [Description("VIII - promoção do desenvolvimento econômico e social e combate à pobreza")] 
        CombatePobreza = 8,

        [Description("IX - experimentação, não lucrativa, de novos modelos socioprodutivos e de sistemas alternativos de produção, comércio, emprego e crédito")] 
        ExperimentacaoNovosModelos = 9,

        [Description("X - promoção de direitos estabelecidos, construção de novos direitos e assessoria jurídica gratuita de interesse suplementar")] 
        PromocaoDireitosEstabelecidos = 10,

        [Description("XI - promoção da ética, da paz, da cidadania, dos direitos humanos, da democracia e de outros valores universais")] 
        PromocaoEtica = 11,

        [Description("XII - organizações religiosas que se dediquem a atividades de interesse público e de cunho social distintas das destinadas a fins exclusivamente religiosos")] 
        OrganizacoesReligiosas = 12,

        [Description("XIII - estudos e pesquisas, desenvolvimento de tecnologias alternativas, produção e divulgação de informações e conhecimentos técnicos e científicos")] 
        TecnologiasAlternativas = 13
    }
}
