using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ControlTrials.Model;

namespace ControlTrials.ViewModel
{
    class ControlTrialsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<Flower> _flowers;
        public ObservableCollection<Flower> Flowers
        {
            get { return _flowers; }
            set
            {
                _flowers = value;
                NotifyPropertyChanged();
            }
        }

        private Flower _selectedFlower;
        public Flower SelectedFlower
        {
            get { return _selectedFlower; }
            set
            {
                _selectedFlower = value;
            }
        }

        public ControlTrialsViewModel()
        {
            fillFlowersCombo();
        }

        private string _txtEdit;
        public string TxtEdit
        {
            get
            {
                return _txtEdit;
            }
            set
            {
                _txtEdit = value;
                OnPropertyChanged("txtTrial");
            }
        }

        private void fillFlowersCombo()
        {
            _flowers = new ObservableCollection<Flower>();
            _flowers.Add(new Flower(1, "Lily"));
            _flowers.Add(new Flower(2, "Jasmin"));
            _flowers.Add(new Flower(3, "Rose"));
            _flowers.Add(new Flower(4, "Violet"));
        }

        public void removeFlowers()
        {
            if (_flowers.Count > 2)
            {
                _flowers.RemoveAt(1);
            }
        }

        public void OnPropertyChanged(string propertyName)
        {
            //Fire the PropertyChanged event in case somebody subscribed to it
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

                if ("txtTrial" == propertyName)
                {
                    string str = _selectedFlower.Name;
                    removeFlowers();
                }
            }
        }

        private void MessageBox(string str)
        {
            throw new NotImplementedException();
        }
    }
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
