using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SonarImplementationServices.Services;
using SonarInterfaceServices.Services;
using System;
using System.IO;

public class ConsoleSubmarineApp
{
    public static int Main(string[] args)
    {
        try
        {
            //registering classes to be injected
            var serviceProvider = new ServiceCollection()
                    .AddLogging()
                    .AddScoped<ISonarReaderService, SonarReaderService>()
                    .AddScoped<ISonarWriterService, SonarWriterService>()
                    .AddScoped<IProcessingService, ProcessingService>()
                    .BuildServiceProvider();

            Console.WriteLine("Starting application");
            var processingService = serviceProvider.GetService<IProcessingService>();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            processingService.ProcessProgram();
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            Console.WriteLine("All done!");
       }
        catch (IOException e)
        {
            TextWriter errorWriter = Console.Error;
            errorWriter.WriteLine(e.Message);
            return 1;
        }

        // Recover the standard output stream so that a
        // completion message can be displayed.
        //var standardOutput = new StreamWriter(Console.OpenStandardOutput());
        //standardOutput.AutoFlush = true;
        //Console.SetOut(standardOutput);
        //Console.WriteLine($"INSERTTABS has completed the processing of.");

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        return 0;
    }
}

