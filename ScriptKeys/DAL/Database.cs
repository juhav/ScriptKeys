namespace ScriptKeys.DAL
{
    using ScriptKeys.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Database
    {
        private const string databaseName = "keys.db";

        private class Collections
        {
            public const string Hotkey = "hotkey";
        }

        public List<HotKey> GetHotKeys()
        {
            using (var db = OpenLiteDB())
            {
                var items = db.GetCollection<HotKey>(Collections.Hotkey);
                return items.FindAll().ToList();
            }
        }

        public void SaveHotKey(HotKey hotkey)
        {
            using (var db = OpenLiteDB())
            {
                var items = db.GetCollection<HotKey>(Collections.Hotkey);
                var existing = items.FindById(hotkey.Id);

                if (existing != null)
                {
                    items.Update(hotkey);
                }
                else
                {
                    items.Insert(hotkey);
                }
            }
        }

        public void DeleteHotKey(HotKey hotkey)
        {
            using (var db = OpenLiteDB())
            {
                var items = db.GetCollection<HotKey>(Collections.Hotkey);

                items.Delete(hotkey.Id);
            }
        }

        private LiteDB.LiteDatabase OpenLiteDB()
        {
            return new LiteDB.LiteDatabase(databaseName);
        }


    }

}
