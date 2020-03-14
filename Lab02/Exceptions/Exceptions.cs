using System;

namespace KMA.CSharp2020.Lab02.Exceptions
{
    class ArgumentInvalidEmailException : ArgumentException //for wrong e-mail
    {
        public ArgumentInvalidEmailException(string message) : base(message)
        { }
    }

    class ArgumentExpiredDateException : ArgumentException //if date is too in past
    {
        public ArgumentExpiredDateException(string message) : base(message)
        { }
    }

    class ArgumentNonExistingDateException : ArgumentException //if date from future
    {
        public ArgumentNonExistingDateException(string message) : base(message)
        { }
    }
}
