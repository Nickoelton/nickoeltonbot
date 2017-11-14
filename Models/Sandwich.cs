using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
#pragma warning disable 649

// The SandwichOrder is the simple form you want to fill out.  It must be serializable so the bot can be stateless.
// The order of fields defines the default order in which questions will be asked.
// Enumerations shows the legal options for each field in the SandwichOrder and the order is the order values will be presented 
// in a conversation.
namespace Microsoft.Bot.Sample.FormBot
{

    public enum Options
    {
        Cumpleaños, Familia, Amigos
    };
    public enum Familia
    {
        Mamá, Papá, Hermanos
    };

    [Serializable]
    public class SandwichOrder
    {
        public Options? Opcion;
        public Familia? Familia;


        public static IForm<SandwichOrder> BuildForm()
        {
            return new FormBuilder<SandwichOrder>()
                    .Message("Hola, no estoy en este momento pero mi nickoeltonbot te ayudara ;) !")
                    .Build();
        }
    };
}