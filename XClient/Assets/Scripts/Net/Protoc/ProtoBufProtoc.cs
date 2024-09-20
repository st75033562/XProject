using Google.Protobuf;
using System.Collections.Concurrent;

public class ProtoBufProtoc<T> : IProtoc<T> where T:class {

    private ConcurrentQueue<PCMD> queuePcmd = new ConcurrentQueue<PCMD> ();

    public void DealWith(byte[] data, int start, int length) {

        CodedInputStream inputStream = new CodedInputStream(data, start, length);
        PCMD pCMD = PCMD.Parser.ParseFrom(inputStream);

        queuePcmd.Enqueue(pCMD);
    }

    public T DequeueData() {
        if (queuePcmd.TryDequeue(out var data)) {
            return data as T;
        }
        return null;
    }

}