namespace DefineClass
{
    using System.Collections.Generic;

    public class GSMTest
    {
        private List<GSM> testGSM = new List<GSM>();

        private GSM firstIPhone = new GSM(
                "NokiaX6",
                "Nokia",
                33.11,
                "Pesho Goshov",
                new Display(4, 333333333),
                new Battery(BatteryType.QuantumBattery, "Li-lon", 10, 4.5));

        private GSM secondIPhone = new GSM(
               "SamsungG7",
               "Samsung",
               55.67,
               "Ivan Goshov",
               new Display(8, 22222222),
               new Battery(BatteryType.SodiumSulfur, "So-Su", 5.5, 4.2));
        
        private GSM thirdIPhone = new GSM(
               "MotorolaTRX",
               "Motorola",
               100.62,
               "Dragan Ivanov",
               new Display(11, 99999999),
               new Battery(BatteryType.ZincCerium, "Zi-Cer", 14, 5.5));

        public GSMTest()
        {
            testGSM.Add(firstIPhone);
            testGSM.Add(secondIPhone);
            testGSM.Add(thirdIPhone);
        }

        public List<GSM> ListOFGSMs
        {
            get
            {
                return this.testGSM;
            }
        }
    }
}
