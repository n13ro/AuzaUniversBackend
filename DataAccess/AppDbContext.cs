using DataAccess.Entites;
using Microsoft.EntityFrameworkCore;


namespace DataAccess;

public class AppDbContext : DbContext
{
    // Инициализация таблиц
    public DbSet<Student> Students { get; set; }
    public DbSet<Pair> Pairs { get; set; }
    public DbSet<Mentor> Mentors { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> ctx) : base(ctx){}

    // Переопределяем для создания кастомных таблиц
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Связь Mentor (1) -> Student (N)
        modelBuilder.Entity<Student>()
            .HasOne(s => s.Mentor)
            .WithMany(m => m.Students)
            .HasForeignKey(k => k.MentorId);

        // Связь Pair (N) <-> Student (1) и Mentor (1)  
        modelBuilder.Entity<Pair>()
            .HasOne(p => p.Student)
            .WithMany()
            .HasForeignKey(k => k.StudentId);

        modelBuilder.Entity<Pair>()
            .HasOne(m => m.Mentor)
            .WithMany()
            .HasForeignKey(k => k.MentorId);
    }

}

