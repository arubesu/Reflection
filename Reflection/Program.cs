using Reflection.Attributes;
using System;

namespace Reflection
{
	class Program
	{
		static void Main(string[] args)
		{
			PrintMembers();
		}

		private static void PrintMembers()
		{
			var type = GetDogType();
			var members = type.GetMembers();
			foreach (var member in members)
			{
				Console.WriteLine(member);
			}
		}

		private static void GetClassType()
		{
			Type type = GetDogType();
			Console.WriteLine($"The class is from {type} Type");
		}

		private static Type GetDogType()
		{
			var dog = new Dog();
			var type = dog.GetType();
			return type;
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
