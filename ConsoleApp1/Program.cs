using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        private static char[] inlocuitor = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
        private static string n = "";
        private static int b1;
        private static int b2;
        private static long inBaza10 = 0;
        private static double inBaza10fr = 0;

        public static void Main(string[] args)
        {
            Nr();
            ConvertireIntregInBaza10();
            ConvertireFractInBaza10();
            ConvertireNrInAltaBaza();
        }

        private static void Nr()
        {

            Console.WriteLine("Introduceti baza numarului ");
            b1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Introduceti baza in care vreti sa fie convertit numarul ");
            b2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Introduceti un numar ");
            n = Console.ReadLine();

        }


        public static void ConvertireIntregInBaza10()
        {


            string nrintreg = n.Split('.')[0];
            int power = nrintreg.Length - 1;
            for (int i = 0; i < nrintreg.Length; i++)
            {
                inBaza10 += (long)Math.Pow(b1, power--) * Array.IndexOf(inlocuitor, nrintreg[i]);
            }

        }



        private static void ConvertireFractInBaza10()
        {

            string inBaza10 = string.Empty;
            try
            {
                inBaza10 = n.Split('.')[1];
            }
            catch
            {

            }


            List<int> n1 = new List<int>();
            List<int> n2 = new List<int>();
            int p = 1;
            for (int i = 0; i < inBaza10.Length; i++)
            {
                n1.Add(int.Parse(inBaza10[i].ToString()));
                n2.Add((int)Math.Pow(b1, p++));
            }

            int s = 0;
            int c = (int)Math.Pow(b1, --p);

            for (int i = 0; i < n1.Count; i++)
                s += n1[i] * (c / n2[i]);


            List<int> k = new List<int>();
            List<int> r = new List<int>();

            int r1 = s % c;
            r.Add(r1);
            bool fperiodica = false;
            do
            {
                k.Add(r1 * 10 / c);
                r1 = r1 * 10 % c;

                if (!r.Contains(r1)) r.Add(r1);
                else fperiodica = true;
            } while (r1 != 0 && fperiodica == false);

            string str = "0.";
            if (!fperiodica)
                foreach (int i in k)
                    str += i;
            else
                for (int i = 0; i < k.Count; i++)
                    str += k[i];


            inBaza10fr = double.Parse(str);
        }


        public static void ConvertireNrInAltaBaza()
        {

            string nrintr = "";
            while (inBaza10 > 0)
            {
                nrintr = inlocuitor[(int)inBaza10 % b2].ToString() + nrintr;
                inBaza10 /= b2;
            }

            string nrfract = "";
            int length = inBaza10fr.ToString().Length;
            double r = 0;
            for (int i = 0; i < length; i++)
            {
                inBaza10fr *= b2;
                nrfract += Math.Floor(inBaza10fr);
                inBaza10fr = inBaza10fr - Math.Floor(inBaza10fr);
                r = inBaza10fr;
            }

            string n = $"{nrintr}.{nrfract}";
            while (n.Length > 2 && n[n.Length - 1] == '0')
                n = n.Substring(0, n.Length - 2);

            if (n[n.Length - 1] == '.')
                n = n.Substring(0, n.Length - 2);

            Console.WriteLine($"Numarul convertit este {n}");
        }
    }
    //DOAR PT NR FARA VIRGULA
    /* static int val(char c)
    {
        if (c >= '0' && c <= '9')
            return (int)c - '0';
        else
            return (int)c - 'A' + 10;
    }

    // Convertire dintre baza oarecare intr o baza decimala(10)

    static int inDec(string str, int baza)
    {


        int l = str.Length;


        int p = 1;


        int n = 0;

        //  str[len-1]*1 + str[len-2]*baza + str[len-3]*(baza^2) + ...
        for (int i = l - 1; i >= 0; i--)
        {

            if (val(str[i]) >= baza)
            {
                Console.Write("Invalid Number");
                return -1;
            }


            n += val(str[i]) * p;


            p = p * baza;
        }
        return n;
    }


    static char Valoare(int n)
    {
        if (n >= 0 && n <= 9)
            return (char)(n + '0');
        else
            return (char)(n - 10 + 'A');
    }

    // Convertire din baza decimala intr-o alta baza
    static string dinDec(int baza, int n)
    {


        string rezultat = "";
        while (n > 0)
        {
            rezultat += Valoare(n % baza);
            n /= baza;
        }

        // Inversam rezultatul
        rezultat = inversare(rezultat);
        return rezultat;
    }

    // Convertim numarul dintr o baza in alta
    static void convertire(string s, int b1, int b2)
    {

        //Conveetim numarul din baza in baza b1 decimala
        int n = inDec(s, b1);

        // Convertim numarul din baza decimala in baza b2 (baza dorita)
        string rez = dinDec(b2, n);
        Console.WriteLine($"Numarul convertit este: {rez}");
    }

    static string inversare(string input)
    {
        char[] a = input.ToCharArray();
        int l, r = a.Length - 1;
        for (l = 0; l < r; l++, r--)
        {
            char x = a[l];
            a[l] = a[r];
            a[r] = x;
        }
        return new string(a);
    }


    static void Main(string[] args)
    {

        int b1, b2;
        Console.WriteLine("Introduceti baza in care este nr: ");
        b1 = int.Parse(Console.ReadLine());
        Console.WriteLine("Introduceti baza in care doriti sa convertiti: ");
        b2 = int.Parse(Console.ReadLine());
        Console.WriteLine("Introduceti secventa: ");
        string s = Console.ReadLine();

        if (b1 == b2)
        {
            Console.WriteLine(s);
        }
        else
            convertire(s, b1, b2);*/
}

