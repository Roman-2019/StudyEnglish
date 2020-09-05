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
    public class ColorService : SEnglishService<ColorModel, Color>, IColorService
    {
        public readonly IMapper _mapper;

        public ColorService(IRepository<Color> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public ColorModel GetById(int id)
        {
            var colorModel = GetAll().FirstOrDefault(x => x.Id == id);
            return colorModel;
        }

        public override ColorModel Map(Color model)
        {
            return _mapper.Map<ColorModel>(model);
        }

        public override Color Map(ColorModel tModel)
        {
            return _mapper.Map<Color>(tModel);
        }

        public override IEnumerable<ColorModel> Map(IList<Color> colors)
        {
            return _mapper.Map<IEnumerable<ColorModel>>(colors);
        }

        public override IEnumerable<Color> Map(IList<ColorModel> colorsModel)
        {
            return _mapper.Map<IEnumerable<Color>>(colorsModel);
        }

    }
}
