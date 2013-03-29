using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZHAW.SoftwareProjekt.Fractals.DataStructures
{
    [TestClass]
    public class BigFloatTests
    {

        [TestMethod]
        public void ZuweisungsTests()
        {
            BigFloat bd7 = "10230.1020300";
            Assert.AreEqual("10230.10203", bd7.ToString(), "0 Zuweisung per String --> fehlerhaft");

            BigFloat bd1 = 123.456m;
            Assert.AreEqual("123.456", bd1.ToString(), "Zuweisung per Dezimal --> fehlerhaft");

            BigFloat bd2 = "123.456";
            Assert.AreEqual("123.456", bd2.ToString(), "Zuweisung per String --> fehlerhaft");

            BigFloat bd3 = "-123.456";
            Assert.AreEqual("-123.456", bd3.ToString(), "Zuweisung per String Negativ --> fehlerhaft");

            BigFloat bd4 = -123.456m;
            Assert.AreEqual("-123.456", bd4.ToString(), "Zuweisung per Dezimal Negativ --> fehlerhaft");

            BigFloat bd5 = 0;
            Assert.AreEqual("0", bd5.ToString(), "0 Zuweisung per Dezimal --> fehlerhaft");

            BigFloat bd6 = 0;
            Assert.AreEqual("0", bd6.ToString(), "0 Zuweisung per String --> fehlerhaft");

        }

        [TestMethod]
        public void AdditionSubtraktionsTests()
        {
            BigFloat bd1 = 123.123m;
            BigFloat bd2 = 123.123m;
            BigFloat r = bd1 + bd2;
            Assert.AreEqual("246.246", r.ToString(), "Addition ohne Überlauf --> fehlerhaft");

            bd1 = 123.123m;
            bd2 = 123.123m;
            r = bd1 - bd2;
            Assert.AreEqual("0", r.ToString(), "Subtraktion ohne Überlauf --> fehlerhaft");

            bd1 = 123.456m;
            bd2 = 123.456m;
            r = bd1 + bd2;
            Assert.AreEqual("246.912", r.ToString(), "Addition mit Überlauf nach dem Dezimalpunkt --> fehlerhaft");

            bd1 = 456.456m;
            bd2 = 456.456m;
            r = bd1 + bd2;
            Assert.AreEqual("912.912", r.ToString(), "Addition mit Überlauf nach und vor dem Dezimalpunkt --> fehlerhaft");

            bd1 = 456.789m;
            bd2 = 456.789m;
            r = bd1 + bd2;
            Assert.AreEqual("913.578", r.ToString(), "Addition mit Überlauf nach und vor dem Dezimalpunkt und über den Dezimalpunkt --> fehlerhaft");

            bd1 = 879056709.213256854m;
            bd2 = 1447.987654321m;
            r = bd1 + bd2;
            Assert.AreEqual("879058157.200911175", r.ToString(), "Komplexe Addition 1 --> fehlerhaft");

            bd1 = -765.924m;
            bd2 = 1447.4098m;
            r = bd1 + bd2;
            Assert.AreEqual("681.4858", r.ToString(), "Komplexe Addition 2 --> fehlerhaft");

            bd1 = 765.924m;
            bd2 = -1447.4098m;
            r = bd1 + bd2;
            Assert.AreEqual("-681.4858", r.ToString(), "Komplexe Addition 3 --> fehlerhaft");

            bd1 = 765.924m;
            bd2 = -1447.4098m;
            r = bd1 - bd2;
            Assert.AreEqual("2213.3338", r.ToString(), "Komplexe Subtraktion 1 --> fehlerhaft");
        }

        [TestMethod]
        public void KombinierteTests()
        {
            BigFloat bd1 = 12.88m;
            BigFloat bd2 = 123.456m;
            BigFloat r = (bd1 + bd2) * (bd1 - bd2);
            Assert.AreEqual("-15075.489536", r.ToString(), "Kombinierte 1 --> fehlerhaft");

            bd1 = 12.88m;
            bd2 = -1;
            r = bd1 * bd2;
            Assert.AreEqual("-12.88", r.ToString(), "Kombinierte 2 --> fehlerhaft");

            bd1 = 123.123m;
            bd2 = 923.529123m;
            BigFloat r1 = bd1 + bd2;
            BigFloat r2 = r1 + bd2;
            BigFloat r3 = r2 + bd2;
            BigFloat r4 = r3 - bd2;
            BigFloat r5 = r4 - bd2;
            BigFloat r6 = r5 - bd2;
            Assert.AreEqual("123.123", r6.ToString(), "Kombinierte 3 --> fehlerhaft");

            bd1 = 12356789.987654321m;
            r = (bd1 * bd1 * bd1 * bd1);
            r = (r / bd1 / bd1 / bd1);
            Assert.AreEqual("12356789.987654321", r.ToString(), "Kombinierte 4 --> fehlerhaft");
        }

    }
}
