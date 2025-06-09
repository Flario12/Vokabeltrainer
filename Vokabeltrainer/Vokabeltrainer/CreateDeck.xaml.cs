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
        private string filename;

        public Deck CreatedDeck { get; private set; }

        // public Deck Deck { get; set; } = null;

        public CreateDeck()
        {
            InitializeComponent();
            

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            string deckName = DeckName.Text;

            if (!string.IsNullOrWhiteSpace(deckName))
            {
                CreatedDeck = new Deck();
                CreatedDeck.Name = deckName;
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Bitte gib einen gültigen Namen ein.");
            }
        }


        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            this.Close();
            window.ShowDialog();
            Log.Information("DeckWindow closed");
        }
    }
}
