using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentacarApp;

namespace RentacarTests.Library
{
    internal class TestLibrary
    {
        /// <summary>
        /// Проверка строки текстового поля
        /// </summary>
        /// <param name="text"></param>
        /// <returns>
        /// true - истина
        /// exception - ошибка
        /// </returns>
        public bool StringTextCheck(string text)
        {
            string Symbols = "йцукеёнгшщзхъфывапролджэячсмитьбюabcdefghijklmnopqrstuvwxyz1234567890?1234567890:;()%№+=@.,-! \\/\"";
            text = text.ToLower();
            if (!text.All(x => Symbols.Contains(x)))
            {
                return false;
            }
            if (text == String.Empty)
            {
                return false;
            }
            return true;
        }
    }
}
