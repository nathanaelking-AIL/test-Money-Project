namespace MoneyModule.Core.Domain
{
    public interface IMoney
    {
        decimal Amount { get; set; }
        string Currency { get; set; }
    }
}