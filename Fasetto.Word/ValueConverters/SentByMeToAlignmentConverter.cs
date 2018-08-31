using System;
using System.Globalization;
using System.Windows;

namespace Fasetto.Word
{
  /// <summary>
  /// A converter that takes in a boolean and if the message is sent by me, and aligns to the right
  /// If not sent by me, aligns to the left
  /// </summary>
  public class SentByMeToAlignmentConverter : BaseValueConverter<SentByMeToAlignmentConverter>
  {
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      var item = (bool)value ? HorizontalAlignment.Right : HorizontalAlignment.Left;
      return (bool)value ? HorizontalAlignment.Right : HorizontalAlignment.Left;
    }

    public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
