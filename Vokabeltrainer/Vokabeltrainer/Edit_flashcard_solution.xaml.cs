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
        private Flashcard _flash;
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
            MainWindow window = new MainWindow();
            this.Close();
            window.ShowDialog();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            // Beendet die Bearbeitung durch einen Input.
            string front_flashcard = input_backcard.Text; 
            Flashcard card = new Flashcard(_flash, front_flashcard); // das _flash
                                                                          // sollte die Eingabe von
            Flashcardlist cards = new Flashcardlist(card);                                                              // der Vorderseite sein!

            cards.Addcard(card); // Problem: Hier wird nichts eingefügt bzw. ist es invalide!
            MainWindow window = new MainWindow(cards);
            cards.Speichern("file.txt");

            this.Close();
            window.ShowDialog();
        }
    }
}
