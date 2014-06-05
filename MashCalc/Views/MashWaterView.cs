using System;
using System.Linq;
using Xamarin.Forms;

namespace MashCalc
{
	public class MashWaterView : BaseView<MashWaterViewModel>
	{
		public MashWaterView () : base()
		{
			var numberConverter = new NumberTypeConverter ();

			var g = new Grid () { 
				Padding = new Thickness( 5, 20, 5, 0 ),
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
			};
			var row = 0;
			g.Children.Add (new Label () { Text = "Brewday Mash Calculator", Font = Font.BoldSystemFontOfSize(NamedSize.Large)}, 0, 2, row, row + 1);
			row++;
			g.Children.Add (new Label () { Text = "Grain Bill:", }, 0, row);
			g.Children.Add (new Entry () { Placeholder = "In lbs", Keyboard = Keyboard.Numeric,}
				.Bind(Entry.TextProperty).To(this.ViewModel, vm=>vm.GrainBill, numberConverter), 1, row);

			row++;
			g.Children.Add (new Label () { Text = "Boil Time (Min):", }, 0, row);
			g.Children.Add (new Entry () { Placeholder = "Minutes", Keyboard = Keyboard.Numeric,}
				.Bind(Entry.TextProperty).To(this.ViewModel, vm=>vm.BoilTime, numberConverter), 1, row);

			row++;
			g.Children.Add (new Label () { Text = "Mash Thickness:", }, 0, row);
			g.Children.Add (new Entry () { Placeholder = "Ratio 1 to 1.5", Keyboard = Keyboard.Numeric,}
				.Bind(Entry.TextProperty).To(this.ViewModel, vm=>vm.MashThickness, numberConverter), 1, row);

			row++;
			g.Children.Add (new Label () { Text = "Target Mash Temp:", }, 0, row);
			g.Children.Add (new Entry () { Placeholder = "Deg f", Keyboard = Keyboard.Numeric,}
				.Bind(Entry.TextProperty).To(this.ViewModel, vm=>vm.TargetMashTemp, numberConverter), 1, row);

			row++;
			g.Children.Add (new Label () { Text = "Grain Temp:", }, 0, row);
			g.Children.Add (new Entry () { Placeholder = "Deg f", Keyboard = Keyboard.Numeric,}
				.Bind(Entry.TextProperty).To(this.ViewModel, vm=>vm.GrainTemp, numberConverter), 1, row);

			row++;
			g.Children.Add (new Label () { Text = "Strike Temp (Deg f):", }, 0, row);
			g.Children.Add (new Label () { }
				.Bind(Label.TextProperty).To(this.ViewModel, vm=>vm.StrikeTemp, numberConverter), 1, row);

			row++;
			g.Children.Add (new Label () { Text = "Strike Size (Gal):", }, 0, row);
			g.Children.Add (new Label () { }
				.Bind(Label.TextProperty).To(this.ViewModel, vm=>vm.StrikeSize, numberConverter), 1, row);

			row++;
			g.Children.Add (new Label () { Text = "Mashout (Gal) Boiling:", }, 0, row);
			g.Children.Add (new Label () { }
				.Bind(Label.TextProperty).To(this.ViewModel, vm=>vm.MashOutSize, numberConverter), 1, row);

			row++;
			g.Children.Add (new Label () { Text = "Sparage Size:", }, 0, row);
			g.Children.Add (new Label () { }
				.Bind(Label.TextProperty).To(this.ViewModel, vm=>vm.SparageSize, numberConverter), 1, row);

			row++;
			g.Children.Add (new Label () { Text = "Batch Size (Gal):", }, 0, row);
			g.Children.Add (new Label () { }
				.Bind(Label.TextProperty).To(this.ViewModel, vm=>vm.BatchSize, numberConverter), 1, row);


			var scroll = new ScrollView () {
				Content = g,
			};

			Content = scroll;
		}
	}
}

