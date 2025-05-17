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
            MainWindow window = new MainWindow();
            this.Close();
            window.ShowDialog();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            // Setzung des Inhaltes von der Vorderseite der Karteikarte
            string front_flashcard = input_frontcard.Text;
            Flashcard card = new Flashcard(front_flashcard); // Einfügung der Vorderseite in die Klasse
            // Aufrufung der Listenklasse und Einfügung der Karte
             // Flashcardlist flashlist = new Flashcardlist(card);

            Edit_flashcard_solution backside_flashcard = new Edit_flashcard_solution(card); // Switch zur Rückseite

            this.Close();
            backside_flashcard.ShowDialog();
        }
    }
}
