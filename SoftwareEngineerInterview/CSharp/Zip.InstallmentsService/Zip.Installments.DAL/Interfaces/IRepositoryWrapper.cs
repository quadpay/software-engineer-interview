namespace Zip.Installments.DAL.Interfaces
{
    public interface IRepositoryWrapper
    {
        IOrdersRepository OrdersRepository { get; }

        Task Save();
    }
}
