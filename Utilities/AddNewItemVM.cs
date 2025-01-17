using Librarius_DL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Librarius_DL.Utilities
{
    public abstract class AddNewItemVM<T> : ViewModelBase
    {
        protected LibraryEntities libraryEntities;
        protected T item;

        private RelayCommand _addNewItemCommand;
        public ICommand AddNewItemCommand
        {
            get
            {
                if (_addNewItemCommand == null)
                    _addNewItemCommand = new RelayCommand(
                        execute: _ => Add(),
                        canExecute: _ => true
                    );
                return _addNewItemCommand;
            }
        }

        private RelayCommand _cancelCommand;
        public ICommand CancelCommand
        {
            get
            {
                if (_cancelCommand == null)
                    _cancelCommand = new RelayCommand(
                        execute: _ => Cancel(),
                        canExecute: _ => true
                    );
                return _cancelCommand;
            }
        }

        public AddNewItemVM()
        {
            libraryEntities = new LibraryEntities();
        }

        public abstract void Add();
        public abstract void Cancel();

        public virtual bool IsValid() => true;

    }
}
