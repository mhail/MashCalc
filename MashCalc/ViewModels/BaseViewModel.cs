using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace MashCalc
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		protected void SetProperty<U>(
			ref U backingStore, U value,
			[CallerMemberName] string propertyName = null,
			Action onChanged = null,
			Action<U> onChanging = null)
		{


			if (EqualityComparer<U>.Default.Equals(backingStore, value))
				return;

			if (onChanging != null)
				onChanging(value);

			OnPropertyChanging(propertyName);

			backingStore = value;

			if (onChanged != null)
				onChanged();

			OnPropertyChanged(propertyName);
		}

		#region INotifyPropertyChanging implementation
		public event Xamarin.Forms.PropertyChangingEventHandler PropertyChanging ;
		#endregion

		public void OnPropertyChanging(string propertyName)
		{
			if (PropertyChanging == null)
				return;

			PropertyChanging(this, new Xamarin.Forms.PropertyChangingEventArgs(propertyName));
		}


		#region INotifyPropertyChanged implementation
		public event PropertyChangedEventHandler PropertyChanged;
		#endregion

		public void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged == null)
				return;

			PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}


}

