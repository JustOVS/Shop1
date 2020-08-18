using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using Shop.Data;
using Shop.API.Models.OutputModels;
using Shop.Data.Dto;
using Shop.API.Models.InputModels;

namespace Shop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly IShopRepository _repo;
        private readonly IMapper _mapper;

        public OrderController( IShopRepository repo, IMapper mapper)
        {

            _mapper = mapper;
            _repo = repo;
        }


        /// <summary>
        /// gets order by Id with all information
        /// </summary>
        /// <param name="id"></param>       

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public ActionResult<OrderOutputModel> GetOrderById(long id)
        {
            DataWrapper<OrderDto> dataWrapper = _repo.GetOrderById(id);
            return MakeResponse(dataWrapper, _mapper.Map<OrderOutputModel>);
        }

        /// <summary>
        /// creates a new order
        /// </summary>
        /// <param name="order"></param>       

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<OrderOutputModel> CreateOrder([FromBody] OrderInputModel order)
        {
          
            DataWrapper<OrderDto> DataWrapper = _repo.CreateOrder(_mapper.Map<OrderDto>(order));
            return MakeResponse(DataWrapper, _mapper.Map<OrderOutputModel>);
        }

        

        
        /// <summary>
        /// gets orders by customers Id 
        /// </summary>
        /// <param name="customerId"></param>       
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("customer/{customerId}")]
        public ActionResult<List<OrderOutputModel>> GetOrdersByCustomerId(int customerId)
        {
            DataWrapper<List<OrderDto>> dataWrapper = _repo.GetOrderByCustomerId(customerId);
            return MakeResponse(dataWrapper, _mapper.Map<List<OrderOutputModel>>);
        }

        /// <summary>
        /// delete order by  id 
        /// </summary>
        /// <param name="id"></param>    
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpDelete("{id}")]
        public ActionResult<int> DeleteOrderById(long id)
        {
            DataWrapper<int> dataWrapper = _repo.DeleteOrderById(id);
            return MakeResponse(dataWrapper);
        }


        private delegate T DtoConverter<T, K>(K dto);

        private ActionResult<T> MakeResponse<T>(DataWrapper<T> dataWrapper)
        {
            if (!dataWrapper.IsOk)
            {
                return BadRequest(dataWrapper.ExceptionMessage);
            }
            return Ok(dataWrapper.Data);
        }

        private ActionResult<T> MakeResponse<T, K>(DataWrapper<K> dataWrapper, DtoConverter<T, K> dtoConverter)
        {
            if (!dataWrapper.IsOk)
            {
                return BadRequest(dataWrapper.ExceptionMessage);
            }
            return Ok(dtoConverter(dataWrapper.Data));
        }
    }
}

