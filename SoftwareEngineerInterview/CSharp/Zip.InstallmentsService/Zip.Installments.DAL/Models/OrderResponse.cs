using Zip.Installments.DAL.Constants;

namespace Zip.Installments.DAL.Models
{
    /// <summary>
    ///     Order response structure definition
    /// </summary>
    public class OrderResponse
    {
        public int Id { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string Message { get; set; }
    }
}
