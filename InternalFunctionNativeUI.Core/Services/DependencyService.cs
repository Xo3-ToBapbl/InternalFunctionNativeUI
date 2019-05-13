using SimpleInjector;

namespace InternalFunctionNativeUI.Core.Services
{
    public static class DependencyService
    {
        private static readonly Container _container;


        static DependencyService()
        {
            _container = new Container();            
        }


        public static void Register<TService, TImplementation>()
            where TService : class 
            where TImplementation : class, TService
        {
            _container.Register<TService, TImplementation>();
        }

        public static TService Get<TService>()
            where TService : class
        {
            return _container.GetInstance<TService>();
        }
    }
}