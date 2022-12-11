using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace demoForHostConsole60
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IHost host = Host
            // 创建生成器对象
            .CreateDefaultBuilder(args)
            // 追加主机配置
            .ConfigureHostConfiguration(configHost =>
            {
                configHost.SetBasePath(Directory.GetCurrentDirectory());
                configHost.AddJsonFile("hostsettings.json", optional: true);
                configHost.AddEnvironmentVariables(prefix: "PREFIX_");
                configHost.AddCommandLine(args);
            })
            // 追加应用配置
            .ConfigureAppConfiguration(configApp =>
            {
                configApp.SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location));
            })
            // 配置生成器对象
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<AppHostService>();
            })
            // 创建IHost实例
            .Build();
            // 对主机对象调用运行方法
            host.Run();

            Console.WriteLine("Hello, World!");
        }
    }
}