using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Models
{
	public class User
	{
		public int Id { get; set; }

		public TypeUser TypeUser { get; set; }
		public string login { get; set; }
		public string password { get; set; }
		public List<Dress> dresses { get; set; }

		public User(string login, string password)
		{
			TypeUser = TypeUser.STANDART;
			this.login = login;
			this.password = password;
			dresses = new List<Dress>();
		}
	}
	public enum TypeUser
	{
		[Description("Админ")]// это просто проще запоменить
		ADMIN,
		[Description("Стандарт")]
		STANDART
	}
}
