namespace Zip.Installements.Common
{
    /// <summary>
    /// Class defines constants values that are used inside the project solution.
    /// </summary>
    public static class Constants
    {
        public const int MinmValue = 0;
        public const int RoundOffValue = 2;

        public const string CommandClassAssemblyName = "Zip.Installements.Command";
        public const string QueryClassAssemblyName = "Zip.Installements.Query";

        public const string AmountReqErrMsg = "Amount is required.";
        public const string AmountMinmValueErrMsg = "Amount must be greater than 0.";

        public const string FrequencyReqErrMsg = "Frequency is required.";
        public const string FrequencyMinmValueErrMsg = "Frequency must be greater than 0.";

        public const string NoOfInstallementReqErrMsg = "Number of installement is required.";
        public const string NoOfInstallementMinmValueErrMsg = "Number of installement must be greater than 0.";
    }
}
