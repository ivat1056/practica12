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
        Pagin pc = new Pagin();
        List<Hotel> listHotel = Base.ep.Hotel.ToList();
        public HotelPage()
        {
            InitializeComponent();
            dgHotels.ItemsSource = Base.ep.Hotel.ToList();
            pc.Countlist = listHotel.Count;
            pc.CountPage = 10;
            dgHotels.ItemsSource = listHotel.Skip(0).Take(pc.CountPage).ToList();  
            DataContext = pc;

        }
        private void txtPageCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                pc.CountPage = Convert.ToInt32(txtPageCount.Text); // если в текстовом поле есnь значение, присваиваем его свойству объекта, которое хранит количество записей на странице
            }
            catch
            {
                pc.CountPage = 10; // если в текстовом поле значения нет, присваиваем свойству объекта, которое хранит количество записей на странице количество элементов в списке
            }
            pc.Countlist = listHotel.Count;  // присваиваем новое значение свойству, которое в объекте отвечает за общее количество записей
            dgHotels.ItemsSource = listHotel.Skip(0).Take(pc.CountPage).ToList();  // отображаем первые записи в том количестве, которое равно CountPage
            pc.CurrentPage = 1; // текущая страница - это страница 1
        }
        private void GoPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;

            switch (tb.Uid)  // определяем, куда конкретно было сделано нажатие
            {
                case "prev":
                    pc.CurrentPage--;
                    break;
                case "next":
                    pc.CurrentPage++;
                    break;
                case "firstPage":
                    pc.CurrentPage = 1;
                    break;
                case "lastPage":
                    pc.CurrentPage = pc.CountPages;
                    break;
                default:
                    pc.CurrentPage = Convert.ToInt32(tb.Text);
                    break;
            }
            dgHotels.ItemsSource = listHotel.Skip(pc.CurrentPage * pc.CountPage - pc.CountPage).Take(pc.CountPage).ToList();  // оображение записей постранично с определенным количеством на каждой странице
        }
        private void btn_Tours_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.MainFrame.Navigate(new MainPage());
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Dell_Click(object sender, RoutedEventArgs e)
        {

        }
       
    }
}
