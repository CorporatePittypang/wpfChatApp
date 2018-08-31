﻿using System;
using System.Globalization;
using System.Windows;

namespace Fasetto.Word
{
  /// <summary>
  /// A converter that takes in a date and returns a user friendly time
  /// </summary>
  public class TimeToDisplayTimeConverter : BaseValueConverter<TimeToDisplayTimeConverter>
  {
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      // Get the time passed in
      var time = (DateTimeOffset)value;

      // If it is today...
      if (time.Date == DateTimeOffset.Now.Date)
        // Return just time
        return time.ToLocalTime().ToString("HH:mm");

      // Otherwise, return a full date
      return time.ToLocalTime().ToString("HH:mm, MMM yyyy");
    }

    public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
