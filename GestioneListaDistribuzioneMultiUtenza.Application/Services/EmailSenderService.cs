using Microsoft.Graph;
using Microsoft.Graph.Models;
using Microsoft.Graph.Users.Item.SendMail;
using GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services;
using Azure.Identity;
using GestioneListaDistribuzioneMultiUtenza.Application.Options;
using Microsoft.Extensions.Options;
using GestioneListaDistribuzioneMultiUtenza.Models.Entities;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly EmailOption _emailOption;
        private readonly IDestinatarioService _destinatarioService;
        public EmailSenderService(IOptions<EmailOption> emailOptions, IDestinatarioService destinatarioService)
        {
            _emailOption = emailOptions.Value;
            _destinatarioService = destinatarioService;
        }

        public async Task<List<Destinatario>> SendEmailAsync(string subject, string body, int idLista)
        {
            var destinatari = await _destinatarioService.GetDestinatariAsync(idLista);
            List<Recipient> recipients = new List<Recipient>();
            foreach (var email in destinatari) 
            {
                recipients.Add(new Recipient()
                {
                    EmailAddress = new EmailAddress()
                    {
                        Address = email.Email
                    }
                });
            }

            var clientCredential = new ClientSecretCredential(_emailOption.TenantId
                , _emailOption.ClientId
                , _emailOption.ClientSecret
                );
            var client = new GraphServiceClient(clientCredential);

            Message message = new()
            {
                Subject = subject,
                Body = new ItemBody
                {
                    ContentType = Microsoft.Graph.Models.BodyType.Text,
                    Content = body
                },
                ToRecipients = recipients
            };

            var postRequestBody = new SendMailPostRequestBody();
            postRequestBody.Message = message;
            postRequestBody.SaveToSentItems = true;

            await client.Users[_emailOption.From]
                .SendMail.PostAsync(postRequestBody);

            //Ritorno la lista di mail a cui ho inviato la mail
            return destinatari;
        }
    }
}
