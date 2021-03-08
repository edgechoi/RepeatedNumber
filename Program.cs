using System;

namespace RepeatedNumber
{
    class Program
    {
        Program(String input)
        {
            try
            {
                Compute(UInt32.Parse(input));
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
            }
        }
        void Compute(UInt32 max)
        {
            if (max > 3037000499)
                throw new Exception();
            for (UInt32 p = 1; p <= max; p++)
            {
                Multiply(p);
            }
        }
        void Multiply(UInt32 p)
        {
            UInt64[] a = new UInt64[3];
            a[0] = p;
            for (int i = 1; i < 3; i++)
            {
                a[i] = a[i - 1] * p;
                if (!Decide(p, a[i]))
                    return;
            }
            Write(a);
        }
        bool Decide(UInt32 p, UInt64 n)
        {
            String pStr = p.ToString();
            String nStr = n.ToString();
            if (pStr.Equals(nStr.Substring(nStr.Length - pStr.Length)))
                return true;
            else
                return false;
        }
        void Write(UInt64[] a)
        {
            Console.Write(a[0] + " / ");
            Console.Write(a[1] + " / ");
            Console.WriteLine(a[2]);
        }

        static void Main(string[] args)
        {
            try
            {
                new Program(args[0]);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("No parameter");
            }
        }
    }
}
