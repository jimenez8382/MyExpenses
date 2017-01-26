using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using Services;
using System.Web.Mvc;

namespace MyExpenses.MVCIoC
{
    public class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            return container;
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<IExpensesServices, ExpensesServices>();
            MvcUnityContainer.Container = container;
            return container;
        }
    }
}
