using System;
using System.Numerics;

namespace ZHAW.SoftwareProjekt.Fractals.DataStructures
{
    public struct BigFloat
    {
        public BigInteger Value { get; set; }          // Beinhaltet in einem beliebiggrossen Array den Wert der Zahl
        public BigInteger Skalierung { get; set; }     // Wo befindet sich der Dezimalpunkt von Rechts aus
        public static int MaxGenauigkeit = 50;        // Genauigkeit bei Division mit Rest

        public BigFloat(BigInteger value, BigInteger skalierung): this()
        {
            Value = value;
            Skalierung = skalierung;
            if (Value == 0)
            {
                Skalierung = 0;
            }
            if (Skalierung > MaxGenauigkeit && Value % BigInteger.Pow(10, MaxGenauigkeit) == 0)
            {
                Value /= BigInteger.Pow(10, MaxGenauigkeit);
                Skalierung -= MaxGenauigkeit;
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

        // Rechenoperationen -->
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
            if (bigFloat2.Value > bigFloat1.Value && bigFloat2.Value % 10 == 0)
            {
                while (bigFloat2.Value % 10 == 0)
                {
                    bigFloat2.Value /= 10;
                    bigFloat1.Skalierung += 1;
                }
            }
            BigInteger bigInteger = bigFloat1.Value * BigInteger.Pow(10, (MaxGenauigkeit + 1 + (int)bigFloat2.Skalierung + 1));
            BigInteger div = bigInteger / bigFloat2.Value;
            BigInteger temp = div / 10;
            BigInteger round = div - (temp * 10);
            if (round >= 5)
            {
                temp = temp + 1;
            }
            while (bigFloat2.Value % 10 == 0)
            {
                bigFloat2.Value /= 10;
                bigFloat1.Skalierung -= 1;
            }
            return Round(new BigFloat(temp, bigFloat1.Skalierung + BigFloat.MaxGenauigkeit + 1));
        }
        /*
        public static BigFloat operator /(BigFloat bigFloat1, BigFloat bigFloat2) // Division
        {
            BigInteger s1 = bigFloat1.Skalierung; // 3
            BigInteger v1 = bigFloat1.Value; // 100002
            BigInteger s2 = bigFloat2.Skalierung; // 0
            BigInteger v2 = bigFloat2.Value; // 2
            v1 *= BigInteger.Pow(10, BigFloat.MaxGenauigkeit + 1);
            BigInteger resultat = v1 / v2;
            while (bigFloat2.Value % 10 == 0)
            {
                bigFloat2.Value = bigFloat2.Value / 10;
                bigFloat1.Skalierung = bigFloat1.Skalierung - 1;
            }
            return Round(new BigFloat(resultat, bigFloat1.Skalierung + BigFloat.MaxGenauigkeit + 1));
        }
        */
        public static BigFloat Sqrt(BigFloat a)
        {
            if (a.Value == 0)
            {
                return new BigFloat(0, 0);
            }
            var x = new BigFloat[50];
            if (a.Value.Sign == -1)
            {
                return new BigFloat(0, 0);
            }
            else
            {
                x[0] = ((a + 1) / 2);
                for (int i = 1; i < 20; i++)
                {
                    x[i] = (x[(i - 1)] + (a / x[(i - 1)])) / 2;
                }
            }
            return Round(x[19]);
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
            if (bigFloat.Skalierung > MaxGenauigkeit)
            {
                BigInteger roundBy = bigFloat.Skalierung - MaxGenauigkeit;
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
            }
            return s;
        }
    }
}
