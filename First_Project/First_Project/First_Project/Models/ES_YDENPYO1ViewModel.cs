using First_Project.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace graduate_project.Models
{

    public class ES_YDENPYO1ViewModel
    {
        public ES_YDENPYO1ViewModel()
        {
            var years = new List<SelectListItem>();
            for (int j = 0; j < 100; j++)
            {
                years.Add(new SelectListItem
                {
                    Text = (Int64.Parse(DateTime.Now.ToString("yyyy")) + j).ToString(),
                    Value = (Int64.Parse(DateTime.Now.ToString("yyyy")) + j).ToString()
                });
            }
            
           this.SUITOKB_year = new SelectList(years, "Value", "Text", null);

            var cashmethod = new List<SelectListItem>();
            cashmethod.Add(new SelectListItem
            {
                Text = "ATM",
                Value = "ATM"
            });
            cashmethod.Add(new SelectListItem
            {
                Text = "Online",
                Value = "Online"
            });
            cashmethod.Add(new SelectListItem
            {
                Text = "Cash",
                Value = "Cash"
            });

            this.SUITOKB_cash = new SelectList(cashmethod, "Value", "Text", null);
        }
        public List<ES_YDENPYO1>? ES_YDENPYO { get; set; }
        public ES_YDENPYO1? ES_YDENPYO1 { get; set; }
        public int Max_id { get; set; }
        public int Max_id_edit  { get; set; }
        public List<ES_YDENPYOD>? ES_YDENPYOD { get; set; }
        /* public ES_YDENPYOD? ES_YDENPYOD1 { get; set; }*/
        public List<BUMON>? BUMON { get; set; }
        public BUMON ? BUMON1 { get; set; }
        public SelectList? KAIKEIND { get; set; }
        public SelectList? SUITOKB { get; set; }
        public SelectList? SUITOKB_year { get; set; }
        public SelectList? SUITOKB_cash { get; set; }
        public string? S_SUITOKB { get; set; }
        public string? SearchSelect { get; set; }
        public string? SearchSelect_cash_start { get; set; }
        public string? SearchSelect_cash_end { get; set; }
        public string? Search_popup { get; set; }
        public string? Bumon_name   { get; set; }
        public SelectList UKETUKEDT { get; set; }


    }
}