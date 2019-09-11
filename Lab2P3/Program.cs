/*
 * Tajbir Sandhu
 * 9/11/2019
 * CECS 275
 */
using System;

public class Program
{

    public static void Main()
    {
        Number myNumber = new Number(100000);
        myNumber.PrintMoney();
        myNumber.PrintNumber();
        myNumber.PrintDecimal();
        myNumber.PrintMoney();
        myNumber.PrintHexadecimal();
    }
}

class Number
{
    private PrintHelper _printHelper;

    public Number(int val)
    {
        _value = val;

        _printHelper = new PrintHelper();
        //subscribe to beforePrintEvent event
        _printHelper.beforePrintEvent += printHelper_beforePrintEvent;
    }
    //beforePrintevent handler
    static void printHelper_beforePrintEvent(object sender, EventArgs e)
    {
        Console.WriteLine("BeforPrintEventHandler: PrintHelper is going to print a value");
    }

    private int _value;

    //creates a property to edit _value
    public int Value
    {
        get { return _value; }
        set { _value = value; }
    }

    public void PrintMoney()
    {
        _printHelper.PrintMoney(_value);
    }

    public void PrintNumber()
    {
        _printHelper.PrintNumber(_value);
    }

    public void PrintDecimal()
    {
        _printHelper.PrintDecimal(_value);
    }

    public void PrintHexadecimal()
    {
        _printHelper.PrintHexadecimal(_value);
    }

    public void PrintTemperature()
    {
        _printHelper.PrintTemperature(_value);
    }
}

public class PrintHelper
{

    //declare event of type delegate
    public event EventHandler beforePrintEvent;

    protected virtual void OnBeforePrint(EventArgs e)
    {
        EventHandler handler = beforePrintEvent;
        if (handler != null)
        {
            handler(this, e);
        }
    }

    public PrintHelper()
    {

    }

    public void PrintNumber(int num)
    {
        //call delegate method before going to print
        if (beforePrintEvent != null)
            //raises the event
            beforePrintEvent(this, EventArgs.Empty);

        Console.WriteLine("Number: {0,-12:N0}", num);
    }

    public void PrintDecimal(int dec)
    {
        if (beforePrintEvent != null)
            beforePrintEvent(this, EventArgs.Empty);

        Console.WriteLine("Decimal: {0:G}", dec);
    }

    public void PrintMoney(int money)
    {
        if (beforePrintEvent != null)
            beforePrintEvent(this, EventArgs.Empty);

        Console.WriteLine("Money: {0:C}", money);
    }

    public void PrintTemperature(int num)
    {
        if (beforePrintEvent != null)
            beforePrintEvent(this, EventArgs.Empty);

        Console.WriteLine("Temperature: {0,4:N1} F", num);
    }
    public void PrintHexadecimal(int dec)
    {
        if (beforePrintEvent != null)
            beforePrintEvent(this, EventArgs.Empty);

        Console.WriteLine("Hexadecimal: {0:X}", dec);
    }
}