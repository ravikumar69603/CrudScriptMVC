using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Razor.Generator;
using WebAppScript.Models;

namespace WebAppScript.Servics
{
    public class CustumerServices
    {
        public string Connect = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        private SqlDataAdapter _adapter;
        private DataSet _ds;

        public IList<CustomerModel> getCustumerList()
        {
            IList<CustomerModel> list = new List<CustomerModel>();
            _ds = new DataSet();

            using (SqlConnection Con = new SqlConnection(Connect))
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("sp_custumer", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "List");
                _adapter = new SqlDataAdapter(cmd);
                _adapter.Fill(_ds);
                if (_ds.Tables.Count > 0)
                {
                    for (int i = 0; i < _ds.Tables[0].Rows.Count; i++)
                    {
                        CustomerModel obj = new CustomerModel();
                        obj.Id = Convert.ToInt32(_ds.Tables[0].Rows[i]["Id"]);
                        obj.EmailId = Convert.ToString(_ds.Tables[0].Rows[i]["EmailId"]);
                        obj.Name = Convert.ToString(_ds.Tables[0].Rows[i]["FirstName"]);
                        obj.Address = Convert.ToString(_ds.Tables[0].Rows[i]["Addres"]);
                        list.Add(obj);
                    }
                }
            }

            return list;
        }


        public void InsertCustumer(CustomerModel model)
        {
            using(SqlConnection con=new SqlConnection(Connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_custumer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "Add");
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@Emailid", model.EmailId);
                cmd.Parameters.AddWithValue("@Addres", model.Address);
                cmd.ExecuteNonQuery();
                
                    
            }

        }

        public CustomerModel GetCustomerById(int Id)
        {
            CustomerModel model = new CustomerModel();
            _ds = new DataSet();

            using (SqlConnection Con = new SqlConnection(Connect))
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("sp_custumer", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "GetById");
                cmd.Parameters.AddWithValue("@Id", Id);
                _adapter = new SqlDataAdapter(cmd);
                _adapter.Fill(_ds);
                if (_ds.Tables.Count > 0)
                {
                    model.Id = Convert.ToInt32(_ds.Tables[0].Rows[0]["Id"]);
                    model.EmailId = Convert.ToString(_ds.Tables[0].Rows[0]["EmailId"]);
                    model.Name = Convert.ToString(_ds.Tables[0].Rows[0]["FirstName"]);
                    model.Address = Convert.ToString(_ds.Tables[0].Rows[0]["Addres"]);

                }
            }

            return model;
        }

        public void UpdateCustumer(CustomerModel model)
        {
            using (SqlConnection con = new SqlConnection(Connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_custumer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "Update");
                cmd.Parameters.AddWithValue("@Id", model.Id);
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@Emailid", model.EmailId);
                cmd.Parameters.AddWithValue("@Addres", model.Address);
                cmd.ExecuteNonQuery();


            }

        }



        public void DeleteCustumer(int id)
        {
            using (SqlConnection con = new SqlConnection(Connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_custumer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "delete");
                cmd.Parameters.AddWithValue("@Id",id);
                cmd.ExecuteNonQuery();



            }

        }




    }
}