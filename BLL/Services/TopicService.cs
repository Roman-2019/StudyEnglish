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
    public class TopicService : SEnglishService<TopicModel, Topic>, ITopicService
    {
        public readonly IMapper _mapper;

        public TopicService(IRepository<Topic> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public TopicModel GetById(int id)
        {
            var topicModel = GetAll().FirstOrDefault(x => x.Id == id);
            return topicModel;
        }

        public override TopicModel Map(Topic model)
        {
            return _mapper.Map<TopicModel>(model);
        }

        public override Topic Map(TopicModel tModel)
        {
            return _mapper.Map<Topic>(tModel);
        }

        public override IEnumerable<TopicModel> Map(IList<Topic> topics)
        {
            return _mapper.Map<IEnumerable<TopicModel>>(topics);
        }

        public override IEnumerable<Topic> Map(IList<TopicModel> topicsModel)
        {
            return _mapper.Map<IEnumerable<Topic>>(topicsModel);
        }

    }
}