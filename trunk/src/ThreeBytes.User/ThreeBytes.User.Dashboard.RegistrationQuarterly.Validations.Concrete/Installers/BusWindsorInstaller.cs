﻿using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using FluentValidation;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.User.Dashboard.RegistrationQuarterly.Validations.Abstract;

namespace ThreeBytes.User.Dashboard.RegistrationQuarterly.Validations.Concrete.Installers
{
    public class BusWindsorInstaller : IBusWindsorRegistration
    {
        public void Install(IWindsorContainer container)
        {
            container.Register(
               AllTypes
                   .FromThisAssembly()
                   .BasedOn(typeof(IValidator<>))
                   .Configure(x => x.LifeStyle.Transient),
               AllTypes.FromThisAssembly().BasedOn<IDashboardRegistrationStatisticsQuarterlyValidatorResolver>().Configure(
                   component =>
                   {
                       component.Named(component.Implementation.Name);
                       component.LifeStyle.Is(LifestyleType.Transient);
                   }).WithService.Base());
        }
    }
}
