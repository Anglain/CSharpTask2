using System;

namespace CSharpTask2
{
    enum ChineseZodiac
    {
        Rat = 1996,
        Ox = 1997,
        Tiger = 1998,
        Rabbit = 1999,
        Dragon = 2000,
        Snake = 2001,
        Horse = 2002,
        Goat = 2003,
        Monkey = 2004,
        Rooster = 2005,
        Dog = 2006,
        Pig = 2007
    }

    internal class Person
    {
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthDateTime;

        internal Person(string name, string surname, string email, DateTime birthDateTime)
        {
            _name = name;
            _surname = surname;
            _email = email;
            _birthDateTime = birthDateTime;
        }

        internal Person(string name, string surname, string email)
        {
            _name = name;
            _surname = surname;
            _email = email;
        }

        internal Person(string name, string surname, DateTime birthDateTime)
        {
            _name = name;
            _surname = surname;
            _birthDateTime = birthDateTime;
        }

        internal string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        internal string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        internal string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        internal DateTime BirthDateTime
        {
            get { return _birthDateTime; }
            set { _birthDateTime = value; }
        }

        internal bool IsAdult
        {
            get
            {
                if (DateTime.Now.Year - BirthDateTime.Year > 18 || 
                    (DateTime.Now.Year - BirthDateTime.Year == 18 && DateTime.Now.Month > BirthDateTime.Month) ||
                    (DateTime.Now.Year - BirthDateTime.Year == 18 && DateTime.Now.Month == BirthDateTime.Month && DateTime.Now.Day >= BirthDateTime.Day))
                {
                    return true;
                }

                return false;
            }
        }

        internal string SunSign
        {
            get {
                string result = "";

                if ((BirthDateTime.Month == 1 && BirthDateTime.Day >= 20) || (BirthDateTime.Month == 2 && BirthDateTime.Day <= 18))
                {
                    result = "Aquarius";
                }
                else if ((BirthDateTime.Month == 2 && BirthDateTime.Day >= 19) || (BirthDateTime.Month == 3 && BirthDateTime.Day <= 20))
                {
                    result = "Pisces";
                }
                else if ((BirthDateTime.Month == 3 && BirthDateTime.Day >= 21) || (BirthDateTime.Month == 4 && BirthDateTime.Day <= 19))
                {
                    result = "Aries";
                }
                else if ((BirthDateTime.Month == 4 && BirthDateTime.Day >= 20) || (BirthDateTime.Month == 5 && BirthDateTime.Day <= 20))
                {
                    result = "Taurus";
                }
                else if ((BirthDateTime.Month == 5 && BirthDateTime.Day >= 21) || (BirthDateTime.Month == 6 && BirthDateTime.Day <= 20))
                {
                    result = "Gemini";
                }
                else if ((BirthDateTime.Month == 6 && BirthDateTime.Day >= 21) || (BirthDateTime.Month == 7 && BirthDateTime.Day <= 22))
                {
                    result = "Cancer";
                }
                else if ((BirthDateTime.Month == 7 && BirthDateTime.Day >= 23) || (BirthDateTime.Month == 8 && BirthDateTime.Day <= 22))
                {
                    result = "Leo";
                }
                else if ((BirthDateTime.Month == 8 && BirthDateTime.Day >= 23) || (BirthDateTime.Month == 9 && BirthDateTime.Day <= 22))
                {
                    result = "Virgo";
                }
                else if ((BirthDateTime.Month == 9 && BirthDateTime.Day >= 23) || (BirthDateTime.Month == 10 && BirthDateTime.Day <= 22))
                {
                    result = "Libra";
                }
                else if ((BirthDateTime.Month == 10 && BirthDateTime.Day >= 23) || (BirthDateTime.Month == 11 && BirthDateTime.Day <= 21))
                {
                    result = "Scorpio";
                }
                else if ((BirthDateTime.Month == 11 && BirthDateTime.Day >= 22) || (BirthDateTime.Month == 12 && BirthDateTime.Day <= 21))
                {
                    result = "Sagittarius";
                }
                else if ((BirthDateTime.Month == 12 && BirthDateTime.Day >= 22) || (BirthDateTime.Month == 1 && BirthDateTime.Day <= 19))
                {
                    result = "Capricorn";
                }

                return result;
            }
        }

        internal string ChineseSign
        {
            get {
                if ((Math.Abs((int)ChineseZodiac.Rat - BirthDateTime.Year) % 12) == 0)
                {
                    return "Rat";
                }
                else if ((Math.Abs((int)ChineseZodiac.Ox - BirthDateTime.Year) % 12) == 0)
                {
                    return "Ox";
                }
                else if ((Math.Abs((int)ChineseZodiac.Tiger - BirthDateTime.Year) % 12) == 0)
                {
                    return "Tiger";
                }
                else if ((Math.Abs((int)ChineseZodiac.Rabbit - BirthDateTime.Year) % 12) == 0)
                {
                    return "Rabbit";
                }
                else if ((Math.Abs((int)ChineseZodiac.Dragon - BirthDateTime.Year) % 12) == 0)
                {
                    return "Dragon";
                }
                else if ((Math.Abs((int)ChineseZodiac.Snake - BirthDateTime.Year) % 12) == 0)
                {
                    return "Snake";
                }
                else if ((Math.Abs((int)ChineseZodiac.Horse - BirthDateTime.Year) % 12) == 0)
                {
                    return "Horse";
                }
                else if ((Math.Abs((int)ChineseZodiac.Goat - BirthDateTime.Year) % 12) == 0)
                {
                    return "Goat";
                }
                else if ((Math.Abs((int)ChineseZodiac.Monkey - BirthDateTime.Year) % 12) == 0)
                {
                    return "Monkey";
                }
                else if ((Math.Abs((int)ChineseZodiac.Rooster - BirthDateTime.Year) % 12) == 0)
                {
                    return "Rooster";
                }
                else if ((Math.Abs((int)ChineseZodiac.Dog - BirthDateTime.Year) % 12) == 0)
                {
                    return "Dog";
                }
                else
                {
                    return "Pig";
                }
            }
        }

        internal bool IsBirthday
        {
            get
            {
                if (DateTime.Now.Month == BirthDateTime.Month && DateTime.Now.Day == BirthDateTime.Day)
                {
                    return true;
                }
                return false;
            }
        }

    }
}