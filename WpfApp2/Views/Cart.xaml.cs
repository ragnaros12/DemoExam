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
	/// Логика взаимодействия для Cart.xaml
	/// </summary>
	public partial class Cart : Page
	{
		public Cart()
		{
			InitializeComponent();
			
		}
		public void Update()
		{
			ListDress.ItemsSource = DB.db.users.Where(u => u.Id == All.user.Id).First().dresses.ToList();
		}
	}
}
