using System;

namespace ClassV
{
	class A
	{
		public virtual void Show()
		{
			Console.WriteLine("A");
		}
	}

	class B : A
	{
		public new virtual void Show()
		{
			Console.WriteLine("B");
		}
	}

	class ClassV
	{
		[STAThread]
		static void Main(string[] args)
		{
			A
				a=new A(),
				_a_;

			B
				b=new B();

			a.Show(); // A
			b.Show(); // B
			_a_=b;
			_a_.Show(); // A
			_a_=new B();
			_a_.Show(); // A
		}
	}
}
