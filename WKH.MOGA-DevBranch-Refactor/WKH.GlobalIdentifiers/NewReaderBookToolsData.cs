using System.Collections.Generic;

namespace WKH.GlobalIdentifiers
{
    public class NewReaderBookToolsData
    {
        public static List<string> GetItalianoMenuItemNames()
        {
            return new List<string>()
            {
                "Stampa",
                "Esporta in PDF",
                "Salva sul Disco",
                "Invia il Testo via Email",
                "Invia il Collegamento via Email",
                "Citazione"
            };
        }
    }
}
