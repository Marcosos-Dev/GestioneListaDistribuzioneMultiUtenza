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
            List<Recipient> recipients = new List<Recipient>();
            foreach (var Email in email) 
            {
                recipients.Add(new Recipient()
                {
                    EmailAddress = new EmailAddress()
                    {
                        Address = Email.Email
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

            //TOGLIERE COMMENTO SE SI VUOLE INVIARE LA MAIL
            /*await client.Users[_emailOption.From]
                .SendMail.PostAsync(postRequestBody);*/

            //Ritorno la lista di mail a cui ho inviato la mail
            return email;
        }
    }
}
