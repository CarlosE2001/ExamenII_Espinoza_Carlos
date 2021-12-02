using Pizza4U.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Pizza4U.Handlers {
    public class ItemHandler : DatabaseHandler {

        public List<ItemModel> GetAllItems() {
            List<ItemModel> items = new List<ItemModel>();

            string query = "SELECT * FROM Item";
            DataTable resultingTable = CreateTableFromQuery(query);

            foreach (DataRow row in resultingTable.Rows) {
                items.Add(CreateItemInstance(row));
            }

            return items;
        }

        public ItemModel GetItemById(int id) {
            ItemModel item = null;

            string query = "SELECT * FROM Item WHERE Id = " + id;
            DataTable resultingTable = CreateTableFromQuery(query);

            item = CreateItemInstance(resultingTable.Rows[0]);

            return item;
        }

        public ItemModel CreateItemInstance(DataRow row) {
            return new ItemModel {
                Id = Convert.ToInt32(row["Id"]),
                Product = Convert.ToString(row["Producto"]),
                Description = Convert.ToString(row["Descripcion"]),
                Price = Convert.ToDouble(row["Precio"]),
                ImgUrl = Convert.ToString(row["FotoUrl"])
            };
        }

        public bool InsertItem(ItemModel item) {
            bool success = false;
            string query = "INSERT INTO Item(Producto,Descripcion,Precio,FotoUrl)" +
                            "VALUES(@product,@description,@price,@imgUrl)";
            SqlCommand queryCommand = new SqlCommand(query, connection);
            AddParametersToQueryCommand(queryCommand, item);

            success = DatabaseQuery(queryCommand);

            return success;
        }

        public void AddParametersToQueryCommand(SqlCommand command, ItemModel item) {
            command.Parameters.AddWithValue("@product", item.Product);
            command.Parameters.AddWithValue("@description", item.Description);
            command.Parameters.AddWithValue("@price", item.Price);
            command.Parameters.AddWithValue("@imgUrl", item.ImgUrl);
        }

    }
}