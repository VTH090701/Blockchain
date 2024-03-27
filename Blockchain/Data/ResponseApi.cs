namespace Blockchain.Data
{

    public class ResponseApi<T>
    {
        public string code { set; get; }   
        public string hints { set; get; }  
        public string message { set; get; }
        public string status {  set; get; }
        public string type { set; get; }
        public T value { set; get; }
    }


}
