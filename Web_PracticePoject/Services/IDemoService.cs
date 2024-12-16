using Web_PracticePoject.Models;

namespace Web_PracticePoject.Services
{
    public interface IDemoService
    {
        Task<List<DemoExcel>> GetAllData();
    }
}
