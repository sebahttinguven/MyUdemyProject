using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
    public class UpdateServiceDto
    {
        public int ServiceID { get; set; }
        [Required(ErrorMessage = "Hizmet ikon linki giriniz")]
        public string ServiceIcon { get; set; }
        [Required(ErrorMessage = "Hizmet başlığı  giriniz")]
        [StringLength(100, ErrorMessage = "En fazla 100 karakter giriniz")]

        public string Title { get; set; }
        [Required(ErrorMessage = "Hizmet açıklaması  giriniz")]
        [StringLength(100, ErrorMessage = "En fazla 500 karakter giriniz")]
        public string Description { get; set; }
    }
}
