using DAL;
using DAL.Interfaces;
using DAL.Models;
using DAL.Repositories;
using LightInject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLLigthInjectConfig
    {
        public static ServiceContainer Configuration(ServiceContainer container)
        {
            container.Register<DBContext>(factory => new DBContext());

            container.Register<IRepository<Audio>, AudioRepository>();
            container.Register<IRepository<Picture>, PictureRepository>();
            container.Register<IRepository<Topic>, TopicRepository>();
            container.Register<IRepository<Word>, WordRepository>();
            container.Register<IRepository<Color>, ColorRepository>();
            return container;
        }

    }
}
