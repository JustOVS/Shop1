﻿using System.Collections.Generic;
//using Shop.API.Models.Input;
//using Shop.API.Models.Output;
//using Shop.Data.DTO;
//using Shop.Data;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using Shop.Data;

namespace Shop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IShopRepository _repo;
        private readonly IMapper _mapper;

        public ProductController( IShopRepository repo, IMapper mapper)
        {

            _mapper = mapper;
            _repo = repo;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public ActionResult<List<LeadOutputModel>> GetLeadsAll()
        {
            DataWrapper<List<LeadDto>> dataWrapper = _repo.GetAll();
            return MakeResponse(dataWrapper, _mapper.Map<List<LeadOutputModel>>);
        }

        /// <summary>
        /// gets the lead by Id with all information
        /// </summary>
        /// <param name="leadId"></param>       
        //[Authorize()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{leadId}")]
        public ActionResult<LeadOutputModel> GetLeadById(long leadId)
        {
            DataWrapper<LeadDto> dataWrapper = _repo.GetById(leadId);
            return MakeResponse(dataWrapper, _mapper.Map<LeadOutputModel>);
        }

        /// <summary>
        /// creates a new lead
        /// </summary>
        /// <param name="leadModel"></param>       
        //[Authorize()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<LeadOutputModel> CreateLead(LeadInputModel leadModel)
        {
            Validation validation = new Validation();
            string badRequest = validation.BadRequestsForLeadInputModel(leadModel);
            if (!string.IsNullOrWhiteSpace(badRequest)) return BadRequest(badRequest);
            string badRequestForUpdateLead = BadRequestsForLeadInputModelForUpdadeLead(leadModel);
            if (!string.IsNullOrWhiteSpace(badRequestForUpdateLead)) return BadRequest(badRequestForUpdateLead);
            leadModel.Password = new PasswordEncryptor().EncryptPassword(leadModel.Password);
            DataWrapper<LeadDto> newDataWrapper = _repo.Add(_mapper.Map<LeadDto>(leadModel));
            return MakeResponse(newDataWrapper, _mapper.Map<LeadOutputModel>);
        }

        /// <summary>
        /// edits lead's information by leadId
        /// </summary>
        /// <param name="leadModel"></param>        
        //[Authorize()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public ActionResult<LeadOutputModel> UpdateLead(LeadInputModel leadModel)
        {
            if (!leadModel.Id.HasValue)
            {
                return BadRequest("ID is empty");
            }
            var leadId = _repo.GetById(leadModel.Id.Value);
            if (leadId == null) return BadRequest("Lead was not found");
            Validation validation = new Validation();
            string badRequest = validation.BadRequestsForLeadInputModel(leadModel);
            if (!string.IsNullOrWhiteSpace(badRequest)) return BadRequest(badRequest);
            leadModel.Password = new PasswordEncryptor().EncryptPassword(leadModel.Password);
            DataWrapper<LeadDto> newDataWrapper = _repo.Update(_mapper.Map<LeadDto>(leadModel));
            return MakeResponse(newDataWrapper, _mapper.Map<LeadOutputModel>);
        }

        /// <summary>
        /// deletes the lead by Id
        /// </summary>
        /// <param name="leadId"></param>        
        //[Authorize()]      
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{leadId}")]
        public ActionResult DeleteLeadById(long leadId)
        {
            DataWrapper<LeadDto> dataWrapper = _repo.GetById(leadId);
            if (dataWrapper.Data.Id == null) return BadRequest("Lead was not found");
            _repo.Delete(leadId);
            return Ok("Successfully deleted");
        }

        /// <summary>
        /// edits lead's email by leadId 
        /// </summary>
        /// <param name="emailModel"></param>        
        //[Authorize()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("email")]
        public ActionResult<string> UpdateEmailByLeadId(EmailInputModel emailModel)
        {
            var leadId = _repo.GetById(emailModel.Id.Value);
            if (leadId == null) return BadRequest("Lead was not found");
            if (string.IsNullOrWhiteSpace(emailModel.Email))
            {
                return BadRequest("Enter the email");
            }
            else
            {
                DataWrapper<int> dataWrapper = _repo.FindLeadByEmail(emailModel.Email);
                if (dataWrapper.Data != 0) return BadRequest("User with this email already exists");
                if ((!Regex.IsMatch(emailModel.Email, Validation.constantForEmail))) return BadRequest("The Email is incorrect");
            }
            DataWrapper<string> newDataWrapper = _repo.UpdateEmailByLeadId(emailModel.Id, emailModel.Email);
            return MakeResponse(newDataWrapper);
        }

        /// <summary>
        /// searches leads by different parameters
        /// </summary>
        /// <param name="searchparameters"></param>        
        //[Authorize()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost("search")]
        public ActionResult<List<LeadOutputModel>> SearchLead(SearchParametersInputModel searchparameters)
        {
            //  LeadSearchParameters searchParams = _imapper.Map<LeadSearchParameters>(searchparameters);
            DataWrapper<List<LeadDto>> dataWrapper = _repo.SearchLeads(_mapper.Map<LeadSearchParameters>(searchparameters));
            return MakeResponse(dataWrapper, _mapper.Map<List<LeadOutputModel>>);
        }

        /// <summary>
        /// gets the account by Id with all information
        /// </summary>
        /// <param name="Id"></param>       
        //[Authorize()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("account/{Id}")]
        public ActionResult<LeadWithAccountsOutputModel> GetAccountById(long Id)
        {
            DataWrapper<LeadDto> dataWrapper = _repo.GetAccountById(Id);
            return MakeResponse(dataWrapper, _mapper.Map<LeadWithAccountsOutputModel>);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{leadId}/accounts")]
        public ActionResult<LeadWithAccountsOutputModel> GetAccountByLeadId(long leadId)
        {
            DataWrapper<LeadDto> dataWrapper = _repo.GetAccountByLeadId(leadId);
            return MakeResponse(dataWrapper, _mapper.Map<LeadWithAccountsOutputModel>);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost("account")]
        public ActionResult<LeadWithAccountsOutputModel> AddAccount(AccountInputModel account)
        {
            DataWrapper<LeadDto> dataWrapper = _repo.AddOrUpdateAccount(_mapper.Map<AccountDto>(account));//_mapper.Map<LeadSearchParameters>
            return MakeResponse(dataWrapper, _mapper.Map<LeadWithAccountsOutputModel>);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPut("account")]
        public ActionResult<LeadWithAccountsOutputModel> UpdateAccount(AccountInputModel account)
        {
            DataWrapper<LeadDto> dataWrapper = _repo.AddOrUpdateAccount(_mapper.Map<AccountDto>(account));//_mapper.Map<LeadSearchParameters>
            return MakeResponse(dataWrapper, _mapper.Map<LeadWithAccountsOutputModel>);
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

