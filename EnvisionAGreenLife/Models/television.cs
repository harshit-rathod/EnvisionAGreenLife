//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EnvisionAGreenLife.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class television
    {
        public int Television_Id { get; set; }
        public Nullable<int> Submit_ID { get; set; }
        public string Brand_Reg { get; set; }
        public string Model_No { get; set; }
        public string Family_Name { get; set; }
        public string SoldIn { get; set; }
        public string Country { get; set; }
        public Nullable<decimal> screensize { get; set; }
        public Nullable<decimal> Screen_Area { get; set; }
        public string Screen_Tech { get; set; }
        public Nullable<decimal> Pasv_stnd_power { get; set; }
        public Nullable<decimal> Act_stnd_power { get; set; }
        public Nullable<decimal> Act_stnd_time { get; set; }
        public Nullable<decimal> Avg_mode_power { get; set; }
        public Nullable<decimal> Star { get; set; }
        public Nullable<decimal> SRI { get; set; }
        public Nullable<decimal> CEC { get; set; }
        public string SubmitStatus { get; set; }
        public Nullable<System.DateTime> ExpDate { get; set; }
        public Nullable<int> GrandDate { get; set; }
        public string Product_Class { get; set; }
        public string Availability_Status { get; set; }
        public Nullable<decimal> Star2 { get; set; }
        public string Product_Website { get; set; }
        public string Representative_Brand_URL { get; set; }
        public Nullable<decimal> Star_Rating_Index { get; set; }
        public string Star_Image_Large { get; set; }
        public string Star_Image_Small { get; set; }
        public string Power_supply { get; set; }
        public string Tuner_Type { get; set; }
        public string What_test_standard_was_used { get; set; }
        public string Registration_Number { get; set; }
        public Nullable<int> Type_Id { get; set; }
    
        public virtual appliance_types appliance_types { get; set; }
    }
}
