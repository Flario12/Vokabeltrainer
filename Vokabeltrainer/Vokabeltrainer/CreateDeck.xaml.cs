using System;
using System.Collections.Generic;
using System.Linq;
using Serilog;
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
    /// Interaction logic for CreateDeck.xaml
    /// </summary>
    public partial class CreateDeck : Window
    {
        public Deck CreatedDeck { get; private set; } // Dies dient dazu um ein
                                                      // Deck zu erstellen und zu speichern.

        // public Deck Deck { get; set; } = null;

        public CreateDeck()
        {
            InitializeComponent();
            Log.Information("CreateWindow was opened ...");

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            string deckName = DeckName.Text;
            Log.Information($"Name was transmitted: {deckName} ...");

            if (!string.IsNullOrWhiteSpace(deckName))
            {
                if (IsNumber(deckName))
                {
                    MessageBox.Show("Bitte geben Sie keine Zahlen ein!");
                    Log.Error("Input was a Number ... (Deck)");
                }
                else
                {
                    CreatedDeck = new Deck(); // neues Deck wird initialisiert
                    CreatedDeck.Name = deckName;
                    this.DialogResult = true; // Das Mainwindow sollte immer noch aktiv sein
                    Log.Information("Create Window was closed ...");
                    this.Close();
                }
            }
            
            else
            {
                MessageBox.Show("Bitte gib einen gültigen Namen ein.");
                Log.Error("Input was Empty or Null ...");
            }
        }


        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            this.Close();
            window.ShowDialog();
            Log.Information("DeckWindow closed");
        }

        private bool IsNumber(string text)
        {
            foreach (char c in text)
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
