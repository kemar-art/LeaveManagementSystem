using LeaveManagementSystem.Application.Contracts.Identity;
using LeaveManagementSystem.Application.Exceptions;
using LeaveManagementSystem.Application.Models.Identity;
using LeaveManagementSystem.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IOptions<JwtSettings> _jwtSettings;

        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<JwtSettings> jwtSettings) 
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings;
        }
        public async Task<AuthResponse> Login(AuthRequest authRequest)
        {
            var user = await _userManager.FindByEmailAsync(authRequest.Email);
            if (user == null)
            {
                throw new NotFoundException($"User with {authRequest.Email} was not found", authRequest.Email);

                
            }

            var loginUser = await _signInManager.CheckPasswordSignInAsync(user, authRequest.Password, false);

            if (!loginUser.Succeeded)
            {
                throw new BadRequestException($"Credentials for {authRequest.Email} is not valid");
            }

            JwtSecurityToken jwtSecurityToken = GenarateToken(user);
        }

        private async JwtSecurityToken GenarateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            //Combin roles and  userClaims in
            var roleClaims = roles.Select(q => new Claim(ClaimTypes.Role, q)).ToList();
        }

        public Task<RegistrationResponse> Register(RegistrationRequest registrationRequest)
        {
            throw new NotImplementedException();
        }
    }
}
