﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace VFlow
{
    public class ItemToListConverter : IValueConverter
    {
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var argType = value.GetType();
                var listType = typeof(List<>).MakeGenericType(argType);
                var list = Activator.CreateInstance(listType) as IList;
                list?.Add(value);

                return list;
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
