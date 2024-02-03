using System;

namespace Sonosthesia.UI
{
    public readonly struct ChannelStreamUIData
    {
        public readonly int Count;
        public readonly string Description;
        public readonly TimeSpan Timestamp;

        public ChannelStreamUIData(int count, string description, TimeSpan timestamp)
        {
            Count = count;
            Description = description;
            Timestamp = timestamp;
        }
    }
    
    public readonly struct ChannelStreamUIData<TData> where TData : struct
    {
        public readonly int Count;
        public readonly TData Data;
        public readonly TimeSpan Timestamp;

        public ChannelStreamUIData(int count, TData data, TimeSpan timestamp)
        {
            Count = count;
            Data = data;
            Timestamp = timestamp;
        }
    }
}