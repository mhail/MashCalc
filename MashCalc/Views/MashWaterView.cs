using System;
using System.Linq;
using Xamarin.Forms;

namespace MashCalc
{
	public class MashWaterView : BaseView<MashWaterViewModel>
	{
		private static readonly NumberTypeConverter NumberConverter = new NumberTypeConverter();

		public MashWaterView () : base()
		{
			this.BackgroundColor = new Color (243/255.0, 167/255.0, 19/255.0);

			this.Content = new ScrollView {
				Content = new Grid { 
					Padding = new Thickness (5, 20, 5, 0),
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					VerticalOptions = LayoutOptions.CenterAndExpand,
				}.Build (b => {

					b.RowSpan (new Label { 
						Text = "Brewday Mash Calculator", 
						Font = Font.BoldSystemFontOfSize (NamedSize.Large)
					}, 2);

					b.AddRow (
						"Grain Bill:".ToLabel (), 
						new Entry () { Placeholder = "In lbs", Keyboard = Keyboard.Numeric, }
						.Bind (Entry.TextProperty).To (this.ViewModel, vm => vm.GrainBill, converter: NumberConverter)
					);

					b.AddRow (
						"Boil Time (Min):".ToLabel (),
						new Entry () { Placeholder = "Minutes", Keyboard = Keyboard.Numeric, }
						.Bind (Entry.TextProperty).To (this.ViewModel, vm => vm.BoilTime, converter: NumberConverter)
					);
				
					b.AddRow (
						"Mash Thickness:".ToLabel (),
						new Entry () { Placeholder = "Ratio 1 to 1.5", Keyboard = Keyboard.Numeric, }
						.Bind (Entry.TextProperty).To (this.ViewModel, vm => vm.MashThickness, converter: NumberConverter)
					);

					b.AddRow (
						"Target Mash Temp:".ToLabel (),
						new Entry () { Placeholder = "Deg f", Keyboard = Keyboard.Numeric, }
						.Bind (Entry.TextProperty).To (this.ViewModel, vm => vm.TargetMashTemp, converter: NumberConverter)
					);

					b.AddRow (
						"Grain Temp:".ToLabel (),
						new Entry () { Placeholder = "Deg f", Keyboard = Keyboard.Numeric, }
						.Bind (Entry.TextProperty).To (this.ViewModel, vm => vm.GrainTemp, converter: NumberConverter)
					);

					b.AddRow (
						"Strike Temp (Deg f):".ToLabel (),
						string.Empty.ToLabel ()
						.Bind (Label.TextProperty).To (this.ViewModel, vm => vm.StrikeTemp, converter: NumberConverter)
					);

					b.AddRow (
						"Strike Size (Gal):".ToLabel (),
						string.Empty.ToLabel ()
						.Bind (Label.TextProperty).To (this.ViewModel, vm => vm.StrikeSize, converter: NumberConverter)
					);

					b.AddRow (
						"Mashout (Gal) Boiling:".ToLabel (),
						string.Empty.ToLabel ()
						.Bind (Label.TextProperty).To (this.ViewModel, vm => vm.MashOutSize, converter: NumberConverter)
					);

					b.AddRow (
						"Sparage Size:".ToLabel (),
						string.Empty.ToLabel ()
						.Bind (Label.TextProperty).To (this.ViewModel, vm => vm.SparageSize, converter: NumberConverter)
					);

					b.AddRow (
						"Batch Size (Gal):".ToLabel (),
						string.Empty.ToLabel ()
						.Bind (Label.TextProperty).To (this.ViewModel, vm => vm.BatchSize, converter: NumberConverter)
					);

				})
			};
		}
	}
}

