namespace Zip.Installements.Domain.BaseEntity
{
    /// <summary>
    /// Generic interface
    /// The intention of having a generic interface to give flexibility to developer and prodcut owner
    /// to define primary key column to any supported primitive data type
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public interface IEntity<TId>
    {
        TId Id { get; set; }
    }
}
