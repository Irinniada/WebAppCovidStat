using System;

namespace WebAppCovidStat
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string City { get; set; }
        public DateTime DayOfVaccination { get; set; }
        public string Vaccine { get; set; }
        public int VaccineDose { get; set; }
    }
}