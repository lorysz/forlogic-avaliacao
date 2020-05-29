using AutoMapper;
using Infra.Entities;
using Service.Dto.Avaliacao;
using Service.Dto.Cliente;
using Service.Dto.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForLogicAvaliacao.AutoMapper
{
    public class MappingEntities : Profile
    {
        public MappingEntities()
        {
            CreateMap<Cliente, VisualizarClienteDto>().ReverseMap();
            CreateMap<Cliente, AlterarClienteDto>().ReverseMap();
            CreateMap<Cliente, CadastrarClienteDto>().ReverseMap();
            CreateMap<Cliente, GridClienteDto>().ReverseMap();

            CreateMap<CadastrarAvaliacaoDto, Avaliacao>()
                .ForMember(x => x.Avaliacoes, o => o.MapFrom(o => o.Respostas));

            CreateMap<AvaliacaoClienteDto, AvaliacaoCliente>();

            CreateMap<Avaliacao, VisualizarAvaliacaoDto>().ReverseMap();

            CreateMap<Avaliacao, GridAvaliacaoDto>().ReverseMap();

            CreateMap<Usuario, LoginUsuarioDto>().ReverseMap();
            CreateMap<Usuario, UsuarioLogadoDto>().ReverseMap();

            CreateMap<AvaliacaoCliente, GridVisualizacaoAvaliacaoClienteDto>()
                .ForMember(x => x.NomeResponsavel, opt => opt.MapFrom(opt => opt.Cliente.NomeResponsavel))
                .ForMember(x => x.RazaoSocial, opt => opt.MapFrom(opt => opt.Cliente.RazaoSocial));

            CreateMap<Cliente, ComboClienteDto>()
                .ForMember(
                    x => x.DescricaoCombo,
                    o => o.MapFrom(opt => opt.Avaliacoes.Count > 0 ? opt.NomeResponsavel + " " + opt.Avaliacoes.OrderBy(x => x.IdAvaliacaoCliente).FirstOrDefault().Avaliacao.Mes.ToString() + "/" + opt.Avaliacoes.OrderBy(x => x.IdAvaliacaoCliente).FirstOrDefault().Avaliacao.Ano.ToString() : opt.NomeResponsavel));
        }
    }
}
