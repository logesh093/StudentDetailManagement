﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Entity.Models;

public partial class StudentDetail
{
    public int Student_Id { get; set; }

    public string Student_Name { get; set; }

    public string Student_DOB { get; set; }

    public string Student_Gender { get; set; }

    public string Student_Course { get; set; }

    public string Student_ContactNumber { get; set; }

    public string Student_Email { get; set; }

    public string Student_Address { get; set; }

    public bool Is_Deleted { get; set; }

    public bool Is_English { get; set; }

    public bool Is_Mathmatics { get; set; }

    public bool Is_Physics { get; set; }

    public bool Is_Chemistry { get; set; }

    public bool Is_Biology { get; set; }

    public DateTime Create_Time_Stamp { get; set; }

    public DateTime Update_Time_Stamp { get; set; }
}