public class BlockData
{
    public string Sender { get; private set; }

    public string Receiver { get; private set; }

    public decimal Amount { get; set; }

    public BlockData(string sender, string receiver, decimal amount)
    {
        this.Sender = sender;
        this.Receiver = receiver;
        this.Amount = amount;
    }
}