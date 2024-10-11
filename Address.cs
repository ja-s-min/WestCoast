﻿namespace WestCoast2;

public class Address
{
  public string AddressLine { get; set; } = "";
  public string PostalCode { get; set; } = "";
  public string City { get; set; } = "";

  
  public override string ToString()
  {
    return $"{AddressLine} Postnummer: {PostalCode} Stad: {City}";
  }


}
