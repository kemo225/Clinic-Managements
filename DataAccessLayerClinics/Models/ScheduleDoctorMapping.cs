﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace _3_DataAccessLayerClinics.Models;

public partial class ScheduleDoctorMapping
{
    public int ID { get; set; }

    public int? DoctorID { get; set; }

    public int? DoctorScheduleID { get; set; } // ID AppointmentDoctor

    public decimal? DetectionCost { get; set; }

    public virtual Doctor Doctor { get; set; }

    public virtual DoctorSchedule DoctorSchedule { get; set; }
}