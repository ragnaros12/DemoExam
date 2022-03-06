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
	/// Логика взаимодействия для AdminCartList.xaml
	/// </summary>
	public partial class AdminCartList : Window
	{
		User user;
		public AdminCartList(User user)
		{
			InitializeComponent();
			this.user = user;
			Update();
		}

		public void Update()
		{
			ListDress.ItemsSource = user.dresses.ToList();
		}

		private void MenuItem_Click(object sender, RoutedEventArgs e)
		{
			if(ListDress.SelectedIndex != -1)
			{
				Dress dress = (Dress)ListDress.SelectedValue;
				user.dresses.Remove(dress);
				DB.db.SaveChanges();
				Update();
			}
			else
			{
				MessageBox.Show("выберите одежду");
			}
		}

		private void MenuItem_Click_1(object sender, RoutedEventArgs e)
		{
			AddDressByUser addDressByUser = new(user);
			addDressByUser.ShowDialog();
			Update();
		}
	}
}
