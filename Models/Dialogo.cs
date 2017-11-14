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
    public class Dialogo : IDialog
    {
        string option1 = "hola";
        string option2 = "bae";

        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MensajeRecivido);
        }

        private async Task MensajeRecivido(IDialogContext context, IAwaitable<object> result)
        {
            await context.PostAsync("Hola soy NickoeltonBot y tengo estas opciones");
            await context.PostAsync(option1 + " \n" + option2);
            context.Wait(opcionrespuesta);
        }

        private async Task opcionrespuesta(IDialogContext context, IAwaitable<object> result)
        {
            var message = await result as Activity;
            if ((message.Text.Equals("hola")) || (message.Text.Equals("bae")))
            {
                if (message.Text.Equals("hola"))
                {
                    await context.PostAsync("habla causita xd");
                }
                else
                {
                    await context.PostAsync("ablaos prro xd");
                }

            }
            else
            {
                await context.PostAsync("No entiendo bro");
                await context.PostAsync(option1 + " \n" + option2);
            }
        }
    }
}