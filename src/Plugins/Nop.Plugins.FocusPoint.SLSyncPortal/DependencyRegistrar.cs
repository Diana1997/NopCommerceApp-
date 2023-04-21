using Autofac;
using Nop.Core.Configuration;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using Nop.Plugins.FocusPoint.SLSyncPortal.Servies;

namespace Nop.Plugins.FocusPoint.SLSyncPortal
{
    public class DependencyRegistrar: IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config)
        {
            builder.RegisterType<HttpService>().As<IHttpService>().InstancePerLifetimeScope();
        }

        public int Order { get; }
    }
}