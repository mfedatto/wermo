using MFedatto.Wermo.Domain.Enum;
using System;

namespace MFedatto.Wermo.Domain.ExtensionMethods
{
	public static class HttpVerbsExtensions
	{
		public static HttpVerb ParseAsHttpVerb(this string httpMethod)
		{
			return httpMethod.ToUpper() switch
			{
				"GET" => HttpVerb.Get,
				"Post" => HttpVerb.Post,
				"Put" => HttpVerb.Put,
				"Delete" => HttpVerb.Delete,
				"Options" => HttpVerb.Options,
				"Head" => HttpVerb.Head,
				"Patch" => HttpVerb.Patch,
				_ => throw new ArgumentOutOfRangeException()
			};
		}
	}
}
