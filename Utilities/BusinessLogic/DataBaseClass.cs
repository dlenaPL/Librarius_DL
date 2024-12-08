using Librarius_DL.Models.Entities;
using System.Linq;

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

        public static IQueryable<KeyAndValue> GetAllConditions()
        {
            return (
                from condition in DataBaseClass.Instance.Conditions
                select new KeyAndValue
                {
                    Key = condition.ConditionID,
                    Value = condition.ConditionName
                }).ToList().AsQueryable();
        }

        public static IQueryable<KeyAndValue> GetAllBooks()
        {
            return (
                from book in DataBaseClass.Instance.Books
                select new KeyAndValue
                {
                    Key = book.BookID,
                    Value = book.Title
                }).ToList().AsQueryable();
        }
    }
}
