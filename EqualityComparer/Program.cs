using System;
using System.Collections.Generic;
using System.Linq;

namespace EqualityComparer
{
	static class Program
	{
		static void Main(string[] args)
		{
			List<User> user = new List<User>
			{
				new User {FirstName = "seba", LastName = "aa"}, 
				new User {FirstName = "seba", LastName = "aa"}, 
				new User {FirstName = "seba", LastName = "1aa1"},
				new User(),
				new User()
			};
			foreach (var usr in user)
			{
				Console.WriteLine(usr.Id + " " + usr.FirstName + " " + usr.LastName);
			}

			var coll = user.Distinct(new MyComparer<User>()).ToList();
			foreach (var usr in coll)
			{
				Console.WriteLine(usr.Id + " " + usr.FirstName + " " + usr.LastName);
			}
			//var ee = coll.OrderBy(a => a.FirstName).ThenBy(a => a.LastName).ThenByDescending(a => a.Id).ToList();
			//var ww = user.GroupBy(cust => cust.Id).Select(grp => grp.First());
			//var t = coll.ToList();

			List<Employee> emp = new List<Employee>
			{
				new Employee {FirstName = "aa", LastName = "bb"}, 
				new Employee {FirstName = "aa", LastName = "bb"}, 
				new Employee {FirstName = "bb", LastName = "cc"}
			};
			foreach (var usr in emp)
			{
				Console.WriteLine(usr.Id + " " + usr.FirstName + " " + usr.LastName);
			}
			Console.WriteLine(Environment.NewLine);
			IEnumerable<Employee> coll1 = emp.Distinct(new Employee()).ToList();
			foreach (var emp1 in coll1)
			{
				Console.WriteLine(emp1.Id + " " + emp1.FirstName + " " + emp1.LastName);
			}
			Console.ReadLine();
		}
	}
}
