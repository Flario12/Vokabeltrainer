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
        private static string filename;
        public Play_Window(string filename)
        {
            InitializeComponent();
            Log.Information("Play was started ...");

            List<Flashcardlist> decks = Deck.LadenAlleDecks(filename);

            foreach (Flashcardlist deck in decks)
            {
                FrontCard_Label.Content = deck.ToString(); // Anzeige im UI-Element
            }
        }
    }
}
