using DataAccess.Entites;
using Microsoft.EntityFrameworkCore;


namespace DataAccess;

public class AppDbContext : DbContext
{
    // Инициализация таблиц
    public DbSet<Student> Students { get; set; }
    public DbSet<Pair> Pairs { get; set; }
    public DbSet<Mentor> Mentors { get; set; }
    //public DbSet<Group> Groups { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> ctx) : base(ctx){}

    // Переопределяем для создания кастомных таблиц
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Group - Student (One-to-Many)
        //modelBuilder.Entity<Student>()
        //    .HasOne(s => s.MyGroup)
        //    .WithMany(g => g.StudentsGroup)
        //    .HasForeignKey(ksg => ksg.MyGroupId);

        // Student - Pair (Many-to-Many)
        modelBuilder.Entity<Student>()
            .HasMany(s => s.MyPairs)
            .WithMany(p => p.Students)
            .UsingEntity(j => j.ToTable("StudentPairs"));

        // Group - Pair (One-to-Many)
        //modelBuilder.Entity<Pair>()
        //    .HasOne(g => g.GroupPair)
        //    .WithMany(g => g.Pairs)
        //    .HasForeignKey(kp => kp.GroupId);

        // Mentor - Pair (One-to-Many)
        modelBuilder.Entity<Mentor>()
            .HasMany(m => m.MyPairs)
            .WithMany(p => p.Mentors)
            .UsingEntity(j => j.ToTable("MentorPairs"));
            

        // Mentor - Group (Many-to-Many)
        //modelBuilder.Entity<Group>()
        //    .HasMany(g => g.Mentors)
        //    .WithMany(s => s.Groups)
        //    .UsingEntity(j => j.ToTable("GroupMentors"));

        modelBuilder.Entity<Student>().HasIndex(s => s.Id).IsUnique();
        modelBuilder.Entity<Mentor>().HasIndex(m => m.Id).IsUnique();
        modelBuilder.Entity<Pair>().HasIndex(p => p.Id);

        //modelBuilder.Entity<Group>().HasKey(g => g.Id);
    }

}

