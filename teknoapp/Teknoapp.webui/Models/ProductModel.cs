using System.ComponentModel.DataAnnotations;
using Teknoapp.entity;

namespace Teknoapp.webui.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
       
        [Required(ErrorMessage="Ürün adı zorunlu bir alan.")]
        [StringLength(60, MinimumLength = 5,ErrorMessage = "Ürün ismi 5-60 karakter arasında olmalıdır.")]
        public string Name { get; set; }
      
        [Required(ErrorMessage = "Url zorunlu bir alan.")]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "Url alanı 5-60 karakter arasında olmalıdır.")]

        public string Url { get; set; }

        [Required(ErrorMessage = "Marka zorunlu bir alan.")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "Marka alanı 4-20 karakter arasında olmalıdır.")]

        public string Marka { get; set; }

        [Required(ErrorMessage="Fiyat zorunlu bir alan.")]
        [Range(1,100000000000,ErrorMessage = "Fiyat alanı için 1-100000000000 arasında değer girin.")]

        public double? Price { get; set; }
        
        [Required(ErrorMessage = "Açıklama zorunlu bir alan.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Açıklama bölümü 5-100 karakter arasında olmalıdır.")]

        public string Description { get; set; }

        //[Required(ErrorMessage = "ResimUrl zorunlu bir alan.")]
        public string ImageUrl { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }
        public List<CategoryEntity>? SelectedCategories { get; set; }





    }
}
