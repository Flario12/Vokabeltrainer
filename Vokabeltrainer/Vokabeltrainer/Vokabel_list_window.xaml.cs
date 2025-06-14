using Serilog;
using System.Windows;
using System.Windows.Controls;

namespace Vokabeltrainer
{
    /// <summary>
    /// Interaction logic for Vokabel_list_window.xaml
    /// </summary>
    public partial class Vokabel_list_window : Window
    {
        public Deck Deck { get; set; } = null;
        public Vokabel_list_window()
        {
            InitializeComponent();
        }

        public Vokabel_list_window(Deck deck)
        {
            
            // Der Inhalt der .txt File wird in die ListView eingefügt
            InitializeComponent();
            Log.Information("The List was opened");
            Deck = deck;

            UpdateListView();

            
            this.Closing += Vokabel_list_window_Closing;
            this.Closed += Vokabel_list_window_Closed;
        }

        private void Vokabel_list_window_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            Deck.Speichern($"./decks");
            Log.Information("The list was closed via X ...");
        }

        private void Vokabel_list_window_Closed(object? sender, System.EventArgs e)
        {
            this.Close();
        }

        private void UpdateListView()
        {
            Flashcard_list.Items.Clear();

            foreach (Flashcard card in Deck.Flashcards)
            {
                Flashcard_list.Items.Add(card);
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Edit_Flashcard edit = new Edit_Flashcard();
            if (edit.ShowDialog() == true)
            {
                Deck.Addcard(edit.Flashcard);
                UpdateListView();
            }
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Deck gleich strukturieren
            Deck.Speichern($"./decks");
            Log.Information("The list was closed ...");
            MainWindow main = new MainWindow();
            this.Close();
            main.ShowDialog();
        }

        private void PlayBtn_Click(object sender, RoutedEventArgs e)
        {
            // TODO: richtiges Deck wählen
            if (Flashcard_list.Items.Count > 0)
            {
                Play_Window play = new Play_Window(Deck); // sonst new Deck()
                this.Close();
                play.ShowDialog();
            }
            else
            {
                Log.Information("There are no cards to play ... ");
                MessageBox.Show("Fügen Sie noch eine Karte hinzu!");
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Flashcard selectedCard = Flashcard_list.SelectedItem as Flashcard;

            MessageBoxResult result = MessageBox.Show(
                "Möchten Sie diese Karte wirklich löschen?",
                "Karte löschen",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning,
                MessageBoxResult.No
            );

            if (result == MessageBoxResult.Yes)
            {
                // Löschen durchführen
                if (selectedCard != null)
                {
                    // Bearbeitet eine Karteikarte
                    Deck.Removecard(selectedCard); // dies löscht eine Karte damit diese
                                                   // auch nicht ans speichern weitergegeben wird.
                                                   // Diese ist somit nicht mehr in der Liste vorhanden.
                    Flashcard_list.Items.Remove(selectedCard);

                    Deck.Speichern("./decks");

                    Log.Information($"The {selectedCard} card was removed ...");
                }
                else
                {
                    MessageBox.Show("please choose a card");
                }
            }
        }
    }
}
