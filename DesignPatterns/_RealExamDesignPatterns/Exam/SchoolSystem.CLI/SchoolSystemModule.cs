using System.IO;
using System.Reflection;
using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using SchoolSystem.Cli.Configuration;
using SchoolSystem.Framework.Core;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.Providers;
using SchoolSystem.Framework.Factories;

namespace SchoolSystem.Cli
{
    public class SchoolSystemModule : NinjectModule
    {
        private const string CreateStudentCommandName = "CreateStudentCommand";
        private const string CreateTeacherCommandName = "CreateTeacherCommand";
        private const string RemoveStudentCommandName = "RemoveStudentCommand";
        private const string RemoveTeacherCommandName = "RemoveTeacherCommand";
        private const string StudentListMarksCommandName = "StudentListMarksCommand";
        private const string TeacherAddMarkCommandName = "TeacherAddMarkCommand";

        public override void Load()
        {
            Kernel.Bind(x =>
            {
                x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .SelectAllClasses()
                .BindDefaultInterface();
            });

            IConfigurationProvider configurationProvider = Kernel.Get<IConfigurationProvider>();
            if (configurationProvider.IsTestEnvironment)
            {
            }


            Bind<ISchoolSystemFactory>().ToFactory().InSingletonScope();

            Bind<ICommand>().To<CreateStudentCommand>().Named(CreateStudentCommandName);
            Bind<ICommand>().To<CreateTeacherCommand>().Named(CreateTeacherCommandName);
            Bind<ICommand>().To<RemoveStudentCommand>().Named(RemoveStudentCommandName);
            Bind<ICommand>().To<RemoveTeacherCommand>().Named(RemoveTeacherCommandName);
            Bind<ICommand>().To<StudentListMarksCommand>().Named(StudentListMarksCommandName);
            Bind<ICommand>().To<TeacherAddMarkCommand>().Named(TeacherAddMarkCommandName);

            Bind<IParser>().To<CommandParserProvider>();
            Bind<IReader>().To<ConsoleReaderProvider>();
            Bind<IWriter>().To<ConsoleWriterProvider>();

            //Bind<IEngine>().To<Engine>();
        }
    }
}