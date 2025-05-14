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
        public MainWindow()
        {
            InitializeComponent();


        }


        // Hier ist der letzte Stand
        public MainWindow(Flashcardlist flashcard)
        {
            InitializeComponent();

            
            Flashcard_list.Items.Add(flashcard);
        }
        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SelectBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            
            Edit_Flashcard newflashcard = new Edit_Flashcard();
            this.Close();
            newflashcard.ShowDialog();
        }
    }
}