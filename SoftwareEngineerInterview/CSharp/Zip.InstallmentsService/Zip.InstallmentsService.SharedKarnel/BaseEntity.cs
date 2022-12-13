namespace Zip.InstallmentsService.SharedKarnel
{
    /// <summary>
    /// Used to hold base entity
    /// </summary>
    /// <typeparam name="T">Generic type to accept value for identity columnv value</typeparam>
    public abstract class BaseEntity<T> : IEntity
    {
        #region Public Properties

        /// <inheritdoc/>
        [Required]
        public DateTime CreatedOnUtc { get; set; }

        /// <inheritdoc/>
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public T Id { get; set; }

        object IEntity.Id
        {
            get { return Id; }
            set { }
        }

        #endregion
    }
}
