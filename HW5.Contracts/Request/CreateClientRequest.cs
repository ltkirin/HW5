using System;

namespace HW5.Contracts.Request
{
    public class CreateClientRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public ulong PhoneNumber { get; set; }
    }
}
