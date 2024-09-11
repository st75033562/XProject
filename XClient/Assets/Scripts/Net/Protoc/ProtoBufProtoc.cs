using Google.Protobuf;

public class ProtoBufProtoc : IProtoc {
    public void DealWith(byte[] data, int start, int length) {

        CodedInputStream inputStream = new CodedInputStream(data, start, length);

      //  MyMessage message = new MyMessage();
      //  message.MergeFrom(inputStream);
    }
}