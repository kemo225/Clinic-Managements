﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace _3_DataAccessLayerClinics.Models;

public partial class Review
{
    public int ID { get; set; }

    public int? BookingID { get; set; }

    public int? PatientID { get; set; }

    public string Notes { get; set; }

    public DateTime? ReviewDate { get; set; }

    public int? DoctorID { get; set; }

    public virtual Booking Booking { get; set; }

    public virtual Doctor Doctor { get; set; }

    public virtual Patient Patient { get; set; }
}