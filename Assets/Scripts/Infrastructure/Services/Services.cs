namespace TDS.Infrastructure.Services
{
    public class Services
    {
        private static Services _instance;
        public static Services Container => _instance ?? (_instance = new Services());

        public void Register<TService>(TService implementation) where TService : IService =>
            Implementation<TService>.Service = implementation;

        public TService Get<TService>() where TService : IService =>
            Implementation<TService>.Service;

        private static class Implementation<TService> where TService : IService
        {
            public static TService Service;
        }
    }
}