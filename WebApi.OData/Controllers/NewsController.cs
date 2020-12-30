using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using WebApi.OData.Models;

namespace WebApi.OData.Controllers
{
    public class NewsController : ODataController
    {
        private static IList<NewsApiModel> _news = new List<NewsApiModel>
        {
            new NewsApiModel
            {
                Uid = Guid.NewGuid(),
                Title = "News №1",
                ShortDescription = "Short Description №1",
                Content = "Content №1",
                CreationDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            },
            new NewsApiModel
            {
                Uid = Guid.NewGuid(),
                Title = "News №2",
                ShortDescription = "Short Description №2",
                Content = "Content №2",
                CreationDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            },
            new NewsApiModel
            {
                Uid = Guid.NewGuid(),
                Title = "News №3",
                ShortDescription = "Short Description №3",
                Content = "Content №3",
                CreationDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            },
        };

        [EnableQuery]
        public NewsApiModel[] Get(ODataQueryOptions<NewsApiModel> queryOptions)
        {
            return _news.ToArray();
        }
    }
}