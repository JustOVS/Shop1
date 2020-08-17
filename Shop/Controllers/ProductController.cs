using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using Shop.Data;
using Shop.API.Models.OutputModels;
using Shop.Data.Dto;
using Shop.API.Models.InputModels;
using System.Linq;

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

        /// <summary>
        /// gets all products by Category id
        /// </summary>
        /// <param name="categoryId"></param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("category/{categoryId}")]
        public ActionResult<List<BaseProductOutputModel>> GetAllProductsByCategoryName(int categoryId)
        {
            DataWrapper<List<ProductDto>> dataWrapper = _repo.GetAllProducts();
            return MakeResponse(dataWrapper, categoryId);
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
        private ActionResult<List<BaseProductOutputModel>> MakeResponse(DataWrapper<List<ProductDto>> dataWrapper, int categoryId)
        {
            if (!dataWrapper.IsOk)
            {
                return BadRequest(dataWrapper.ExceptionMessage);
            }
            return Ok(SelectOfDesiredCategory(dataWrapper.Data, categoryId));
        }

        private ActionResult<T> MakeResponse<T, K>(DataWrapper<K> dataWrapper, DtoConverter<T, K> dtoConverter)
        {
            if (!dataWrapper.IsOk)
            {
                return BadRequest(dataWrapper.ExceptionMessage);
            }
            return Ok(dtoConverter(dataWrapper.Data));
        }

        

        private dynamic SelectOfDesiredCategory (List<ProductDto> products, int categoryId)
        {
            switch (categoryId)
            {
                case 1:
                    {
                        var selectedProducts = products.Where(p => p.NoiseLevel != null && p.Power != null && p.NumberOfNozzles != null).ToList();
                        return _mapper.Map<List<VacuumCleanerOutputModel>>(selectedProducts);
                    }
                case 2:
                    {
                        var selectedProducts = products.Where(p => p.NoiseLevel != null && p.DryingMode != null && p.Volume != null).ToList();
                        return _mapper.Map<List<WashingMachineOutputModel>>(selectedProducts);
                    }
                case 3:
                    {
                        var selectedProducts = products.Where(p => p.NumberOfRecipes != null && p.Power != null && p.NumberOfModes != null).ToList();
                        return _mapper.Map<List<MicrowaveOutputModel>>(selectedProducts);
                    }
                case 4:
                    {
                        var selectedProducts = products.Where(p => p.NumberOfRecipes != null && p.DescalingProtection != null && p.NumberOfCompartments != null).ToList();
                        return _mapper.Map<List<KitchenStoveOutputModel>>(selectedProducts);
                    }
                case 5:
                    {
                        var selectedProducts = products.Where(p => p.Volume != null && p.Power != null && p.DescalingProtection != null).ToList();
                        return _mapper.Map<List<KettleOutputModel>>(selectedProducts);
                    }
                case 6:
                    {
                        var selectedProducts = products.Where(p => p.NumberOfRecipes != null && p.Volume != null && p.NumberOfModes != null).ToList();
                        return _mapper.Map<List<CoffeeMakerOutputModel>>(selectedProducts);
                    }
                case 7:
                    {
                        var selectedProducts = products.Where(p => p.NoiseLevel != null && p.DryingMode != null && p.NumberOfCompartments != null).ToList();
                        return _mapper.Map<List<DishwasherOutputModel>>(selectedProducts);
                    }
                case 8:
                    {
                        var selectedProducts = products.Where(p => p.NumberOfRecipes != null && p.Volume != null && p.DescalingProtection != null).ToList();
                        return _mapper.Map<List<MulticookerOutputModel>>(selectedProducts);
                    }
                case 9:
                    {
                        var selectedProducts = products.Where(p => p.NumberOfRecipes != null && p.NumberOfCompartments != null && p.NumberOfModes != null).ToList();
                        return _mapper.Map<List<ToasterOutputModel>>(selectedProducts);
                    }
                case 10:
                    {
                        var selectedProducts = products.Where(p => p.DryingMode != null && p.DescalingProtection != null && p.NumberOfModes != null).ToList();
                        return _mapper.Map<List<IronOutputModel>>(selectedProducts);
                    }
                case 11:
                    {
                        var selectedProducts = products.Where(p => p.DescalingProtection != null && p.Power != null && p.NumberOfNozzles != null).ToList();
                        return _mapper.Map<List<MixerOutputModel>>(selectedProducts);
                    }
                case 12:
                    {
                        var selectedProducts = products.Where(p => p.DryingMode != null && p.AirSpeed != null && p.NumberOfNozzles != null).ToList();
                        return _mapper.Map<List<HairdryerOutputModel>>(selectedProducts);
                    }
                case 13:
                    {
                        var selectedProducts = products.Where(p => p.NoiseLevel != null && p.Power != null && p.AirSpeed != null).ToList();
                        return _mapper.Map<List<FanOutputModel>>(selectedProducts);
                    }


                default: return null;
            }
        }
    }
}

