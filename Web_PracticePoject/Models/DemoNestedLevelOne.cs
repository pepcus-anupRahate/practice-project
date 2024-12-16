using System.ComponentModel;

namespace Web_PracticePoject.Models
{
    public class DemoNestedLevelOne
    {
        public short? Experience { get; set; }
        [DisplayName("Extn")]
        public int? Extension { get; set; }
        public DemoNestedLevelTwo DemoNestedLevelTwos { get; set; }
    }
}
