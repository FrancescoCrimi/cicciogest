using System.Threading.Tasks;

namespace AppW10.Model
{
    public interface IDataService
    {
        Task<DataItem> GetData();
    }
}