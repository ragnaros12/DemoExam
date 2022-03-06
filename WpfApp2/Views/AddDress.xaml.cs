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

namespace WpfApp2.Views
{
	/// <summary>
	/// Логика взаимодействия для AddDress.xaml
	/// </summary>
	public partial class AddDress : Window
	{
		public AddDress()
		{
			InitializeComponent();
		}

		private void Add_Click(object sender, RoutedEventArgs e)
		{
			DB.db.dresses.Add(new(Material.Text, Convert.ToInt32(Size.Text), Convert.ToDouble(price.Text)));
			DB.db.SaveChanges();
			Close();

		}
	}
}
