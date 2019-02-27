using System.Threading.Tasks;

namespace AppUwp.Model
{
    public interface IDataService
    {
        Task<DataItem> GetData();
    }
}