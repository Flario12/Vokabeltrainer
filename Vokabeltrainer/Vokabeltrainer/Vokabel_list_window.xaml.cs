using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for Vokabel_list_window.xaml
    /// </summary>
    public partial class Vokabel_list_window : Window
    {
        public Flashcardlist Flashcards { get; set; } = null;

        private static string filename;
        public Vokabel_list_window()
        {
            // Der Inhalt der .txt Datei wird herausgelesen
            // und in die ListView eingefügt
            InitializeComponent();

            List<Flashcard> flashcard_f = Flashcardlist.Laden("file.txt");

            //string flash_s = flashcard_f.ToString();
            //foreach (Flashcard card in flashcard_f)
            //{
            //    Flashcard_list.Items.Add(card);
            //}
        }

        public Vokabel_list_window(Flashcardlist flashcards)
        {
            InitializeComponent();

            Flashcards = flashcards;

            UpdateListView();
        }

        private void UpdateListView()
        {
            foreach (Flashcard card in Flashcards.Flashcards)
            {
                Flashcard_list.Items.Add(card);
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            // es werden die Vokabellisten geöffnet
            Vokabel_list_window vok = new Vokabel_list_window();
            this.Close();
            vok.ShowDialog();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Edit_Flashcard edit = new Edit_Flashcard();
            this.Close();
            edit.ShowDialog();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Close();
            main.ShowDialog();
        }

        private void PlayBtn_Click(object sender, RoutedEventArgs e)
        {
            Play_Window play = new Play_Window(filename);
            this.Close();
            play.ShowDialog();
        }
    }
}
