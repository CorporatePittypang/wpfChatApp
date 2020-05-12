using System;
using System.Windows;
using System.Windows.Controls;

namespace Fasetto.Word
{
	/// <summary>
	/// Match the label width of all text entry controls inside this panel
	/// </summary>
	public class TextEntryWidthMatcherProperty : BaseAttachedProperty<TextEntryWidthMatcherProperty, bool>
	{
		public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			// Get the panel (grid typically)
			var panel = (sender as Panel);

            SetWidths(panel);

            // Wait for panel to load
            RoutedEventHandler onLoaded = null;
            onLoaded = (s, ee) =>
			{
                panel.Loaded -= onLoaded;

                SetWidths(panel);

				foreach(var child in panel.Children)
				{
                    if (!(child is TextEntryControl control))
                        continue;

                    control.Label.SizeChanged += (es, eee) =>
                    {
                        SetWidths(panel);
                    };
                }
			};

            panel.Loaded += onLoaded;
		}

        // Set everything to the same, the maxSize
        private void SetWidths(Panel panel)
        {
            var maxSize = 0d;

            foreach (var child in panel.Children)
            {
                if (!(child is TextEntryControl control))
                    continue;

                control.LabelWidth = GridLength.Auto;

                maxSize = Math.Max(maxSize, control.RenderSize.Width + control.Label.Margin.Left + control.Label.Margin.Right);
            }

            var gridLength = (GridLength)new GridLengthConverter().ConvertFromString(maxSize.ToString());
            foreach (var child in panel.Children)
            {
                if (!(child is TextEntryControl control))
                    continue;

                control.LabelWidth = gridLength;
            }
        }
    }
}
