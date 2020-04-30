using Lykke.Common.ApiLibrary.Contract;
using Lykke.Common.ApiLibrary.Exceptions;

namespace MAVN.Service.PartnerApi.Infrastructure.Constants
{
    /// <summary>
    ///     Class for storing all possible error codes that may happen in Api.
    ///     Use it with <see cref="LykkeApiErrorException" />.
    /// </summary>
    public static class ApiErrorCodes
    {
        /// <summary>
        ///     Group for client and service related error codes.
        /// </summary>
        public static class Service
        {
            /// <summary>
            ///     Login or password is not valid.
            /// </summary>
            public static readonly ILykkeApiErrorCode InvalidCredentials =
                new LykkeApiErrorCode(nameof(InvalidCredentials), "Login or password is not valid.");

            /// <summary>
            /// Customer id is required
            /// </summary>
            public static readonly ILykkeApiErrorCode CustomerIdEmpty =
                new LykkeApiErrorCode(nameof(CustomerIdEmpty), "Customer id is required");

            /// <summary>
            /// Customer id is required
            /// </summary>
            public static readonly ILykkeApiErrorCode CustomerIdInvalidLength =
                new LykkeApiErrorCode(nameof(CustomerIdInvalidLength),
                    "Customer id must be between 1 and 100 characters in length");
        }

        /// <summary>
        ///     Group for all model validation error codes.
        /// </summary>
        public static class ModelValidation
        {
            /// <summary>
            ///     Common error code for any failed validation.
            ///     Use it as default validation error code if specific code is not required.
            /// </summary>
            public static readonly ILykkeApiErrorCode ModelValidationFailed =
                new LykkeApiErrorCode(nameof(ModelValidationFailed), "The model is invalid.");
        }
    }
}
