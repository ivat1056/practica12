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
       //List<Tour> listFilter = Base.ep.Tour.ToList();
        public MainPage()
        {
            InitializeComponent();
            lvListTour.ItemsSource = Base.ep.Tour.ToList();
            //List<Type> type = Base.ep.Type.ToList();
            //ComboBox1.Items.Add("Все типы");
            //for (int i = 0; i < type.Count; i++)
            //{
            //    ComboBox1.Items.Add(type[i].Name);
            //}
            //ComboBox1.SelectedIndex = 0;
            
        }

        private void cbActual_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void btn_hotel_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.MainFrame.Navigate(new HotelPage());
        }
    }
}
