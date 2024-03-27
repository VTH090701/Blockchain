namespace Blockchain.Data
{
    public class Sinature
    {
        public string id { get; set; }
        public List<Entry> entry { get; set; }
    }



    public class Entry
    {
        public string name { get; set; }
        public string birthday { get; set; }
        public int encounter { get; set; }
    }
}
