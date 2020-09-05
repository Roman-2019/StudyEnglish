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
    public class WordService: SEnglishService<WordModel, Word>, IWordService
    {
        public readonly IMapper _mapper;

        public WordService(IRepository<Word> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public WordModel GetById(int id)
        {
            var wordModel = GetAll().FirstOrDefault(x => x.Id == id);
            return wordModel;
        }

        public override WordModel Map(Word model)
        {
            return _mapper.Map<WordModel>(model);
        }

        public override Word Map(WordModel tModel)
        {
            return _mapper.Map<Word>(tModel);
        }

        public override IEnumerable<WordModel> Map(IList<Word> words)
        {
            return _mapper.Map<IEnumerable<WordModel>>(words);
        }

        public override IEnumerable<Word> Map(IList<WordModel> wordsModel)
        {
            return _mapper.Map<IEnumerable<Word>>(wordsModel);
        }

    }
}
