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
using System.IO;

namespace Vokabeltrainer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DeckManager deckManager { get; set; } = new DeckManager();
        private string DeckName { get; set; }
        public MainWindow()
        {
            
            // Der Inhalt der .txt Datei wird herausgelesen
            // und in die ListView eingefügt
            InitializeComponent();

            //MessageBox.Show(
            //    "Hallo, Willkommen zu meinem Vokabeltrainer-Projekt",
            //    "Willkommen",
            //    MessageBoxButton.OK,
            //    MessageBoxImage.Information
            //);

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


            deckManager.Laden();

            foreach (Deck deck in deckManager.Decks)
            {
                ListViewDecks.Items.Add(deck); // Anzeige im UI-Element
            }
        }

        public MainWindow(DeckManager deckManager)
        {
            InitializeComponent();
            this.deckManager = deckManager;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Log.Information("Application closed ...");
        }


        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            // Holen der ausgewählten Flahscards
            Deck selectedDeck = ListViewDecks.SelectedItem as Deck;

            if (selectedDeck != null)
            {
                // Bearbeitet eine Karteikarte
                Vokabel_list_window vok = new Vokabel_list_window(selectedDeck);
                this.Close();
                vok.ShowDialog();

                Log.Information("EditWindow started ...");
            }
            else
            {
                MessageBox.Show("Bitte eine Liste auswählen");
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Deck selectedDeck = ListViewDecks.SelectedItem as Deck;

            MessageBoxResult result = MessageBox.Show(
                "Möchten Sie das Deck wirklich löschen?",
                "Deck löschen",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning,
                MessageBoxResult.No
            );

            if (result == MessageBoxResult.Yes)
            {
                // Löschen durchführen
                if (selectedDeck != null)
                {
                    // Bearbeitet eine Karteikarte
                    ListViewDecks.Items.Remove(selectedDeck);
                    string dateipfad = $"./decks/{selectedDeck.Name}.txt"; // Hier wird der Pfad gesucht.

                    // Hier wird geprüft ob die File existiert und diese wird dann somit gelöscht.
                    if (File.Exists(dateipfad))
                    {
                        File.Delete(dateipfad);
                        Console.WriteLine("Datei wurde gelöscht.");
                        Log.Information($"File got deleted {dateipfad} ... ");
                    }
                    else
                    {
                        Console.WriteLine("Datei existiert nicht.");
                        Log.Error($"The chosen File does not exist {dateipfad} ... ");
                    }

                    Log.Information($"The {selectedDeck.Name} Deck was removed ...");
                }
                else
                {
                    MessageBox.Show("Bitte eine Liste auswählen");
                    Log.Information("No List was chosen ...");
                }
            }            
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            CreateDeck createDeckWindow = new CreateDeck();
            
            // Hier wird ShowDialog verwendet um die Properties vom CreateDeck zu bekommen
            // Dies erkennt man am .CreatedDeck
            if (createDeckWindow.ShowDialog() == true)
            {
                Deck newDeck = createDeckWindow.CreatedDeck;

                if (newDeck != null)
                {
                    DeckName = newDeck.Name;
                    deckManager.Decks.Add(newDeck); // Deck zur Liste hinzufügen
                    ListViewDecks.Items.Add(newDeck); // UI aktualisieren
                    deckManager.Speichern(); // Speichern

                    Log.Information($"new deck got created and saved: {newDeck.Name}");
                }
            }
        }
    }
}