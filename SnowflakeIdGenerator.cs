namespace SnowflakeIdGeneratorForCSharp;

public sealed class SnowflakeIdGenerator
{
    private long lastTimestamp = -1L;
    private long sequence = 0L;

    private readonly long workerId;
    private readonly long datacenterId;

    private readonly object lockObj = new object();

    public SnowflakeIdGenerator(long workerId, long datacenterId)
    {        
        this.workerId = workerId;
        this.datacenterId = datacenterId;
    }

    public long CreateId()
    {
        lock (lockObj)
        {
            long timestamp = CurrentTimeMillis();

            if(timestamp != lastTimestamp)
            {
                sequence = 0L;
            }

            if(sequence++ >= 4095)
            {
                while(timestamp <= lastTimestamp)
                {
                    timestamp = CurrentTimeMillis();
                }
            }

            lastTimestamp = timestamp;
            long id =  (timestamp << 22) | (datacenterId << 17) | (workerId << 12) | sequence;
            return id;
        }
    }

    private static long CurrentTimeMillis()
    {
        return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }
}
