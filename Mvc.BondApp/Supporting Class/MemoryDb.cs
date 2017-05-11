
using LiteDB;


namespace Mvc.BondApp
{
    public class GridPayment
    {
        public string BONDSL { get; set; }
        public string BONDPREFIX { get; set; }
        public string BONDNO { get; set; }
        public string BONDVALUE { get; set; }
        //column.Add(o => o.BONDSL).Titled("Sl No");
        //column.Add(o => o.BONDPREFIX).Titled("Prefix");
        //column.Add(o => o.BONDNO).Titled("Bond No");
        //column.Add(o => o.BONDVALUE).Titled("Bond Value");
    }
    // Create your POCO class entity
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string[] Phones { get; set; }
        public bool IsActive { get; set; }
    }






    public class MemoryDb
    {
        private LiteDatabase _db;
        public MemoryDb()
        {

            //column.Add(o => o.BONDSL).Titled("Sl No");
            //column.Add(o => o.BONDPREFIX).Titled("Prefix");
            //column.Add(o => o.BONDNO).Titled("Bond No");
            //column.Add(o => o.BONDVALUE).Titled("Bond Value");
            // Open database (or create if doesn't exist)


        }

        public LiteDatabase CreateOrGetLiteDatabase()
        {

            _db = new LiteDatabase(System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/SampleDatabase.db"));
            return _db;
        }

        public LiteCollection<T> CreateOrGetCollection<T>(string collectionName) where T : class
        {
            // Get a collection (or create, if doesn't exist)
            var col = CreateOrGetLiteDatabase().GetCollection<T>(collectionName);
            return col;
        }

        public void InsertNewItemToCollection<T>(T newItem, string collectionName) where T : class
        {
            CreateOrGetCollection<T>(collectionName).Insert(newItem);

        }

        public void UpdateItemInCollection<T>(T newItem, string collectionName) where T : class
        {
            // Update a document inside a collection
            CreateOrGetCollection<T>(collectionName).Update(newItem);
        }

        public void DeleteItemInCollection<T>(T item, string collectionName) where T : class
        {
            // Update a document inside a collection
            CreateOrGetCollection<T>(collectionName).Delete(i => i.Equals(item));
        }











        //// Index document using document Name property
        //col.EnsureIndex(x => x.Name);

        //// Use LINQ to query documents
        //var results = col.Find(x => x.Name.StartsWith("Jo"));




    }
}