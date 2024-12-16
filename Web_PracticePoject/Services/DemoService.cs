using DocumentFormat.OpenXml.Office2010.Excel;
using Web_PracticePoject.Models;

namespace Web_PracticePoject.Services
{
    public class DemoService : IDemoService
    {
        public async Task<List<DemoExcel>> GetDemoExcels()
        {
            return
            [
                new DemoExcel { Id = 1, Name = "ABC", Position = "Accountant", Offices = "Pune" },
                new DemoExcel { Id = 2, Name = "DEF", Position = "CEO", Offices = "Indore" },
                new DemoExcel { Id = 3, Name = "GHI", Position = "HR", Offices = "Pune" },
                new DemoExcel { Id = 4, Name = "JKL", Position = "IT Service", Offices = "Noida" },
                new DemoExcel { Id = 5, Name = "MNO", Position = "Adminstrator", Offices = "Indore" },
            ];
        }

        public async Task<List<DemoExcel>> GetAllData()
        {
            return await GetDemoExcels();
        }
    }
}
