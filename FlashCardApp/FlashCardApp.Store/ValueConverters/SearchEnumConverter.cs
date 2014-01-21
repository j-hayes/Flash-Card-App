using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

using Windows.UI.Xaml.Data;

namespace FlashCardApp.Store.ValueConverters
{
    public class SearchEnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
            {
                return "rull value";
            }
            var _member = value.GetType().GetRuntimeFields()
                .FirstOrDefault(x => x.Name == value.ToString());
            if (_member == null)
            {
                return "null member";
            }
            var _Attribute = _member.GetCustomAttribute(
                typeof (DisplayAttribute), false) as DisplayAttribute;
            if (_Attribute == null)
            {
                return value.ToString();
            }
            return _Attribute.Name;
        }


        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    } 
}
