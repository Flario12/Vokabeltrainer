using System.Diagnostics.Eventing.Reader;
using System.Text;
using Serilog;
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
            
            // Der Inhalt der .txt Datei wird herausgelesen
            // und in die ListView eingefügt
            InitializeComponent();

            // Logger konfigurieren
            // MinimumLevel gibt an ab welchem Log-Level
            // die Log Messages auch wirklcih im Output landen
            // MinimumLevel Warning:
            // NUR Warnign, Fatal, Error werden gelogt
            // Reihenfolge der LogLevels
            //  0 ... Verbose
            //  1 ... Debug
            //  2 ... Information
            //  3 ... Warning
            //  4 ... Error
            //  5 ... Fatal

            Log.Logger = new LoggerConfiguration(). // Fluid API:  Punkt punkt punkt Konf.
                MinimumLevel.Verbose().
                WriteTo.Console().
                WriteTo.File("Vokabeltrainer.log", rollingInterval: RollingInterval.Minute). // es geht auch Month
                CreateLogger();


            Log.Logger.Information("MainWindow started ...");


            List<Flashcard> deck = Deck.Laden("beispiel.txt");

            foreach (Flashcard card in deck)
            {
                Flashcard_list.Items.Add(card); // Anzeige im UI-Element
            }
        }

        public MainWindow(Flashcardlist flashcards)
        {
            InitializeComponent();
            this.flashcards = flashcards;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Log.Information("Application closed ...");
        }

        private void SelectBtn_Click(object sender, RoutedEventArgs e)
        {
            // Wählt eine Karteikarte aus

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            // Bearbeitet eine Karteikarte
            Vokabel_list_window vok = new Vokabel_list_window();
            this.Close();
            vok.ShowDialog();

            Log.Information("EditWindow started ...");
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            // Löscht alle karteikarten im Moment (noch ändern 21.05.2025)
            List<Flashcard> flashcard_ff = Flashcardlist.Laden("file.txt");

            foreach (Flashcard card in flashcard_ff)
            {
                Flashcard_list.Items.Remove(card);
            }
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            CreateDeck deck = new CreateDeck();

            Log.Information("CreateWindow started ...");

            this.Close();
            deck.ShowDialog();
        }
    }
}