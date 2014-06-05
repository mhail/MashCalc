using System;
using Xamarin.Forms;
using System.Linq.Expressions;
using System.ComponentModel;

namespace MashCalc
{
	public class BaseView<T> : ContentPage where T : BaseViewModel
	{
		public BaseView (T viewModel = null)
		{
			this.BindingContext = viewModel ?? Activator.CreateInstance<T> ();
		}

		public T ViewModel 
		{
			get { return this.BindingContext as T; }
		}
	}

	public interface IBindableObjectFrom<B> where B : BindableObject
	{
		B Object { get; }
		BindableProperty TargetProperty { get; }
	}

	public static class BaseViewExtensions
	{
		public static IBindableObjectFrom<B> Bind<B>(this B b, BindableProperty targetProperty) where B : BindableObject
		{
			return new BindableObjectFrom<B>(b, targetProperty);
		}

		public static B To<B, S>(this IBindableObjectFrom<B> f, S s, Expression<Func<S, object>> src, IValueConverter converter = null) where B : BindableObject where S : INotifyPropertyChanged
		{
			f.Object.BindingContext = s;
			f.Object.SetBinding(f.TargetProperty, src, BindingMode.TwoWay, converter);
			return f.Object;
		}

		private class BindableObjectFrom<B> : IBindableObjectFrom<B> where B : BindableObject
		{
			public BindableObjectFrom(B obj, BindableProperty targetProperty)
			{
				this.Object = obj;
				this.TargetProperty = targetProperty;
			}

			#region IBindableObjectFrom implementation
			public B Object {
				get;
				private set; 
			}
			public BindableProperty TargetProperty {
				get ;
				private set;
			}
			#endregion
		}
	}
}

