using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;
using System.Web.Http.Cors;

namespace ConsolServer
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            var config = new HttpSelfHostConfiguration("http://localhost:1234");
            config.Routes.MapHttpRoute("default",
                                        "api/{controller}/{id}",
                                        defaults: new { id = RouteParameter.Optional });
            //new { controller = "Home", id = RouteParameter.Optional });
            config.EnableCors();
            var server = new HttpSelfHostServer(config);
            var task = server.OpenAsync();
            task.Wait();

            Console.WriteLine("Web API Server has started at http://localhost:1234");
            Console.ReadLine();
            /*var config = new HttpSelfHostConfiguration("http://localhost:1234");

            var server = new HttpSelfHostServer(config, new MyWebAPIMessageHandler());
            var task = server.OpenAsync();
            task.Wait();

            Console.WriteLine("Web API Server has started at http://localhost:1234");
            Console.ReadLine();
            */
        }
    }
}

