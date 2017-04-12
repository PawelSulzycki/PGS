using System;

namespace PGS
{
    public class PersonalData
    {
        public int Id { get; set; }
        public string Name { get; set;}
        public string Surname { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public PersonalData(string name, string surname, string address, string phoneNumer)
        {
            Name = name;
            Surname = surname;
            Address = address;
            PhoneNumber = phoneNumer;
        }

        public override string ToString()
        {
            return Name + "\n" + Surname + "\n" + Address + "\n" + PhoneNumber;
        }
    }

}