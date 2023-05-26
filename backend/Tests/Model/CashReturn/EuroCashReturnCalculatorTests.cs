using BakeSale.Models.CashReturn;

namespace Tests.Model.CashReturn
{
    [TestClass]
    public class EuroCashReturnCalculatorTests
    {
        private static readonly List<CashReturnResponseLine> zeroResponseExpected = new();
        private static readonly List<CashReturnResponseLine> exactResponseExpected = new() 
        { 
            new CashReturnResponseLine(0.5m, 1), 
        };
        private static readonly List<CashReturnResponseLine> lowAmountResponseExpected = new()
        {
            new CashReturnResponseLine(0.5m, 1),
            new CashReturnResponseLine(0.2m, 1),
        };
        private static readonly List<CashReturnResponseLine> highAmountResponseExpected = new()
        {
            new CashReturnResponseLine(50m, 1),
            new CashReturnResponseLine(10m, 1),
            new CashReturnResponseLine(5m, 1),
            new CashReturnResponseLine(2m, 1),
            new CashReturnResponseLine(0.50m, 1),
            new CashReturnResponseLine(0.20m, 1),
            new CashReturnResponseLine(0.05m, 1),
        };

        [TestMethod] public void FindReturnCurrencyNotesEmptyTest()
        {
            decimal input = 0;
            var actual = EuroCashReturnCalculator.FindReturnCurrencyNotes(input);
            CollectionAssert.AreEqual(zeroResponseExpected, actual);
        }

        [TestMethod]
        public void FindReturnCurrencyNotesExactAmountTest()
        {
            decimal input = 0.5m;
            var actual = EuroCashReturnCalculator.FindReturnCurrencyNotes(input);
            CollectionAssert.AreEqual(exactResponseExpected, actual);
        }

        [TestMethod]
        public void FindReturnCurrencyNotesLowAmountTest()
        {
            decimal input = 0.7m;
            var actual = EuroCashReturnCalculator.FindReturnCurrencyNotes(input);
            CollectionAssert.AreEqual(lowAmountResponseExpected, actual);
        }

        [TestMethod]
        public void FindReturnCurrencyNotesHighAmountTest()
        {
            decimal input = 67.75m;
            var actual = EuroCashReturnCalculator.FindReturnCurrencyNotes(input);
            CollectionAssert.AreEqual(highAmountResponseExpected, actual);
        }
    }
}
