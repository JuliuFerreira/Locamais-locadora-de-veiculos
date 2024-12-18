using LocaMais.Data;
using LocaMais.Repositorio;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        // Adiciona serviços ao contêiner antes de construir o aplicativo
        builder.Services.AddDbContext<BancoContext>(options =>

            options.UseSqlServer(@"Server=DESKTOP-1UA88TQ\SQLEXPRESS;Database=LocadoraDeCarros;Trusted_Connection=True;TrustServerCertificate=True;"));


        builder.Services.AddControllersWithViews();
        builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        builder.Services.AddTransient<IClienteRepositorio, ClienteRepositorio>();
        // Constrói o aplicativo
        var app = builder.Build();

        // Configura o pipeline de requisição HTTP
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts(); // Configuração HSTS para produção
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}



