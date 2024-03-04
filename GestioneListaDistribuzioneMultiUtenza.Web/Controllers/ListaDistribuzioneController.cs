using GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services;
using GestioneListaDistribuzioneMultiUtenza.Application.Factories;
using GestioneListaDistribuzioneMultiUtenza.Application.Models.Requests;
using GestioneListaDistribuzioneMultiUtenza.Application.Models.Responses;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestioneListaDistribuzioneMultiUtenza.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ListaDistribuzioneController : ControllerBase
    {
        private readonly IListaDistribuzioneService _listaDistribuzioneService;
        private readonly IEmailSenderService _emailSenderService;
        public ListaDistribuzioneController(IListaDistribuzioneService listaDistribuzioneService, IEmailSenderService emailSenderService)
        {
            _listaDistribuzioneService = listaDistribuzioneService;
            _emailSenderService = emailSenderService;
        }

        [HttpPost]
        [Route("createListaDistribuzione")]
        public async Task<IActionResult> CreateListaDistribuzioneAsync(CreateListaDistribuzioneRequest request)
        {
            int IdUtente = Convert.ToInt32(HttpContext.Items["IdUtente"]);
            var lista = request.ToEntity();
            lista.IdProprietario = IdUtente;
            await _listaDistribuzioneService.AddListaDistribuzioneAsync(lista);

            var response = new CreateListaDistribuzioneResponse();
            response.ListaDistribuzione = new Application.Models.Dtos.ListaDistribuzioneDto(lista);
            return Ok(ResponseFactory
          .WithSuccess(response)
          );
        }

        [HttpPost]
        [Route("getListeUtente")]
        public async Task<IActionResult> GetListeUtenteByEmailAsync(GetListeUtenteByEmailRequest request)
        {
            int IdUtente = Convert.ToInt32(HttpContext.Items["IdUtente"]);
            var (listeDistribuzione, totalNum) = await _listaDistribuzioneService.GetListeUtenteByEmailAsync(IdUtente,
                request.email, request.PageNumber * request.PageSize, request.PageSize);

            if (listeDistribuzione.Count == 0)
            {
                return BadRequest(ResponseFactory.WithError("L'email fornita non esiste o non è associata a nessuna lista dell'utente" +
                    " o l'utente non possiede alcuna lista o sei in una pagina troppo avanti"));
            }

            var pageFound = (totalNum / (decimal)request.PageSize);

            var response = new GetListeUtenteByEmailResponse
            {
                ListeDistribuzione = listeDistribuzione.Select(s =>
            new Application.Models.Dtos.ListaDistribuzioneDto(s)).ToList(),
                NumeroPagine = (int)Math.Ceiling(pageFound)
            };

            return Ok(ResponseFactory.WithSuccess(response));
        }

        [HttpPost]
        [Route("sendEmail")]
        public async Task<IActionResult> SendEmailToListaAsync(SendEmailToListaRequest request)
        {
            var IdProprietario = await _listaDistribuzioneService.GetProprietarioListaAsync(request.idLista);
            int IdUtente = Convert.ToInt32(HttpContext.Items["IdUtente"]);
            if (IdUtente.Equals(IdProprietario))
            {
                var emailSent = await _emailSenderService.SendEmailAsync(request.Subject, request.Body, request.idLista);
                var response = new SendEmailToListResponse
                {
                    DestinatariDto = emailSent.Select(s =>
                new Application.Models.Dtos.DestinatarioDto(s)).ToList()
                };
                return Ok(ResponseFactory.WithSuccess(response));
            }
            else
            {
                return BadRequest(ResponseFactory.WithError("Tentativo di invio di email in una lista di cui non si è proprietari o che non esiste"));
            }
        }
    }
}
