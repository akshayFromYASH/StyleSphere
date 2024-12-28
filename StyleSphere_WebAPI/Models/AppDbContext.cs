using Microsoft.EntityFrameworkCore;

namespace StyleSphere.Models{

    // AppDbContext ==> - Used to manage and coordinate the interaction with the database.
                    // - Responsible for configuring the database connection and defining the DbSet properties that represent tables in the database.
    public class AppDbContext:DbContext{

        // Declare a reference of type IConfiguration
        private readonly IConfiguration configuration;      // IConfiguration is used to access configuration settings, such as connection strings.
        public AppDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // An overridden method that configures the database context. 
        // It uses the DbContextOptionsBuilder to specify that the context should use SQL Server.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(configuration.GetConnectionString("MyConStr"));
        }

        public DbSet<User> users { get; set;}
        public DbSet<Product> products { get; set;}
        public DbSet<Category> categories { get; set;}
        public DbSet<Cart> carts { get; set;}
        public DbSet<ReviewandRating> ReviewsRatings { get; set;}
        public DbSet<Order> orders { get; set;}
        public DbSet<Shipping_Detail> shipping_details { get; set;}
        public DbSet<Payment> payments { get; set;}
    }
}