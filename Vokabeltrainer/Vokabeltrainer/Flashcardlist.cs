using System.IO;

namespace Vokabeltrainer
{
    public class Flashcardlist
    {
        private string name { get; set; }
        private List<Flashcard> flashcards { get; set; }

        // Konstruktor, der eine einzelne Flashcard übergeben bekommt
        public Flashcardlist(Flashcard flashcard)
        {
            flashcards = new List<Flashcard> { flashcard }; // flashcard wird zur Liste hergegeben.
        }

        public List<Flashcard> Addcard(Flashcard flashcard)
        {
            flashcards.Add(flashcard);
            return flashcards; // noch ändern, willkürliche Eingabe
        }

        public void Removecard(Flashcard flashcard)
        {
            flashcards.Remove(flashcard);
        }

        public int Count()
        {
            return flashcards.Count;
        }

        public static List<Flashcard> Laden(string data)
        {
            List<Flashcard> list = new List<Flashcard>(); // Eine wird benötigt, da man ja.
                                                          // eine Liste von Werten laden möchte.
            using (StreamReader sr = new StreamReader(data))
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

        public void Speichern(string data)
        {
            using (StreamWriter sw = new StreamWriter(data))
            {
                foreach (Flashcard card in flashcards) // Durchläuft alle Werte aus der Liste
                {
                    sw.WriteLine(card.Serialize());
                }
            }
        }

        public void Hinzufügen(string data)
        {
            // Appenden eines Inhaltes in eine File
            using (StreamWriter sw = new StreamWriter(data, true))
            {
                foreach (Flashcard card in flashcards) // Durchläuft alle Werte aus der Liste
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
            foreach (Flashcard card in flashcards)
            {
                result += card.ToString();
            }
            return result;
        }
    }
}