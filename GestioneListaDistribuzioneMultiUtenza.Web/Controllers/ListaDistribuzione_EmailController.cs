using GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services;
using GestioneListaDistribuzioneMultiUtenza.Application.Factories;
using GestioneListaDistribuzioneMultiUtenza.Application.Models.Requests;
using GestioneListaDistribuzioneMultiUtenza.Application.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GestioneListaDistribuzioneMultiUtenza.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ListaDistribuzione_EmailController : ControllerBase
    {
        private readonly IListaDistribuzione_EmailService _listaDistribuzione_EmailService;
        private readonly IListaDistribuzioneService _listaDistribuzioneService;
        public ListaDistribuzione_EmailController(IListaDistribuzione_EmailService emailDestinatarioService, IListaDistribuzioneService listaDistribuzioneService)
        {
            _listaDistribuzione_EmailService = emailDestinatarioService;
            _listaDistribuzioneService = listaDistribuzioneService;
        }

        [HttpPost]
        [Route("addDestinatario")]
        public async Task<IActionResult> AggiungiDestinatarioAsync(AddDestinatarioToListRequest request)
        {
            var IdProprietario = await _listaDistribuzioneService.OttieniProprietarioListaAsync(request.listId);
            int IdUtente = Convert.ToInt32(HttpContext.Items["IdUtente"]);
            if (IdUtente.Equals(IdProprietario))
            {
                var risultatoAggiunta = await _listaDistribuzione_EmailService.AddDestinatarioToListAsync(request.listId,request.email);
                //possibile modifica con DTO e response adeguata
                if (risultatoAggiunta == null)
                {
                    return BadRequest(ResponseFactory.WithError("Tentativo di aggiunta di un destinatario ad una lista in cui è già presente"));
                }
            }
            else
            {
                return BadRequest(ResponseFactory.WithError("Tentativo di aggiunta di un destinatario in una lista di cui non si è proprietari o che non esiste"));
            }
            return Ok(ResponseFactory.WithSuccess("Destinatario aggiunto con successo"));
        }

        [HttpDelete]
        [Route("deleteDestinatario")]
        public async Task<IActionResult> DeleteDestinatarioFromList(DeleteListaDistribuzione_EmailRequest request)
        {
            var IdProprietario = await _listaDistribuzioneService.OttieniProprietarioListaAsync(request.listId);
            int IdUtente = Convert.ToInt32(HttpContext.Items["IdUtente"]);
            if (IdUtente.Equals(IdProprietario))
            {
                var item = request.ToEntity();
                var deletedRecord = await _listaDistribuzione_EmailService.DeleteDestinatarioFromListAsync(item.IdLista,item.IdEmailDestinatario);
                if(deletedRecord == null) 
                {
                    return BadRequest(ResponseFactory.WithError("I parametri forniti non hanno fornito nessun risultato"));
                }
            }
            else
            {
                return BadRequest(ResponseFactory.WithError("Tentativo di eliminazione di una email da una lista di cui non si è proprietari o che non esiste"));
            }
            return Ok(ResponseFactory.WithSuccess("Destinatario rimosso con successo"));
        }

        [HttpPost]
        [Route("getLists")]
        public async Task<IActionResult> GetListaDistribuzioneFromEmail(GetListaFromEmailRequest request)
        {
            int IdUtente = Convert.ToInt32(HttpContext.Items["IdUtente"]);

            var listeDiDistribuzione = await _listaDistribuzione_EmailService.GetListaDistribuzioneOfUtenteFromEmail(IdUtente, request.email);

            var response = new GetListeFromEmailResponse
            {
                Liste = listeDiDistribuzione.Select(s =>
            new Application.Models.Dtos.ListaDistribuzioneDto(s)).ToList()
            };

            if (listeDiDistribuzione.Count == 0)
            {
                return BadRequest(ResponseFactory.WithError("L'email fornita non esiste o non è associata a nessuna lista"));
            }

            return Ok(ResponseFactory.WithSuccess(response));
        }

        [HttpPost]
        [Route("sendEmail")]
        public IActionResult SendEmailToList(DeleteListaDistribuzione_EmailRequest request)
        {
            return BadRequest();
        }
    }
}
