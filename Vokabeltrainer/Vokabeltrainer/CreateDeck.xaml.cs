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

        public CreateDeck()
        {
            InitializeComponent();
            

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            DeckManager deck = new DeckManager();

            if (deck != null)
            {
                deck.Speichern();
                

                MainWindow window = new MainWindow();
                this.Close();
                window.ShowDialog();
            }
            else
            {
                Log.Error($"deck is Null!: {deck}");
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
