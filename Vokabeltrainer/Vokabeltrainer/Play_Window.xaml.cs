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
using System.IO;

namespace Vokabeltrainer
{
    /// <summary>  
    /// Interaction logic for Play_Window.xaml  
    /// </summary>  
    public partial class Play_Window : Window
    {
        public string Answer = null;
        private string Solution = null;

        private int points = 0;

        public Deck Deck = null;
        private int cardIndex = 0;
        private string folder = "./points";
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
            Vokabel_list_window vok = new Vokabel_list_window(Deck);
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
                points += 1;
                PointsLabel.Content = $"Points: {points}";
            }
            else
            {
                MessageBox.Show("Falsch");
            }

            // TODO Index erhöhen und prüfen ob es die letzte Karte war
            if (cardIndex >= Deck.Flashcards.Count - 1)
            {
                Vokabel_list_window vok = new Vokabel_list_window(Deck);
                Speichern(folder);
                this.Close();
                vok.ShowDialog();
            }
            else
            {
                cardIndex++;
                ShowCardText();
            }

            void Speichern(string folder)
            {
                string filePath = System.IO.Path.Combine(folder + ".txt");
                using (StreamWriter sw = new StreamWriter(filePath, true))
                {
                    sw.WriteLine(points.ToString());
                }
            }
        // TODO Falls nicht letzte Karte, neuen Text anzeigen
    }
    }
}
