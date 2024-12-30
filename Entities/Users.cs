namespace RestApi.Entities {
    public class Users(string name, string email, string phone) {
        private int id = new Random().Next();
        private string name = name;
        private string email = email;
        private string phone = phone;

        public int Id {
            get {return id;}
        }
        public string Name {
            get {return name;}
            set {name = value;}
        }

        public string Email {
            get {return email;}
            set {email = value;}
        }
        
        public string Phone {
            get {return phone;}
            set {phone = value;}
        }    
    }
}