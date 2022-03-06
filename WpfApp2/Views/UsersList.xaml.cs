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
	/// Логика взаимодействия для UsersList.xaml
	/// </summary>
	public partial class UsersList : Page
	{
		public UsersList()
		{
			InitializeComponent();
		}

		public void update()
		{
			usersList.ItemsSource = DB.db.users.Include(u => u.dresses).ToList();
		}

		private void MenuItem_Click(object sender, RoutedEventArgs e)
		{
			if(usersList.SelectedIndex != -1)
			{
				AdminCartList cartList = new AdminCartList(DB.db.users.Include(u => u.dresses).Where(u => u.Id == ((User)usersList.SelectedValue).Id).First());
				cartList.ShowDialog();
			}
			else
			{
				MessageBox.Show("не выбран пользователь");
			}
		}
	}
}
