using demoForHostWpf60;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace demoForHostApp60
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// 构建主机对象
        /// </summary>
        private static readonly IHost _host = Host
            // 创建生成器对象
            .CreateDefaultBuilder()
            // 配置生成器对象
            .ConfigureServices((hostContext, services) =>
            {
                // 添加应用主机服务
                services.AddHostedService<AppHostService>();
                // 添加窗体
                services.AddSingleton<MainWindow>();
            })
            // 创建IHost实例
            .Build();

        /// <summary>
        /// 获取应用服务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetService<T>() where T : class
        {
            return _host.Services.GetService<T>();
        }

        /// <summary>
        /// 应用启动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnStartup(object sender, StartupEventArgs e)
        {
            await _host.RunAsync();
        }

        /// <summary>
        /// 应用退出事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnExit(object sender, ExitEventArgs e)
        {
            await _host.StopAsync();
            _host.Dispose();
        }
    }
}
