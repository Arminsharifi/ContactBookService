namespace ContactBookService.API.Models
{
    public class Contact
    {
        public int Id { get; private set; }
        public string FullName { get; private set; }
        public string PhoneNumber { get; private set; }
        public DateTime CreateDate { get; private set; }
        public bool isDeleted { get; private set; }

        public Contact(string fullName, string phoneNumber)
        {
            FullName = fullName;
            PhoneNumber = phoneNumber;
            CreateDate = DateTime.Now;
            isDeleted = false;
        }

        public Contact(int id, string fullName, string phoneNumber)
        {
            Id = id;
            FullName = fullName;
            PhoneNumber = phoneNumber;
            CreateDate = DateTime.Now;
            isDeleted = false;
        }

        public void Update(string fullName, string phoneNumber)
        {
            FullName = fullName;
            PhoneNumber = phoneNumber;
        }

        public void Delete()
        {
            isDeleted = true;
        }
    }
}