namespace Zip.InstallmentsService.SharedKarnel.Interfaces
{
    /// <summary>
    /// When implemented provides base for creating any object
    /// </summary>
    public interface IEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the created date with UTC time
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the identifier
        /// </summary>
        object Id { get; set; }

        #endregion
    }
}
