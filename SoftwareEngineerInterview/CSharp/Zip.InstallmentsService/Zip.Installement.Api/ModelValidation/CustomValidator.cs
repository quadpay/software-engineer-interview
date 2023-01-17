﻿namespace Zip.Installements.Api.ModelValidation
{
    using FluentValidation;
    using Zip.Installements.Common;
    using Zip.Installements.Contract.Request;

    /// <summary>
    /// Class defines the custom validation using fluent validation api methods.
    /// </summary>
    public class CustomValidator : AbstractValidator<PaymentPlanRequest>
    {
        public CustomValidator()
        {
            RuleFor(x => x.Amount).NotEmpty()
                .WithMessage(Constants.AmountReqErrMsg);
            RuleFor(x => x.Amount).GreaterThan(Constants.MinmValue)
                .WithMessage(Constants.AmountMinmValueErrMsg);

            RuleFor(x => x.NumofInstallement).NotEmpty()
                .WithMessage(Constants.NoOfInstallementReqErrMsg);
            RuleFor(x => x.NumofInstallement).GreaterThan(Constants.MinmValue)
                .WithMessage(Constants.NoOfInstallementMinmValueErrMsg);

            RuleFor(x => x.Frequency).NotEmpty()
                .WithMessage(Constants.FrequencyReqErrMsg);
            RuleFor(x => x.Frequency).GreaterThan(Constants.MinmValue)
                .WithMessage(Constants.FrequencyMinmValueErrMsg);
        }
    }
}
