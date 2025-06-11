using System;
using System.Collections.Generic;
using System.Linq;
using Serilog;
using System.Text;
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
    /// Interaction logic for Edit_Flashcard.xaml
    /// </summary>
    public partial class Edit_Flashcard : Window
    {
        // TODO: Bug fixen bei der Eingabe
        //private string deckFolder = "./decks";

        public Flashcard Flashcard { get; set; } = new Flashcard();

        public Edit_Flashcard()
        {
            Log.Information("The Edit Window got opened ... ");
            InitializeComponent();
        }

        public Edit_Flashcard(Flashcard flashcard)
        {
            Log.Information($"The Edit Window got opened with a " +
                $"transmitted flashcard {flashcard} ... ");
            InitializeComponent();

            Flashcard = flashcard;

            // TODO: textboxen befüllen
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Log.Information("The Edit Window got closed");
            this.Close();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Bug-fixen per Nachfrage beim DIL
            string front_flashcard = input_frontcard.Text;
            string back_flashcard = input_backcard.Text;
            try
            {
                // Setzung des Inhaltes von der Vorderseite der Karteikarte
                if (IsNumber(front_flashcard) || IsNumber(back_flashcard))
                {
                    Log.Error($"Front Input was a Number ...  ");
                    throw new Exception("Numbers are not permitted!");
                }
                
                if (!string.IsNullOrEmpty(front_flashcard) && !string.IsNullOrEmpty(back_flashcard))
                {

                    Flashcard.FrontText = front_flashcard;
                    Flashcard.BackText = back_flashcard;
                    
                    Log.Information($"Card was submitted ... {front_flashcard} - {back_flashcard}");

                    DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Texte müssen befüllt sein");
                }
            }
            catch
            {
                MessageBox.Show("please submit an valid input!");
                Log.Error($"Input was invalid ... {input_frontcard} ");
            }
        }

        private bool IsNumber(string text)
        {
            foreach (char c in text)
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
