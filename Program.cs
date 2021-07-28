using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagmen
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //调用两个方法首先是buil一个再东西 然后run这个程序
            CreateWebHostBuilder(args).Build().Run();
        }
        //逻辑判断从startup
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
