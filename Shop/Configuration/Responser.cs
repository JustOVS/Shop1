using Microsoft.AspNetCore.Mvc;
using Shop.API.Models.OutputModels;
using Shop.Data;
using Shop.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.API.Configuration
{
    public class Responser : Controller
    { 

        protected readonly ProductToCategoryMapper _categoryMapper;

        public Responser(ProductToCategoryMapper categoryMapper)
        {

            _categoryMapper = categoryMapper;
        }
    
        protected delegate T DtoConverter<T, K>(K dto);

        protected ActionResult<T> MakeResponse<T>(DataWrapper<T> dataWrapper)
        {
            if (!dataWrapper.IsOk)
            {
                return BadRequest(dataWrapper.ExceptionMessage);
            }
            return Ok(dataWrapper.Data);
        }

        protected ActionResult<T> MakeResponse<T, K>(DataWrapper<K> dataWrapper, DtoConverter<T, K> dtoConverter)
        {
            if (!dataWrapper.IsOk)
            {
                return BadRequest(dataWrapper.ExceptionMessage);
            }
            return Ok(dtoConverter(dataWrapper.Data));
        }

        protected ActionResult<List<BaseProductOutputModel>> MakeResponse(DataWrapper<List<ProductDto>> dataWrapper, int categoryId)
        {
            if (!dataWrapper.IsOk)
            {
                return BadRequest(dataWrapper.ExceptionMessage);
            }
            return Ok(_categoryMapper.SelectOfDesiredCategory(dataWrapper.Data, categoryId));
        }

        protected ActionResult<BaseProductOutputModel> MakeResponse(DataWrapper<ProductDto> dataWrapper)
        {
            if (!dataWrapper.IsOk)
            {
                return BadRequest(dataWrapper.ExceptionMessage);
            }
            return Ok(_categoryMapper.MapToCategory(dataWrapper.Data));
        }

        protected ActionResult<List<BaseProductOutputModel>> MakeResponse(DataWrapper<List<ProductDto>> dataWrapper)
        {
            if (!dataWrapper.IsOk)
            {
                return BadRequest(dataWrapper.ExceptionMessage);
            }
            return Ok(_categoryMapper.MapToCategory(dataWrapper.Data));
        }
    }
}
