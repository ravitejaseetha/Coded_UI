using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading
{
    class Distance
{
    public int Values
    {
        get;
        set;
    }
    public static Distance operator + ( Distance d1, Distance d2)
    {
        Distance d = new Distance();
        d.Values = d1.Values + d2.Values;
        return d;
    }


    //public static int operator +(int d1, int d2)
    //{
    //    //Distance d = new Distance();
    //    //d.Values = d1 + d2;
    //    return 2;
    //}
}
class Program
{
    static void Main ( string[ ] args )
    {
        String[] val = new string[4] { "ad", "ads", "Dsds", "ASdas" };

        for(int i=0;i<val.Length;i++)
        {
            val[i] = val[i].ToString().ToLower();

        }
        Distance d1 = new Distance();
        Distance d4 = new Distance();
        d1.Values = 10;
        d4.Values = 20;
        Distance d3 = d1 + d4 + d1;
        //int x = 12, y = 14;
        //int d5 = x + y;
        Console.WriteLine("Sum is {0}", d3.Values );
        Console.Read();
    }
}
}
