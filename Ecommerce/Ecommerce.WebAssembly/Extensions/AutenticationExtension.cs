using Blazored.LocalStorage;
using Ecommerce.DTO;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Ecommerce.WebAssembly.Extensions
{
    public class AutenticationExtension : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;
        private ClaimsPrincipal _noInfo = new ClaimsPrincipal(new ClaimsIdentity());

        public AutenticationExtension(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService; 
        }

        public async Task UpdateAutenticationState(SessionDTO sessionDTO)
        {
            ClaimsPrincipal claimsPrincipal;
            if(sessionDTO != null)
            {
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim> {
                    new Claim(ClaimTypes.NameIdentifier, sessionDTO.Id.ToString()),
                    new Claim(ClaimTypes.Name, sessionDTO.Name),
                    new Claim(ClaimTypes.Email, sessionDTO.Email),
                    new Claim(ClaimTypes.Role, sessionDTO.Rol),     
                }, "JwtAuth"));

                await _localStorageService.SetItemAsync("session", sessionDTO);
            }
            else
            {
                claimsPrincipal = _noInfo;
                await _localStorageService.RemoveItemAsync("session");
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var userSession = await _localStorageService.GetItemAsync<SessionDTO>("session");
            if (userSession == null)
                return await Task.FromResult(new AuthenticationState(_noInfo));
            
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim> {
                    new Claim(ClaimTypes.NameIdentifier, userSession.Id.ToString()),
                    new Claim(ClaimTypes.Name, userSession.Name),
                    new Claim(ClaimTypes.Email, userSession.Email),
                    new Claim(ClaimTypes.Role, userSession.Rol),
                }, "JwtAuth"));

            return await Task.FromResult(new AuthenticationState(claimsPrincipal));

        }
    }
}
