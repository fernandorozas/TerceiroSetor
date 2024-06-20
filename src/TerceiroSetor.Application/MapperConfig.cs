using AutoMapper;
using TerceiroSetor.Domain.Entities.OrganizacoesSociais;
using TerceiroSetor.Domain.Entities.Shared;
using TerceiroSetor.Domain.ValueObjects;
using TerceiroSetor.DTOs.OrganizacaoSocial.Commands;
using TerceiroSetor.DTOs.OrganizacoesSociais;
using TerceiroSetor.DTOs.Shared;
using TerceiroSetor.DTOs.Shared.Commands;

namespace TerceiroSetor.Application
{
    public class MapperConfig : Profile
    {
        public MapperConfig() 
        { 
            //Shared
            CreateMap<ArquivoDTO, Arquivo>().ReverseMap();
            CreateMap<BancoDTO, Banco>().ReverseMap();
            CreateMap<CargoDTO, Cargo>().ReverseMap();
            CreateMap<CategoriaDespesaDTO, CategoriaDespesa>().ReverseMap();
            CreateMap<ClassificacaoDespesaDTO, ClassificacaoDespesa>().ReverseMap();
            CreateMap<CnpjDTO, Cnpj>().ReverseMap();
            CreateMap<ContaBancariaDTO, ContaBancaria>().ReverseMap();
            CreateMap<CredorDTO, Credor>().ReverseMap();
            CreateMap<EnderecoCommand, Endereco>();
            CreateMap<EnderecoDTO, Endereco>().ReverseMap();
            CreateMap<FonteRecursoDTO, FonteRecurso>().ReverseMap();
            CreateMap<PessoaDTO, Pessoa>().ReverseMap();
            CreateMap<PessoaCommand, Pessoa>();
            CreateMap<TipoContaDTO, TipoConta>().ReverseMap();
            CreateMap<TipoCredorDTO, TipoCredor>().ReverseMap();
            CreateMap<TipoDocumentoBancarioDTO, TipoDocumentoBancario>().ReverseMap();

            //OrganizacoesSociais
            CreateMap<ConselhoDTO, Conselho>().ReverseMap();
            CreateMap<ConselhoMembroDTO, ConselhoMembro>().ReverseMap();
            CreateMap<CorpoDiretivoDTO, CorpoDiretivo>().ReverseMap();
            CreateMap<CorpoDiretivoMembroDTO, CorpoDiretivoMembro>().ReverseMap();
            CreateMap<FinalidadeDTO, Finalidade>().ReverseMap();
            CreateMap<OrganizacaoSocialDTO, OrganizacaoSocial>().ReverseMap();
            
            CreateMap<OrganizacaoSocialCommand, OrganizacaoSocial>()
                .ForMember(os => os.Nome, src => src.MapFrom(cmd => cmd.Identificacao.Nome))
                .ForMember(os => os.TipoOrganizacaoSocial, src => src.MapFrom(cmd => cmd.Identificacao.TipoOrganizacaoSocial))
                .ForMember(os => os.DataConstituicao, src => src.MapFrom(cmd => cmd.Identificacao.DataConstituicao))
                .ForMember(os => os.Telefone, src => src.MapFrom(cmd => cmd.Identificacao.Telefone))
                .ForMember(os => os.Cnpj, src => src.MapFrom(cmd => cmd.Identificacao.Cnpj))
                .ForMember(os => os.ArtigoReferencia, src => src.MapFrom(cmd => cmd.Identificacao.ArtigoReferencia))
                .ForMember(os => os.Finalidade, src => src.MapFrom(cmd => cmd.Identificacao.Finalidade))
                .ForMember(os => os.FinalidadeResumida, src => src.MapFrom(cmd => cmd.Identificacao.FinalidadeResumida));



            CreateMap<ConselhoCommand, Conselho>();
            CreateMap<ConselhoMembroCommand, ConselhoMembro>();
            CreateMap<ResponsavelDTO, Responsavel>().ReverseMap();
            CreateMap<ResponsavelCommand, Responsavel>();
            CreateMap<TipoConselhoDTO, TipoConselho>().ReverseMap();
            CreateMap<TipoOrganizacaoSocialDTO, TipoOrganizacaoSocial>().ReverseMap();
            CreateMap<VinculoTrabalhistaDTO, VinculoTrabalhista>().ReverseMap();

        }
    }
}
