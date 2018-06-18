namespace MeetingAssist.Presentation.Model
{
    class User
    {
        public User()
        { }

        public User(int Id, string Name, string MailID)
        {
            _id = Id;
            _name = Name;
            _mailID = MailID;
        }

        private int _id;
        // Gets or Sets Unique integer ID for the User
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;
        // Gets or Sets Name of the User
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _mailID;
        // Gets or Sets MailID of the User
        public string MailID
        {
            get { return _mailID; }
            set { _mailID = value; }
        }
    }
}
