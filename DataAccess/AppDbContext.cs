using DataAccess.Entites;
using Microsoft.EntityFrameworkCore;


namespace DataAccess;

public class AppDbContext : DbContext
{
    // Инициализация таблиц
    public DbSet<Student> Students { get; set; }
    public DbSet<Pair> Pairs { get; set; }
    public DbSet<Mentor> Mentors { get; set; }

    public DbSet<Coin> Coins { get; set; }

    public DbSet<Group> Groups { get; set; }

    //public DbSet<Achievement> Achievements { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> ctx) : base(ctx){}

    // Переопределяем для создания кастомных таблиц
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Group - Student (One-to-One)
        modelBuilder.Entity<Group>()
            .HasMany(s => s.Students)
            .WithOne(s => s.MyGroup)
            .HasForeignKey(k => k.MyGroupId);

        // Group - Mentor (Many-to-Many)
        modelBuilder.Entity<Group>()
            .HasMany(s => s.Mentors)
            .WithMany(g => g.Groups)
            .UsingEntity(j => j.ToTable("MentorGroups"));

        // Student - Pair (Many-to-Many)
        modelBuilder.Entity<Student>()
            .HasMany(s => s.MyPairs)
            .WithMany(p => p.Students)
            .UsingEntity(j => j.ToTable("StudentPairs"));

        modelBuilder.Entity<Student>()
            .HasOne(s => s.MyGroup).WithMany(g => g.Students).HasForeignKey(k => k.MyGroupId);

        // Student - Coins (Many-to-Many)
        modelBuilder.Entity<Student>()
            .HasMany(s => s.Coins)
            .WithMany(c => c.Students)
            .UsingEntity(j => j.ToTable("StudentCoins"));

        // Mentor - Pair (One-to-Many)
        modelBuilder.Entity<Mentor>()
            .HasMany(m => m.MyPairs)
            .WithMany(p => p.Mentors)
            .UsingEntity(j => j.ToTable("MentorPairs"));

        // Student - Achievs (Many-to-Many)
        // 
        // 
        // 
        // 

        // Achievs - Student (Many-to-One)
        // 
        // 
        // 
        // 


        modelBuilder.Entity<Student>().HasIndex(s => s.Id).IsUnique();
        modelBuilder.Entity<Mentor>().HasIndex(m => m.Id).IsUnique();
        modelBuilder.Entity<Pair>().HasIndex(p => p.Id);
        modelBuilder.Entity<Coin>().HasIndex(k => k.Id);
        modelBuilder.Entity<Group>().HasIndex(g => g.Id);


        modelBuilder.Entity<Student>().Property(s => s.Id).IsConcurrencyToken();
        modelBuilder.Entity<Mentor>().Property(m => m.Id).IsConcurrencyToken();
        modelBuilder.Entity<Pair>().Property(p => p.Id).IsConcurrencyToken();
        modelBuilder.Entity<Coin>().Property(c => c.Id).IsConcurrencyToken();
    }

}

