namespace MeetingAssist.Presentation.Model
{
    class User
    {

        #region Private Members

        private int _id;
        private string _name;
        private string _mailID;

        #endregion

        #region Properties
        
        // Gets or Sets Unique integer ID for the User
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        // Gets or Sets Name of the User
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        // Gets or Sets MailID of the User
        public string MailID
        {
            get { return _mailID; }
            set { _mailID = value; }
        }

        #endregion

        #region Constructors

        public User()
        { }

        public User(int Id, string Name, string MailID)
        {
            _id = Id;
            _name = Name;
            _mailID = MailID;
        }

        #endregion

    }
}
