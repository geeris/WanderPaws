using WanderPaws.Application.DTOs.Auth;
using WanderPaws.Application.DTOs.JWT;
using WanderPaws.Application.Interfaces;
using WanderPaws.Implementation.Auth.Commands;
using WanderPaws.Implementation.Auth.Queries;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace WanderPaws.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(ILogger<AuthController> logger, IJwtAuthManager jwtAuthManager, IMediator mediator) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginUserQuery request)
        {
            return Ok(await mediator.Send(request));
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand request)
        {

            var result = await mediator.Send(request);
            return Ok(new { message = "The user account has been successfully created." });

        }

        //public IActionResult Index()
        //{
        //    var user = HttpContext.User;
        //    if (user.Identity.IsAuthenticated)
        //    {
        //        var userName = user.Identity.Name;
        //        // Additional user information can be accessed here
        //    }
        //    return View();
        //}

        [HttpPost("logout")]
        [Authorize]
        public ActionResult Logout()
        {
            // optionally "revoke" JWT token on the server side --> add the current token to a block-list
            // https://github.com/auth0/node-jsonwebtoken/issues/375

            var email = User.Identity?.Name!;
            jwtAuthManager.RemoveRefreshTokenByUserEmail(email);
            logger.LogInformation("User [{email}] logged out the system.", email);
            return Ok();
        }

        [HttpPost("refresh-token")]
        [Authorize]
        public async Task<ActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            try
            {
                var email = User.Identity?.Name!;
                logger.LogInformation("User [{email}] is trying to refresh JWT token.", email);

                if (string.IsNullOrWhiteSpace(request.RefreshToken))
                {
                    return Unauthorized();
                }

                var accessToken = await HttpContext.GetTokenAsync("Bearer", "access_token");
                var jwtResult = jwtAuthManager.Refresh(request.RefreshToken, accessToken ?? string.Empty, DateTime.Now);
                logger.LogInformation("User [{email}] has refreshed JWT token.", email);
                return Ok(new LoginResult
                {
                    Email = email,
                    AccessToken = jwtResult.AccessToken,
                    RefreshToken = jwtResult.RefreshToken.TokenString
                });
            }
            catch (SecurityTokenException e)
            {
                return Unauthorized(e.Message); // return 401 so that the client side can redirect the user to login page
            }
        }

        [HttpPost("impersonation")]
        //[Authorize(Roles = UserRoles.Admin)]
        public ActionResult Impersonate([FromBody] ImpersonationRequest request)
        {
            var email = User.Identity?.Name!;
            logger.LogInformation("User [{email}] is trying to impersonate [{anotherUserName}].", email, request.Email);

            //var impersonatedRole = userService.GetUserRole(request.UserName);
            //if (string.IsNullOrWhiteSpace(impersonatedRole))
            //{
            //    logger.LogInformation("User [{userName}] failed to impersonate [{anotherUserName}] due to the target user not found.", userName, request.UserName);
            //    return BadRequest($"The target user [{request.UserName}] is not found.");
            //}

            //if (impersonatedRole == UserRoles.Admin)
            //{
            //    logger.LogInformation("User [{userName}] is not allowed to impersonate another Admin.", userName);
            //    return BadRequest("This action is not supported.");
            //}

            var claims = new[]
            {
            new Claim(ClaimTypes.Name,request.Email),
            new Claim("OriginalUserName", email)
        };

            var jwtResult = jwtAuthManager.GenerateTokens(request.Email, claims, DateTime.Now);
            logger.LogInformation("User [{request.Email}] is impersonating [{anotherUserName}] in the system.", email, request.Email);
            return Ok(new LoginResult
            {
                Email = request.Email,
                OriginalEmail = email,
                AccessToken = jwtResult.AccessToken,
                RefreshToken = jwtResult.RefreshToken.TokenString
            });
        }

        [HttpPost("stop-impersonation")]
        [Authorize]
        public ActionResult StopImpersonation()
        {
            var email = User.Identity?.Name!;
            var originalEmail = User.FindFirst("OriginalUserName")?.Value;
            if (string.IsNullOrWhiteSpace(originalEmail))
            {
                return BadRequest("You are not impersonating anyone.");
            }
            logger.LogInformation("User [{originalUserName}] is trying to stop impersonate [{userName}].", originalEmail, email);

            var claims = new[]
            {
            new Claim(ClaimTypes.Name,originalEmail)
        };

            var jwtResult = jwtAuthManager.GenerateTokens(originalEmail, claims, DateTime.Now);
            logger.LogInformation("User [{originalUserName}] has stopped impersonation.", originalEmail);
            return Ok(new LoginResult
            {
                Email = originalEmail,
                OriginalEmail = string.Empty,
                AccessToken = jwtResult.AccessToken,
                RefreshToken = jwtResult.RefreshToken.TokenString
            });
        }
    }

}