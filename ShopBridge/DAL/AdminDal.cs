using ShopBridge.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ShopBridge.DAL
{
    public class AdminDal : DBConnection
    {
        public List<Item> GetListOfItems()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("GetListOfItems", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                List<Item> itemList = new List<Item>();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Item item = new Item()
                    {
                        ItemId = Convert.ToInt32(reader["ItemId"]),
                        Name = reader["Name"].ToString(),
                        Description = reader["Description"].ToString(),
                        Price = Convert.ToDecimal(reader["Price"]),
                        Quantity = Convert.ToInt32(reader["Quantity"]),
                        IsActive = Convert.ToBoolean(reader["IsActive"]),
                        DateOfCreation = reader["DateOfCreation"].ToString(),
                        DateOfUpdation = reader["DateOfUpdation"].ToString(),
                        DateOfDeletion = reader["DateOfDeletion"].ToString(),
                    };
                    itemList.Add(item);
                }

                return itemList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }


        public int InsertItem(Item itemObj)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("InsertItemInfo", con);

                cmd.Parameters.AddWithValue("@Name", itemObj.Name);
                cmd.Parameters.AddWithValue("@Description", itemObj.Description);
                cmd.Parameters.AddWithValue("@Price", itemObj.Price);
                cmd.Parameters.AddWithValue("@Quantity", itemObj.Quantity);

                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                int insertCustomer = cmd.ExecuteNonQuery();
                return insertCustomer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public int UpdateItem(Item itemObj)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("UpdateItemInfo", con);
                cmd.Parameters.AddWithValue("@ItemId", itemObj.ItemId);
                cmd.Parameters.AddWithValue("@Name", itemObj.Name);
                cmd.Parameters.AddWithValue("@Description", itemObj.Description);
                cmd.Parameters.AddWithValue("@Price", itemObj.Price);
                cmd.Parameters.AddWithValue("@Quantity", itemObj.Quantity);

                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public int DeleteItem(int itemId)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("DeleteItem", con);
                cmd.Parameters.AddWithValue("@ItemId", itemId);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
    }
}