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
        public string[] Solutions = null;
        private string Solution = null;
        public Play_Window(Deck deck)
        {
            InitializeComponent();
            Log.Information("Play was started ...");

            foreach (Flashcard card in deck.Flashcards)
            {
                // Aufrufung der Inhalte 
                string[] solutions = deck.Flashcards

                // Das sollte den FrontText herausnehmen
                .Where(card => !string.IsNullOrEmpty(card.FrontText))
                .Select(card => card.FrontText)
                .ToArray();
                Solutions = solutions;

                string answer = FrontCard_Text.Text;
                Answer = answer;

                Flashcard[] solution = deck.Flashcards.ToArray();
                Solution = solution.ToString();
                
            }
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Vokabel_list_window vok = new Vokabel_list_window();
            this.Close();
            vok.ShowDialog();
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            string[] solutions = Solutions;
            string answer = Answer;
            for (int i = 0; i < solutions.Length; i++)
            {
                if (answer == solutions[i] && !string.IsNullOrEmpty(answer))
                {
                    MessageBox.Show("Richtig");
                    i++;
                }
                else
                {
                    // MessageBox.Show("Falsch");
                }
            }
        }
    }
}
