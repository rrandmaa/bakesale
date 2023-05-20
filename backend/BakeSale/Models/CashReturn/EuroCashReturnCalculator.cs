namespace BakeSale.Models.CashReturn
{
    public static class EuroCashReturnCalculator
    {
        private static readonly decimal[] euroNotesAndCoins =
            {
                200m,
                100m,
                50m,
                20m,
                10m,
                5m,
                2m,
                1m,
                0.5m,
                0.2m,
                0.1m,
                0.05m,
                0.02m,
                0.01m
            };

        public static List<CashReturnResponseLine> FindReturnCurrencyNotes(decimal inputAmount)
        {
            int noteAndCoinCount = euroNotesAndCoins.Length;
            var output = new List<CashReturnResponseLine>();

            for (int i = 0; i < noteAndCoinCount; i++)
            {
                if (inputAmount >= euroNotesAndCoins[i])
                {
                    output.Add(new CashReturnResponseLine(
                        euroNotesAndCoins[i],
                        (int)Math.Floor(inputAmount / euroNotesAndCoins[i])));

                    inputAmount %= euroNotesAndCoins[i];
                }
            }

            return output;
        }
    }
}
