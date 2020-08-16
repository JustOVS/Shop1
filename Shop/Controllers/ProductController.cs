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
    public class ProductController : Controller
    {
        private readonly IShopRepository _repo;
        private readonly IMapper _mapper;

        public ProductController(IShopRepository repo, IMapper mapper)
        {

            _mapper = mapper;
            _repo = repo;
        }


        /// <summary>
        /// gets all products
        /// </summary>
  

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public ActionResult<List<ProductOutputModel>> GetAllProducts()
        {
            DataWrapper<List<ProductDto>> dataWrapper = _repo.GetAllProducts();
            return MakeResponse(dataWrapper, _mapper.Map<List<ProductOutputModel>>);
        }

        /// <summary>
        /// gets product by Id
        /// </summary>
        /// <param name="id"></param>       

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public ActionResult<ProductOutputModel> GetProductById(long id)
        {
            DataWrapper<ProductDto> dataWrapper = _repo.GetProductById(id);
            return MakeResponse(dataWrapper, _mapper.Map<ProductOutputModel>);
        }

        /// <summary>
        /// Add new product
        /// </summary>
        /// <param name="product"></param>       

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<long> AddProduct(ProductInputModel product)
        {
            DataWrapper<long> DataWrapper = _repo.AddProduct(_mapper.Map<ProductDto>(product));
            return MakeResponse(DataWrapper);
        }



        /// <summary>
        /// delete product by  id 
        /// </summary>
        /// <param name="id"></param>    
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpDelete("{id}")]
        public ActionResult<int> DeleteProductById(long id)
        {
            DataWrapper<int> dataWrapper = _repo.DeleteProductById(id);
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

