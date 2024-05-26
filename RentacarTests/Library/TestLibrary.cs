using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            string Symbols = "абвгдеёжзийклмнопрстуфхцчшщъыьэюяabcdefghijklmnopqrstuvwxyz";
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
        
        /// <summary>
        /// Проверка поля государственного номера автомобиля
        /// </summary>
        /// <param name="text"></param>
        /// <returns>
        /// true - истина
        /// exception - ошибка
        /// </returns>
        public bool StringRegNumberCheck(string text)
        {
            string pattern = @"^[АВЕКМНОРСТУХ][0-9]{3}[АВЕКМНОРСТУХ]{2}[-][0-9]{2,3}$";
            Regex r = new Regex(pattern);
            if (!r.IsMatch(text))
            {
                return false;
            }
            if (text == String.Empty)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Проверка корректности ввода номера телефона
        /// </summary>
        /// <param name="phone">Номер телефона</param>
        /// <returns>
        /// true - в случае корректного ввода
        /// throw - в случае ввода некорректных данных
        /// </returns>
        public bool PhoneCheck(string phone)
        {
            string phonenumber = "1234567890+-";
            if (phone == String.Empty)
            {
                return false;
            }
            if (phone.Length < 11)
            {
                return false;
            }
            if (phone.Length > 12)
            {
                return false;
            }
            if (!phone.All(x => phonenumber.Contains(x)))
            {
                return false;
            }
            if (phone.StartsWith("+7"))
            {
                phone.Replace("+7", "8");
            }
            return true;
        }

        /// <summary>
        /// Проверка числового поля
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns>
        /// true - истина
        /// exception - ошибка
        /// </returns>
        public bool DigitTextCheck(string numbers)
        {
            string digit = "1234567890";
            numbers = numbers.ToLower();
            if (!numbers.All(x => digit.Contains(x)))
            {
                return false;
            }
            if (numbers == String.Empty)
            {
                return false;
            }
            return true;
        }
    }
}
