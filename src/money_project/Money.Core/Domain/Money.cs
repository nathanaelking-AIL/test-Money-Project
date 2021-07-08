namespace MoneyModule.Core.Domain
{
    public class Money : IMoney
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }
}
