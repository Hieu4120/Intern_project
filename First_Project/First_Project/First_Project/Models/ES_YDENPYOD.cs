using System.ComponentModel.DataAnnotations;
namespace First_Project.Models
{
    public class ES_YDENPYOD
    {
        [Key]
        [Display(Name = "行番号")]
        public int GYONO { get; set; }

        [Display(Name = "伝票番号")]
        public int DENPYONO { get; set; }

        [Display(Name = "移動年月日")]
        public string? IDODT { get; set; }

        [Display(Name = "出発地")]
        public string SHUPPATSUPLC { get; set; }

        [Display(Name = "目的地")]
        public string MOKUTEKIPLC { get; set; }

        [Display(Name = "経路")]
        public string KEIRO { get; set; }

        [Display(Name = "金額")]
        public int KINGAKU { get; set; }

        [Display(Name = "登録オペレータID")]
        public string INSERT_OPE_ID { get; set; } = "1";

        [Display(Name = "登録プログラムID")]
        public string INSERT_PGM_ID { get; set; } = "AWCYO26029";

        [Display(Name = "登録プログラム・パラメータ")]
        public string INSERT_PGM_PRM { get; set; } = "11111"; 

        [Display(Name = "登録日時")]
        public string INSERT_DATE { get; set; } = DateTime.Now.ToString();

        [Display(Name = "更新オペレータID")]
        public string UPDATE_OPE_ID { get; set; } = "1";

        [Display(Name = "更新プログラムID")]
        public string UPDATE_PGM_ID { get; set; } = "AWCYO30158";

        [Display(Name = "更新プログラム・パラメータ")]
        public string UPDATE_PGM_PRM { get; set; } = "33333"; 

        [Display(Name = "更新日時")]
        public string UPDATE_DATE { get; set; } = DateTime.Now.ToString();

    }
}
