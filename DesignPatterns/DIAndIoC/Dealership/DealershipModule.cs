using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Dealership.Commands;
using Dealership.Commands.CommandsHandler;
using Dealership.Contracts;
using Dealership.Contracts.ReadersAndWriters;
using Dealership.Engine;
using Dealership.Factories;
using Dealership.Models;
using Dealership.ReadersAndWriters;
using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;
using Ninject.Modules;

namespace Dealership
{
    public class DealershipModule : NinjectModule
    {
        private const string AddCommentCommandHandlerName = "AddCommentCommandHandler";
        private const string AddVehicleCommandHandlerName = "AddVehicleCommandHandler";
        private const string LoginCommandHandlerName = "LoginCommandHandler";
        private string LogoutCommandrHandelrName = "LogoutCommandrHandelr";
        private string RegisterUserCommandHandelrName = "RegisterUserCommandHandelr";
        private string RemoveCommentCommandHandlerName = "RemoveCommentCommandHandler";
        private string RemoveVehicleCommandHandlerName = "RemoveVehicleCommandHandler";
        private string ShowUsersCommandHandlerName = "ShowUsersCommandHandler";
        private string ShowVehiclesCommandHandlerName = "ShowVehiclesCommandHandler";

        public override void Load()
        {
            Kernel.Bind(x =>
            {
                x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .SelectAllClasses()
                .BindDefaultInterface();
            });

            Bind<IReader>().To<ConsoleReaderAndWriter>();
            Bind<IWriter>().To<ConsoleReaderAndWriter>();
            Bind<IDealershipFactory>().ToFactory();
            Bind<ICommandFactory>().ToFactory();

            Bind<ICommandHandler>().To<AddCommentCommandHandler>().Named(AddCommentCommandHandlerName);
            Bind<ICommandHandler>().To<AddVehicleCommandHandler>().Named(AddVehicleCommandHandlerName);
            Bind<ICommandHandler>().To<LoginCommandHandler>().Named(LoginCommandHandlerName);
            Bind<ICommandHandler>().To<LogoutCommandrHandelr>().Named(LogoutCommandrHandelrName);
            Bind<ICommandHandler>().To<RegisterUserCommandHandelr>().Named(RegisterUserCommandHandelrName);
            Bind<ICommandHandler>().To<RemoveCommentCommandHandler>().Named(RemoveCommentCommandHandlerName);
            Bind<ICommandHandler>().To<RemoveVehicleCommandHandler>().Named(RemoveVehicleCommandHandlerName);
            Bind<ICommandHandler>().To<ShowUsersCommandHandler>().Named(ShowUsersCommandHandlerName);
            Bind<ICommandHandler>().To<ShowVehiclesCommandHandler>().Named(ShowVehiclesCommandHandlerName);
            Bind<ICommandHandler>().ToMethod(context =>
            {
                ICommandHandler addCommentCommandHandler = context.Kernel.Get<ICommandHandler>(AddCommentCommandHandlerName);
                ICommandHandler addVehicleCommandHandlerName = context.Kernel.Get<ICommandHandler>(AddVehicleCommandHandlerName);
                ICommandHandler loginCommandHandler = context.Kernel.Get<ICommandHandler>(LoginCommandHandlerName);
                ICommandHandler logoutCommandrHandelr = context.Kernel.Get<ICommandHandler>(LogoutCommandrHandelrName);
                ICommandHandler registerUserCommandHandelr = context.Kernel.Get<ICommandHandler>(RegisterUserCommandHandelrName);
                ICommandHandler removeCommentCommandHandler = context.Kernel.Get<ICommandHandler>(RemoveCommentCommandHandlerName);
                ICommandHandler removeVehicleCommandHandler = context.Kernel.Get<ICommandHandler>(RemoveVehicleCommandHandlerName);
                ICommandHandler showUsersCommandHandler = context.Kernel.Get<ICommandHandler>(ShowUsersCommandHandlerName);
                ICommandHandler showVehiclesCommandHandler = context.Kernel.Get<ICommandHandler>(ShowVehiclesCommandHandlerName);

                addCommentCommandHandler.SetNext(addVehicleCommandHandlerName);
                addVehicleCommandHandlerName.SetNext(loginCommandHandler);
                loginCommandHandler.SetNext(logoutCommandrHandelr);
                logoutCommandrHandelr.SetNext(registerUserCommandHandelr);
                registerUserCommandHandelr.SetNext(removeCommentCommandHandler);
                removeCommentCommandHandler.SetNext(removeVehicleCommandHandler);
                removeVehicleCommandHandler.SetNext(showUsersCommandHandler);
                showUsersCommandHandler.SetNext(showVehiclesCommandHandler);

                return addCommentCommandHandler;
            }).WhenInjectedInto<DealershipEngine>();


            //Bind<IEngine>().To<DealershipEngine>().InSingletonScope();
            //Bind<IEngine>().To<DealershipEngine>().InSingletonScope();
            //Bind<IEngine>().To<DealershipEngine>().InSingletonScope();

            //this.Bind<ICommandHandler>()
            //    .ToMethod(ctx =>
            //    {
            //        var assembly = this.GetType()
            //                           .GetTypeInfo()
            //                           .Assembly;

            //        IList<Type> typeInfos = assembly.GetTypes()
            //                                        .Where(t => t.IsSubclassOf(typeof(CommandHandler)))
            //                                        .ToList();

            //        var commandHandlers = new List<ICommandHandler>();
            //        for (var i = 0; i < typeInfos.Count; i++)
            //        {
            //            var handler = Activator.CreateInstance(typeInfos[i]) as ICommandHandler;
            //            commandHandlers.Add(handler);
            //            if (i != 0)
            //            {
            //                commandHandlers[i - 1].SetNext(handler);
            //            }
            //        }

            //        return commandHandlers.FirstOrDefault();
            //    });

            //this.Bind<IVehicle>().To<Car>().Named(typeof(Car).Name);
            //this.Bind<IComment>().To<Comment>().Named(typeof(Comment).Name);
            //this.Bind<ICommand>().To<Command>().Named(typeof(Command).Name);
            //this.Bind<IUser>().To<User>().Named(typeof(User).Name);
            //this.Bind<IVehicle>().To<Truck>().Named(typeof(Truck).Name);
            //this.Bind<IVehicle>().To<Motorcycle>().Named(typeof(Motorcycle).Name);
        }
    }
}
