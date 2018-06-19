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
        static ObservableCollection<User> _users;
        
        /// Add a User        
        internal void Add(User user)
        {
            _users.Add(user);
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
            NpgsqlConnection conn = null;
            try
            {
                conn = DBUtil.GetDBConnection();
                conn.Open();
                String sql = "SELECT \"USER_ID\",\"NAME\",\"MAILID\" FROM \"USER\"";
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                NpgsqlDataReader dr = command.ExecuteReader();
                _users = new ObservableCollection<User>();
                while (dr.Read())
                {
                    User user = new User((int)dr[0], (string)dr[1], (string)dr[2]);
                    Add(user);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in FetchRepository : " + e.ToString());
                throw;
            }
            finally
            {
                conn.Close();
            }
            return _users;
        }
    }
}

