﻿namespace Test3.Application.DTOs.Identity;

public class JwtSettings
{
    public string Key { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public double DurationInWeeks { get; set; }
}
