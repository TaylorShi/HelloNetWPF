using demoForHostApp60;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace demoForHostWpf60
{
    /// <summary>
    /// 应用主机服务
    /// </summary>
    public class AppHostService : IHostedService
    {
        /// <summary>
        /// 容器服务提供者
        /// </summary>
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// 日志服务
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="serviceProvider"></param>
        public AppHostService(ILogger<AppHostService> logger, IServiceProvider serviceProvider, IHostApplicationLifetime hostApplicationLifetime, IHostLifetime hostLifetime, IHostEnvironment hostEnvironment)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;

            // 注册应用已启动事件处理方法
            hostApplicationLifetime.ApplicationStarted.Register(OnStarted);
            // 注册应用正在停止事件处理方法
            hostApplicationLifetime.ApplicationStopping.Register(OnStopping);
            // 注册应用已停止事件处理方法
            hostApplicationLifetime.ApplicationStopped.Register(OnStopped);
            // 可选调用停止应用方法
            //hostApplicationLifetime.StopApplication();
            
            // 应用当前设置环境
            _logger.LogInformation("App EnvironmentName:{0}", hostEnvironment.EnvironmentName);
            // 应用当前设置名称
            _logger.LogInformation("App ApplicationName:{0}", hostEnvironment.ApplicationName);
            // 应用当前文件根目录
            _logger.LogInformation("App ContentRootPath:{0}", hostEnvironment.ContentRootPath);
            // 应用当前文件提供方
            _logger.LogInformation("App ContentRootFileProvider:{0}", hostEnvironment.ContentRootFileProvider);
        }

        /// <summary>
        /// 应用已启动
        /// </summary>
        private void OnStarted()
        {
            _logger.LogInformation("App Started");
        }

        /// <summary>
        /// 应用正在停止
        /// </summary>
        private void OnStopping()
        {
            _logger.LogInformation("App Stopping");
        }

        /// <summary>
        /// 应用已停止
        /// </summary>
        private void OnStopped()
        {
            _logger.LogInformation("App Stopped");
        }

        /// <summary>
        /// 启动主机
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Host Start");
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
            return Task.CompletedTask;
        }

        /// <summary>
        /// 停止主机
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Host Stop");
            return Task.CompletedTask;
        }
    }
}
