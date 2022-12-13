using System.Text.Json;

namespace Zip.InstallmentsService.ApiContracts
{
    /// <summary>
    /// Used to hold create payment plan requests
    /// </summary>
    public class CreatePaymentPlanRequest
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the frequency
        /// </summary>
        public int Frequency { get; set; }

        /// <summary>
        /// Gets or sets the number of installments
        /// </summary>
        public int NumberOfInstallments { get; set; }

        /// <summary>
        /// Gets or sets the purchase amount
        /// </summary>
        public decimal PurchaseAmount { get; set; }

        /// <summary>
        /// Gets or sets the purchase date
        /// </summary>
        public DateTime PurhcaseDate { get; set; }

        #endregion

        #region Public Method

        /// <summary>
        /// Overridden method to convert <see cref="CreatePaymentPlanRequest"/> to json string
        /// </summary>
        /// <returns>JSON string of <see cref="CreatePaymentPlanRequest"/></returns>
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }

        #endregion
    }
}
