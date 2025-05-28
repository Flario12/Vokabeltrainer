using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

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
            decks = new List<Flashcardlist>(); // hier wird die Flashcardlist ins deck eingefügt
        }

        public Deck(string deckname, string filename) : this()
        {
            Deckname = deckname;
            Filename = filename;
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

        public static List<Flashcard> Laden(string filename)
        {
            List<Flashcard> list = new List<Flashcard>(); // Eine wird benötigt, da man ja.
                                                          // eine Liste von Werten laden möchte.
            using (StreamReader sr = new StreamReader(filename))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine(); // liest jede Zeile durch.
                    if (!string.IsNullOrEmpty(line)) // prüft ob es nicht leer oder nicht null ist.
                    {
                        Flashcard card = Flashcard.Deserialize(line);
                        if (card != null) // Das überprüft ob die Karte existiert.
                        {
                            list.Add(card);
                        }
                    }
                }
            }
            return list;
        }
    }
}
