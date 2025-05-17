using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Vokabeltrainer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Flashcardlist flashcards;
        public MainWindow()
        {
            InitializeComponent();


        }

        // Hier ist der letzte Stand
        public MainWindow(Flashcardlist flashcard)
        {
            InitializeComponent();

            // Hier wird List<Flashcard>, da dies der datenbasierte Rückgabeparameter ist.
            List<Flashcard> flashcard_f = Flashcardlist.Laden("file.txt"); // Dadurch dass
                                                                           // eine Liste in
                                                                           // die Laden Methode
                                             // eingefügt wurde, kann man jetzt auch eine
                                             // Variable erstellen lassen.
            string flash_string = flashcard_f.ToString();
            foreach ( Flashcard card in flashcard_f)
            {
                Flashcard_list.Items.Add(flashcard_f);
            }
        }
        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SelectBtn_Click(object sender, RoutedEventArgs e)
        {
            // Wählt eine Karteikarte aus

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            // Bearbeitet eine Karteikarte
            
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            // Löscht eine Karteikarte

        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            // Erstellt eine neue Karteikarte
            Edit_Flashcard newflashcard = new Edit_Flashcard();
            this.Close();
            newflashcard.ShowDialog();
        }
    }
}