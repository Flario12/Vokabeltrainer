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
            InitializeComponent();
        }

        public Edit_flashcard_solution(Flashcard flash) : this()
        {
            _flash = flash;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            this.Close();
            window.ShowDialog();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();

            string front_flashcard = input_frontcard.Text;
            Flashcard card = new Flashcard(_flash, input_frontcard.Text); // das _flash sollte die Eingabe von der Vorderseite sein!

            Flashcardlist cards = new Flashcardlist(card);
            cards.Addcard(card); // Problem: Hier wird nichts eingefügt bzw. ist es invalide!
            cards.Speichern("file.txt");

            this.Close();
            window.ShowDialog();
        }
    }
}
