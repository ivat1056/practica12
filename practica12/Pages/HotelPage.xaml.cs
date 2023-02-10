using practica12.Classs;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace practica12.Pages
{
    /// <summary>
    /// Логика взаимодействия для HotelPage.xaml
    /// </summary>
    public partial class HotelPage : Page
    {
       
        List<Hotel> listHotel = Base.ep.Hotel.ToList();
        public HotelPage()
        {
            InitializeComponent();
            dgHotels.ItemsSource = Base.ep.Hotel.ToList();
            
            
        }
    }
}
