namespace WebApp.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Services;

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

        public DateTime CreatedAt { get; set; }

        [NotMapped]
        public string ImgUrl { get { return FileServices.GetPublicResource(FileKey); } set { } }
    }
}