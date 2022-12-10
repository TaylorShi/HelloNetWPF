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
            // �����������������������󡢴���ʵ��������ʵ��
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// ��������������������
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            // ��������������
            Host.CreateDefaultBuilder(args)
                // ����Web����������
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
