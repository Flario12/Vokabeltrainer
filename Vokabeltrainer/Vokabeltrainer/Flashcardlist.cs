using System.IO;

namespace Vokabeltrainer
{
    public class Flashcardlist
    {
        private string name { get; set; }
        private List<Flashcard> flashcards { get; set; }
        private Flashcard flashcard = new Flashcard();

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

        public static void Laden(string data)
        {
            using (StreamReader sr = new StreamReader(data))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                    {
                        Flashcard.Deserialize(line);
                    }
                }
            }
        }

        public void Speichern(string data)
        {
            using (StreamWriter sw = new StreamWriter(data))
            {
                sw.WriteLine(flashcard.Serialize());
            }
        }
    }
}
