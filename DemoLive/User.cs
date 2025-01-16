using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLive
{
    public class User
    {
        public string Email { get; set; }
        public bool IsConnected { get; set; }

        public int Value { get; set; }

        public User(string email)
        {
            Email = email;
            IsConnected = false;
            Value = 0;
        }

        public void Connect()
        {
            IsConnected = true;
        }

        public string ReturnStringWithSomething(string myMessage)
        {
            return $"Quelques choses + {myMessage}";
        }

        public void AddFiveToValue()
        {
            if (!IsConnected)
                throw new Exception("User is not connected");

            if (Value < 0)
                throw new CannotUseNegativeNumber("Negative number are forbidden.");

            if (Value >= 1000)
                throw new CannotUseHigherThanThousandNumber("Can't add value to number higher than 1000");

            Console.WriteLine("Do something"); // On va pas le tester
            Value += 5;
        }

        public string ReturnEmail()
        {
            return Email;
        }
    }

    public class CannotUseNegativeNumber : Exception
    {
        public CannotUseNegativeNumber(string? message) : base(message)
        {
        }
    }

    public class CannotUseHigherThanThousandNumber : Exception
    {
        public CannotUseHigherThanThousandNumber(string? message) : base(message)
        {
        }
    }
}