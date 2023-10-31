using Microsoft.Extensions.DependencyInjection;
using TGC.ConsoleBuilder;
using TGC.WarcryOptimizer.ConsoleApp;

var consoleAppBuilder = ConsoleBuilder.CreateApp(args);

var consoleApp = consoleAppBuilder.Build();

consoleApp.RunFromServiceProvider(s => s.GetRequiredService<IRunner>().Run());
