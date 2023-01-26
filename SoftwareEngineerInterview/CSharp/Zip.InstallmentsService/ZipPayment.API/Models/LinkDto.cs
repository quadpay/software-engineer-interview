namespace ZipPayment.API.Models
{
    /// <summary>
    /// Link Dto attribute link information for api
    /// </summary>
    public class LinkDto
    {
        public string? Href { get; private set; }

        public string? Rel { get; private set; }

        public string Method { get; private set; }

        /// <summary>
        /// Link dto
        /// </summary>
        /// <param name="href">Href</param>
        /// <param name="rel">string</param>
        /// <param name="method">HttpMethod</param>
        public LinkDto(string? href, string? rel, string method)
        {
            Href = href;
            Rel = rel;
            Method = method;
        }
    }
}
