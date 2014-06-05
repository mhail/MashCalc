using System;
using Xamarin.Forms;

namespace MashCalc
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			return new MashWaterView (){
				BindingContext = new MashWaterViewModel(),
			};
		}
	}
}

