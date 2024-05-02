using Microsoft.EntityFrameworkCore;

namespace MyApi;

public class Initializer
{
    private readonly AppDbContext _context;

    public Initializer(AppDbContext context)
    {
        _context = context;
    }

    public async Task InitializeAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        if (_context.Messages.Any())
            return;

        _context.Messages.Add(new Message()
        {
            Title="Yes"
        });

        await _context.SaveChangesAsync();
    }
}


public static class InitializerExtensions
{
    public static async Task InitializeDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initializer = scope.ServiceProvider.GetRequiredService<Initializer>();

        await initializer.InitializeAsync();

        await initializer.SeedAsync();
    }
}
