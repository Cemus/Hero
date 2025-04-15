namespace Hero.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            Console.WriteLine("^^" + services);      
        }
    }
}
