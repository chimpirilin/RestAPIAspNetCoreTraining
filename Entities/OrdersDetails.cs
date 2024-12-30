namespace RestApi.Entities {
    public class OrdersDetails(int quantity, decimal subTotal) {
        private int quantity = quantity;
        private decimal subTotal = subTotal;
        public int Date {
            get {return quantity;}
            set {quantity = value;}
        }

        public decimal SubTotal {
            get {return subTotal;}
            set {subTotal = value;}
        }   
    }
}