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
        public EmailSenderService(IOptions<EmailOption> emailOptions)
        {
            _emailOption = emailOptions.Value;
        }

        //nome mail = per ora INFO di default
        //subject = oggetto della mail
        //body = contenuto
        public async Task<List<EmailDestinatario>> SendEmailAsync(string subject, string body, List<EmailDestinatario> email)
        {
            //1-Prendo tutte le mail tramite repo _listaDist_email

            //2-Trovo la lista di stringa di mail effettive tramite _emailService
            
            //3-Mando la mail tramite _emailSenderService
            List<Recipient> recipients = new List<Recipient>(); //va presa tramite gli altri service
            recipients.Add(new Recipient()
            {
                EmailAddress = new EmailAddress()
                {
                    Address = "marcobellilorenzo@gmail.com"
                }
            });
            recipients.Add(new Recipient()
            {
                EmailAddress = new EmailAddress()
                {
                    Address = "lorenzo.marcobelli@studenti.unicam.it"
                }
            });

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

            //TOGLIERE COMMENTO SE SI VUOLE INVIARE LA MAIL
            /*await client.Users[_emailOption.From]
                .SendMail.PostAsync(postRequestBody);*/

            //Ritorno la lista di mail a cui ho inviato la mail
            return new List<EmailDestinatario>();
        }
    }
}
