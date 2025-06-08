using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Serilog;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Vokabeltrainer
{
    /// <summary>  
    /// Interaction logic for Play_Window.xaml  
    /// </summary>  
    public partial class Play_Window : Window
    {
        public string Answer = null;
        private string Solution = null;

        public Deck Deck = null;
        private int cardIndex = 0;
        public Play_Window(Deck deck)
        {
            InitializeComponent();
            Log.Information("Play was started ...");

            Deck = deck;
            ShowCardText();

            //foreach (Flashcard card in deck.Flashcards)
            //{

            //    string answer = FrontCard_Text.Text;
            //    Answer = answer;
            //}
        }

        private void ShowCardText()
        {
            Flashcard card = Deck.Flashcards[cardIndex];
            // TODO: Kartentext anzeigen
            FrontCard_Text.Text = card.FrontText;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Vokabel_list_window vok = new Vokabel_list_window();
            this.Close();
            vok.ShowDialog();
        }


        private void SubmitBtn_Click_1(object sender, RoutedEventArgs e)
        {
            Flashcard card = Deck.Flashcards[cardIndex];

            // TODO Eingabe holden
            string answer = BackCard_Text.Text;

            // Prüfen ob richtig
            if (answer == card.BackText)
            {
                // richtig
                MessageBox.Show("Richtig");
            }
            else
            {
                MessageBox.Show("Falsch");
            }

            // TODO Index erhöhen und prüfen ob es die letzte Karte war
            if (cardIndex >= Deck.Flashcards.Count - 1)
            {
                Vokabel_list_window vok = new Vokabel_list_window(Deck);
                this.Close();
                vok.ShowDialog();
            }
            else
            {
                cardIndex++;
                ShowCardText();
            }

            // TODO Falls nicht letzte Karte, neuen Text anzeigen
        }
    }
}
