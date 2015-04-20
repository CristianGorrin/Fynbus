using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.EF_DataInterfaces
{
    public interface IBasicInformation
    {
        int ID { get; }
        string Name { get; }
        int CVR { get; }
        string AltName { get; }
    }

    public interface IUser
    {
        int id { get; }
        string Acc { get; }
        string Email { get; }
    }

    public interface IOffersform_SingleVehicle
    {
        int ID { get; }
        int? GuaranteeID { get; }
        string RegistrationLetters { get; }
        int? RegistrationNumbers { get; }
        int PhoneNumber { get; }
        byte? VehicleType { get; }
        byte? StairMachineType { get; }
        byte? Highchairs { get; }
        string StreetName { get; }
        short StreetNumber { get; }
        short ZipCode { get; }
        string City { get; }
        string Municipality { get; }
        // { set up fee, hourly fee, hourly down time } for Weekdays, WeekdaysEvening and WeekendersHelligdage
        decimal[] Weekdays { get; }
        decimal[] WeekdaysEvening { get; }
        decimal[] WeekendersHelligdage { get; }
        decimal StairMachine { get; }
        string AdditionalInformation { get; }
    }
}
