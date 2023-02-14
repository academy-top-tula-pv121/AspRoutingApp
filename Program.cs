namespace AspRoutingApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.Map("/", IndexPage);
            app.MapGet("/about", () => "About page");
            app.Map("/contact", () => "Conact page");

            app.Map("/routes", (IEnumerable<EndpointDataSource> eps) 
                => 
            string.Join("\n", eps.SelectMany(source => source.Endpoints)));

            app.Run();
        }

        static string IndexPage()
        {
            return "Home page";
        }
    }
}