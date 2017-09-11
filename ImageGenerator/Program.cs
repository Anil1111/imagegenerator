using System;
using ImageGenerator.Utilities;
using NLog;

namespace ImageGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Manages unhandled exceptions
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Bootstrap.Start();

            StartUp.Start(args);

        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            logger.Error(e.ExceptionObject.ToString);
            Console.WriteLine(e.ExceptionObject.ToString());
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
            Environment.Exit(1);
        }
    }
}
