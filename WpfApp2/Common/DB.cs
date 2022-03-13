using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Models;

namespace WpfApp2.Common
{
	public class DB : DbContext
	{
		public DbSet<Dress> dresses { get; set; }
		public DbSet<User> users { get; set; }

		private static DB? _DB;
		public static DB? db 
		{
			get
			{
				if(_DB == null)
				{
					_DB = new DB();
				}
				return _DB;
			}
		}
		private DB() : base()
		{
			Database.EnsureDeleted();
			Database.EnsureCreated();
			if (users.Count() == 0)
			{
				users.Add(new("11", "1") { TypeUser = TypeUser.ADMIN});
				dresses.Add(new("metal", 300, 1));
				SaveChanges();
			}
			SaveChanges();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder contextOptions)
		{
			contextOptions.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=dress6;Trusted_Connection=True;");
		}
	}
}
