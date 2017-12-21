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
                return (int) Math.Floor(maxTmp);
            }
        }
    }
}
