using AutoMapper;
using BLL.Models;
using SEnglish.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SEnglish.App_Start
{
    public class AutomapperProfile: Profile
    {
        public AutomapperProfile()
        {
            CreateMap<TopicViewModel, TopicModel>()
                .ForMember(x => x.WordModels, s => s.MapFrom(x => x.WordViewModels))
                .ForMember(x => x.AudioModels, s => s.MapFrom(x => x.AudioViewModels))
                .ReverseMap();
            CreateMap<WordViewModel, WordModel>()
                .ForMember(x => x.TopicModel, s => s.MapFrom(x => x.TopicViewModel))
                .ForMember(x => x.TopicModelId, s => s.MapFrom(x => x.TopicViewModelId))
                .ForMember(x => x.PictureModels, s => s.MapFrom(x => x.PictureViewModels))
                .ForMember(x => x.AudioModels, s => s.MapFrom(x => x.AudioViewModels))
                .ForMember(x => x.ColorModels, s => s.MapFrom(x => x.ColorViewModels))
                .ReverseMap();
            CreateMap<AudioViewModel, AudioModel>()
                .ForMember(x => x.TopicModelId, s => s.MapFrom(x => x.TopicViewModelId))
                .ForMember(x => x.WordModelId, s => s.MapFrom(x => x.WordViewModelId))
                .ReverseMap();
            CreateMap<PictureViewModel, PictureModel>()
                .ForMember(x => x.WordModels, s => s.MapFrom(x => x.WordViewModels))
                .ReverseMap();
            CreateMap<ColorViewModel, ColorModel>()
                .ForMember(x => x.WordModels, s => s.MapFrom(x => x.WordViewModels))
                .ReverseMap();
        }

    }
}