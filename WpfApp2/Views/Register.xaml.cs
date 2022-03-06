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

namespace WpfApp2.Views
{
	/// <summary>
	/// Логика взаимодействия для Register.xaml
	/// </summary>
	public partial class Register : Page
	{
		public Register()
		{
			InitializeComponent();
		}


		private void register_Click(object sender, RoutedEventArgs e)
		{
			string login = LoginText.Text;
			string password = Password.Text;
			if (String.IsNullOrWhiteSpace(login) || String.IsNullOrWhiteSpace(password))
			{
				MessageBox.Show("данные введены неправильно");
				return;
			}
			if (DB.db.users.Where(u => u.login == login || password == u.password).Count() == 0)
			{
				DB.db.users.Add(new(login, password));
				DB.db.SaveChanges();
				All.StartLogin();
			}
			else
			{
				MessageBox.Show("такой пользовтель уже существует");
			}
		}

		private void login_Click_1(object sender, RoutedEventArgs e)
		{
			All.StartLogin();
		}
	}
}
