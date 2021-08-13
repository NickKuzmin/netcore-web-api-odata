using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using WebApi.OData.Entities;
using WebApi.OData.Models;

namespace WebApi.OData.Controllers
{
    public class ProductController : ODataController
    {
        private static IList<ProductApiModel> _products = new List<ProductApiModel>
        {
            new ProductApiModel
            {
                Uid = Guid.NewGuid(),
                Title = "Product №1",
                CreationDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            },
            new ProductApiModel
            {
                Uid = Guid.NewGuid(),
                Title = "Product №2",
                CreationDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            },
            new ProductApiModel
            {
                Uid = Guid.NewGuid(),
                Title = "Product №3",
                CreationDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            },
        };

        private ApplicationDbContext db;

        public ProductController(ApplicationDbContext context)
        {
            db = context;
        }

        [EnableQuery]
        // /Shop/Product
        public IQueryable<ProductApiModel> Get(ODataQueryOptions<ProductApiModel> queryOptions)
        {
            return db.Products.Select(x => new ProductApiModel
            {
                Uid = x.Uid,
                Title = x.Title,
                CreationDate = x.CreationDate,
                ModifiedDate = x.ModifiedDate
            });
        }
    }
}