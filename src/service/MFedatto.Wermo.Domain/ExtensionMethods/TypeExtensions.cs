using System;
using System.Linq;

namespace MFedatto.Wermo.Domain.ExtensionMethods
{
	public static class TypeExtensions
	{
		public static string GetGenericsNames(this Type type)
		{
			string genericArgs;

			if (!type.IsGenericType)
				return type.Name;

			genericArgs = string.Join(
				",",
				type.GetGenericArguments()
					.Select(ta => GetGenericsNames(ta)).ToArray());

			return genericArgs;
		}

		public static string GetNameWithGenerics(this Type type)
		{
			string genericTypeName;
			string genericArgs;

			if (!type.IsGenericType)
				return type.Name;

			genericTypeName = type.GetGenericTypeDefinition().Name;
			genericTypeName = genericTypeName.Substring(0, genericTypeName.IndexOf('`'));
			genericArgs = GetGenericsNames(type);

			return genericTypeName + "<" + genericArgs + ">";
		}
	}
}
