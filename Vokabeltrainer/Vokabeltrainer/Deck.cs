using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vokabeltrainer
{
    public class Deck
    {
         // Initialisierung eines decks durch eine Schnittstelle
         // (+ Indezes können ausgelesen und bearbeitet werden,
         // keine Konvertierung nötig)

        // Hier wird die Liste initialisiert, welches im Konstruktor somit verwendet wird.
        private List<Flashcardlist> decks { get; set; }
        public string Deckname { get; } 
        public string Filename { get; }
        public Deck()
        {
            decks = new List<Flashcardlist>();
        }

        public Deck(string deckname, string filename) : this()
        {
            Deckname = deckname;
            Filename = filename;
        }

        private Deck(Flashcardlist deck) : this() 
        {
            // Hier wird eine Liste von einer Flashcardliste gespeichert
            decks = new List<Flashcardlist> { deck };
        }

        

        
        public void Speichern(string filename)
        {
            // Hier sollte das Deck gespeichert werden.
            using (StreamWriter sw = new StreamWriter(filename))
            {
                List<Flashcard> flashcards = Flashcardlist.Laden("file.txt");

                sw.WriteLine(Filename);
                sw.WriteLine(Deckname);

                foreach (Flashcard card in flashcards)
                {
                    sw.WriteLine(card.Serialize());
                }
            }
        }
    }
}
