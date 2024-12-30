namespace RestApi.Entities {
    public class Orders(DateTime date, decimal total) {
        private DateTime date = date;
        private decimal total = total;
        public DateTime Date {
            get {return date;}
            set {date = value;}
        }

        public decimal Total {
            get {return total;}
            set {total = value;}
        }   
    }
}