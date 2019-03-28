using AutoMapper;
using CoreCodeCamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCodeCamp.Data
{
    /// <summary>
    /// Esta es la configuracion de Automaper que lo que hace es un mapeo para hacer la injeccion de dependencias
    /// </summary>
    public class CampProfile : Profile
    {
        public CampProfile()
        {
            this.CreateMap<Camp, CampModel>()
                //esto lo que hace es sacar el venue del location y pasarlo a la propiedad venue
                .ForMember(c => c.Venue, o => o.MapFrom(m => m.Location.VenueName))
                .ReverseMap();

            this.CreateMap<Talk, TalkModel>()
                .ReverseMap()
                .ForMember(t => t.Camp, opt => opt.Ignore())
                .ForMember(t => t.Speaker, opt => opt.Ignore());

            this.CreateMap<Speaker, SpeakerModel>()
                .ReverseMap();
        }
    }
}
