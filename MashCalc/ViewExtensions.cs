using System;
using Xamarin.Forms;

namespace MashCalc
{
	public interface IGridBuilder<G> where G : Grid
	{
		G Grid { get; }
		int Row { get; set; }
		int Col { get; set; }
	}


	public static class ViewExtensions
	{
		public static G Build<G>(this G grid, Action<IGridBuilder<G>> action) where G : Grid
		{
			var builder = new GridBuilder<G> (grid);
			action (builder);
			return grid;
		}

		public static Label ToLabel(this string text)
		{
			return new Label { Text = text };
		}

		public class GridBuilder<G> : IGridBuilder<G> where G : Grid
		{
			public G Grid { get; private set; }

			public GridBuilder(G grid) 
			{
				this.Grid = grid;
			}

			public int Row { get; set; }
			public int Col { get; set; }
		}

		public static IGridBuilder<G> AddRow<G>(this IGridBuilder<G> builder, params View[] views) where G : Grid
		{
			builder.Col = 0;
			foreach (var view in views) {
				builder.Grid.Children.Add (view, builder.Col, builder.Row);
				builder.Col++;
			}
			builder.Row++;

			return builder;
		}

		public static IGridBuilder<G> RowSpan<G>(this IGridBuilder<G> builder, View view, int span = -1) where G : Grid
		{
			if (span < 0) {
				span = builder.Grid.ColumnDefinitions.Count;
			}
			builder.Col = 0;
			builder.Grid.Children.Add (view, builder.Col, builder.Col + span, builder.Row, builder.Row +1);
			builder.Col+=span;
			builder.Row++;

			return builder;
		}
	}
}

