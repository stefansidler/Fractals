using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Globalization;

namespace ZHAW.SoftwareProjekt.Fractals.DataStructures
{
    public struct BigFloat
    {
        public BigInteger _Value { get; set; }          // Beinhaltet in einem beliebiggrossen Array den Wert der Zahl
        public BigInteger _Skalierung { get; set; }     // Wo befindet sich der Dezimalpunkt von Rechts aus

        public BigFloat(BigInteger Value, BigInteger Skalierung): this()
        {
            _Value = Value;
            _Skalierung = Skalierung;
            while (Skalierung > 0 && Value % 10 == 0)
            {
                Value /= 10;
                Skalierung -= 1;
            }
        }

        public static implicit operator BigFloat(decimal Dezimal) // Zuweisung mit "=", Achtung "m" nicht vergessen !!! (134.12345m)
        {
            BigInteger value = (BigInteger)Dezimal;
            BigInteger skalierung = 0;
            decimal faktor = 1m;
            while ((decimal)value != Dezimal * faktor)
            {
                skalierung += 1;
                faktor *= 10;
                value = (BigInteger)(Dezimal * faktor);
            }
            return new BigFloat(value, skalierung);
        }

        public static implicit operator BigFloat(string Dezimal) // Zuweisung mit "=", als String
        {
            BigInteger skalierung = 0;
            if (Dezimal.Contains("."))
            {
                char[] charsToTrim = {'0'};

                Dezimal = Dezimal.TrimEnd(charsToTrim);
                skalierung = (Dezimal.Length - Dezimal.IndexOf(".")) - 1;
                Dezimal = Dezimal.Replace(".", "");
            }
            BigInteger value = BigInteger.Parse(Dezimal);
            return new BigFloat(value, skalierung);
        }

        // Rechenoperationen -->
        public static BigFloat operator +(BigFloat BigFloat1, BigFloat BigFloat2) // Addition
        {
            int SkalierungsDifferenz = (int)(BigFloat1._Skalierung - BigFloat2._Skalierung);
            BigInteger neueSkalierung = BigFloat1._Skalierung;
            if (SkalierungsDifferenz > 0)
            {
                BigFloat2._Value = BigFloat2._Value * BigInteger.Pow(10, SkalierungsDifferenz);
                neueSkalierung = BigFloat1._Skalierung;
            }
            else if (SkalierungsDifferenz <= 0)
            {
                BigFloat1._Value = BigFloat1._Value * BigInteger.Pow(10, Math.Abs(SkalierungsDifferenz));
                neueSkalierung = BigFloat2._Skalierung;
            }
            return Norm(new BigFloat(BigFloat1._Value + BigFloat2._Value, neueSkalierung));
        }

        public static BigFloat operator -(BigFloat BigFloat1, BigFloat BigFloat2) // Subtraktion
        {
            int SkalierungsDifferenz = (int)(BigFloat1._Skalierung - BigFloat2._Skalierung);
            BigInteger neueSkalierung = BigFloat1._Skalierung;
            if (SkalierungsDifferenz > 0)
            {
                BigFloat2._Value = BigFloat2._Value * BigInteger.Pow(10, SkalierungsDifferenz);
                neueSkalierung = BigFloat1._Skalierung;
            }
            else if (SkalierungsDifferenz <= 0)
            {
                BigFloat1._Value = BigFloat1._Value * BigInteger.Pow(10, Math.Abs(SkalierungsDifferenz));
                neueSkalierung = BigFloat2._Skalierung;
            }
            return Norm(new BigFloat(BigFloat1._Value - BigFloat2._Value, neueSkalierung));
        }

        public static BigFloat operator *(BigFloat BigFloat1, BigFloat BigFloat2) // Multiplikation
        {
            return new BigFloat(BigFloat1._Value * BigFloat2._Value, BigFloat1._Skalierung + BigFloat2._Skalierung);
        }

        public static BigFloat operator /(BigFloat BigFloat1, BigFloat BigFloat2) // Division
        {
            return new BigFloat(BigFloat1._Value / BigFloat2._Value, BigFloat1._Skalierung - BigFloat2._Skalierung);
        }
        // <-- Rechenoperationen

        public override string ToString()
        {
            string s = _Value.ToString();
            if (_Skalierung != 0)
            {
                if (_Skalierung > Int32.MaxValue) return "[Zu Grosse Skalierung --> Kann nicht angeziegt werden]";
                int Dezimalpunkt = s.Length - (int)_Skalierung;
                s = s.Insert(Dezimalpunkt, Dezimalpunkt == 0 ? "0." : ".");
            }
            return s;
        }

        private static BigFloat Norm(BigFloat BigFloat1)
        {
            if (BigFloat1._Value == 0)
            {
                BigFloat1._Skalierung = 0;
            }
            BigFloat BigFloat2 = BigFloat1.ToString();
            return BigFloat2;
        }
    }
}
