using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Campus.Libs.IoC;

namespace Campus.SOPMobilityOnline.RestApi
{
    /// <summary>
    ///     http://blog.ploeh.dk/2012/09/28/DependencyInjectionandLifetimeManagementwithASP.NETWebAPI/
    ///     http://blog.ploeh.dk/2012/10/03/DependencyInjectioninASP.NETWebAPIwithCastleWindsor/
    /// </summary>
    public class IocCompositionRoot : IHttpControllerActivator
    {
        public IHttpController Create(
            HttpRequestMessage request,
            HttpControllerDescriptor controllerDescriptor,
            Type controllerType)
        {
            var controller = DependencyContainer.Resolve(controllerType) as IHttpController;
            return controller;
        }
    }
}