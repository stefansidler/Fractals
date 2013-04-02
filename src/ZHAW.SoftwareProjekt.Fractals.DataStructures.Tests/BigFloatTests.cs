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
        public void BigFloat_Division_1()
        {
            BigFloat bd1 = 100m;
            BigFloat bd2 = 7;
            BigFloat r = bd1 / bd2;
            Assert.AreEqual("14.2857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857142857", r.ToString(), "BigFloat_Division_1 --> fehlerhaft");
        }

        [TestMethod]
        public void BigFloat_Multiplikation_1()
        {
            BigFloat bd1 = 100.0000200m;
            BigFloat bd2 = 7;
            BigFloat r = bd1 * bd2;
            Assert.AreEqual("700.00014", r.ToString(), "BigFloat_Multiplikation_1 --> fehlerhaft");
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

        [TestMethod]
        public void BigFloat_Sqrt_1()
        {
            BigFloat bd = 9;
            BigFloat r = BigFloat.Sqrt(bd);
            Assert.AreEqual("3", r.ToString(), "BigFloat_Sqrt_1 --> fehlerhaft");
        }

        [TestMethod]
        public void BigFloat_Sqrt_2()
        {
            BigFloat bd = 123.123456789m;
            BigFloat r = BigFloat.Sqrt(bd);
            Assert.AreEqual("11.096100972368627468175859791090330007720832711696802116109361236089261718398367348101621589465444258734824931025096485987410171359509247672361724078637226938022265035034920766149627848017852716234072694192812415291216342350009915276221055297649561805711276086923544156212570276142415556325185814825910714669758550009542609005773953543935242207310953545304976856000922202310324370466895518168260177945538336225091845293605755702001066297405207663842067981047003076776561139877409840316613250569617423610095153341584710700965669001631839270337992568276847792430515412238520801473307310789655609076113123924023763675077181969813754123954564553116026203123482712715112442459720729220359984043282859795909953948624013022537810785113859373699909662656051906123503138412961640327588388657574346344806847906153559040795315122991429640183310137537476629053954444892590283575513691726876440374789958346898830523634135450261147810809634778228534882619917231693204121203027334583658792303877719748085976906448197976536054", r.ToString(), "BigFloat_Sqrt_2 --> fehlerhaft");
        }

    }
}
