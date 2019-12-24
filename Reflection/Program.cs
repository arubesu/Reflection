using Reflection.Attributes;
using System;
using System.Reflection;
using System.Linq.Expressions;

namespace Reflection
{
	class Program
	{
		static void Main(string[] args)
		{
			LinqExpression();

		}

		private static void LinqExpression()
		{
			//Divide delegate
			Func<float, float> half = (number) => number / 2;

			//Doing the same with Linq Expressions

			ParameterExpression parameterExpression = Expression.Parameter(typeof(float), "Number");
			ConstantExpression constantExpression = Expression.Constant(2f, typeof(float));
			BinaryExpression binaryExpression = Expression.Divide(parameterExpression, constantExpression);

			//Create Expression Tree

			Expression<Func<float, float>> expression =
				Expression.Lambda<Func<float, float>>(
					binaryExpression,
					new ParameterExpression[] { parameterExpression });

			var halfExpression = expression.Compile();

			var number = 9;

			Console.WriteLine($"The half from {number} is {halfExpression(number)}");
		}

		private static void PrintAssembliesNames()
		{
			var assembly = Assembly.GetExecutingAssembly();
			var types = assembly.GetTypes();
			foreach (var type in types)
			{
				Console.WriteLine(type.Name);
			}
		}

		private static void InvokeMethodByReflection()
		{
			Dog dog = GetDogInstance();

			Console.WriteLine(dog.ToString());
			var type = dog.GetType();

			var methodInfo = type.GetMethod("set_Name");
			methodInfo?.Invoke(dog, new object[] { "Thod Modified" });
			Console.WriteLine(dog.ToString());
		}

		private static Dog GetDogInstance()
		{
			var dog = new Dog();
			dog.Name = "Thor";
			dog.Color = "Gray";
			return dog;
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
