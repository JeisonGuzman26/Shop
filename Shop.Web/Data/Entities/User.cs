namespace Shop.Web.Data.Entities
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    public class User : IdentityUser
    {
        [MaxLength(50, ErrorMessage = "the field {0} only can countain {} characters length.")]
        public string FirstName { get; set; }

        [MaxLength(50, ErrorMessage = "the field {0} only can countain {} characters length.")]
        public string LastName { get; set; }
               
        [MaxLength(100, ErrorMessage ="the field {0} only can countain {} characters length.")]
        public string Anddress { get; set; }

        public int CityId { get; set; }

        public City City { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return $"{this.FirstName}{this.LastName}"; }
        }
    }

}
