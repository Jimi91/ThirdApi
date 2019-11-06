using MediatR;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mediator.Mediator
{
    public class MediatorPipelineRegistry : Registry
    {
        public MediatorPipelineRegistry(string projectApplicationAssembly)
        {
            Scan(scanner =>
            {
                scanner.TheCallingAssembly();
                scanner.Assembly(projectApplicationAssembly);
                scanner.AssemblyContainingType(typeof(BaseHandler<,>));
                scanner.AssemblyContainingType(typeof(IRequestHandler<,>));

                //scanner.ConnectImplementationsToTypesClosing(typeof(FluentValidation.IValidator<>));
                //scanner.ConnectImplementationsToTypesClosing(typeof(BaseValidator<>));
                scanner.ConnectImplementationsToTypesClosing(typeof(IRequestHandler<,>));
            });


            For<ServiceFactory>().Use<ServiceFactory>(ctx => ctx.GetInstance);
            For<IMediator>().Use<MediatR.Mediator>();
            //For<DbContext>().Use<HalzaDbContext>();

            // Configure decorators over feature handlers
            For(typeof(IRequestHandler<,>)).DecorateAllWith(typeof(MediatorPipelineHandler<,>));
        }
    }
}
