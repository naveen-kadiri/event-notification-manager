using Microsoft.EntityFrameworkCore;

public class EventDbContext : DbContext
{
    public EventDbContext(DbContextOptions<EventDbContext> options)
        : base(options)
    {

    }

    public DbSet<Notification> Notifications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(n => n.Id);
            entity.Property(n => n.Recipient).IsRequired().HasMaxLength(100);
            entity.Property(n => n.Message).IsRequired().HasMaxLength(500);
            entity.Property(n => n.Type).IsRequired();
            entity.Property(n => n.SendAt).IsRequired();
        });
        //base.OnModelCreating(modelBuilder);
    }
}