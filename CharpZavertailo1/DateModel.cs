using System;

namespace CharpZavertailo1
{
    internal class DateModel
    {
        internal int Age { get; }
        internal string ChineseZodiacSign { get; private set; }
        internal string WesternZodiacSign { get; private set; }
        internal DateModel(DateTime dayOfBirthday)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - dayOfBirthday.Year;
            if (now.Month < dayOfBirthday.Month || (now.Month == dayOfBirthday.Month && now.Day < dayOfBirthday.Day))
                age--;
            int delta = (DateTime.Today - dayOfBirthday).Days;
            if (age < 135 && delta >= 0)
            {
                var dayOfBDay = dayOfBirthday;
                Age = age;
                switch (dayOfBDay.Month)
                {
                    // According to wikipedia (Second variant)
                    case 1: // January
                        WesternZodiacSign = dayOfBDay.Day <= 20 ? "Capricorn" : "Aquarius";
                        break;
                    case 2:
                        WesternZodiacSign = dayOfBDay.Day <= 19 ? "Aquarius" : "Pisces";
                        break;
                    case 3:
                        WesternZodiacSign = dayOfBDay.Day <= 20 ? "Pisces" : "Aries";
                        break;
                    case 4:
                        WesternZodiacSign = dayOfBDay.Day <= 20 ? "Aries" : "Taurus";
                        break;
                    case 5:
                        WesternZodiacSign = dayOfBDay.Day <= 21 ? "Taurus" : "Gemini";
                        break;
                    case 6:
                        WesternZodiacSign = dayOfBDay.Day <= 21 ? "Gemini" : "Cancer";
                        break;
                    case 7:
                        WesternZodiacSign = dayOfBDay.Day <= 22 ? "Cancer" : "Leo";
                        break;
                    case 8:
                        WesternZodiacSign = dayOfBDay.Day <= 21 ? "Leo" : "Virgo";
                        break;
                    case 9:
                        WesternZodiacSign = dayOfBDay.Day <= 23 ? "Virgo" : "Libra";
                        break;
                    case 10:
                        WesternZodiacSign = dayOfBDay.Day <= 23 ? "Libra" : "Scorpio";
                        break;
                    case 11:
                        WesternZodiacSign = dayOfBDay.Day <= 22 ? "Scorpio" : "Sagittarius";
                        break;
                    case 12:
                        WesternZodiacSign = dayOfBDay.Day <= 22 ? "Sagittarius" : "Capricorn";
                        break;
                    default:
                        WesternZodiacSign = "Unknown";
                        break;
                }

                switch (dayOfBDay.Year % 12)
                {
                    case 0:
                        ChineseZodiacSign = "Monkey";
                        break;
                    case 1:
                        ChineseZodiacSign = "Rooster";
                        break;
                    case 2:
                        ChineseZodiacSign = "Dog";
                        break;
                    case 3:
                        ChineseZodiacSign = "Pig";
                        break;
                    case 4:
                        ChineseZodiacSign = "Rat";
                        break;
                    case 5:
                        ChineseZodiacSign = "Ox";
                        break;
                    case 6:
                        ChineseZodiacSign = "Tiger";
                        break;
                    case 7:
                        ChineseZodiacSign = "Rabbit";
                        break;
                    case 8:
                        ChineseZodiacSign = "Dragon";
                        break;
                    case 9:
                        ChineseZodiacSign = "Snake";
                        break;
                    case 10:
                        ChineseZodiacSign = "Horse";
                        break;
                    case 11:
                        ChineseZodiacSign = "Sheep";
                        break;
                    default:
                        ChineseZodiacSign = "Unknown";
                        break;

                }
            }
            else
                throw new Exception();
        }
    }
}
