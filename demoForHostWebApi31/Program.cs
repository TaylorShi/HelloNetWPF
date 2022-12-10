using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoForHostWebApi31
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // 创建并配置主机生成器对象、创建实例、运行实例
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// 创建并配置生成器对象
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            // 创建生成器对象
            Host.CreateDefaultBuilder(args)
                // 配置Web生成器对象
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
