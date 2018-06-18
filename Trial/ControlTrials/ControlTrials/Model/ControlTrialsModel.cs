using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTrials.Model
{
    class Flower
    {
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { Name = value; }
        }

        public Flower(int i, string name)
        {
            _id = i;
            _name = name;
        }
    }
    class ControlTrialsModel
    {

        
    }
}
