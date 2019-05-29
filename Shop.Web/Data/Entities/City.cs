namespace Shop.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    public class City : IEntity
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "City") ]
        [MaxLength(50,ErrorMessage ="The field {} only can contain {1} characteres length")]
        public string Name { get; set; }
    }
}
