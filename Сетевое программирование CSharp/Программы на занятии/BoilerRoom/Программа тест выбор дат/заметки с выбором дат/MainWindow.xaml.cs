using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace testing_ezhednevnik2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public List<Zametka> zametki = new List<Zametka>();
        public List<Zametka> for_data = new List<Zametka>();
        public MainWindow()
        {

            InitializeComponent();

            var deserializedData = serdeser.Deserialize<List<Zametka>>();
            if (deserializedData != null)
            {
                zametki = deserializedData;
            }

            Title = "☆ diary ☆";
            Date.Text = DateTime.Now.ToString();

        }

        private void clearAllNote()
        {
            List.Items.Clear();
            for_data.Clear();
       
            foreach (Zametka item in zametki)
            {
               if (Convert.ToDateTime(Date.SelectedDate).Day == item.data.Day)
               {
                    List.Items.Add(item.name);
                    for_data.Add(item);
               }
            }
           
           serdeser.Serialize(zametki);
            
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            if (List.SelectedItems.Count != 0)
            {
                for_data[List.SelectedIndex].name = Name.Text;
                for_data[List.SelectedIndex].description = Description.Text;
                clearAllNote();
                clear();
            }
            else
            {
                MessageBox.Show("✘ where is ur note for saving???", Title="Error"); 
            }
        }

        private void create_Click(object sender, RoutedEventArgs e)
        {
      
            if (Name.Text == "")
            {
                MessageBox.Show("✎ error: choose name of your note!",Title = "Error");
            }
            else if (Description.Text == "")
            {
                MessageBox.Show("✎ error: choose description of your note!", Title = "Error");
            }
            else 
            {
                Zametka zametka = new Zametka(Name.Text, Description.Text, Convert.ToDateTime(Date.SelectedDate));
                zametki.Add(zametka);
                clearAllNote();
                clear();
            }
        }
        
        private void leftDatePicker_Click(object sender, RoutedEventArgs e)
        {
      
            if (Name.Text == "")
            {
                MessageBox.Show("✎ error: choose name of your note!",Title = "Error");
            }
            else if (Description.Text == "")
            {
                MessageBox.Show("✎ error: choose description of your note!", Title = "Error");
            }
            else 
            {
                Zametka zametka = new Zametka(Name.Text, Description.Text, Convert.ToDateTime(Date.SelectedDate));
                zametki.Add(zametka);
                clearAllNote();
                clear();
            }
        }
        
        

        private void del_Click(object sender, RoutedEventArgs e)
        {
            if (List.SelectedItems.Count == 0)
            {
                MessageBox.Show("✂ where is ur note to delete???", Title = "Error");
            }
            else
            {
                zametki.RemoveAt(zametki.IndexOf(for_data[List.SelectedIndex]));
                clearAllNote();
                clear();
            }
        }

        private void listat(object sender, SelectionChangedEventArgs e)
        {
            if (List.SelectedIndex != -1)
            {
                Name.Text = for_data[List   .SelectedIndex].name;
                Description.Text = for_data[List.SelectedIndex].description;
            } 
        }

        private void Date_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            clearAllNote();
        }

        private void clear()
        {
            Name.Text = "";
            Description.Text = "";
        }
    }
}