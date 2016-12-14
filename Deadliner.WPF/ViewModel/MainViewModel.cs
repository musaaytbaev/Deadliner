using Deadliner.Lib.DbModel;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;

namespace Deadliner.WPF.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { Set(() => Name, ref _name, value) ; }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set { Set(()=> Description, ref _description, value); }
        }

        private DateTime _date;

        public DateTime Date
        {
            get { return _date; }
            set { Set(() => Date, ref _date, value); }
        }

        private Priority _priority;

        public Priority Priority
        {
            get { return _priority; }
            set { Set(() => Priority, ref _priority, value); }
        }

        private Deadline _deadline;

        public Deadline Deadline
        {
            get { return _deadline; }
            set { Set(() => Deadline, ref _deadline, value); }
        }

        private List<Deadline> _deadlines;

        public List<Deadline> Deadlines
        {
            get { return _deadlines; }
            set { Set(() => Deadlines, ref _deadlines, value); }
        }

        public void AddDeadline()
        {

        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }
    }
}