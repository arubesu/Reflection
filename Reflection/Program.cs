using Reflection.Attributes;
using System;
using System.Reflection;
using System.Linq.Expressions;
using Reflection.Expressions;

namespace Reflection
{
	class Program
	{
		static void Main(string[] args)
		{
			GetPropertiesInfo();
		}

		private static void GetPropertiesInfo()
		{
			var type = typeof(Dog);
			var properties = type.GetProperties();
			foreach (var property in properties)
			{
				Console.WriteLine($"Name: {property.Name}");
				Console.WriteLine($"Can Read: {property.CanRead}");
				Console.WriteLine($"Can Write: {property.CanWrite}\n");
			}
		}

		private static void PrintAssemblyInformation()
		{
			//Tasks
			//1 - Get Assembly full name 
			Assembly assembly = Assembly.GetExecutingAssembly();
			Console.WriteLine($"Assembly: {assembly.FullName}");

			//2 - Get Assembly Version
			var assemblyIdentity = assembly.GetName();
			Console.WriteLine($"Version: {assemblyIdentity.Version}");
			//3 - Check whether assembly is in GAC - Global Assembly cache
			Console.WriteLine($"Assembly in GAC: {assembly.GlobalAssemblyCache}");
			//4- Discover all moddules, types and members

			foreach (var module in assembly.GetModules())
			{
				Console.WriteLine($"Module: {module.Name}");
				foreach (var type in module.GetTypes())
				{
					Console.WriteLine($"\tType: {type.Name}");

					foreach (var member in type.GetMembers())
					{
						Console.WriteLine($"\t\tMember:{member.Name} ({member.MemberType})");
					}
				}
			}
		}

		private static void ChangeLinqExpression()
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


			//Changing Expression

			ChangeExpressionToMultiply changeExpressionToMultiply = new ChangeExpressionToMultiply();
			Expression<Func<float, float>> expressionDouble
				= (Expression<Func<float, float>>)changeExpressionToMultiply.Change(expression);

			var compiledDoubleExpression = expressionDouble.Compile();
			Console.WriteLine($"The half from {number} is {compiledDoubleExpression(number)}");
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
