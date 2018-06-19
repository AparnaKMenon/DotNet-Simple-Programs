namespace MeetingAssist.Presentation.Model
{
    class MeetingRoom
    {
        #region Private Members
        private int _id;
        private string _name;

        #endregion

        #region Properties

        // Gets or Sets Unique integer ID for the Meeting Room
        public int RoomId
        {
            get { return _id; }
            set { _id = value; }
        }

        // Gets or Sets Name of the Meeting Room
        public string RoomName
        {
            get { return _name; }
            set { _name = value; }
        }

        #endregion

        #region Constructors

        public MeetingRoom(int id, string name)
        {
            _id = id;
            _name = name;
        }

        #endregion
    }
}
