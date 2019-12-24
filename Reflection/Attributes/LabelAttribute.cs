using System;

namespace Reflection.Attributes
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public class LabelAttribute : Attribute
	{
		public string Label { get; }
		public LabelAttribute(string label)
		{
			this.Label = label;
		}
	}
}
