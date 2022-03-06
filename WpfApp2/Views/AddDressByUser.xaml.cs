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
using WpfApp2.Common;
using WpfApp2.Models;

namespace WpfApp2.Views
{
	/// <summary>
	/// Логика взаимодействия для AddDressByUser.xaml
	/// </summary>
	public partial class AddDressByUser : Window
	{
		User user;
		public AddDressByUser(User user)
		{
			InitializeComponent();
			dress.ItemsSource = DB.db.dresses.ToList();
			this.user = user;
		}


		private void Add_Click_1(object sender, RoutedEventArgs e)
		{
			if (dress.SelectedIndex != -1)
			{
				user.dresses.Add((Dress)dress.SelectedValue);
				DB.db.SaveChanges();
				Close();
			}
			else
			{
				MessageBox.Show("выберите одежду");
			}
		}
	}
}
