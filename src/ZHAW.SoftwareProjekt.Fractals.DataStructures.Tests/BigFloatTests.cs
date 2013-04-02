using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZHAW.SoftwareProjekt.Fractals.DataStructures.Tests
{
    [TestClass]
    public class BigFloatTests
    {
        [TestMethod]
        public void BigFloat_Zuweisungs_1()
        {
            BigFloat bd = "10230.102030000";
            Assert.AreEqual("10230.10203", bd.ToString(), "BigFloat_Zuweisungs_1 'Nomerierung' --> fehlerhaft");
        }

        [TestMethod]
        public void BigFloat_Zuweisungs_2()
        {
            BigFloat bd = 123.4560m;
            Assert.AreEqual("123.456", bd.ToString(), "BigFloat_Zuweisungs_2 'Dezimal' --> fehlerhaft");
            bd = -123.4560m;
            Assert.AreEqual("-123.456", bd.ToString(), "BigFloat_Zuweisungs_2 'Negativ Dezimal' --> fehlerhaft");
            bd = 0;
            Assert.AreEqual("0", bd.ToString(), "BigFloat_Zuweisungs_2 '0 Dezimal' --> fehlerhaft");
        }

        [TestMethod]
        public void BigFloat_Zuweisungs_3()
        {
            BigFloat bd = "1230.4560";
            Assert.AreEqual("1230.456", bd.ToString(), "BigFloat_Zuweisungs_3 'String' --> fehlerhaft");
            bd = "-1230.4560";
            Assert.AreEqual("-1230.456", bd.ToString(), "BigFloat_Zuweisungs_3 'Negativ String' --> fehlerhaft");
            bd = "0";
            Assert.AreEqual("0", bd.ToString(), "BigFloat_Zuweisungs_3 '0 String' --> fehlerhaft");
        }

        [TestMethod]
        public void BigFloat_Addition_1()
        {
            BigFloat bd1 = 126.877000000000m;
            BigFloat bd2 = 123.12300001m;
            BigFloat r = bd1 + bd2;
            Assert.AreEqual("250.00000001", r.ToString(), "BigFloat_Addition_1 --> fehlerhaft");
        }

        [TestMethod]
        public void BigFloat_Addition_2()
        {
            BigFloat bd1 = -765.924m;
            BigFloat bd2 = 1447.4098m;
            BigFloat r = bd1 + bd2;
            Assert.AreEqual("681.4858", r.ToString(), "BigFloat_Addition_2 --> fehlerhaft");
        }

        [TestMethod]
        public void BigFloat_Subtraktion_1()
        {
            BigFloat bd1 = 126.877000000000m;
            BigFloat bd2 = 123.92300001m;
            BigFloat r = bd1 - bd2;
            Assert.AreEqual("2.95399999", r.ToString(), "BigFloat_Subtraktion_1 --> fehlerhaft");
        }

        [TestMethod]
        public void BigFloat_Subtraktion_2()
        {
            BigFloat bd1 = 126.877000000000m;
            BigFloat bd2 = -163.92306001m;
            BigFloat r = bd1 - bd2;
            Assert.AreEqual("290.80006001", r.ToString(), "BigFloat_Subtraktion_2 --> fehlerhaft");
        }

        [TestMethod]
        public void BigFloat_Vergleichsoperationen_1()
        {
            BigFloat bd1 = 123.123m;
            BigFloat bd2 = 123.123m;
            Assert.IsTrue(bd1 == bd2, "BigFloat_Vergleichsoperationen_1 '==' --> fehlerhaft");
            Assert.IsTrue(bd1 <= bd2, "BigFloat_Vergleichsoperationen_1 '<=' --> fehlerhaft");
            Assert.IsTrue(bd1 >= bd2, "BigFloat_Vergleichsoperationen_1 '>=' --> fehlerhaft");
            Assert.IsFalse(bd1 != bd2, "BigFloat_Vergleichsoperationen_1 '!=' --> fehlerhaft");
        }

        [TestMethod]
        public void BigFloat_Vergleichsoperationen_2()
        {
            BigFloat bd1 = 123.124m;
            BigFloat bd2 = 123.123m;
            Assert.IsTrue(bd1 > bd2, "BigFloat_Vergleichsoperationen_2 '>' --> fehlerhaft");
            Assert.IsTrue(bd1 >= bd2, "BigFloat_Vergleichsoperationen_2 '>=' --> fehlerhaft");
            Assert.IsFalse(bd1 < bd2, "BigFloat_Vergleichsoperationen_2 '<' --> fehlerhaft");
            Assert.IsFalse(bd1 <= bd2, "BigFloat_Vergleichsoperationen_2 '<=' --> fehlerhaft");
        }

        [TestMethod]
        public void BigFloat_Vergleichsoperationen_3()
        {
            BigFloat bd1 = 123.122m;
            BigFloat bd2 = 123.123m;
            Assert.IsTrue(bd1 < bd2, "BigFloat_Vergleichsoperationen_3 '<' --> fehlerhaft");
            Assert.IsTrue(bd1 <= bd2, "BigFloat_Vergleichsoperationen_3 '<=' --> fehlerhaft");
            Assert.IsFalse(bd1 > bd2, "BigFloat_Vergleichsoperationen_3 '>' --> fehlerhaft");
            Assert.IsFalse(bd1 >= bd2, "BigFloat_Vergleichsoperationen_3 '>=' --> fehlerhaft");
        }

        [TestMethod]
        public void BigFloat_Kombiniert_1()
        {
            BigFloat bd1 = 12.88m;
            BigFloat bd2 = 123.456m;
            BigFloat r = (bd1 + bd2) * (bd1 - bd2);
            Assert.AreEqual("-15075.489536", r.ToString(), "BigFloat_Kombiniert_1 --> fehlerhaft");
        }

        [TestMethod]
        public void BigFloat_Kombiniert_2()
        {
            BigFloat bd1 = 123.123m;
            BigFloat bd2 = 923.529123m;
            BigFloat r1 = bd1 + bd2;
            BigFloat r2 = r1 + bd2;
            BigFloat r3 = r2 + bd2;
            BigFloat r4 = r3 - bd2;
            BigFloat r5 = r4 - bd2;
            BigFloat r6 = r5 - bd2;
            Assert.AreEqual("123.123", r6.ToString(), "BigFloat_Kombiniert_2 --> fehlerhaft");
        }

        [TestMethod]
        public void BigFloat_Kombiniert_3()
        {
            BigFloat bd = 12356789.987654321m;
            BigFloat r = (bd * bd * bd * bd);
            r = (r / bd / bd / bd);
            Assert.AreEqual("12356789.987654321", r.ToString(), "BigFloat_Kombiniert_3 --> fehlerhaft");
        }
    }
}
