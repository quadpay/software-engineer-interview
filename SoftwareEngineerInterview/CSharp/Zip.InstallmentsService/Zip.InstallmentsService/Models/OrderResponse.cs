using Zip.InstallmentsService.Constants;

namespace Zip.InstallmentsService.Models
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
