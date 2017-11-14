using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace SimpleEchoBot.Models
{
    [Serializable]
    public class botones : IDialog
    {
        const string SiOption = "si";
        const string NoOption = "no";
        int band = 0;
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MensajeRecibido);
        }

        private async Task MensajeRecibido(IDialogContext context, IAwaitable<object> result)
        {
            if (band == 0)
            {
                PromptDialog.Choice(context, Seleccion, new[] { SiOption, NoOption }, 
                    "Quieres hacer una pregunta?", promptStyle: PromptStyle.Auto);
            }
            else
            {
                PromptDialog.Choice(context, Seleccion, new[] { SiOption, NoOption }, 
                    "Quieres hacer otra pregunta?", promptStyle: PromptStyle.Auto);
            }
        }

        private async Task Seleccion(IDialogContext context, IAwaitable<string> result)
        {
            var opcion = await result;
            switch (opcion)
            {
                case SiOption:
                    await context.PostAsync("Dimela papu v:");
                    band++;
                    context.Wait(MensajeRecibido);
                    break;
                case NoOption:
                    await context.PostAsync("Largo entonces xd");
                    band = 0;
                    break;
            }
        }
    }
}