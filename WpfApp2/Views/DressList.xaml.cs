using Microsoft.EntityFrameworkCore;
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
using WpfApp2.Common;
using WpfApp2.Models;

namespace WpfApp2.Views
{
	/// <summary>
	/// Логика взаимодействия для DressList.xaml
	/// </summary>
	public partial class DressList : Page
	{
		public DressList()
		{
			InitializeComponent();
		}

		public void update()
		{
			ListDress.ItemsSource = DB.db.dresses.ToList();
			if(All.user.TypeUser == TypeUser.STANDART)
			{
				AddItem.Visibility = Visibility.Hidden;
				Users.Visibility = Visibility.Hidden;
				ListDress.IsReadOnly = true;
			}
		}

		private void ListButton_Click(object sender, RoutedEventArgs e)
		{
			update();
		}

		private void Cart_Click(object sender, RoutedEventArgs e)
		{
			if(ListDress.SelectedIndex != -1)
			{
				DB.db.users.Where(u => u.Id == All.user.Id).Include(u => u.dresses).First().dresses.Add((Dress)ListDress.SelectedValue);
				DB.db.SaveChanges();
			}
			else
			{
				MessageBox.Show("не выбран элемент");
			}
		}

		private void ToCart_Click(object sender, RoutedEventArgs e)
		{
			All.toCart();
		}

		private void AddItem_Click(object sender, RoutedEventArgs e)
		{
			AddDress addDress = new AddDress();
			addDress.ShowDialog();
			update();
		}

		private void ListDress_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
		{
			DB.db.SaveChanges();
		}

		private void Users_Click(object sender, RoutedEventArgs e)
		{
			All.toUsersList();
		}
		bool id = false, size = false;
		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			List<Dress> dresses = (List<Dress>)ListDress.ItemsSource;
			if (id)
				ListDress.ItemsSource = dresses.OrderBy(u => u.Id).ToList();
			else
				ListDress.ItemsSource = dresses.OrderBy(u => u.Id).Reverse().ToList();
			id = !id;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			List<Dress> dresses = (List<Dress>)ListDress.ItemsSource;
			if (size)
				ListDress.ItemsSource = dresses.OrderBy(u => u.size).ToList();
			else
				ListDress.ItemsSource = dresses.OrderBy(u => u.size).Reverse().ToList();
			size = !size;
		}
	}
}
