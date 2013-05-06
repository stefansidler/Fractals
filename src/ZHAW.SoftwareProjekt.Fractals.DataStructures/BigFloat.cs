using System;
using System.Numerics;

namespace ZHAW.SoftwareProjekt.Fractals.DataStructures
{
    public struct BigFloat
    {
        public BigInteger Value { get; set; }          // Beinhaltet in einem beliebiggrossen Array den Wert der Zahl
        public BigInteger Skalierung { get; set; }     // Wo befindet sich der Dezimalpunkt von Rechts aus
        public static int MaxGenauigkeit = 50;        // Genauigkeit

        public BigFloat(BigInteger value, BigInteger skalierung): this()
        {
            Value = value;
            Skalierung = skalierung;
            if (Value == 0)
            {
                Skalierung = 0;
            }
            while (Skalierung > BigFloat.MaxGenauigkeit && Value % BigInteger.Pow(10, BigFloat.MaxGenauigkeit) == 0)
            {
                Value /= BigInteger.Pow(10, BigFloat.MaxGenauigkeit);
                Skalierung -= BigFloat.MaxGenauigkeit;
            }
            while (Skalierung > 0 && Value % 10 == 0)
            {
                Value /= 10;
                Skalierung -= 1;
            }
        }

        public static implicit operator BigFloat(decimal dezimal) // Zuweisung mit "=", Achtung "m" nicht vergessen !!! (134.12345m)
        {
            var value = (BigInteger)dezimal;
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

        public static BigFloat operator +(BigFloat bigFloat1, BigFloat bigFloat2) // Addition
        {
            int skalierungsDifferenz = (int)(bigFloat1.Skalierung - bigFloat2.Skalierung);
            BigInteger neueSkalierung = 0;
            if (skalierungsDifferenz > 0)
            {
                bigFloat2.Value *= BigInteger.Pow(10, skalierungsDifferenz);
                neueSkalierung = bigFloat1.Skalierung;
            }
            else
            {
                bigFloat1.Value *= BigInteger.Pow(10, Math.Abs(skalierungsDifferenz));
                neueSkalierung = bigFloat2.Skalierung;
            }
            return Round(new BigFloat(bigFloat1.Value + bigFloat2.Value, neueSkalierung));
        }

        public static BigFloat operator -(BigFloat bigFloat1, BigFloat bigFloat2) // Subtraktion
        {
            var skalierungsDifferenz = (int)(bigFloat1.Skalierung - bigFloat2.Skalierung);
            BigInteger neueSkalierung = 0;
            if (skalierungsDifferenz > 0)
            {
                bigFloat2.Value *= BigInteger.Pow(10, skalierungsDifferenz);
                neueSkalierung = bigFloat1.Skalierung;
            }
            else
            {
                bigFloat1.Value *= BigInteger.Pow(10, Math.Abs(skalierungsDifferenz));
                neueSkalierung = bigFloat2.Skalierung;
            }
            return Round(new BigFloat(bigFloat1.Value - bigFloat2.Value, neueSkalierung));
        }

        public static BigFloat operator *(BigFloat bigFloat1, BigFloat bigFloat2) // Multiplikation
        {
            return Round(new BigFloat(bigFloat1.Value * bigFloat2.Value, bigFloat1.Skalierung + bigFloat2.Skalierung));
        }
        
        public static BigFloat operator /(BigFloat bigFloat1, BigFloat bigFloat2) // Division
        {
            BigInteger scale = BigInteger.Pow(10, BigFloat.MaxGenauigkeit + 1);
            BigInteger result = BigInteger.Divide(bigFloat1.Value * scale, bigFloat2.Value);
            return Round(new BigFloat(result, BigFloat.MaxGenauigkeit + 1 - bigFloat2.Skalierung + bigFloat1.Skalierung));
        }

        public static BigFloat Sqrt(BigFloat a)
        {
            if (a.Value == 0)
            {
                return new BigFloat(0, 0);
            }
            BigFloat x0;
            if (a.Value.Sign == -1)
            {
                return new BigFloat(0, 0);
            }
            else
            {
                x0 = DivisonSqrt((a + 1), 2);
                for (int i = 0; i < 20; i++)
                {
                    x0 = DivisonSqrt((x0 + DivisonSqrt(a, x0)), 2);
                }
            }
            return Round(x0);
        }

        public static BigFloat DivisonSqrt(BigFloat bigFloat1, BigFloat bigFloat2) // Division für SQRT --> ohne Runden
        {
            BigInteger scale = BigInteger.Pow(10, 2 * BigFloat.MaxGenauigkeit + 1);
            BigInteger result = BigInteger.Divide(bigFloat1.Value * scale, bigFloat2.Value);
            return new BigFloat(result, 2 * BigFloat.MaxGenauigkeit + 1 - bigFloat2.Skalierung + bigFloat1.Skalierung);
        }

        public static double Log(BigFloat a)
        {
            return BigInteger.Log10(a.Value) - (double)a.Skalierung;
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

        private static BigFloat Round(BigFloat bigFloat)
        {
            if (bigFloat.Skalierung > BigFloat.MaxGenauigkeit)
            {
                BigInteger roundBy = bigFloat.Skalierung - BigFloat.MaxGenauigkeit;
                BigInteger ValueNeu = bigFloat.Value / BigInteger.Pow(10, (int)roundBy);
                BigInteger rest = (bigFloat.Value / BigInteger.Pow(10, (int)roundBy - 1)) - (ValueNeu * 10);
                if (rest >= 5)
                {
                    ValueNeu += 1;
                }
                bigFloat.Value = ValueNeu;
                bigFloat.Skalierung -= roundBy;
            }
            return bigFloat;
        }

        public override string ToString()
        {
            string s = Value.ToString();
            if (Value.Sign == -1)
            {
                s = s.Substring(1, s.Length - 1);   
            }
            
            if (Skalierung != 0)
            {
                if (Skalierung > Int32.MaxValue) return "[Zu Grosse Skalierung --> Kann nicht angeziegt werden]";
                int dezimalpunkt = s.Length - (int)Skalierung;
                while (dezimalpunkt < 0)
                {
                    s = "0" + s;
                    dezimalpunkt++;
                }
                s = s.Insert(dezimalpunkt, dezimalpunkt == 0 ? "0." : ".");
                if (Value.Sign == -1)
                {
                    s = "-" + s;
                }
            }
            return s;
        }
    }
}
