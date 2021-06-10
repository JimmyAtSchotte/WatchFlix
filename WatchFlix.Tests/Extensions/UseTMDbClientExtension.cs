using ArrangeDependencies.Autofac.Extensions;
using ArrangeDependencies.Core.Interfaces;
using Autofac;
using TMDbLib.Client;

namespace WatchFlix.Tests.Extensions
{
    public static class UseTMDbClientExtension
    {
        private static readonly TMDbClient Client = new TMDbClient("9d9273dd0511107b21baa2cb13b70181");

        public static IArrangeBuilder<ContainerBuilder> UseTMDbClient(
            this IArrangeBuilder<ContainerBuilder> dependencies)
        {
            dependencies.UseImplementation<TMDbClient, TMDbClient>(Client);
            
            return dependencies;
        }
    }
}