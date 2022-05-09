using Business_Layer;
using Domain_Layer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace day6webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderBusiness _orderBusiness;

        public OrderController(ILogger<OrderController> logger, IOrderBusiness orderBusiness)
        {
            _logger = logger;
            _orderBusiness = orderBusiness;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json", Type = typeof(IEnumerable<Orderst>))]
        [Route("get-all-orders")]
        public async Task<ActionResult<IEnumerable<Orderst>>> GetAllOrders()
        {
            try
            {
                var resp = await _orderBusiness.GetAllOrders();

                if (resp == null || resp.Count == 0)
                {
                    return StatusCode(404, "No Data available.");
                }
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json", Type = typeof(Orderst))]
        [Route("get-order")]
        public async Task<ActionResult<Orderst>> GetOrderById(int Id)
        {
            try
            {
                var resp = await _orderBusiness.GetOrderById(Id);

                if (resp == null)
                {
                    return StatusCode(404, "No Data available.");
                }
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("insert-order")]
        public async Task<ActionResult> InsertOrder([FromBody] Orderst order)
        {
            try
            {
                await _orderBusiness.InsertOrder(order);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("update-order")]
        public async Task<ActionResult> UpdateOrder([FromBody] Orderst order)
        {
            try
            {
                await _orderBusiness.UpdateOrder(order);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("delete-order")]
        public async Task<ActionResult> DeleteOrderById(int Id)
        {
            try
            {
                await _orderBusiness.DeleteOrderById(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json", Type = typeof(IEnumerable<Orderst>))]
        [Route("get-all-orders-by-country-name")]
        public async Task<ActionResult<List<Orderst>>> GetAllOrdersByCountryName(List<string> order)
        {
            try
            {




                var resp = await _orderBusiness.GetAllOrdersByCountryName(order);




                if (resp == null || resp.Count == 0)
                {
                    return StatusCode(404, "No Data available.");
                }
                return Ok(resp);


            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json", Type = typeof(IEnumerable<Orderst>))]
        [Route("get-sum-of-orders-by-country")]
        public async Task<ActionResult<Sumoforders>> GetSumOfOrdersByCountry()
        {
            try
            {

                var resp = await _orderBusiness.GetSumOfOrdersByCountry();

                if (resp == null || resp.Count == 0)
                {
                    return StatusCode(404, "No Data available.");
                }

                return Ok(resp);


            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }


}

    



