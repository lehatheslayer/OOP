using System;
using System.Text.RegularExpressions;
using Banks.Exceptions;

namespace Banks.Client
{
    public class Client
    {
        private string _name;
        private string _secondName;
        private string _address = null;
        private string _passport = null;

        public Client(string name, string secondName, string address, string passport)
        {
            _name = name;
            _secondName = secondName;
            if (address.Length != 0)
                _address = address;
            if (passport.Length == 11)
                _passport = passport;
        } 
        
        public string Name
        {
            get => _name;
        }

        public string SecondName
        {
            get => _secondName;
        }

        public string Address
        {
            get => _address;
            set
            {
                if (_address != null)
                    throw new Exception("Адрес уже указан");
                else if (value.Length != 1)
                    _address = value;
                else 
                    throw new Exception("Строка адреса не может быть пустой");
            }
        }
        
        public string Passport
        {
            get => _passport;
            set
            {
                if (_passport != null)
                    throw new Exception("Паспорт уже указан");
                else if (value.Length == 11)
                    _passport = value;
            }
        }
    }
}