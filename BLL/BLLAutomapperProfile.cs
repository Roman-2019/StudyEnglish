using AutoMapper;
using BLL.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLAutomapperProfile : Profile
    {
        public BLLAutomapperProfile()
        {
            CreateMap<WordModel, Word>()
                .ForMember(x => x.Topic, y => y.MapFrom(x => x.TopicModel))
                .ForMember(x => x.Audio, y => y.MapFrom(x => x.AudioModels))
                .ForMember(x => x.TopicId, y => y.MapFrom(x => x.TopicModelId))
                .ForMember(x => x.Pictures, y => y.MapFrom(x => x.PictureModels.ToList()))
                .ReverseMap();

            //CreateMap<CategoryModel, Category>().ReverseMap();
            CreateMap<TopicModel, Topic>()
                .ForMember(x => x.Words, y => y.MapFrom(x => x.WordModels))
                .ForMember(x => x.Audio, y => y.MapFrom(x => x.AudioModels))
                //.ForMember(x => x.AuthorId, y => y.MapFrom(x => x.AuthorModelId))
                //.ForMember(x => x.PostId, y => y.MapFrom(x => x.PostModelId))
                .ReverseMap();

            CreateMap<AudioModel, Audio>()
                .ForMember(x => x.TopicId, y => y.MapFrom(x => x.TopicModelId))
                .ForMember(x => x.WordId, y => y.MapFrom(x => x.WordModelId))
                .ReverseMap();
            CreateMap<PictureModel, Picture>()
                .ForMember(x => x.Words, y => y.MapFrom(x => x.WordModels))
                .ReverseMap();
            CreateMap<ColorModel, Color>()
                .ForMember(x => x.Words, y => y.MapFrom(x => x.WordModels))
                .ReverseMap();
        }

    }
}