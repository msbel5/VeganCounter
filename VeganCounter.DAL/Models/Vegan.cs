using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VeganCounter.DAL.Models
{
    public class Vegan
    {
        public int Id { get; set; }
        [Required, DataType(DataType.EmailAddress, ErrorMessage = "Geçerli bir Email adresi giriniz.")]
        public string Email { get; set; }
        [Required, Compare("Email", ErrorMessage = "Emailleriniz birbiriyle uyuşmalıdır.")]
        public string EmailVerify { get; set; }

        [Required]
        public int CityId { get; set; }
        public City City { get; set; }

    }
}
