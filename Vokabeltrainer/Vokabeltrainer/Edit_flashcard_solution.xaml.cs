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
    /// Interaction logic for Edit_flashcard_solution.xaml  
    /// </summary>  
    public partial class Edit_flashcard_solution : Window
    {
        Flashcard _flash = new Flashcard(); // Initialisieren einer Flashcard, welche
                                            // übertragen wird. (21.05.2025)
        public Edit_flashcard_solution()
        {
            // Default Prozess
            InitializeComponent();

            Log.Information("EditFlashcardWindow started ...");
        }

        public Edit_flashcard_solution(Flashcard flash) : this()
        {
            // Prozess falls die Vorderseite fertig bearbeitet wurde.
            InitializeComponent();
            string flash_f = flash.ToString(); // flash_f ... für flashcard front (Vorderseite)
            Flashcard _flash = new Flashcard(flash_f);

            Log.Information($"Flashcard was transmitted {_flash} ...");
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            // Erklärt sich von selber, aber beendet die Bearbeitung.
            Vokabel_list_window window = new Vokabel_list_window();

            Log.Information("Edit Solution Window was closed ... ");

            this.Close();
            window.ShowDialog();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            // Beendet die Bearbeitung durch einen Input.
            try
            {
                string back_flashcard = input_backcard.Text;
                if (!string.IsNullOrEmpty(back_flashcard))
                {
                    foreach (char c in back_flashcard)
                    {
                        if (char.IsDigit(c))
                        {
                            Log.Error($"Back Input was a Number ... {c} ");
                            throw new Exception("Numbers are not permitted!");
                        }
                    }

                    Flashcard card = new Flashcard(_flash.Showfront(), back_flashcard); // das _flash
                                                                                        // sollte die Eingabe von
                    Flashcardlist cards = new Flashcardlist(card);           // der Vorderseite sein!

                    // cards.Addcard(card); // Problem: Hier wird nichts eingefügt bzw. es ist invalide! // gelöst
                    cards.Hinzufügen("file.txt"); // Problem (21.05.2025) : ;;Inhalt anstatt   Inhalt;Inhalt;
                    Vokabel_list_window window = new Vokabel_list_window();


                    Log.Information($"Flashcard was created {cards} ...");

                    this.Close();
                    window.ShowDialog();
                }
                else
                {

                    Log.Error($"Back input was invalid ... {back_flashcard}");
                    throw new Exception();
                }
                              
            }
            catch
            {
                MessageBox.Show("please submit an valid input!");
            }

        }
    }
}