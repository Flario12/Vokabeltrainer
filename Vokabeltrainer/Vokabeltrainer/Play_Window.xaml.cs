using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Serilog;
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
    /// Interaction logic for Play_Window.xaml
    /// </summary>
    public partial class Play_Window : Window
    {
        public Play_Window(Deck deck)
        {
            InitializeComponent();
            Log.Information("Play was started ...");

            foreach (Flashcard card in deck.Flashcards)
            {
                
            }
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Vokabel_list_window vok = new Vokabel_list_window();
            this.Close();
            vok.ShowDialog();
        }
    }
}
