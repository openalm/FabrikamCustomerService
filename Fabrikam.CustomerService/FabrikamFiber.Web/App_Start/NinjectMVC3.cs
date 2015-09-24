[assembly: WebActivator.PreApplicationStartMethod(typeof(FabrikamFiber.Web.App_Start.NinjectMVC3), "Start")]
////[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(FabrikamFiber.Web.App_Start.NinjectMVC3), "Stop")]

namespace FabrikamFiber.Web.App_Start
{
    using FabrikamFiber.DAL.Data;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Mvc;

    public static class NinjectMVC3 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ICustomerRepository>().To<CustomerRepository>();
            kernel.Bind<IEmployeeRepository>().To<EmployeeRepository>();
            kernel.Bind<IServiceTicketRepository>().To<ServiceTicketRepository>();
            kernel.Bind<IServiceLogEntryRepository>().To<ServiceLogEntryRepository>();

            kernel.Bind<IAlertRepository>().To<AlertRepository>();
            kernel.Bind<IMessageRepository>().To<MessageRepository>();
            kernel.Bind<IScheduleItemRepository>().To<ScheduleItemRepository>();
        }
    }
}
