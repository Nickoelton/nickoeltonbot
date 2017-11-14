using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;

namespace SimpleEchoBot.Models
{ 

    [Serializable]
    public class Carrusel : IDialog
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MensajeRecibido);
        }

        private async Task MensajeRecibido(IDialogContext context, IAwaitable<object> result)
        {
            var reply = context.MakeMessage();
            reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;  // de tipo carrusel (horizontal)
            // reply.AttachmentLayout = AttachmentLayoutTypes.List;   // de tipo lista (vertical)
            reply.Attachments = GetCards();
            await context.PostAsync(reply);
            context.Wait(MensajeRecibido);
        }



        private static IList<Attachment> GetCards()
        {
            return new List<Attachment>()
            {
                GetHeroCard(),
                GetTumbailCard()
            };
        }

        // creando las tarjetas graficas
        private static Attachment GetHeroCard()
        {
            var hercoCard = new HeroCard
            {
                Title = "Tarjeta URL",
                Subtitle = "mi tarjeta",
                Text = "",
                Images = new List<CardImage> { new CardImage("http://www.nickoelton.com/images/background.jpg") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "Ir a mi web", value: "http://www.nickoelton.com") }
            };
            return hercoCard.ToAttachment();
        }

        private static Attachment GetTumbailCard()
        {
            var tumbailCard = new ThumbnailCard
            {
                Title = "Tarjeta URL",
                Subtitle = "mi tarjeta",
                Text = "",
                Images = new List<CardImage> { new CardImage("http://www.nickoelton.com/images/background.jpg") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.PostBack, "opcion", value: "opcion") }
            };
            return tumbailCard.ToAttachment();
        }
    }
}