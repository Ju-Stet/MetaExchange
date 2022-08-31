using MetaExchange.Models;
using MetaExchange.Services;
using MetaExchange.Services.Models;
using MetaExchange.Services.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MetaExchange.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderBookService _orderBookService;
        private readonly IRequestValidator _requestValidator;

        public OrdersController(IOrderBookService orderBookService,
            IRequestValidator requestValidator)
        {
            _orderBookService = orderBookService;
            _requestValidator = requestValidator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ServiceObjectResult<IEnumerable<GetOrderResponse>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult GetBestSuitableOrders([FromBody] RequestInfo requestInfo)
        {
            var validationResult = _requestValidator.Validate(requestInfo);

            if (!validationResult.IsSuccess)
                return BadRequest(validationResult);

            var result = _orderBookService.FindBestFit(requestInfo);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

    }
}
