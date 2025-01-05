using BudgetBloom.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BudgetBloom.DataAccess
{
    public class BudgetBloomContext : DbContext
    {
        public BudgetBloomContext()
        {
                
        }

        public BudgetBloomContext(DbContextOptions<BudgetBloomContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=GERI\SQLEXPRESS;Initial Catalog=BudgetBloom;Integrated Security=True;Trust Server Certificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Role>().HasData(new List<Role>
            //{
            //    new Role { Id = 1, Value = "Admin" },
            //    new Role { Id = 2, Value = "User"}
            //});

            //modelBuilder.Entity<TagPost>().HasKey(x => new { x.TagId, x.PostId });
            //modelBuilder.Entity<CategoryPost>().HasKey(x => new { x.CategoryId, x.PostId });
            //modelBuilder.Entity<ExceptionLog>().HasKey(x => x.Guid);
            //modelBuilder.Entity<UserUseCase>().HasKey(x => new { x.UserId, x.UseCaseId });

            //modelBuilder.Entity<User>().HasData(new List<User>{
            //    new User { Id = 1, Name = "Mark", Username = "mark86", Email = "mark@gmail.com", Password = BCrypt.Net.BCrypt.HashPassword("Sifra1!"), RoleId = 2 },
            //    new User { Id = 2, Name = "Elenore", Username = "elenore86", Email = "elenore@gmail.com", Password = BCrypt.Net.BCrypt.HashPassword("Sifra1!"), RoleId = 2 },
            //    new User { Id = 3, Name = "Admin", Username = "admin", Email = "admin@gmail.com", Password = BCrypt.Net.BCrypt.HashPassword("Sifra1!"), RoleId = 1 }
            //});

            //modelBuilder.Entity<Category>().HasData(new List<Category>{
            //    new Category { Id = 1, Name = "Training"},
            //    new Category { Id = 2, Name = "Search Engine Optimization"},
            //    new Category { Id = 3, Name = "Food"},
            //    new Category { Id = 4, Name = "Travel"},
            //    new Category { Id = 5, Name = "Fashion"},
            //    new Category { Id = 6, Name = "Personal"},
            //    new Category { Id = 7, Name = "Art"},
            //    new Category { Id = 8, Name = "Photography"},
            //    new Category { Id = 9, Name = "Cookbooks"}
            //});

            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }

        //public override int SaveChanges()
        //{

        //    foreach (var entry in ChangeTracker.Entries())
        //    {
        //        if (entry.Entity is Entity e)
        //        {
        //            switch (entry.State)
        //            {
        //                case EntityState.Added:
        //                    e.CreatedAt = DateTime.Now;
        //                    e.ModifiedAt = null;
        //                    e.ModifiedBy = null;
        //                    e.DeletedAt = null;
        //                    e.DeletedBy = null;
        //                    e.IsActive = true;
        //                    break;

        //                case EntityState.Modified:
        //                    e.ModifiedAt = DateTime.Now;
        //                    break;
        //            }
        //        }
        //    }
        //    return base.SaveChanges();
        //}


        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
