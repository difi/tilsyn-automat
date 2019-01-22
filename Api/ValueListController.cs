using Difi.Sjalvdeklaration.Api.Base;
using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.ValueList;
using Difi.Sjalvdeklaration.Shared.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Difi.Sjalvdeklaration.Api
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ValueListController : ApiControllerBase
    {
        private readonly IValueListRepository valueListRepository;

        public ValueListController(IValueListRepository valueListRepository, IConfiguration configuration, IHttpContextAccessor httpContextAccessor) : base(valueListRepository, configuration, httpContextAccessor)
        {
            this.valueListRepository = valueListRepository;
        }

        [HttpGet]
        [Route("GetAllTypeOfMachine")]
        public ApiResult<List<ValueListTypeOfMachine>> GetAllTypeOfMachine()
        {
            return HandleRequest<List<ValueListTypeOfMachine>>() ?? valueListRepository.GetAllTypeOfMachine<List<ValueListTypeOfMachine>>();
        }

        [HttpGet]
        [Route("GetAllTypeOfTest")]
        public ApiResult<List<ValueListTypeOfTest>> GetAllTypeOfTest()
        {
            return HandleRequest<List<ValueListTypeOfTest>>() ?? valueListRepository.GetAllTypeOfTest<List<ValueListTypeOfTest>>();
        }

        [HttpGet]
        [Route("GetAllTypeOfSupplierAndVersion")]
        public ApiResult<List<ValueListTypeOfSupplierAndVersion>> GetAllTypeOfSupplierAndVersion()
        {
            return HandleRequest<List<ValueListTypeOfSupplierAndVersion>>() ?? valueListRepository.GetAllTypeOfSupplierAndVersion<List<ValueListTypeOfSupplierAndVersion>>();
        }

        [HttpGet]
        [Route("GetAllTypeOfStatus")]
        public ApiResult<List<ValueListTypeOfStatus>> GetAllTypeOfStatus()
        {
            return HandleRequest<List<ValueListTypeOfStatus>>() ?? valueListRepository.GetAllTypeOfStatus<List<ValueListTypeOfStatus>>();
        }

        [HttpGet]
        [Route("GetAllPurposeOfTest")]
        public ApiResult<List<ValueListPurposeOfTest>> GetAllPurposeOfTest()
        {
            return HandleRequest<List<ValueListPurposeOfTest>>() ?? valueListRepository.GetAllPurposeOfTest<List<ValueListPurposeOfTest>>();
        }
    }
}