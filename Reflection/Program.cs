using System;

namespace Reflection
{
	class Program
	{
		static void Main(string[] args)
		{
			CheckIfDogIsSerializable();
		}

		private static void CheckIfDogIsSerializable()
		{
			var result = Attribute.IsDefined(typeof(Dog), typeof(SerializableAttribute)) ?
							"Yes" : "No";
			Console.WriteLine(result);
		}
	}
}
