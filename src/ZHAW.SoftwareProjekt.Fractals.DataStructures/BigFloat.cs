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
        public BigInteger Value { get; set; }          // Beinhaltet in einem beliebiggrossen Array den Wert der Zahl
        public BigInteger Skalierung { get; set; }     // Wo befindet sich der Dezimalpunkt von Rechts aus
        public static int DivisionsGenauigkeit = 100;        // Genauigkeit bei Division mit Rest

        public BigFloat(BigInteger value, BigInteger skalierung): this()
        {
            Value = value;
            Skalierung = skalierung;
            if (Value == 0)
            {
                Skalierung = 0;
            }
            if (Skalierung >= BigFloat.DivisionsGenauigkeit && Value % BigFloat.DivisionsGenauigkeit == 0) 
            {
                Skalierung -= BigFloat.DivisionsGenauigkeit;
                Value /= BigInteger.Pow(10, BigFloat.DivisionsGenauigkeit);
            }
            while (Skalierung > 0 && Value % 10 == 0)
            {
                Value /= 10;
                Skalierung -= 1;
            }
        }

        public static implicit operator BigFloat(decimal dezimal) // Zuweisung mit "=", Achtung "m" nicht vergessen !!! (134.12345m)
        {
            BigInteger value = (BigInteger)dezimal;
            BigInteger skalierung = 0;
            decimal faktor = 1m;
            while ((decimal)value != dezimal * faktor)
            {
                skalierung += 1;
                faktor *= 10;
                value = (BigInteger)(dezimal * faktor);
            }
            return new BigFloat(value, skalierung);
        }

        public static implicit operator BigFloat(string dezimal) // Zuweisung mit "=", als String
        {
            BigInteger skalierung = 0;
            if (dezimal.Contains("."))
            {
                char[] charsToTrim = {'0'};
                dezimal = dezimal.TrimEnd(charsToTrim);
                skalierung = (dezimal.Length - dezimal.IndexOf(".")) - 1;
                dezimal = dezimal.Replace(".", "");
            }
            return new BigFloat(BigInteger.Parse(dezimal), skalierung);
        }

        // Rechenoperationen -->
        public static BigFloat operator +(BigFloat bigFloat1, BigFloat bigFloat2) // Addition
        {
            int skalierungsDifferenz = (int)(bigFloat1.Skalierung - bigFloat2.Skalierung);
            BigInteger neueSkalierung = 0;
            if (skalierungsDifferenz > 0)
            {
                bigFloat2.Value = bigFloat2.Value * BigInteger.Pow(10, skalierungsDifferenz);
                neueSkalierung = bigFloat1.Skalierung;
            }
            else
            {
                bigFloat1.Value = bigFloat1.Value * BigInteger.Pow(10, Math.Abs(skalierungsDifferenz));
                neueSkalierung = bigFloat2.Skalierung;
            }
            return new BigFloat(bigFloat1.Value + bigFloat2.Value, neueSkalierung);
        }

        public static BigFloat operator -(BigFloat bigFloat1, BigFloat bigFloat2) // Subtraktion
        {
            int skalierungsDifferenz = (int)(bigFloat1.Skalierung - bigFloat2.Skalierung);
            BigInteger neueSkalierung = 0;
            if (skalierungsDifferenz > 0)
            {
                bigFloat2.Value = bigFloat2.Value * BigInteger.Pow(10, skalierungsDifferenz);
                neueSkalierung = bigFloat1.Skalierung;
            }
            else
            {
                bigFloat1.Value = bigFloat1.Value * BigInteger.Pow(10, Math.Abs(skalierungsDifferenz));
                neueSkalierung = bigFloat2.Skalierung;
            }
            return new BigFloat(bigFloat1.Value - bigFloat2.Value, neueSkalierung);
        }

        public static BigFloat operator *(BigFloat bigFloat1, BigFloat bigFloat2) // Multiplikation
        {
            return new BigFloat(bigFloat1.Value * bigFloat2.Value, bigFloat1.Skalierung + bigFloat2.Skalierung);
        }
        /*
        public static BigFloat operator /(BigFloat bigFloat1, BigFloat bigFloat2) // Division
        {
            BigInteger bigInteger = bigFloat1.Value * BigInteger.Pow(10, BigFloat.DivisionsGenauigkeit);
            return new BigFloat(bigInteger / bigFloat2.Value, bigFloat1.Skalierung - bigFloat2.Skalierung + BigFloat.DivisionsGenauigkeit);
        }
        */
        public static BigFloat operator /(BigFloat bigFloat1, BigFloat bigFloat2) // Division
        {
            BigInteger bigInteger = bigFloat1.Value * BigInteger.Pow(10, (BigFloat.DivisionsGenauigkeit + (int)bigFloat2.Skalierung + 1));
            BigInteger div = bigInteger / bigFloat2.Value;
            BigInteger temp = div / 10;
            BigInteger round = div - (temp * 10);
            if (round >= 5)
            {
                temp = temp + 1;
            }
            return new BigFloat(temp, bigFloat1.Skalierung - bigFloat2.Skalierung + BigFloat.DivisionsGenauigkeit + bigFloat2.Skalierung);
        }
        
        // <-- Rechenoperationen

        // Vergleichsoperationen -->
        public static bool operator ==(BigFloat bigFloat1, BigFloat bigFloat2) // Gleich
        {
            BigFloat differenz = bigFloat1 - bigFloat2;
            if (differenz.Value.Sign == 0)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(BigFloat bigFloat1, BigFloat bigFloat2) // Ungleich
        {
            BigFloat differenz = bigFloat1 - bigFloat2;
            if (differenz.Value.Sign != 0)
            {
                return true;
            }
            return false;
        }

        public static bool operator >(BigFloat bigFloat1, BigFloat bigFloat2) // Grösser
        {
            BigFloat differenz = bigFloat1 - bigFloat2;
            if (differenz.Value.Sign == 1) {
                return true;
            }
            return false;
        }

        public static bool operator >=(BigFloat bigFloat1, BigFloat bigFloat2) // Grösser Gleich
        {
            BigFloat differenz = bigFloat1 - bigFloat2;
            if (differenz.Value.Sign == 1 || differenz.Value.Sign == 0)
            {
                return true;
            }
            return false;
        }

        public static bool operator <(BigFloat bigFloat1, BigFloat bigFloat2) // Kleicner
        {
            BigFloat differenz = bigFloat1 - bigFloat2;
            if (differenz.Value.Sign == -1)
            {
                return true;
            }
            return false;
        }

        public static bool operator <=(BigFloat bigFloat1, BigFloat bigFloat2) // Kleiner Gleich
        {
            BigFloat differenz = bigFloat1 - bigFloat2;
            if (differenz.Value.Sign == -1 || differenz.Value.Sign == 0)
            {
                return true;
            }
            return false;
        }
        // <-- Vergleichsoperationen

        public static BigFloat Sqrt(BigFloat a)
        {
            if (a.Value == 0)
            {
                return new BigFloat(0,0);
            }
            BigFloat[] x = new BigFloat[50];
            if (a.Value.Sign == -1)
            {
                return new BigFloat(0,0);
            }
            else
            {
                x[0] = ((a+1)/2);    
                for (int i = 1; i < 50; i++)
                {
                    x[i] = (x[(i - 1)] + (a / x[(i - 1)])) / 2;
                }
            }
            return x[49];
        }

        public override string ToString()
        {
            string s = Value.ToString();
            if (Skalierung != 0)
            {
                if (Skalierung > Int32.MaxValue) return "[Zu Grosse Skalierung --> Kann nicht angeziegt werden]";
                int dezimalpunkt = s.Length - (int)Skalierung;
                s = s.Insert(dezimalpunkt, dezimalpunkt == 0 ? "0." : ".");
            }
            return s;
        }
    }
}
