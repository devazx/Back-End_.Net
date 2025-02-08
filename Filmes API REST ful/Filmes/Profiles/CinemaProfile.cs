using AutoMapper;
using Filmes.Data.Dtos;
using Filmes.Models;

namespace Filmes.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<CreateCinemaDto, Cinema>();
            CreateMap<UpdateCinemaDto, Cinema>();
            CreateMap<Cinema, UpdateCinemaDto>();                
            CreateMap<Cinema, ReadCinemaDto>()
                .ForMember(cinemaDto => cinemaDto.Endereco,
                opt => opt.MapFrom(cinema => cinema.Endereco));
        }
    }
}
