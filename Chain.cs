using System.Collections.Generic;
using CoreCoin;

public class Chain
{
    public LinkedList<Block> Blocks { get; } = new LinkedList<Block>();

    private Queue<BlockData> PendingBlockDatas { get; } = new Queue<BlockData>();

    public Chain()
    {
        var genesis = new Block(string.Empty, null);

        this.Blocks.AddFirst(genesis);
    }

    public void AddBlock(BlockData data)
    {
        this.PendingBlockDatas.Enqueue(data);
    }

    public void MineCoreCoin()
    {
        if (this.PendingBlockDatas.Count > 0)
        {
            var last = this.Blocks.Last.Value;

            var data = this.PendingBlockDatas.Dequeue();

            var block = new Block(last.Hash, data);

            this.Blocks.AddLast(block);

            this.PendingBlockDatas.Enqueue(new BlockData(string.Empty, Program.Me, 10));
        }
    }

    public bool IsChainValid()
    {
        var current = this.Blocks.First.Next;

        do
        {
            var block = current.Value;
            var previous = current.Previous.Value;

            if (block.Hash != block.CalculateHash())
            {
                return false;
            }
            if (block.PreviousHash != previous.Hash)
            {
                return false;
            }

        } while (current.Next != null);

        return true;
    }
}
