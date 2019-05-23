namespace Shop.Web.Data.Repository
{
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;

    public interface IOrderResitory : IGenericRepository<Order>
    {
        Task<IQueryable<Order>> GetOrdersAsync(string userName);
    }
}
