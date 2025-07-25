﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _3_DataAccessLayerClinics.Models;

[Index(nameof(Phone), IsUnique = true)]

public partial class Patient
{
    public int ID { get; set; }

    public string FirstName { get; set; }

    public string SecondName { get; set; }

    public string ThirdName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Address { get; set; }
    [Required]

    public string Phone { get; set; }

    public int? Age { get; set; }

    public string Gender { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}