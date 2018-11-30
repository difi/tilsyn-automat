using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.ValueList;
using Difi.Sjalvdeklaration.Shared.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Difi.Sjalvdeklaration.Api
{
    [Route("api/[controller]")]
    public class ValueListController : ControllerBase
    {
        private readonly IValueListRepository valueListRepository;

        public ValueListController(IValueListRepository valueListRepository)
        {
            this.valueListRepository = valueListRepository;
        }

        [HttpGet]
        [Route("GetAllTypeOfMachine")]
        public ApiResult<List<ValueListTypeOfMachine>> GetAllTypeOfMachine()
        {
            return valueListRepository.GetAllTypeOfMachine<List<ValueListTypeOfMachine>>();
        }

        [HttpGet]
        [Route("GetAllTypeOfTest")]
        public ApiResult<List<ValueListTypeOfTest>> GetAllTypeOfTest()
        {
            return valueListRepository.GetAllTypeOfTest<List<ValueListTypeOfTest>>();
        }

        [HttpGet]
        [Route("GetAllTypeOfSupplierAndVersion")]
        public ApiResult<List<ValueListTypeOfSupplierAndVersion>> GetAllTypeOfSupplierAndVersion()
        {
            return valueListRepository.GetAllTypeOfSupplierAndVersion<List<ValueListTypeOfSupplierAndVersion>>();
        }

        [HttpGet]
        [Route("GetAllTypeOfStatus")]
        public ApiResult<List<ValueListTypeOfStatus>> GetAllTypeOfStatus()
        {
            return valueListRepository.GetAllTypeOfStatus<List<ValueListTypeOfStatus>>();
        }

        [HttpGet]
        [Route("GetAllPurposeOfTest")]
        public ApiResult<List<ValueListPurposeOfTest>> GetAllPurposeOfTest()
        {
            return valueListRepository.GetAllPurposeOfTest<List<ValueListPurposeOfTest>>();
        }
    }
}