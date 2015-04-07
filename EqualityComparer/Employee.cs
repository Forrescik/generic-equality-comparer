using System.Collections.Generic;

namespace EqualityComparer
{
	class Employee : IEqualityComparer<Employee>
	{
		public int? Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public bool Equals(Employee x, Employee y)
		{
			return x.FirstName == y.FirstName && x.LastName == y.LastName && x.Id == y.Id;
		}

		public int GetHashCode(Employee obj)
		{
			return obj.FirstName.GetHashCode() + obj.LastName.GetHashCode() + obj.Id.GetHashCode();
		}

	}
}
