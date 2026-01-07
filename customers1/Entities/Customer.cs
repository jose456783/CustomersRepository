using customers1.customerModel;

namespace customers1.entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string ExternalId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Document { get; set; }
        public string DocumentType { get; set; }

        public Customer(CustomerRequest request) 
        {
            var randon = new Random();
            ExternalId = "cus" + randon.Next(99999);
            Name = request.Name;
            Document = request.Document;
            DocumentType = request.DocumentType;
            Email = request.Email;

        }

        protected Customer()
        {
            
        }

      
    }
}
