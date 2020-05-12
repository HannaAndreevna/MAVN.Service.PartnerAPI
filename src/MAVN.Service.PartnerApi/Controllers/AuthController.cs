using System;
using System.Net;
using System.Threading.Tasks;
using Common.Log;
using MAVN.Common.Middleware.Authentication;
using Lykke.Common.ApiLibrary.Exceptions;
using Lykke.Common.Log;
using MAVN.Service.Sessions.Client;
using MAVN.Service.PartnerApi.Domain.Services;
using MAVN.Service.PartnerApi.Infrastructure.Constants;
using MAVN.Service.PartnerApi.Models.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MAVN.Service.PartnerApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IRequestContext _requestContext;
        private readonly ISessionsServiceClient _sessionsServiceClient;
        private readonly ILog _log;

        public AuthController(IAuthService authService, IRequestContext requestContext,
            ISessionsServiceClient sessionsServiceClient, ILogFactory logFactory)
        {
            _authService = authService;
            _requestContext = requestContext;
            _sessionsServiceClient = sessionsServiceClient;
            _log = logFactory.CreateLog(this);
        }

        /// <summary>
        /// Login partner user
        /// </summary>
        /// <param name="model">Login credentials</param>
        /// <returns>Login response with authentication token</returns>
        /// <remarks>
        /// Error codes:
        /// - InvalidCredentials
        /// </remarks>
        [HttpPost("login")]
        [AllowAnonymous]
        [SwaggerOperation("Login")]
        [ProducesResponseType(typeof(LoginResponseModel), (int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        [ProducesResponseType((int) HttpStatusCode.Forbidden)]
        public async Task<IActionResult> Login([FromBody] LoginRequestModel model)
        {
            var authModel = await _authService.AuthAsync(model.ClientId, model.ClientSecret, model.UserInfo);

            switch (authModel.Error)
            {
                case ServicesError.None:
                    return Ok(new LoginResponseModel {Token = authModel.Token});

                case ServicesError.LoginNotFound:
                case ServicesError.PasswordMismatch:
                case ServicesError.InvalidCredentials:
                    throw LykkeApiErrorException.Unauthorized(ApiErrorCodes.Service.InvalidCredentials);

                default:
                    throw new InvalidOperationException(
                        $"Unexpected error during Authenticate for {model.ClientId} - {authModel.Error}");
            }
        }

        /// <summary>
        /// Logout partner user
        /// </summary>
        /// <returns></returns>
        [HttpPost("logout")]
        [LykkeAuthorize]
        [SwaggerOperation("logout")]
        [ProducesResponseType((int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Logout()
        {
            var token = _requestContext.SessionToken;

            _log.Info("Trying to delete session", new { token });

            await _sessionsServiceClient.SessionsApi.DeleteSessionIfExistsAsync(token);

            _log.Info("Session deleted. Logout called", new { token });

            return Ok();
        }
    }
}
