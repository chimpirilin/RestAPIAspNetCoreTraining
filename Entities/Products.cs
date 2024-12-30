namespace RestApi.Entities {
    public class Products(string name, string description, decimal price) {
        private string name = name;
        private string description = description;
        private decimal price = price;
        public string Name {
            get {return name;}
            set {name = value;}
        }

        public string Description {
            get {return description;}
            set {description = value;}
        }
        
        public decimal Price {
            get {return price;}
            set {price = value;}
        }    
    }
}