using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NovelStore.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private NovelStoreDbContext context;
        public EFOrderRepository(NovelStoreDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Order> Orders => context.Orders
        .Include(o => o.Lines)
        .ThenInclude(l => l.Novel);
        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(l => l.Novel));
            if (order.OrderID == 0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
    }
}