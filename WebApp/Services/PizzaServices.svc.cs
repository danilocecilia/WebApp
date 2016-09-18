namespace WebApp.Services
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.ServiceModel.Activation;
    using Data;
    using Models;

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class PizzaServices : IPizzaServices
    {
        public void Save(Pizza pizza)
        {
            using (var db = new WebAppContext())
            {
                var isNew = pizza.Id == 0;

                db.Pizzas.Attach(pizza);

                db.Entry(pizza).State = isNew ? EntityState.Added : EntityState.Modified;

                db.SaveChanges();
            }
        }

        public Pizza Get(int id)
        {
            using (var db = new WebAppContext())
            {
                return db.Pizzas.FirstOrDefault(d => d.Id == id);
            }
        }

        public IEnumerable<Pizza> GetAll()
        {
            using (var db = new WebAppContext())
            {
                return db.Pizzas.ToArray();
            }
        }

        public void Delete(int id)
        {
            using (var db = new WebAppContext())
            {
                db.Pizzas.Remove(db.Pizzas.FirstOrDefault(d => d.Id == id));
                db.SaveChanges();
            }
        }
    }
}