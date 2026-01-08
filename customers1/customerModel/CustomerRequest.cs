using System.ComponentModel.DataAnnotations;

namespace customers1.customerModel
{
    public class CustomerRequest
    {
        [Required (ErrorMessage = "the required name")]
        public string Name { get; set; }
        [Required (ErrorMessage = "the required email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "the required document")]
        public string Document { get; set; }
        [Required(ErrorMessage = "the required documentType")]
        public string DocumentType { get; set; }

    }
}
