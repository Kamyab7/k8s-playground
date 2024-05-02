using Microsoft.EntityFrameworkCore;

namespace MyApi;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Message> Messages => Set<Message>();
}

public class Message
{
    public int Id { get; set; }
    public string? Title { get; set; }
}
