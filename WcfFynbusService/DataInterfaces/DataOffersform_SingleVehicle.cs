using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfFynbusService.DataInterfaces
{
    public class DataOffersform_SingleVehicle : Interface.EF_DataInterfaces.IOffersform_SingleVehicle
    {
        public int ID
        {
            get; set;
        }

        public int? GuaranteeID
        {
            get; set;
        }

        public string RegistrationLetters
        {
            get; set;
        }

        public int? RegistrationNumbers
        {
            get; set;
        }

        public int PhoneNumber
        {
            get; set;
        }

        public byte? VehicleType
        {
            get; set;
        }

        public byte? StairMachineType
        {
            get; set;
        }

        public byte? Highchairs
        {
            get; set;
        }

        public string StreetName
        {
            get; set;
        }

        public short StreetNumber
        {
            get; set;
        }

        public short ZipCode
        {
            get; set;
        }

        public string City
        {
            get; set;
        }

        public string Municipality
        {
            get; set;
        }

        public decimal[] Weekdays
        {
            get; set;
        }

        public decimal[] WeekdaysEvening
        {
            get; set;
        }

        public decimal[] WeekendersHelligdage
        {
            get; set;
        }

        public string AdditionalInformation
        {
            get; set;
        }

        public decimal StairMachine
        {
            get; set;
        }
    }
}
