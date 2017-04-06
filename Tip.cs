using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Tip
/// </summary>
public class Tip
{
    private double mealAmount; /*declaring it private to only show in this class*/
    private double tipPercent; /*double is a numerical value with decimals*/
    private const double TAXPERCENT = .101; /*can't change a const (constant)*/
    public Tip(double amount, double tipPerc)
    {
        mealAmount = amount;
        tipPercent = tipPerc;
    }

    public double CalculateTax()
    {
        return mealAmount * TAXPERCENT; /*method, once called it will send a number*/
    }

    public double CalculateTip()
    {
        return mealAmount * tipPercent;
    }

    public double Total()
    {
        return mealAmount + CalculateTax() + CalculateTip();
    }
}
