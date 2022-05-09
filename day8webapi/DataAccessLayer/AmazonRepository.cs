using DataAccessLayer.Models;
using Domain_Layer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class AmazonRepository : IAmazonRepository
    {

        public async Task<List<Amazons>> GetAllAmazonCountries()
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var amazonorders = await dbContext.Amazons.ToListAsync();


                List<Amazons> domainModels = new List<Amazons>();

                foreach (var cm in amazonorders)
                {
                    domainModels.Add(new Amazons
                    {

                        Id = cm.Id,
                        Name = cm.Name,


                    });
                }

                return domainModels;
            }
        }


        public async Task<Amazons> GetAmazonCountryById(int Id)
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {

                var amazonorders1 = await dbContext.Amazons.FirstOrDefaultAsync(x => x.Id == Id);
                Amazons domainModel = new Amazons
                {

                    Id = amazonorders1.Id,
                    Name = amazonorders1.Name,

                };

                return domainModel;
            };
        }

        public async Task InsertAmazonCountry(Amazons amazons)
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var dbModel = new Amazon
                {

                    Id = amazons.Id,
                    Name = amazons.Name,


                };

                dbContext.Amazons.Add(dbModel);
                await dbContext.SaveChangesAsync();
            };
        }

        public async Task UpdateAmazonCountry(Amazons amazons)
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var findOrder = await dbContext.Amazons.FirstOrDefaultAsync(x => x.Id == amazons.Id);

                
                findOrder.Name = amazons.Name;


                dbContext.Amazons.Update(findOrder);
                await dbContext.SaveChangesAsync();
            };
        }



        public async Task DeleteAmazonCountryById(int Id)
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var findOrder = await dbContext.Orders.FirstOrDefaultAsync(x => x.Id == Id);
                dbContext.Orders.Remove(findOrder);
                await dbContext.SaveChangesAsync();
            };
        }

        public async Task<List<Orderst>> GetAllOrders()
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var orders = await dbContext.Orders.ToListAsync();


                List<Orderst> domainModels = new List<Orderst>();

                foreach (var ord in orders)
                {
                    domainModels.Add(new Orderst
                    {

                        Id = ord.Id,
                        UserName = ord.UserName,
                        Cost = (int)ord.Cost,
                        ItemQty = ord.ItemQty,
                        CreatedDate = ord.CreatedDate,
                        UpdatedDate = ord.UpdatedDate,
                        AmazonID = ord.AmazonId,
                    });
                }

                return domainModels;
            };
        }
        public async Task InsertOrder(Orderst order)
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var dbModel = new Order
                {
                    UserName = order.UserName,
                    Cost = order.Cost,
                    ItemQty = order.ItemQty,
                    CreatedDate = order.CreatedDate,
                    UpdatedDate = order.UpdatedDate,
                    AmazonId = order.AmazonId
                };

                dbContext.Orders.Add(dbModel);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateOrder(Orderst order)
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var findOrder = await dbContext.Orders.FirstOrDefaultAsync(x => x.Id == order.Id);

                findOrder.UserName = order.UserName;
                findOrder.Cost = order.Cost;
                findOrder.ItemQty = order.ItemQty;

                dbContext.Orders.Update(findOrder);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteOrderById(int Id)
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var findOrder = await dbContext.Orders.FirstOrDefaultAsync(x => x.Id == Id);
                dbContext.Orders.Remove(findOrder);
                await dbContext.SaveChangesAsync();
            };
        }

        public async Task<Orderst> GetOrderById(int id)
        {
            

            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var amazonOrders2 = await dbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);

                Orderst domainModel = new Orderst
                {
                    AmazonId = (int)amazonOrders2.AmazonId,
                    UserName = amazonOrders2.UserName,
                    Cost = (int)amazonOrders2.Cost,
                    ItemQty = amazonOrders2.ItemQty,
                    CreatedDate = amazonOrders2.CreatedDate,
                    UpdatedDate = amazonOrders2.UpdatedDate,

                };

                return domainModel;
            }
        }

        public async Task<List<Orderst>> GetAllOrdersByCountryName(List<string> order)
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var orders = await dbContext.Orders.ToListAsync();


                List<Orderst> domainModels = new List<Orderst>();

                foreach (var ord in orders)
                {
                    domainModels.Add(new Orderst
                    {

                        Id = ord.Id,
                        UserName = ord.UserName,
                        Cost = (int)ord.Cost,
                        ItemQty = ord.ItemQty,
                        CreatedDate = ord.CreatedDate,
                        UpdatedDate = ord.UpdatedDate,
                        AmazonID = ord.AmazonId,
                    });
                }

                return domainModels;
            }
        }

        public async Task<List<Ordergroup>> GetSumOfOrdersByCountry()
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {

                var sumoforders = await dbContext.Orders.GroupBy(a => a.Amazon.Id).Select(a => new Ordergroup
                {
                    CountryName = a.Select(a => a.Amazon.Name).FirstOrDefault(),
                    Cost = (int)a.Sum(b => b.Cost)
                }).ToListAsync();

                List<Orderst> domainModels = new List<Orderst>();

                return sumoforders;

            }
        }
    }
}
        

       
    


