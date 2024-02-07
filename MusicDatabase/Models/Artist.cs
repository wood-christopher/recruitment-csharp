namespace MusicDatabase.Models
{
    public class Artist : BaseModel
    {
        private string _name {  get; set; }
        public string name { get {  return _name; } set { _name = value; } }
    }
}
