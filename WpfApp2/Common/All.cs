using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfApp2.Models;
using WpfApp2.Views;

namespace WpfApp2.Common
{
	public static class All
	{
		public static TextBlock Name { get; set; }
		public static DressList dressList = new DressList();
		public static UsersList usersList = new UsersList();
		public static Login login = new Login();
		public static Cart cart = new Cart();
		public static Register register = new Register();
		public static Frame MainFrame { get; set; }
		public static User user { get; set; }

		public static void toCart()
		{
			MainFrame.Navigate(cart);
			Name.Text = cart.Title;
			cart.Update();
		}

		public static void toUsersList()
		{
			MainFrame.Navigate(usersList);
			usersList.update();
			Name.Text = usersList.Title;
		}

		public static void EndLogin()
		{
			MainFrame.Navigate(dressList);
			dressList.update();
			Name.Text = dressList.Title;
		}
		public static void StartLogin()
		{
			MainFrame.Navigate(login);
			Name.Text = login.Title;
		}
		public static void StartReg()
		{
			MainFrame.Navigate(register);
			Name.Text = register.Title;
		}

		public static void EndReg()
		{
			StartLogin();
		}
	}
}
