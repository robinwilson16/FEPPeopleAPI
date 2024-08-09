namespace FEPPeopleAPI.Models
{
    public class Note
    {
        public int NoteID { get; set; }
        public int ObjectID { get; set; }
        public string? ObjectType { get; set; }
        public string? NoteText { get; set; }
    }
}
