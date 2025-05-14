using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vokabeltrainer
{
    internal class Flashcard_Manager
    {
        private List<Flashcardlist> decks {  get; set; }
        private Flashcardlist currentDeck { get; set; }
        public Flashcard_Manager (Flashcardlist deck)
        {
            decks = new List<Flashcardlist>() { deck };
        }

        
    }
}
