namespace WebApp.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Pizza
    {
        public Pizza()
        {
            this.CreatedAt = DateTime.Now;
        }

        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        [Required]
        [StringLength(512)]
        public string Description { get; set; }

        [StringLength(128)]
        public string FileKey { get; set; }

        public Uri ImgUrl { get { return new Uri("http://www.iconshock.com/img_jpg/REALVISTA/food/jpg/256/pizza_icon.jpg"); } }

        public DateTime CreatedAt { get; private set; }
    }
}