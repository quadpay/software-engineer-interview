namespace Zip.InstallmentsService.SharedKarnel.Interfaces
{
    /// <summary>
    /// When implemented in base class, provides abilty to perform CURD opertion various
    /// </summary>
    public interface IRepositoryBase<T> where T : class
    {
        /// <summary>
        /// Create and add new entity to database
        /// </summary>
        /// <param name="entity">Generic type of Dataset object</param>
        Task CreateAsync(T entity);


        /// <summary>
        /// Fetches entity by using given expression
        /// </summary>
        /// <param name="expression">"/></param>
        /// <returns>Generic type of Dataset object</returns>
        /// 
        /// <summary>
        /// Retrives query on specific type based on expression
        /// </summary>
        /// <param name="expression">Expression to retrive query <seealso cref="Expression<Func<T, bool>></param>
        /// <returns><see cref="IQueryable<T>"/></returns>
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
    }
}
