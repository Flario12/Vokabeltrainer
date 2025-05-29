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
        public Edit_Flashcard()
        {
            InitializeComponent();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Vokabel_list_window window = new Vokabel_list_window();
            this.Close();
            window.ShowDialog();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Setzung des Inhaltes von der Vorderseite der Karteikarte
                string front_flashcard = input_frontcard.Text;
                if (!string.IsNullOrEmpty(front_flashcard))
                {
                    foreach (char c in front_flashcard)
                    {
                        if (char.IsDigit(c))
                        {
                            throw new Exception("Numbers are not permitted!");
                            Log.Error($"Front Input was a Number ... {c} ");
                        }
                        else
                        {
                            continue;
                        }
                    }

                    Flashcard card = new Flashcard(front_flashcard); // Einfügung der Vorderseite in die Klasse
                                                                     // Aufrufung der Listenklasse und Einfügung der Karte
                                                                     // Flashcardlist flashlist = new Flashcardlist(card);

                    Edit_flashcard_solution backside_flashcard = new Edit_flashcard_solution(card); // Switch zur Rückseite
                    Flashcardlist cards = new Flashcardlist(card);           // der Vorderseite sein!

                    // cards.Addcard(card); // Problem: Hier wird nichts eingefügt bzw. es ist invalide! // gelöst, aber doppelter Eintrag
                    cards.Speichern("file.txt"); // Problem (21.05.2025) : ;;Inhalt anstatt   Inhalt;Inhalt;

                    Log.Information($"frontside was submitted ... {front_flashcard}");

                    this.Close();
                    backside_flashcard.ShowDialog();

                }
            }
            catch
            {
                MessageBox.Show("please submit an valid input!");
                Log.Error($"Input was invalid ... {input_frontcard} ");
            }
        }
    }
}
