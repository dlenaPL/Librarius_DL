using Librarius_DL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Librarius_DL.Utilities
{
    public abstract class AllViewModel<T> : ViewModelBase
    {
        protected readonly LibraryEntities libraryEntities;

        private RelayCommand _loadCommand;
        public ICommand LoadCommand
        {
            get
            {
                if (_loadCommand == null)
                    _loadCommand = new RelayCommand(
                        execute: _ => Load(), 
                        canExecute: _ => true 
                    );
                return _loadCommand;
            }
        }

        private RelayCommand _addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                    _addCommand = new RelayCommand(
                        execute: _ => Add(), 
                        canExecute: _ => true 
                    );
                return _addCommand;
            }
        }

        //do sortowania
        public string SortField { get; set; }
        public List<string> SortComboboxItems 
        { 
            get
            {
                return GetComboboxSortList();
            }
        }
        public abstract List<string> GetComboboxSortList();

        private RelayCommand _sortCommand;
        public ICommand SortCommand
        {
            get
            {
                if (_sortCommand == null)
                    _sortCommand = new RelayCommand(
                        execute: _ => Sort(),
                        canExecute: _ => true
                    );
                return _sortCommand;
            }
        }

        public abstract void Sort();

        // do filtrowania

        public string FindField { get; set; }
        public List<string> FindComboboxItems
        {
            get
            {
                return GetComboboxFindList();
            }
        }
        public abstract List<string> GetComboboxFindList();

        private RelayCommand _findCommand;
        public ICommand FindCommand
        {
            get
            {
                if (_findCommand == null)
                    _findCommand = new RelayCommand(
                        execute: _ => Find(),
                        canExecute: _ => true
                    );
                return _findCommand;
            }
        }

        public abstract void Find();
        public string FindTextBox { get; set; }


        private ObservableCollection<T> _List;
        public ObservableCollection<T> List
        {

            get
            {
                if (_List == null)
                    Load();
                return _List;
            }

            set
            {
                _List = value;
                OnPropertyChanged();
            }
        }


        public AllViewModel()
        {
            libraryEntities = new LibraryEntities();
        }


        public abstract void Load();
        public abstract void Add();


    }
}
