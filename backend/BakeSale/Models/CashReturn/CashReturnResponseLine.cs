namespace BakeSale.Models.CashReturn
{
    public readonly struct CashReturnResponseLine
    {
        public CashReturnResponseLine(decimal value, int count)
        {
            Value = value; 
            Count = count;
        }
        public decimal Value { get; }
        public int Count { get; }
    }
}
