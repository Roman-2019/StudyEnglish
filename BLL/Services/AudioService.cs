using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AudioService : SEnglishService<AudioModel, Audio>, IAudioService
    {
        public readonly IMapper _mapper;

        public AudioService(IRepository<Audio> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public AudioModel GetById(int id)
        {
            var audioModel = GetAll().FirstOrDefault(x => x.Id == id);
            return audioModel;
        }

        public override AudioModel Map(Audio model)
        {
            return _mapper.Map<AudioModel>(model);
        }

        public override Audio Map(AudioModel tModel)
        {
            return _mapper.Map<Audio>(tModel);
        }

        public override IEnumerable<AudioModel> Map(IList<Audio> audios)
        {
            return _mapper.Map<IEnumerable<AudioModel>>(audios);
        }

        public override IEnumerable<Audio> Map(IList<AudioModel> audiosModel)
        {
            return _mapper.Map<IEnumerable<Audio>>(audiosModel);
        }

    }
}