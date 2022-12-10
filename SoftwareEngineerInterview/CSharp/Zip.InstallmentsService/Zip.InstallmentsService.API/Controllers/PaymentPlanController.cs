﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Zip.InstallmentsService.Entity.Dto;
using Zip.InstallmentsService.Interface;
using Zip.InstallmentsService.Data.Interface;
using Microsoft.VisualBasic;
using Zip.InstallmentsService.Implementation;

namespace Zip.InstallmentsService.API.Controllers
{

    /// <summary>
    /// Controller which defines all the end points for a purchase installment plan.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentPlanController : ControllerBase
    {

        private readonly IPaymentPlanProvider _paymentPlanProvider;


        [HttpPost]
        [Authorize]
        [Route("Create")]
        public ActionResult<PaymentPlanDto> Create(PaymentPlanDto _requestModel)
        {
            try
            {
                if (_requestModel.PurchaseDate == DateTime.MinValue) 
                    _requestModel.PurchaseDate = DateTime.UtcNow;

                //Validate Request
                var validRequestViewModel = _paymentPlanProvider.ValidateCreateRequest(_requestModel);
                if (!validRequestViewModel.IsValid)
                {
                    return BadRequest(validRequestViewModel.Message);
                }

                //Create Plan
                var result = _paymentPlanProvider.Create(_requestModel);
                if (result == null)
                {
                    return NotFound(new PaymentPlanDto());
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


    }



}
