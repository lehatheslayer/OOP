namespace Banks.Client
{
    public class ClientBuilder
    {
        private string _name;
        private string _secondName;
        private string _address = null;
        private string _passport = null;

        public ClientBuilder SetName(string name)
        {
            this._name = name;
            return this;
        }
        
        public ClientBuilder SetSecondName(string secondName)
        {
            this._secondName = secondName;
            return this;
        }
        
        public ClientBuilder SetAddress(string address)
        {
            this._address = address;
            return this;
        }
        
        public ClientBuilder SetPassport(string passport)
        {
            this._passport = passport;
            return this;
        }
        
        public Client Build()
        {
            return new Client(_name, _secondName, _address, _passport);
        }
    }
}