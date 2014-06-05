using System;
using Xamarin.Forms;

namespace MashCalc
{
	public class NumberTypeConverter : IValueConverter
	{
		#region IValueConverter implementation
		public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (targetType == typeof(string)) {
				return value.ToString();
			}
			return null;
		}
		public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			float s;
			if (targetType == typeof(float) && float.TryParse(value.ToString(), out s)) {
				return s;
			}
			return null;
		}
		#endregion
	}
}

