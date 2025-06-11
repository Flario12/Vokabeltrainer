using System.IO;
using Serilog;

namespace Vokabeltrainer
{
    public class Deck
    {
        public string Name { get; set; } 
        public List<Flashcard> Flashcards { get; set; } // Liste von Flashcards für das Deck

        public Deck()
        {
            Flashcards = new List<Flashcard>(); // flashcard wird zur Liste hergegeben.
        }

        // Konstruktor, der eine einzelne Flashcard übergeben bekommt
        public Deck(Flashcard flashcard)
        {
            Flashcards = new List<Flashcard> { flashcard }; // flashcard wird zur Liste hergegeben.
        }

        public List<Flashcard> Addcard(Flashcard flashcard)
        {
            Flashcards.Add(flashcard);
            return Flashcards; // noch ändern, willkürliche Eingabe
        }

        public void Removecard(Flashcard flashcard)
        {
            Flashcards.Remove(flashcard); // Dies löscht eine Karte
        }

        public int Count()
        {
            // Aufzählung der Inhalt eines Decks
            return Flashcards.Count;
        }

        public static Deck Laden(string deckFilePath) // TODO: name als dateiname nehmen
        {
            Deck deck = new Deck();
            deck.Name = Path.GetFileNameWithoutExtension(deckFilePath); // dies findet den Pfad einer
                                                                        // Datei bzw. den Namen der File
                                                                        
            using (StreamReader sr = new StreamReader(deckFilePath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine(); // liest jede Zeile durch.
                    if (!string.IsNullOrEmpty(line)) // prüft ob es nicht leer oder nicht null ist.
                    {
                        Flashcard card = Flashcard.Deserialize(line); 
                        if (card != null) // Das überprüft ob die Karte existiert.
                        {
                            deck.Flashcards.Add(card);
                        }
                    }
                }
            }
            return deck;
        }

        public void Löschen(string folder)
        {
            string filePath = Path.Combine(folder, Name + ".txt");
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public void Speichern(string folder)
        {
            string filePath = Path.Combine(folder, Name + ".txt");
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach (Flashcard card in Flashcards) // Durchläuft alle Werte aus der Liste
                {
                    sw.WriteLine(card.Serialize());
                }
            }
        }

        public void Hinzufügen(string folder)
        {
            // Appenden eines Inhaltes in eine File
            string filePath = Path.Combine(folder, Name + ".txt");
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                foreach (Flashcard card in Flashcards) // Durchläuft alle Werte aus der Liste
                {
                    sw.WriteLine(card.Serialize());
                }
            }
        }

        public override string ToString()
        {
            // Das durchläuft, um die einzelnen Werte
            // der Liste darzustellen, eine Schleife.
            string result = $"";
            foreach (Flashcard card in Flashcards)
            {
                result += card.ToString();
            }
            return result;
        }
    }
}