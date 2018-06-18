namespace MeetingAssist.Presentation.Model
{
    class MeetingRoom
    {
        public MeetingRoom(int id, string name)
        {
            _id = id;
            _name = name;
        }

        private int _id;
        // Gets or Sets Unique integer ID for the Meeting Room
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;
        // Gets or Sets Name of the Meeting Room
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
