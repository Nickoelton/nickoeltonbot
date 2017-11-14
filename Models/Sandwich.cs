using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
#pragma warning disable 649


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