using MeetingAssist.Presentation.Model;
using System.Collections.ObjectModel;

namespace MeetingAssist.DataAccess
{
    class AttendeesRepository
    {
        public AttendeesRepository()
        {
        }

        //Maintains the User collection locally
        static ObservableCollection<User> _attendees = new ObservableCollection<User>();


        ///// Remove a user        
        ///// <param name="user">User to remove</param>
        //internal void Remove(User user)
        //{
        //    _attendees.Remove(user);
        //}


        /// Search for the entry with User ID        
        /// <param name="id">User ID</param>
        /// <returns></returns>
        internal User Search(int id)
        {
            //Get the users index in the collection
            int index = GetIndex(id);
            //If present then return the element
            if (index > -1)
                return _attendees[index];
            return null;
        }


        /// Search for the User ID in the collection and return the Index        
        /// <param name="id"></param>
        /// <returns></returns>
        private int GetIndex(int id)
        {
            int index = -1;
            //If Collection has Items
            if (_attendees.Count > 0)
            {
                //Loop through the collection
                for (int i = 0; i < _attendees.Count; i++)
                {
                    //If match
                    if (_attendees[i].Id == id)
                    {
                        index = i;
                        break;
                    }
                }
            }
            return index;
        }

        //private void RemoveAll()
        //{
        //    //If Collection has Items
        //    if (_attendees.Count > 0)
        //    {
        //        //Loop through the collection
        //        for (int i = 0; i < _attendees.Count; i++)
        //        {
        //            //If match
        //            _attendees.RemoveAt(i);
        //        }
        //    }
        //}

        public ObservableCollection<User> FetchRepository()
        {
            ObservableCollection<User> attendees = new ObservableCollection<User>();
            attendees = _attendees;
            return attendees;
        }

        /// Add a User         
        internal void Add(User user)
        {
            _attendees.Add(user);
        }
    }
}
