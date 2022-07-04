using System.ComponentModel.DataAnnotations;
namespace First_Project.Models
{
    public class BUMON
    {
        [Key]
        [Display(Name = "部門コード")]
        public string BUMONCD { get; set; }

        [Display(Name = "部門名")]
        public string BUMONNM { get; set; }

    }
}
