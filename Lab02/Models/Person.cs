using KMA.CSharp2020.Lab02.Exceptions;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KMA.CSharp2020.Lab02
{
    internal class Person
    {
        #region Fields
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthDate;
        private string _westernZodiac;
        private string _chineseZodiac;
        static readonly string[] _westernZodiacSigns = {
            "Aquarius",            "Pisces",            "Aries",
            "Taurus",              "Gemini",            "Cancer",
            "Leo",                 "Virgo",             "Libra",
            "Scorpio",             "Sagittarius",       "Capricorn"};
        static readonly string[] _chineseZodiacSigns = {
            "Monkey",            "Rooster",            "Dog",
            "Pig",               "Rat",                "Ox",
            "Tiger",             "Rabbit",             "Dragon",
            "Snake",             "Horse",              "Goat"};
        #endregion

        #region Properties
        private string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }
        private string Email
        {
            get { return _email; }
            set
            {
                if (!Regex.IsMatch(value, "[\\w-+']+@[\\w\\.]+\\.\\w{2,3}"))
                    throw new ArgumentInvalidEmailException($"Email address '{value}' is invalid.");
                _email = value;
            }
        }

        public DateTime BirthDate
        {
            get { return _birthDate; }
            set
            {
                _birthDate = value;
                if (_birthDate.Year < DateTime.Today.Year - 135)
                    throw new ArgumentExpiredDateException($"{BirthDate.Date:D} is too old date.");
                if (_birthDate > DateTime.Today)
                    throw new ArgumentNonExistingDateException($"{BirthDate.Date:D} does not exist yet.");
                else FillProperties();
            }
        }

        public int Age
        {
            get
            {
                int res = DateTime.Now.Year - _birthDate.Year;
                return DateTime.Now < _birthDate.AddYears(res) ? res - 1 : res;
            }
        }

        public bool IsAdult { get { return Age >= 18; } }
        public bool IsBirthday { get { return BirthDate.Day == DateTime.Today.Day && BirthDate.Month == DateTime.Today.Month; } }
        public string SunSign { get { return _westernZodiac; } }
        public string ChineseSign { get { return _chineseZodiac; } }
        private string WesternZodiac { set { _westernZodiac = value; } }
        private string ChineseZodiac { set { _chineseZodiac = value; } }
        #endregion

        #region Constructors
        public Person(string name, string surname, DateTime birthDate)
        {
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
        }

        public Person(string name, string surname, string email)
        {
            Name = name;
            Surname = surname;
            Email = email;
        }

        public Person(string name, string surname, string email, DateTime birthDate)
        {
            Name = name;
            Surname = surname;
            Email = email;
            BirthDate = birthDate;
        }
        #endregion


        private async void FillProperties()
        {
            CalcWesternZodiac();
            await Task.Run(() => CalcChineseZodiac());
        }

        private void CalcWesternZodiac()
        {
            int m = BirthDate.Month;
            switch (m)
            {
                case 1:
                    WesternZodiac = BirthDate.Day < 20 ? _westernZodiacSigns[11] : _westernZodiacSigns[m - 1];
                    break;
                case 2:
                    WesternZodiac = BirthDate.Day < 19 ? _westernZodiacSigns[m - 2] : _westernZodiacSigns[m - 1];
                    break;
                case 3:
                    WesternZodiac = BirthDate.Day < 21 ? _westernZodiacSigns[m - 2] : _westernZodiacSigns[m - 1];
                    break;
                case 4:
                    WesternZodiac = BirthDate.Day < 20 ? _westernZodiacSigns[m - 2] : _westernZodiacSigns[m - 1];
                    break;
                case 5:
                    WesternZodiac = BirthDate.Day < 21 ? _westernZodiacSigns[m - 2] : _westernZodiacSigns[m - 1];
                    break;
                case 6:
                    WesternZodiac = BirthDate.Day < 21 ? _westernZodiacSigns[m - 2] : _westernZodiacSigns[m - 1];
                    break;
                case 7:
                    WesternZodiac = BirthDate.Day < 23 ? _westernZodiacSigns[m - 2] : _westernZodiacSigns[m - 1];
                    break;
                case 8:
                    WesternZodiac = BirthDate.Day < 23 ? _westernZodiacSigns[m - 2] : _westernZodiacSigns[m - 1];
                    break;
                case 9:
                    WesternZodiac = BirthDate.Day < 23 ? _westernZodiacSigns[m - 2] : _westernZodiacSigns[m - 1];
                    break;
                case 10:
                    WesternZodiac = BirthDate.Day < 23 ? _westernZodiacSigns[m - 2] : _westernZodiacSigns[m - 1];
                    break;
                case 11:
                    WesternZodiac = BirthDate.Day < 22 ? _westernZodiacSigns[m - 2] : _westernZodiacSigns[m - 1];
                    break;
                case 12:
                    WesternZodiac = BirthDate.Day < 22 ? _westernZodiacSigns[m - 2] : _westernZodiacSigns[m - 1];
                    break;
            }
        }

        private void CalcChineseZodiac() { ChineseZodiac = _chineseZodiacSigns[_birthDate.Year % 12]; }
    }
}