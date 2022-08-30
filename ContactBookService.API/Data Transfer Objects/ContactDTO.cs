namespace ContactBookService.API.Data_Transfer_Objects
{
    public class ContactDTO
    {
        public int Id { get; private set; }
        public string FullName { get; private set; }
        public string PhoneNumber { get; private set; }

        public ContactDTO(int id, string fullName, string phoneNumber)
        {
            Id = id;
            FullName = fullName;
            PhoneNumber = phoneNumber;
        }

        //public ContactDTO()
        //{

        //}
    }
}