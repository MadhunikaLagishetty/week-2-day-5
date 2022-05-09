using DataAccessLayer;
using Domain_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    public class OrderBusiness : IOrderBusiness
    {

        private readonly IAmazonRepository _amazonRepository;

        public OrderBusiness(IAmazonRepository amazonRepository)
        {
            _amazonRepository = amazonRepository;
        }
        public async Task DeleteAmazonCountryById(int Id)
        {
            await _amazonRepository.DeleteAmazonCountryById(Id);
        }

        public async Task DeleteOrderById(int Id)
        {
            await _amazonRepository.DeleteOrderById(Id);
        }

        public async Task<List<Amazons>> GetAllAmazonCountries()
        {
            return await _amazonRepository.GetAllAmazonCountries();
        }

        public async Task<List<Orderst>> GetAllOrders()
        {
            return await _amazonRepository.GetAllOrders();
        }

        public async Task<List<Orderst>> GetAllOrdersByCountryName(List<string> order)
        {
            return await _amazonRepository.GetAllOrdersByCountryName(order);
        }

        public async Task<Amazons> GetAmazonCountryById(int Id)
        {
            return await _amazonRepository.GetAmazonCountryById(Id);
        }

        public async Task<Orderst> GetOrderById(int Id)
        {
            return await _amazonRepository.GetOrderById(Id);
        }

        public async Task<List<Ordergroup>> GetSumOfOrdersByCountry()
        {
            return await _amazonRepository.GetSumOfOrdersByCountry();
        }

        public async Task InsertAmazonCountry(Amazons amazons)
        {
            await _amazonRepository.InsertAmazonCountry(amazons);
        }

        public async Task InsertOrder(Orderst order)
        {
            await _amazonRepository.InsertOrder(order);
        }

        

        public async Task UpdateAmazonCountry(Amazons amazons)
        {
            await _amazonRepository.UpdateAmazonCountry(amazons);
        }

        public async Task UpdateOrder(Orderst order)
        {
            await _amazonRepository.UpdateOrder(order);
        }

       

        
    }
}
