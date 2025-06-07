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

            Deck = deck;

            UpdateListView();
        }

        private void UpdateListView()
        {
            Flashcard_list.Items.Clear();

            foreach (Flashcard card in Deck.Flashcards)
            {
                Flashcard_list.Items.Add(card);
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            // es werden die Vokabellisten geöffnet
            Vokabel_list_window vok = new Vokabel_list_window(Deck);
            this.Close();
            vok.ShowDialog();
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
            Deck.Speichern("./decks");
            MainWindow main = new MainWindow();
            this.Close();
            main.ShowDialog();
        }

        private void PlayBtn_Click(object sender, RoutedEventArgs e)
        {
            // TODO: richtiges Deck wählen
            Play_Window play = new Play_Window(Deck); // sonst new Deck()
            this.Close();
            play.ShowDialog();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Flashcard selectedCard = Flashcard_list.SelectedItem as Flashcard;

            if (selectedCard != null)
            {
                // Bearbeitet eine Karteikarte
                Flashcard_list.Items.Remove(selectedCard);

                Log.Information($"The {selectedCard} card was removed ...");
            }
            else
            {
                MessageBox.Show("please choose a card");
            }
        }
    }
}
