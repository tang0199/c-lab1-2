using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Furniture
/// </summary>
public class Furniture
{
    private string name;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    private string description;
    public string Description
    {
        get { return description; }
        set { description = value; }
    }

    private decimal cost;
    public decimal Cost
    {
        get { return cost; }
        set { cost = value; }
    }

    public Furniture(string name, string description,
      decimal cost)
    {
        Name = name;
        Description = description;
        Cost = cost;
    }
}