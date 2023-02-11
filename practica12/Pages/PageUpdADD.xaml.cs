using practica12.Classs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для PageUpdADD.xaml
    /// </summary>
    public partial class PageUpdADD : Page
    {
        Hotel hotel;
        bool a;
        public PageUpdADD()
        {
            InitializeComponent();
            a = true;
            cbCountry.ItemsSource = Base.ep.Country.ToList();
            cbCountry.SelectedValuePath = "Code";
            cbCountry.DisplayMemberPath = "Name";
            cbCountry.SelectedIndex = 0;
        }

        public PageUpdADD(Hotel hotel)
        {
            InitializeComponent();
            this.hotel = hotel;
            tbName.Text = hotel.Name;
            cbCountry.ItemsSource = Base.ep.Country.ToList();
            cbCountry.SelectedValuePath = "Code";
            cbCountry.DisplayMemberPath = "Name";
            cbCountry.SelectedIndex = 0;
            tbCountOfStars.Text = Convert.ToString(hotel.CountOfStars);
            cbCountry.SelectedValue = hotel.CountryCode;
            tbDescription.Text = hotel.Description;
            a = false;
        }
       
        private void btnAddUpd_Click(object sender, RoutedEventArgs e)
        {
            if (tbName.Text != "" && tbCountOfStars.Text != "" && tbDescription.Text != "" && cbCountry.SelectedIndex != -1)
            {
                if (a == true)
                {
                    hotel = new Hotel();
                }
                hotel.Name = tbName.Text;
                Regex r1 = new Regex("^[0-5]{1}$");
                if (r1.IsMatch(tbCountOfStars.Text) == true)
                {
                    hotel.CountOfStars = Convert.ToInt32(tbCountOfStars.Text);
                    hotel.CountryCode = Convert.ToString(cbCountry.SelectedValue);
                    hotel.Description = tbDescription.Text;
                    if (a == true)
                    {
                        Base.ep.Hotel.Add(hotel);
                    }
                    Base.ep.SaveChanges();
                    if (a == true)
                    {
                        MessageBox.Show("Запись добавлена");
                    }
                    else
                    {
                        MessageBox.Show("Запись изменена");
                    }
                    FrameClass.MainFrame.Navigate(new HotelPage());
                }
                else
                {
                    MessageBox.Show("Звезды должны находится в диапазоне от 0 до 5");
                }
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены  ");
            }

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.MainFrame.Navigate(new HotelPage());
        }
        
    }
}
