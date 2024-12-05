using Librarius_DL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Librarius_DL.Utilities.BusinessLogic
{
    public static class DataBaseClass
    {


        private static LibraryEntities _instance;

        public static LibraryEntities Instance
        {
            get
            {
                if(_instance == null) 
                    _instance = new LibraryEntities();
                return _instance;
            }
        }

        //public LibraryEntities LibraryEntities { get; set; }
        //public DataBaseClass()
        //{
        //    this.LibraryEntities = LibraryEntities;
        //}

        public static IQueryable<KeyAndValue> GetAllStatuses()
        {
            return (
                from statuses in DataBaseClass.Instance.Statuses
                select new KeyAndValue
                {
                    Key = statuses.StatusID,
                    Value = statuses.StatusName
                }).ToList().AsQueryable();
        }
        public static IQueryable<KeyAndValue> GetAllPublishers()
        {
            return (
                from publisher in DataBaseClass.Instance.Publishers
                select new KeyAndValue
                {
                    Key = publisher.PublisherID,
                    Value = publisher.PublisherName
                }).ToList().AsQueryable();
        }


    }
}
