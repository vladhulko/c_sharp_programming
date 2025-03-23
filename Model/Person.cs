using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01.Model
{
    public class Person
    {
        public DateTime BirthDate { get; set; }

        public int Age
        {
            get
            {
                DateTime today = DateTime.Today;
                int age = today.Year - BirthDate.Year;

                if (today.Month < BirthDate.Month || (today.Month == BirthDate.Month && today.Day < BirthDate.Day))
                {
                    age--;
                }
                return age;
            }
        }
        public bool IsBirthday
        {
            get
            {
                DateTime today = DateTime.Today;
                return today.Day == BirthDate.Day && today.Month == BirthDate.Month;
            }
        }
        public bool IsValidAge
        {
            get
            {
                return Age >= 0 && Age <= 135;
            }
        }
        public string WesternZodiacSign
        {
            get
            {
                int month = BirthDate.Month;
                int day = BirthDate.Day;

                if ((month == 3 && day >= 21) || (month == 4 && day <= 19))
                    return "Овен";
                if ((month == 4 && day >= 20) || (month == 5 && day <= 20))
                    return "Телець";
                if ((month == 5 && day >= 21) || (month == 6 && day <= 20))
                    return "Близнюки";
                if ((month == 6 && day >= 21) || (month == 7 && day <= 22))
                    return "Рак";
                if ((month == 7 && day >= 23) || (month == 8 && day <= 22))
                    return "Лев";
                if ((month == 8 && day >= 23) || (month == 9 && day <= 22))
                    return "Діва";
                if ((month == 9 && day >= 23) || (month == 10 && day <= 22))
                    return "Терези";
                if ((month == 10 && day >= 23) || (month == 11 && day <= 21))
                    return "Скорпіон";
                if ((month == 11 && day >= 22) || (month == 12 && day <= 21))
                    return "Стрілець";
                if ((month == 12 && day >= 22) || (month == 1 && day <= 19))
                    return "Козеріг";
                if ((month == 1 && day >= 20) || (month == 2 && day <= 18))
                    return "Водолій";

                return "Риби";
            }
        }

        public string ChineseZodiacSign
        {
            get
            {
                string[] signs = { "Мавпа", "Півень", "Собака", "Свиня", "Щур", "Бик", "Тигр", "Кролик", "Дракон", "Змія", "Кінь", "Коза" };
                return signs[BirthDate.Year % 12];
            }
        }
    }
}
