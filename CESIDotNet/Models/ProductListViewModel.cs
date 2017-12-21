using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CESICommerce.Models
{
    public class ProductListViewModel
    {
        public IQueryable<Product> products { get; set; }
        public PaginationInfo pagination;

        public ProductListViewModel(IQueryable<Product> products, int countPerPage, int page, int count){
            this.products = products;
            this.pagination = new PaginationInfo { countPerPage = countPerPage, page = page, count = count };
        }
    }

    public class PaginationInfo
    {
        public int countPerPage { get; set; }
        public int page { get; set; }
        public int count { get; set; }
        public int maxPage {
            get {
                decimal maxTmp = (this.count / this.countPerPage) + 1;
                Console.WriteLine("Count is " + maxTmp);
                //if (maxTmp % 1 == 0) maxTmp--;
                return (int) Math.Ceiling(maxTmp);
            }
        }
    }
}
