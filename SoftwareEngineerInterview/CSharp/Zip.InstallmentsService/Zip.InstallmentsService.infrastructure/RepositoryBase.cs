namespace Zip.InstallmentsService.Infrastructure
{
    /// <summary>
    /// Used to hold create and search functionality for data sets
    /// </summary>
    /// <typeparam name="T">Generic type of Dataset object</typeparam>
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        #region Private Variables

        private readonly InstallmentsServiceDbContext _context;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates instance of <see cref="RepositoryBase"/>
        /// </summary>
        /// <param name="context"><see cref="InstallmentsServiceDbContext"/></param>
        public RepositoryBase(InstallmentsServiceDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Public Methods

        /// <inheritdoc/>        
        public async Task CreateAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>        
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            _context.Set<T>().Where(expression).AsNoTracking();

        #endregion
    }
}
