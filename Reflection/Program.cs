using Reflection.Attributes;
using System;

namespace Reflection
{
	class Program
	{
		static void Main(string[] args)
		{
		}

		private static void GetClassType()
		{
			var dog = new Dog();
			var type = dog.GetType();
			Console.WriteLine($"The class is from {type} Type");
		}

		private static void GetClassAttribute()
		{
			var label = ((LabelAttribute)Attribute.GetCustomAttribute(typeof(Dog), typeof(LabelAttribute))).Label;
			Console.WriteLine(label);
		}

		private static void CheckIfDogIsSerializable()
		{
			var result = Attribute.IsDefined(typeof(Dog), typeof(SerializableAttribute)) ?
							"Yes" : "No";
			Console.WriteLine(result);
		}
	}
}
