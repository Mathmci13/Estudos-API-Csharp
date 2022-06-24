using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;


namespace ApiBiblioteca
{
    public class Program
    {
        public static List<Livro> livros { get; set; }

        public static void Main(string[] args)
        {
            var json = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\livros.json");
            var js = new DataContractJsonSerializer(typeof(List<Livro>));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            livros = (List<Livro>)js.ReadObject(ms);
            CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
