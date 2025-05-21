using System;
using System.Collections.Generic;
using System.Linq;
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
        }

        public Edit_flashcard_solution(Flashcard flash) : this()
        {
            // Prozess falls die Vorderseite fertig bearbeitet wurde.
            InitializeComponent();
            string flash_f = flash.ToString(); // flash_f ... für flashcard front (Vorderseite)
            Flashcard _flash = new Flashcard(flash_f);
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            // Erklärt sich von selber, aber beendet die Bearbeitung.
            Vokabel_list_window window = new Vokabel_list_window();
            this.Close();
            window.ShowDialog();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            // Beendet die Bearbeitung durch einen Input.
            
            string back_flashcard = input_backcard.Text; 
            Flashcard card = new Flashcard(_flash.Showfront(), back_flashcard); // das _flash
                                                                     // sollte die Eingabe von
            Flashcardlist cards = new Flashcardlist(card);           // der Vorderseite sein!

             // cards.Addcard(card); // Problem: Hier wird nichts eingefügt bzw. es ist invalide! // gelöst
            cards.Hinzufügen("file.txt"); // Problem (21.05.2025) : ;;Inhalt anstatt   Inhalt;Inhalt;
            Vokabel_list_window window = new Vokabel_list_window();

            this.Close();
            window.ShowDialog();
        }
    }
}