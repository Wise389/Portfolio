using CarDealership.Models;
using CarDealership.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.DAL.Interface
{
    public interface ISalesRepository
    {
        Sale GetSaleById(int id);
        List<Sale> GetAllSales();
        List<Sale> GetSearchedSales(int? minPrice, int? maxPrice, int? minYear, int? maxYear, string searchString);
        void Create(Sale Sale);
    }
}
