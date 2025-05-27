using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vokabeltrainer
{
    public class Deck
    {
        // Hier wird die Liste initialisiert, welches im Konstruktor somit verwendet wird.
        private List<Flashcardlist> deck = new List<Flashcardlist>();

        private Deck(List<Flashcardlist> deck)
        {
            // Hier wird eine Liste von einer Flashcardliste gespeichert
            deck = new List<Flashcardlist> ();
        }

        public void Speichern(string path)
        {
            // Hier sollte das Deck gespeichert werden.
            using (StreamWriter sw = new StreamWriter(path))
            {
                
                for (int i = 0; i < deck.Count; i++) // Durchläuft alle Werte aus der Liste
                {
                    Flashcard card = new Flashcard();
                    
                    sw.WriteLine(card.Serialize());
                }
            }
        }
    }
}
