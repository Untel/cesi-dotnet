using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CESICommerce.Models;

namespace CESICommerce.Controllers
{
    public class ProductController : Controller
    {
        private int countPerPage = 5;
        private IProductRepository Repository;

        public ProductController(IProductRepository Repository)
        {
            this.Repository = Repository;
        }

        public ViewResult List(int page)
        {
            IQueryable<Product> products = this.Repository.Products.Skip((page > 0 ? (page - 1) * this.countPerPage : 0)).Take(countPerPage);
            decimal maxTmp = this.Repository.Products.Count() / countPerPage;
            int maxPage = (int) Math.Floor(maxTmp) + 1;

            // Console.WriteLine("Data : max : " + maxPage + " count : " + countPerPage + " skip : " + (page * this.countPerPage) + " page : " + page);

            ViewData["products"] = products;
            ViewData["countPerPage"] = countPerPage;
            ViewData["page"] = page;
            ViewData["maxPage"] = maxPage;

            return View("list");
        }

        public ViewResult Product(int id)
        {
            return View("product", this.Repository.Products.Where(P => P.ProductID == id).First());
        }

    }
}
