using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using WebApi.OData.Models;

namespace WebApi.OData.Controllers
{
    public class OrderController : ODataController
    {
        private static IList<OrderApiModel> _orders = new List<OrderApiModel>
        {
            new OrderApiModel
            {
                Uid = Guid.NewGuid(),
                Title = "Order №1",
                CreationDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            },
            new OrderApiModel
            {
                Uid = Guid.NewGuid(),
                Title = "Order №2",
                CreationDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            },
            new OrderApiModel
            {
                Uid = Guid.NewGuid(),
                Title = "Order №3",
                CreationDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            },
        };

        private ApplicationDbContext db;

        public OrderController(ApplicationDbContext context)
        {
            db = context;
        }

        [EnableQuery]
        // /Shop/Order
        public IQueryable<OrderApiModel> Get(ODataQueryOptions<OrderApiModel> queryOptions)
        {
            return db.Orders.Select(x => new OrderApiModel
            {
                Uid = x.Uid,
                Title = x.Title,
                CreationDate = x.CreationDate,
                ModifiedDate = x.ModifiedDate
            });
        }
    }
}