﻿namespace WpfApp1;

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => $"{LastName} {FirstName}";
    
}