using practica12.Classs;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace practica12.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
       List<Tour> listFilter = Base.ep.Tour.ToList();
       List<Tour> list = Base.ep.Tour.ToList();
        public MainPage()
        {
            InitializeComponent();
            lvListTour.ItemsSource = Base.ep.Tour.ToList();
            List<Type> type = Base.ep.Type.ToList();
            ComboBox1.Items.Add("Все типы");
            for (int i = 0; i < type.Count; i++)
            {
                ComboBox1.Items.Add(type[i].Name);
            }
            ComboBox1.SelectedIndex = 0;
            Sort.SelectedIndex = 0;
        }

        private void cbActual_Checked(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void btn_hotel_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.MainFrame.Navigate(new HotelPage());
        }
        public void Filter()
        {
            
            string t = ComboBox1.SelectedValue.ToString();
            int index = ComboBox1.SelectedIndex;
            List<TypeOfTour> types = Base.ep.TypeOfTour.Where(z => z.Type.Name == t).ToList();
            if (index != 0)
            {
                listFilter = new List<Tour>();
                foreach (TypeOfTour tot in types)
                {
                    foreach (Tour tour in list)
                    {
                        if (tour.Id == tot.TourId)
                        {
                            listFilter.Add(tour);
                        }
                    }
                }
            }
            else
            {
                listFilter = Base.ep.Tour.ToList();
            }

            if (!string.IsNullOrWhiteSpace(Search.Text))
            {
                listFilter = listFilter.Where(z => z.Name.ToLower().Contains(Search.Text.ToLower())).ToList();
            }

            if (cbActual.IsChecked == true) 
            {
                listFilter = listFilter.Where(z => z.IsActual == true).ToList();
            }

            switch (Sort.SelectedIndex) 
            {
                case 1:
                    listFilter.Sort((x, y) => x.Price.CompareTo(y.Price));
                    break;
                case 2:
                    listFilter.Sort((x, y) => x.Price.CompareTo(y.Price));
                    listFilter.Reverse();
                    break;
            }

            lvListTour.ItemsSource = listFilter;
            int price = 0;
            foreach (Tour tour in listFilter) 
            {
                price += (int)tour.Price * tour.TicketCount;
            }
            tbTotalCostOfTours.Text = string.Format("Общая стоимость туров: {0:C2}", price);
            if (listFilter.Count == 0)
            {
                MessageBox.Show("нет записей");
            }
        }

        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void Sort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }
        
    }
}
