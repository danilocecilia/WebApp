namespace WebApp.Data
{
    using System.Data.Entity;
    using Models;

    public class WebAppContext : DbContext
    {
        public WebAppContext() : base("WebAppContext") { }

        public DbSet<Pizza> Pizzas { get; set; }
    }
}