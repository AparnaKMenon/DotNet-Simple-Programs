using MeetingAssist.Presentation.Model;
using Npgsql;
using System;
using System.Collections.ObjectModel;

namespace MeetingAssist.DataAccess
{
    class UsersRepository
    {
        public UsersRepository()
        {
        }

        //Maintains the User collection locally
        static ObservableCollection<User> _users = new ObservableCollection<User>();

        
        /// Add a User        
        internal void Add(User user)
        {
            _users.Add(user);
        }

        
        /// Remove a user based on         
        /// User to remove</param>
        internal void Remove(User user)
        {
            _users.Remove(user);
        }

        
        /// Search for the entry with User ID        
        /// <param name="id">User ID</param>
        /// <returns></returns>
        internal User Search(int id)
        {
            //Get the users index in the collection
            int index = GetIndex(id);
            //If present then return the element
            if (index > -1)
                return _users[index];
            return null;
        }

        
        /// Search for the User ID in the collection and return the Index        
        /// <param name="id"></param>
        /// <returns></returns>
        private int GetIndex(int id)
        {
            int index = -1;
            //If Collection has Items
            if (_users.Count > 0)
            {
                //Loop through the collection
                for (int i = 0; i < _users.Count; i++)
                {
                    //If match
                    if (_users[i].Id == id)
                    {
                        index = i;
                        break;
                    }
                }
            }
            return index;
        }

        private void RemoveAll()
        {
            //If Collection has Items
            if (_users.Count > 0)
            {
                //Loop through the collection
                for (int i = 0; i < _users.Count; i++)
                {
                    //If match
                    _users.RemoveAt(i);
                }
            }
        }

        public ObservableCollection<User> FetchRepository()
        {
            RemoveAll();
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User Id=postgres; " +
                "Password=postgres;Database=myoffice;");
            conn.Open();
            String sql = "SELECT \"USER_ID\",\"NAME\",\"MAILID\" FROM \"USER\"";
            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            NpgsqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                User user = new User((int)dr[0], (string)dr[1], (string)dr[2]);
                Add(user);
            }
            return _users;
        }
    }
}

