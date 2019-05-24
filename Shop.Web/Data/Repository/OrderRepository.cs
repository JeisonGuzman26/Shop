namespace Shop.Web.Data.Repository
{

    using System.Linq;
    using System.Threading.Tasks;
    using Entities;
    using Helpers;
    using Microsoft.EntityFrameworkCore;
    using Shop.Web.Models;

    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;

        public OrderRepository(DataContext context, IUserHelper userHelper) : base(context)
        {
            this.context = context;
            this.userHelper = userHelper;
        }

        public async Task<IQueryable<Order>> GetOrdersAsync(string userName)
        {
            var user = await this.userHelper.GetUserByEmailAsync(userName);
            if (user == null)
            {
                return null;
            }

            if (await this.userHelper.IsUserInRoleAsync(user, "Admin"))
            {
                return this.context.Orders.Include(o => o.Items)
                    .ThenInclude(i => i.Product)
                    .OrderByDescending(o => o.OrderDate);
            }
            return this.context.Orders.Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .Where(o => o.User == user)
                .OrderByDescending(o => o.OrderDate);
        }

        public async Task<IQueryable<OrderDetailTemp>> GetDetailTempsAsync(string userName)
        {
            var user = await this.userHelper.GetUserByEmailAsync(userName);
            if (user == null)
            {
                return null;
            }

            return this.context.OrderDetailTemps
                .Include(o => o.Product)
                .Where(o => o.User == user)
                .OrderBy(o => o.Product.Name);
        }

        public async Task AddItemToOrderAsync(AddItemViewModel model, string userName)
        {
            var user = await this.userHelper.GetUserByEmailAsync(userName);
            if (user == null)
            {
                return;
            }

            var product = await this.context.Products.FindAsync(model.ProductId);
            if (product == null)
            {
                return;
            }

            var orderDetailItem = await this.context.OrderDetailTemps.
                Where(odt => odt.User == user && odt.Product == product).
                FirstOrDefaultAsync();
            if (orderDetailItem == null)
            {
                orderDetailItem = new OrderDetailTemp
                {
                    Price = product.Price,
                    Product = product,
                    Quantity = model.Quantity,
                    User = user
                };

                this.context.OrderDetailTemps.Add(orderDetailItem);
            }
            else
            {
                orderDetailItem.Quantity += model.Quantity;

                
            }
        }

        public Task ModifyOrderDetailTempQuantityAsync(int id, double quantity)
        {
            throw new System.NotImplementedException();
        }
    }
}
