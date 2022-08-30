using System.ComponentModel.DataAnnotations;

namespace ContactBook.Razor.UI.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        public Contact(string fullName, string phoneNumber)
        {
            FullName = fullName;
            PhoneNumber = phoneNumber;
        }

        public Contact()
        {

        }
    }
}