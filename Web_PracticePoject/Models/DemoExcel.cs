using System.ComponentModel.DataAnnotations;

namespace Web_PracticePoject.Models
{
    public class DemoExcel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        [Display(Name = "Office")]
        public string Offices { get; set; }
        //public DemoNestedLevelOne DemoNestedLevelOne { get; set; }
    }
}
