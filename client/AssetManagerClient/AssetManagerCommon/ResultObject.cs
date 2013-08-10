using System.Runtime.Serialization;

namespace AssetManagerCommon
{
    public class ResultObject<T>
    {
        public int RetCode { get; set; }
        public T RetObject { get; set; }
        public string Message;// Error message
    }
}
