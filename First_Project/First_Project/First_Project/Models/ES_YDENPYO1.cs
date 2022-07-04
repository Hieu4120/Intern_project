using System.ComponentModel.DataAnnotations;

namespace graduate_project.Models
{
    public class ES_YDENPYO1
    {
        [Key]

        [Display(Name = "伝票番号	")]
        public int DENPYONO { get; set; }

        [Display(Name = "年度")]

        public int? KAIKEIND { get; set; }

        [Display(Name = "年月日")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string UKETUKEDT { get; set; }

        [Display(Name = "伝票日付")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DENPYODT { get; set; } = DateTime.Now;

        [Display(Name = "起票部門コード")]
        /*[RegularExpression("[0-9]+", ErrorMessage = "Number only")]
        [Required(ErrorMessage = "Please, Enter this field")]*/
        public string BUMONCD_YKANR { get; set; }

        [Display(Name = "出張目的(備考)")]
        public string BIKO { get; set; }

        [Display(Name = "出納方法")]
       /* [Required(ErrorMessage = "Please, Enter this field")]*/
        public string? SUITOKB { get; set; }

        [Display(Name = "支払予定日")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string SHIHARAIDT { get; set; }

        [Display(Name = "金額")]
        public int KINGAKU { get; set; }

        [Display(Name = "登録オペレータID")]
        public string INSERT_OPE_ID { get; set; } = "1";

        [Display(Name = "登録プログラムID")]
        public string INSERT_PGM_ID { get; set; } = "AWCYO26029";

        [Display(Name = "登録プログラム・パラメータ")]
        public string INSERT_PGM_PRM { get; set; } = "55555";

        [Display(Name = "登録日時")]
        public string INSERT_DATE { get; set; } = DateTime.Now.ToString();

        [Display(Name = "更新オペレータID")]
        public string UPDATE_OPE_ID { get; set; } = "1";

        [Display(Name = "更新プログラムID")]
        public string UPDATE_PGM_ID { get; set; } = "AWCYO30158";

        [Display(Name = "更新プログラム・パラメータ")]
        public string UPDATE_PGM_PRM { get; set; } = "88888";

        [Display(Name = "更新日時")]
        public string UPDATE_DATE { get; set; } = DateTime.Now.ToString();

    }   
}
