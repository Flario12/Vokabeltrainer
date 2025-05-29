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

        public static List<Flashcardlist> LadenAlleDecks(string filename)
        {
            // Hier wird der Inhalt eines Decks geladen
            List<Flashcardlist> decks = new List<Flashcardlist>(); // hier wird ein deck mit dem Inhalt einer
                                                                   // Flashcardliste initiliasiert,
                                                                   // weil es sich hierbei um eine
                                                                   // Liste von Flashcardlisten handelt
            Flashcardlist? currentDeck = null; // hier wird geprüft ob das aktuelle Deck null ist
            foreach (string line in File.ReadLines(filename))
            { // hier geht man mit einer foreach-loop jeden Inhalt einer File durch (man liest ihn heraus)
                if (line.Trim() == "---") // Das dient als Trenner zwischen verschieden Listen
                    // Frage1|Antwort1 ... Frage1;Antwort1
                {
                    if (currentDeck != null) 
                        decks.Add(currentDeck); // falls es existiert
                    currentDeck = null;
                }
                else if (!string.IsNullOrWhiteSpace(line))
                {
                    string[] parts = line.Split('|');
                    Flashcard card = parts.Length == 2
                        ? new Flashcard(parts[0], parts[1])
                        : new Flashcard(parts[0]);
                    if (currentDeck == null)
                        currentDeck = new Flashcardlist(card);
                    else
                        currentDeck.Addcard(card);
                }
            }
            if (currentDeck != null)
                decks.Add(currentDeck);
            return decks;
        }
    }
}
