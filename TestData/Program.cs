using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{

    private static void Main(string[] args)
    {
        Console.WriteLine("A testar DB context");

        var services = new ServiceCollection();

        services.AddDbContext<AppDBContext>(options => options.UseSqlServer("Server=CBRAIN-VII\\SQLEXPRESS;Database=Rumos;Trusted_Connection=True;"));

        var serviceProvider = services.BuildServiceProvider();
        AppDBContext AppDBContext = serviceProvider.GetService<AppDBContext>();
        
    }
}