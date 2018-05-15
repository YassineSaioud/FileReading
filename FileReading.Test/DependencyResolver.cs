using FileReading.Core;
using System;
using System.Collections.Generic;
using Unity;

namespace FileReading.Test
{

    public static class DependencyResolver
    {
        static IUnityContainer Container => container.Value;

        static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        public static T Resolve<T>() => Container.Resolve<T>();

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IFileReadingType, SimpleFileReading>("simple");
            container.RegisterType<IFileReadingType, EncryptedFileReading>("encrypted");
            container.RegisterType<IEnumerable<IFileReadingType>, IFileReadingType[]>();

            container.RegisterType<IFileReading, TextFileReading>("txt");
            container.RegisterType<IFileReading, XmlFileReading>("xml");
            container.RegisterType<IFileReading, JsonFileReading>("json");
            container.RegisterType<IEnumerable<IFileReading>, IFileReading[]>();
        }
    }

}

