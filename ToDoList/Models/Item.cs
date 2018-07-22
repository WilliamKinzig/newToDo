using System.Collections.Generic;
using MySql.Data.MySqlClient;
namespace ToDoList.Models
{
    public class Item
    {
        private int _id;
        private string _description;
        //private static List<Item> _instances = new List<Item> {};

        public Item(string Description, int Id = 0)
        {
            _id = Id;
            _description = Description;
        }

        public string GetDescription()
        {
            return _description;
        }

        public void SetDescription(string newDescription)
        {
            _description = newDescription;
        }
        public int GetId()
        {
            return _id;
        }


        public static List<Item> GetAll()
        {
            List<Item> allItems = new List<Item> {};
//             cd ..MySqlConnection conn = DB.Connection();
//             conn.Open();
//             MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
//
// //SQL command. Teslls MySQL to select and return all entries in the items table.
//             cmd.CommandText = @"SELECT * FROM items;";
//
//             MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
//             while(rdr.Read())
//             {
//               int itemId = rdr.GetInt32(0);
//               string itemDescription = rdr.GetString(1);
//               Item newItem = new Item(itemDescription, itemId);
//               allItems.Add(newItem);
//             }
//             conn.Close();
//             if (conn != null)
//             {
//                 conn.Dispose();
//             }
            return allItems;
            //return _instances;
        }


        public static void DeleteAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM items;";

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
       }

       public static Item Find(int id)
       {
           MySqlConnection conn = DB.Connection();
           conn.Open();
           var cmd = conn.CreateCommand() as MySqlCommand;
           cmd.CommandText = @"SELECT * FROM items WHERE id = @thisId;";
           MySqlParameter thisId = new MySqlParameter();
           thisId.ParameterName = "@thisId";
           thisId.Value = id;
           cmd.Parameters.Add(thisId);
           var rdr = cmd.ExecuteReader() as MySqlDataReader;
           int itemId = 0;
           string itemDescription = "";
           while (rdr.Read())
           {
               itemId = rdr.GetInt32(0);
               itemDescription = rdr.GetString(1);
           }
           Item foundItem= new Item(itemDescription, itemId);
           conn.Close();
           if (conn != null)
           {
               conn.Dispose();
           }
           return foundItem;
       }

        // public static void ClearAll()
        // {
        //     _instances.Clear();
        // }
        // public static Item Find(int searchId)
        // {
        //     return _instances[searchId-1];
        // }































    }
}
