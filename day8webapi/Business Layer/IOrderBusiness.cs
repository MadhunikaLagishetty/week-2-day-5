using Domain_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    public interface IOrderBusiness
    {

        public Task<List<Amazons>> GetAllAmazonCountries();
        public Task<Amazons> GetAmazonCountryById(int Id);
        public Task InsertAmazonCountry(Amazons amazons);
        public Task UpdateAmazonCountry(Amazons amazons);
        public Task DeleteAmazonCountryById(int Id);

        public Task<List<Orderst>> GetAllOrders();
        public Task<Orderst> GetOrderById(int Id);
        public Task InsertOrder(Orderst order);
        public Task UpdateOrder(Orderst order);
        public Task DeleteOrderById(int Id);

        public Task<List<Orderst>> GetAllOrdersByCountryName(List<string> order);
        public Task<List<Ordergroup>> GetSumOfOrdersByCountry();

    }
}
