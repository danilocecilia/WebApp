namespace WebApp.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;
    using Models;
    using Services;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApp.Data.WebAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApp.Data.WebAppContext context)
        {
            var items = new[]
            {
                new
                {
                    Entity = new Pizza { Name = "Atum", Description = "Pizza de atum fresco, cebolas em rodelas caramelizada no azeite e azeitonas", Price = 18 },
                    Img = App_LocalResources.Images.atum_400x300,
                    Filename = "atum.jpg"
                },
                new
                {
                    Entity = new Pizza { Name = "Frango com catupiry", Description = "Molho, frango desfiado, catupiry e azeitonas.", Price = 25 },
                    Img = App_LocalResources.Images.frango_com_catupiry_400x300,
                    Filename = "frango com catupiry.jpg"
                },
                new
                {
                    Entity = new Pizza { Name = "Calabresa", Description = "Pizza com base de molho de tomate caseiro da casa, uma camada de mussarela de alta qualidade e linguiça calabresa diretamente de minas.", Price = 23 },
                    Img = App_LocalResources.Images.calabresa_400x300,
                    Filename = "calabresa.jpg"
                },
                new
                {
                    Entity = new Pizza { Name = "Pepperoni", Description = "A mais tradicional receita de pizza, com os melhores ingredientes e um sabor inesquecível. O nosso tempero especial, pepperonis frescos e queijo mussarela importado.", Price = 24 },
                    Img = App_LocalResources.Images.pepperoni_400x300,
                    Filename = "pepperoni.jpg"
                },
                new
                {
                    Entity = new Pizza { Name = "Rúcula com tomate seco", Description = "Rúculas e tomates orgânicos, ótimo tempero, pizza vegana.", Price = 27 },
                    Img = App_LocalResources.Images.rucula_com_tomate_seco_400x300,
                    Filename = "rucula com tomate seco.jpg"
                },
                new
                {
                    Entity = new Pizza { Name = "Mussarela", Description = "A opção mais simples não poderia faltar, receita singela unindo mussarela, orégano, nosso tempero especial e azeita extra-virgem.", Price = 27 },
                    Img = App_LocalResources.Images.mussarela_400x300,
                    Filename = "mussarela.jpg"
                },
            }
            .Where(item => !context.Pizzas.Any(pizza => pizza.Name == item.Entity.Name))
            .ToArray();

            var fileServices = new FileServices();

            foreach (var item in items)
            {
                using (var memoryStream = new MemoryStream())
                {
                    item.Img.Save(memoryStream, ImageFormat.Jpeg);
                    memoryStream.Position = 0;
                    item.Entity.FileKey = fileServices.Upload(item.Filename, memoryStream);
                }
            }

            context.Pizzas.AddOrUpdate(p => p.Name, items.Select(item => item.Entity).ToArray());
        }
    }
}