using charity_management_system.Models;
using charity_management_system.Utils;
using System;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Collections.Generic;

namespace charity_management_system.Repositories
{
    class DonorRepo : IRepository<Donor>
    {
        private OracleConnection connection;
        private OracleCommand command;

        public DonorRepo()
        {
            connection = DBManager.instance.connection;
            command = new OracleCommand();
            command.Connection = connection;
        }
        public bool delete(Donor model)
        {
            command.CommandText = "delete from Donor where id =:DonorID";
            command.CommandType = System.Data.CommandType.Text;
            command.Parameters.Add("DonorID", model.id);
            int check = command.ExecuteNonQuery();
            
            if(check == -1)
            {
                return false;
            }
            return true;
        }

        public List<Donor> find(string column, string value)
        {
            command.CommandText = "select * from donor where :columnName =:value";
            command.CommandType = System.Data.CommandType.Text;
            command.Parameters.Add("columnName", column);
            command.Parameters.Add("value", value);

            OracleDataReader reader = command.ExecuteReader();
            List<Donor> Donors = new List<Donor>();
            while (reader.Read())
            {
                Donor donor = new Donor(int.Parse(reader["id"].ToString()),
                                        reader["name"].ToString(),
                                        reader["mobile"].ToString(),
                                        reader["address_line1"].ToString(),
                                        reader["city"].ToString(),
                                        reader["governorate"].ToString());
                donor.addressLine2 = reader["address_line2"].ToString();
                Donors.Add(donor);
            }
            reader.Close();
            return Donors;

        }

        public List<Donor> findAll()
        {
            command.CommandText = "select * from donor";
            command.CommandType = System.Data.CommandType.Text;

            OracleDataReader reader = command.ExecuteReader();
            List<Donor> Donors = new List<Donor>();
            while (reader.Read())
            {
                Donor donor = new Donor(int.Parse(reader["id"].ToString()),
                                        reader["name"].ToString(),
                                        reader["mobile"].ToString(),
                                        reader["address_line1"].ToString(),
                                        reader["city"].ToString(),
                                        reader["governorate"].ToString());
                donor.addressLine2 = reader["address_line2"].ToString();
                Donors.Add(donor);
            }
            reader.Close();
            return Donors;
        }
            
        public Donor findByID(string id)
        {
            command.CommandText = "select * from donor where id=:donorID";
            command.CommandType = System.Data.CommandType.Text;
            command.Parameters.Add("donorID", id);
    
            OracleDataReader reader = command.ExecuteReader();
            Donor foundDonor;
            if (reader.Read())
            {
                foundDonor = new Donor(int.Parse(reader["id"].ToString()),
                                        reader["name"].ToString(),
                                        reader["mobile"].ToString(),
                                        reader["address_line1"].ToString(),
                                        reader["city"].ToString(),
                                        reader["governorate"].ToString());
                foundDonor.addressLine2 = reader["address_line2"].ToString();
            }
            else
            {
                reader.Close();
                return null;
            }
            reader.Close();
            return foundDonor;

        }
        //insert
        public Donor save(Donor model)
        {
            command.CommandText = "insert into donors values (:name, :mobile, :address_line1, :address_line2, :city, :governorate)";
            command.CommandType = System.Data.CommandType.Text;
            command.Parameters.Add("name", model.name);
            command.Parameters.Add("mobile", model.mobile);
            command.Parameters.Add("address_line1", model.addressLine1);
            command.Parameters.Add("address_line2", model.addressLine2);
            command.Parameters.Add("city", model.city);
            command.Parameters.Add("governorate", model.governorate);
            
            int check = command.ExecuteNonQuery();
            //if (check != -1)
            //{
            //    return model;
            //}
            return null;
        }

        public bool update(Donor newModel)
        {
            command.CommandText = "update donor set name =:name, mobile =:mobile, address_line1 =:address_line1, address_line2 =:address_line2, city =:city,  governorate =:governorate";
            command.CommandType = System.Data.CommandType.Text;
          
            command.Parameters.Add("name", newModel.name);
            command.Parameters.Add("mobile", newModel.mobile);
            command.Parameters.Add("address_line1", newModel.addressLine1);
            command.Parameters.Add("address_line2", newModel.addressLine2);
            command.Parameters.Add("city", newModel.city);
            command.Parameters.Add("governorate", newModel.governorate);

            int check = command.ExecuteNonQuery();
            if(check == -1)
            {
                return false;
            }
            return true;

        }   
    }
}
