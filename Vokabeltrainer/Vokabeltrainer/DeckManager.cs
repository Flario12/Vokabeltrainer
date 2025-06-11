using Serilog;
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
    public class DeckManager
    {
        // Initialisierung eines decks durch eine Schnittstelle
        // (+ Indezes können ausgelesen und bearbeitet werden,
        // keine Konvertierung nötig)

        private string deckFolder = "./decks";

        // Hier wird die Liste initialisiert, welches im Konstruktor somit verwendet wird.
        public List<Deck> Decks { get; set; }
        public string DeckName { get; set; }
        
        public Deck CurrentDeck { get; set; }
        
        public DeckManager()
        {
            Decks = new List<Deck>(); // hier wird die Flashcardlist ins deck eingefügt
        }

        public DeckManager(string deckName) : this()
        {
            this.DeckName = deckName;
        }

        public List<Deck> AddDeck(Deck flashcards)
        {
            Decks.Add(flashcards);
            return Decks; // noch ändern, willkürliche Eingabe
        }

        public void Speichern()
        {
            // Hier sollte das Deck gespeichert werden.
            foreach (Deck deck in Decks)
            {
                deck.Speichern(deckFolder);
            }
        }

        public void Laden()
        {
            Decks.Clear();

            string[] deckFilenames = Directory.GetFiles("./decks", "*.txt");

            Log.Information("Loading decks from ./decks folder ...");
            foreach (string deckFilename in deckFilenames)
            {
                // TODO: Laden des Decks aus dem File
                Log.Information(deckFilename);

                Deck deck = Deck.Laden(deckFilename);
                Decks.Add(deck);
            }
        }
    }
}
