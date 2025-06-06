using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vokabeltrainer
{
    public class Flashcard
    {
        public string? FrontText { get; set; }
        public string? BackText { get; set; }
        private DateTime lastReviewed { get; set; }
        private int timesReviewed { get; set; }

        public Flashcard()
        {

        }
        
        public Flashcard(string fronttext) : this()
        {
            this.FrontText = fronttext;
        }

        public Flashcard(string fronttext, string backtext) : this() // hier wird ein existierendes Flashcard objekt verwendet.
        {
            this.BackText = backtext;
            this.FrontText = fronttext;
        }

        public string Showfront()
        {
            return FrontText;
        }

        public string Showback()
        {
            return BackText;
        }

        public void Review()
        {

        }

        public void ResetProgress()
        {

        }

        public string Serialize()
        {
            return $"{FrontText};{BackText}";
        }

        public override string ToString()
        {
            return $"{FrontText} - {BackText}";
        }

        public static Flashcard Deserialize(string data)
        {
            string[] datasplit = data.Split(";");
            if (datasplit.Length < 2)
            {
                Log.Error("invalide split length ...");
                throw new Exception("Dieser Inhalt ist invalide");
            } 
            else
            {
                return new Flashcard(datasplit[0], datasplit[1]);
                // Flashcard(fronttext, backtext)
            }
        }
    }
}
