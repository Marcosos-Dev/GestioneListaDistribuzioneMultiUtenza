using GestioneListaDistribuzioneMultiUtenza.Application.Models.Requests;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services
{
    public interface ITokenService
    {
        Task<string> CreateTokenAsync(string email, string password);
    }
}
