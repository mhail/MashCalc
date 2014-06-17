using System;
using Xamarin.Forms;

namespace MashCalc
{
	public interface IDependencyContainer
	{
		T Resolve<T>() where T : class;
	}

	public abstract class AppBase
	{
		private static IDependencyContainer _container;
		public static IDependencyContainer Container
		{
			get {
				return _container ?? (_container = new DefaultDependencyContainer());
			}
			protected set { 
				_container = value;
			}
		}

		internal class DefaultDependencyContainer : IDependencyContainer
		{
			#region IDependencyContainer implementation
			public T Resolve<T> () where T : class
			{
				return Xamarin.Forms.DependencyService.Get<T> ();
			}
			#endregion
		}

	}


	public class App : AppBase
	{
		static App() {
			Container = null;
		}

		public static Page GetMainPage ()
		{	

			return new MashWaterView (){
				BindingContext = new MashWaterViewModel(),
			};
		}
	}
}

