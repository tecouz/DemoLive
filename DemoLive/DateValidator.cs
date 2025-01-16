using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLive
{
    public class DateValidator
    {
        private readonly string _date;
        private const int _numberOfDashes = 2;
        private const int _minDayNumber = 1;
        private const int _maxDayNumber = 31;
        private const int _minMonthNumber = 1;
        private const int _maxMonthNumber = 12;
        private const int _minYearNumber = 2000;
        private readonly int _maxYearNumber;
        private readonly string[] _splitted;

        public DateValidator(string date)
        {
            _date = date;
            _splitted = _date.Split('-');
            _maxYearNumber = DateTime.Now.Year;

            // Attention ici, ça nécessite de tester directement la fonction CheckNumberOfDashes
            // Depuis le constructeur, c'est un cas particulier à d'ailleurs éviter
            if (!CheckNumberOfDashes())
                throw new Exception("Le nombre de tirets présent dans la chaine n'est pas correct");
        }

        public bool IsValid()
        {
            return CheckNumberOfDashes()
                && CheckAllNumbersAreIntegers()
                && CheckDayNumber()
                && CheckMonthNumber()
                && CheckYearNumber();
        }

        public bool CheckNumberOfDashes()
        {
            return _splitted.Length == _numberOfDashes + 1;
        }

        public bool CheckAllNumbersAreIntegers()
        {
            return int.TryParse(_splitted[0], out _)
                && int.TryParse(_splitted[1], out _)
                && int.TryParse(_splitted[2], out _);
        }

        public bool CheckDayNumber()
        {
            ThrowExceptionIfNumbersAreNotIntegers();

            return Convert.ToInt32(_splitted[0]) >= _minDayNumber
                && Convert.ToInt32(_splitted[0]) <= _maxDayNumber;
        }

        public bool CheckMonthNumber()
        {
            ThrowExceptionIfNumbersAreNotIntegers();

            return Convert.ToInt32(_splitted[1]) >= _minMonthNumber
                && Convert.ToInt32(_splitted[1]) <= _maxMonthNumber;
        }

        public bool CheckYearNumber()
        {
            ThrowExceptionIfNumbersAreNotIntegers();

            return Convert.ToInt32(_splitted[2]) >= _minYearNumber
                && Convert.ToInt32(_splitted[2]) <= _maxYearNumber;
        }

        public void ThrowExceptionIfNumbersAreNotIntegers()
        {
            if (!CheckAllNumbersAreIntegers())
                throw new InvalidCastException("Toutes les partie de la date doivent être des entiers");
        }
    }
}
}
