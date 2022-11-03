using System.ComponentModel.DataAnnotations;
using Teknoapp.entity;

namespace Teknoapp.webui.Models
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage="Kategori adı zorunludur.")]
        [StringLength(40,MinimumLength =5,ErrorMessage ="Kategori alanı için 5-100 arasında değer giriniz.")]
        public string? Name { get; set; }
        [Required(ErrorMessage="Url zorunludur.")]
        [StringLength(40, MinimumLength = 5, ErrorMessage = "Url alanı için 5-100 arasında değer giriniz.")]

        public string? Url { get; set; }
        public List<ProductEntity>? Products { get; set; }
    }
}
