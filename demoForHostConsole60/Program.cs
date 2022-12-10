using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace demoForHostConsole60
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IHost host = Host
            // 创建生成器对象
            .CreateDefaultBuilder(args)
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