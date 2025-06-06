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
        
        public Deck CurrentDeck { get; set; }
        
        public DeckManager()
        {
            Decks = new List<Deck>(); // hier wird die Flashcardlist ins deck eingefügt
        }

        public DeckManager(string deckFolder) : this()
        {
            this.deckFolder = deckFolder;
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

        //public static List<Deck> LadenAlleDecks()
        //{
        //    // Hier wird der Inhalt eines Decks geladen
        //    List<Deck> decks = new List<Deck>(); // hier wird ein deck mit dem Inhalt einer
        //                                                           // Flashcardliste initiliasiert,
        //                                                           // weil es sich hierbei um eine
        //                                                           // Liste von Flashcardlisten handelt

        //    string[] deckFilenames = Directory.GetFiles("./decks", "*.txt");

        //    Log.Information("Loading decks from ./decks folder ...");
        //    foreach (string deckFilename in deckFilenames)
        //    {
        //        // TODO: Laden des Decks aus dem File
        //        Log.Information(deckFilename);

        //        Deck.Laden(deckFilename);
        //    }

        //    Deck? currentDeck = null; // hier wird geprüft ob das aktuelle Deck null ist
        //    foreach (string line in File.ReadLines(filename))
        //    { // hier geht man mit einer foreach-loop jeden Inhalt einer File durch (man liest ihn heraus)
        //        if (line.Trim() == "---") // Das dient als Trenner zwischen verschiedenen Listen
        //            // Frage1|Antwort1 ... Frage1;Antwort1
        //        {
        //            if (currentDeck != null) 
        //                decks.Add(currentDeck); // falls es existiert
        //            currentDeck = null;
        //        }
        //        else if (!string.IsNullOrWhiteSpace(line))
        //        { // Hier wird nochmals für das Deck speziell deserialisiert,
        //          // da man dadurch leichter auf die Karten zugreifen kann
        //            string[] parts = line.Split('|');
        //            Flashcard card = parts.Length == 2
        //                ? new Flashcard(parts[0], parts[1])
        //                : new Flashcard(parts[0]);
        //            if (currentDeck == null)
        //                currentDeck = new Deck(card);
        //            else
        //                currentDeck.Addcard(card);
        //        }
        //    }
        //    if (currentDeck != null)
        //        decks.Add(currentDeck);
        //    return decks;
        //}
    }
}
