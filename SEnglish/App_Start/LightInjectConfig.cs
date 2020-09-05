using AutoMapper;
using BLL;
using BLL.Interfaces;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using LightInject;
using BLL.Models;

namespace SEnglish.App_Start
{
    public static class LightInjectConfig
    {
        public static void Configurate()
        {
            var container = new ServiceContainer();

            container.RegisterControllers(Assembly.GetExecutingAssembly());

            container.EnablePerWebRequestScope();

            var config = new MapperConfiguration(cfg => cfg.AddProfiles(
                 new List<Profile>() { new AutomapperProfile(), new BLLAutomapperProfile() }));

            container.Register(c => config.CreateMapper());

            container = BLLLigthInjectConfig.Configuration(container);

            container.Register<IAudioService, AudioService>();
            container.Register<IPictureService, PictureService>();
            container.Register<ITopicService, TopicService>();
            container.Register<IWordService, WordService>();
            container.Register<IColorService, ColorService>();

            container.EnableMvc();

        }

    }
}