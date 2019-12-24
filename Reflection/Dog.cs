using Reflection.Attributes;
using System;

namespace Reflection
{
	[Serializable]
	[Label("Animal")]
	public class Dog
	{
		public string Name { get; set; }
		public string Color { get; set; }

		public void Bark() => Console.WriteLine("Rowf Rowf");
	}
}
