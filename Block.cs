using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

public class Block
{
    public string Hash { get; private set; }

    public string PreviousHash { get; private set; }

    public DateTime TimeStamp { get; private set; }

    public BlockData Data { get; private set; }

    public int Salt { get; private set; }

    public string CalculateHash()
    {
        this.Salt = int.MinValue;

        var calculated = string.Empty;

        using (var sha256 = SHA256.Create())
        {
            while (!calculated.StartsWith("1979"))
            {
                var json = JsonSerializer.Serialize(new { this.Data, this.Salt, this.TimeStamp });

                var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(json));

                calculated = BitConverter.ToString(hash).Replace("-", "").ToLower();

                this.Salt++;
            }
        }

        return calculated;
    }

    public Block(string previousHash, BlockData data)
    {
        this.PreviousHash = previousHash;
        this.TimeStamp = DateTime.Now;
        this.Data = data;
        this.Hash = this.CalculateHash();
    }
}