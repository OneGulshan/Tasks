﻿using System.ComponentModel;

namespace DataAccessLayer.ViewModels
{
    public class CustomerVM
    {
        public int Std_Id { get; set; }
        [DisplayName("Name")]
        public string Std_Name { get; set; }
        [DisplayName("Class")]
        public string Std_Class { get; set; }
        [DisplayName("School Name")]
        public string Std_School { get; set; }
        [DisplayName("Address")]
        public string Std_Address { get; set; }
        [DisplayName("Mobile Number")]
        public string Std_Mobile { get; set; }
        [DisplayName("Image")]
        public string Std_Image { get; set; } = "";
        public int C_Id { get; set; }
        public int S_Id { get; set; }
        public int City_Id { get; set; }
        public List<CustomerVM> ListCustomer { get; set; }
        public List<CountryVm> ListCountry { get; set; }
        public List<StateVm> ListState { get; set; }
        public List<CityVm> ListCity { get; set; }
    }
}
