using System.ComponentModel;

namespace TerceiroSetor.DTOs.OrganizacoesSociais
{
    public enum TipoOrganizacaoSocialDTO
    {
        [Description("Organização Social")]
        OS = 1,
        
        [Description("Organização da Sociedade Civil")]
        OSC = 2,

        [Description("Organização da Sociedade Civil de Interesse Público")]
        OSCIP = 3,
        
        [Description("Entidade Convêniada")]
        Conveniada = 4,
        
        [Description("Entidade Gerenciada")]
        EG = 5
    }
}
