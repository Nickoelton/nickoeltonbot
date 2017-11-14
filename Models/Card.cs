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
    public class Card : IDialog
    {
        const string HeroCard = "Web Hero Card";
        const string TumblaidCard = "Mini Web Tumblaid Card";
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MensajeRecibido);
        }

        private async Task MensajeRecibido(IDialogContext context, IAwaitable<object> result)
        {
            PromptDialog.Choice(context, Seleccion, new[] { HeroCard, TumblaidCard},"Selecciona una opcion", promptStyle: PromptStyle.Auto);
        }

        private async Task Seleccion(IDialogContext context, IAwaitable<string> result)
        {
            var resultadoSelec = await result;
            var respuesta = context.MakeMessage();

            var attachment = GetSeleccionCards(resultadoSelec);
            respuesta.Attachments.Add(attachment);

            await context.PostAsync(respuesta);
            context.Wait(MensajeRecibido);
        }


        private static Attachment GetSeleccionCards(string selecionCard)
        {
            switch (selecionCard)
            {
                case HeroCard:
                    return GetHeroCard();
                    break;
                case TumblaidCard:
                    return GetTumbailCard();
                    break;
                default:
                    return GetHeroCard();
            }
        }

        // creando las tarjetas graficas
        private static Attachment GetHeroCard()
        {
            var hercoCard = new HeroCard
            {
                Title = "Nickoelton",
                Subtitle = "Mi página web",
                Text = "Aqui podrás encontrar un One Slide sobre mi y como contactarme.",
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
                Text = "esta es version mini xd",
                Images = new List<CardImage> { new CardImage("http://www.nickoelton.com/images/background.jpg") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.PostBack, "opcion", value: "opcion") }
            };
            return tumbailCard.ToAttachment();
        }
    }
}