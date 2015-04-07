using System;
using System.Collections.Generic;
using System.Reflection;

namespace EqualityComparer
{
	public class MyComparer<T> : IEqualityComparer<T>
	{
		public bool Equals(T source, T destination)
		{
			Type sourceType = source.GetType();
			Type destinationType = destination.GetType();
			if (sourceType != destinationType)
			{
				throw new ArgumentException("Porównywane obiekty są różne");
			}
			PropertyInfo[] sourcePropertyInfos = sourceType.GetProperties();
			foreach (PropertyInfo info in sourcePropertyInfos)
			{
				//if (sourceType.GetProperty(info.Name).GetValue(this, null) == null && destinationType.GetProperty(info.Name).GetValue(this, null) == null)
				if (sourceType.GetProperty(info.Name).GetValue(source, null) == null && destinationType.GetProperty(info.Name).GetValue(destination, null) == null)
					//można zwrócić wyjątek ale dla wartości nullable nie jest to wskazane!? Jeżeli wyjdzie na to, że wszystkie właściwości są nullowe to są one równe
					continue; 
				//if (sourceType.GetProperty(info.Name).GetValue(this, null) == null || destinationType.GetProperty(info.Name).GetValue(this, null) == null)
				if (sourceType.GetProperty(info.Name).GetValue(source, null) == null || destinationType.GetProperty(info.Name).GetValue(destination, null) == null)
					return false;
				//if (sourceType.GetProperty(info.Name).GetValue(this, null).ToString() != destinationType.GetProperty(info.Name).GetValue(this, null).ToString())
				if (sourceType.GetProperty(info.Name).GetValue(source, null).ToString() != destinationType.GetProperty(info.Name).GetValue(destination, null).ToString())
					return false;
			}
			return true;
		}

		public int GetHashCode(T obj)
		{
			Type objType = obj.GetType();
			PropertyInfo[] propInfo = objType.GetProperties();
			int result = 0;
			foreach (PropertyInfo property in propInfo)
			{
				if (objType.GetProperty(property.Name).GetValue(obj, null) != null)
					result += objType.GetProperty(property.Name).GetValue(obj, null).GetHashCode();
			}
			return result;
		}		
	}
}
