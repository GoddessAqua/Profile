using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profile
{
    public class AuthData
    {
        public string? Phone { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? BirthDay { get; set; }

        public DocumentData? DocumentsData { get; set; }

        /// <summary>
        /// Проверка профиля пользователя на пустоту
        /// </summary>
        /// <param name="dataForAuth"></param>
        /// <returns>true (профиль пуст), если какие-то из свойств (или все) оказались null или пустым string(""), в противном случае, false (профиль не пуст)</returns>
        public static bool IsProfileNullOrEmpty(AuthData profileData)
        {
            /*
               * Мне не нравится идея запихивать всё в анонимный тип.
               * Я также не хочу писать кучу if на проверку null или пустоту. Я сделала проверку через отражение.
               * У текущей проверки через отражения есть одно "но": в классе AuthData есть свойство DocumentData, которое является классом. 
               * Если писать без анонимного типа, то свойства класса DocumentData будут игнорироваться, но они должны проверяться наряду с другими. 
               * Проверка на пустой профиль работает, тесты все проходят, можете проверить. Но код мне не нравится. Я думаю, что можно придумать что-то адекватнее.
               * Был вариант создать объекты с null-свойствами и пустыми строками и каким-то образом сравнивать.
            */

            var dataForAuth = new
            {
                profileData.Phone,
                profileData.FirstName,
                profileData.LastName,
                profileData.BirthDay,
                profileData.DocumentsData?.DocumentNumber,
                profileData.DocumentsData?.DocumetSeries
            };

            return dataForAuth.GetType()
                              .GetProperties()
                              .Where(p => p.PropertyType == typeof(string))
                              .Select(prop => (string)prop.GetValue(dataForAuth))
                              .Any(value => string.IsNullOrEmpty(value));
        }
    }
}
