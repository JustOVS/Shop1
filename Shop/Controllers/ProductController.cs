using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using Shop.Data;
using Shop.API.Models.OutputModels;
using Shop.Data.Dto;
using Shop.API.Models.InputModels;
using System.Linq;
using Shop.API.Configuration;

namespace Shop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IShopRepository _repo;
        private readonly IMapper _mapper;
        private readonly ProductToCategoryMapper _categoryMapper;

        public ProductController(IShopRepository repo, IMapper mapper, ProductToCategoryMapper categoryMapper)
        {

            _mapper = mapper;
            _repo = repo;
            _categoryMapper = categoryMapper;
        }


        /// <summary>
        /// gets all products
        /// </summary>
  

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public ActionResult<List<BaseProductOutputModel>> GetAllProducts()
        {
            DataWrapper<List<ProductDto>> dataWrapper = _repo.GetAllProducts();
            return MakeResponse(dataWrapper);
        }

        /// <summary>
        /// gets product by Id
        /// </summary>
        /// <param name="id"></param>       

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public ActionResult<BaseProductOutputModel> GetProductById(long id)
        {
            DataWrapper<ProductDto> dataWrapper = _repo.GetProductById(id);
            return MakeResponse(dataWrapper);
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

        /// <summary>
        /// gets all products by Category id
        /// </summary>
        /// <param name="categoryId"></param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("category/{categoryId}")]
        public ActionResult<List<BaseProductOutputModel>> GetAllProductsByCategoryId(int categoryId)
        {
            DataWrapper<List<ProductDto>> dataWrapper = _repo.GetAllProducts();
            return MakeResponse(dataWrapper, categoryId);
        }

        private ActionResult<T> MakeResponse<T>(DataWrapper<T> dataWrapper)
        {
            if (!dataWrapper.IsOk)
            {
                return BadRequest(dataWrapper.ExceptionMessage);
            }
            return Ok(dataWrapper.Data);
        }
        private ActionResult<List<BaseProductOutputModel>> MakeResponse(DataWrapper<List<ProductDto>> dataWrapper, int categoryId)
        {
            if (!dataWrapper.IsOk)
            {
                return BadRequest(dataWrapper.ExceptionMessage);
            }
            return Ok(_categoryMapper.SelectOfDesiredCategory(dataWrapper.Data, categoryId));
        }

        private ActionResult<BaseProductOutputModel> MakeResponse(DataWrapper<ProductDto> dataWrapper)
        {
            if (!dataWrapper.IsOk)
            {
                return BadRequest(dataWrapper.ExceptionMessage);
            }
            return Ok(_categoryMapper.MapToCategory(dataWrapper.Data));
        }

        private ActionResult<List<BaseProductOutputModel>> MakeResponse(DataWrapper<List<ProductDto>> dataWrapper)
        {
            if (!dataWrapper.IsOk)
            {
                return BadRequest(dataWrapper.ExceptionMessage);
            }
            return Ok(_categoryMapper.MapToCategory(dataWrapper.Data));
        }

    }
}

