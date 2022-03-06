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
	/// Логика взаимодействия для Login.xaml
	/// </summary>
	public partial class Login : Page
	{
		public Login()
		{
			InitializeComponent();
		}


		private void register_Click(object sender, RoutedEventArgs e)
		{
			All.StartReg();
		}

		private void login_Click(object sender, RoutedEventArgs e)
		{
			string login = LoginText.Text;
			string password = Password.Text;
			if (String.IsNullOrWhiteSpace(login) || String.IsNullOrWhiteSpace(password))
			{
				MessageBox.Show("данные введены неправильно");
				return;
			}
			if (DB.db.users.Where(u => u.login == login && password == u.password).Count() != 0)
			{
				User user = DB.db.users.Where(u => u.login == login && password == u.password).First();
				All.user = user;
				MessageBox.Show("Вход успешен. Добрый день " + user.login);
				All.EndLogin();
			}
			else
			{
				MessageBox.Show("такого пользователя не сущствует");
			}
		}
	}
}
