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

            //ViewData["products"] = products;
            //ViewData["countPerPage"] = countPerPage;
            //ViewData["page"] = page;
            //ViewData["maxPage"] = maxPage;

            return View("list", new ProductListViewModel(products, countPerPage, page, this.Repository.Products.Count()));
        }

        public ViewResult Product(int id)
        {
            return View("product", this.Repository.Products.Where(P => P.ProductID == id).First());
        }

    }
}
