using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace WpfApp2.Converters
{
	public class EnumToString : IValueConverter//наследуемся от IValueConverter
	{
		private string GetEnumDescription(Enum enumObj)
		{
			FieldInfo fieldInfo = enumObj.GetType().GetField(enumObj.ToString());// получаем информацию о поле. Сначала getType, что вернет тип нашего enum(в данном случае TypeUser), затем getField получаем значение enum по имени(то есть ADMIN, или STANDART)
			var descriptionAttr = fieldInfo
				.GetCustomAttributes(false)//устаналвиваем отстутствие кастомных аттрибутов
				.OfType<DescriptionAttribute>()
				.Cast<DescriptionAttribute>()
				.SingleOrDefault();// получем аттрибут Description(Он уже вшит в дефолтные версии аттрибутов)
			if (descriptionAttr == null)//если null, то возвращаем имя enum(оно будет на английском)
			{
				return enumObj.ToString();
			}
			else// если все хорошо взвращает имя на русском
			{
				return descriptionAttr.Description;
			}
		}

		object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)// получает enum возвращает его описание
		{
			Enum myEnum = (Enum)value;//преобразуем value в enum(любой)
			string description = GetEnumDescription(myEnum);// получаем описание
			return description;// возвращаем
		}

		object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return string.Empty;// возвращаем пустую строку, так как обратное преобразование нам не нужно
		}
	}
}
