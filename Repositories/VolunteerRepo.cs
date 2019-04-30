using charity_management_system.Models;
using charity_management_system.Utils;
using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace charity_management_system.Repositories
{
    class VolunteerRepo : IRepository<Volunteer>
    {
        private OracleConnection connection;
        private OracleCommand command;

        public VolunteerRepo()
        {
            connection = DBManager.instance.connection;
            command = new OracleCommand();
            command.Connection = connection;
        }

        public bool delete(Volunteer model)
        {
            command = new OracleCommand();
            command.Connection = connection;

            command.CommandText = "delete_volunteer";
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add("ssn", model.SSN);
            int check = command.ExecuteNonQuery();
            if (check == -1)
            {
                return false;
            }
            return true;
        }

        public List<Volunteer> find(string column, string value)
        {
            throw new NotImplementedException();
        }

        public List<Volunteer> findAll()
        {
            command = new OracleCommand();
            command.Connection = connection;

            command.CommandText = "find_all_volunteers";
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add("volunteer", OracleDbType.RefCursor, ParameterDirection.Output);
            OracleDataReader reader = command.ExecuteReader();
            List<Volunteer> volunteers = new List<Volunteer>();

            while (reader.Read())
            {
                Volunteer volunteer = new Volunteer
                {
                    SSN = reader["ssn"].ToString(),
                    name = reader["name"].ToString(),
                    mobile = reader["mobile"].ToString(),
                    birthDate = Convert.ToDateTime(reader["birth_date"]),
                    gender = char.Parse(reader["gender"].ToString()),
                    addressLine1 = reader["address_line1"].ToString(),
                    addressLine2 = reader["address_line2"].ToString(),
                    city = reader["city"].ToString(),
                    governorate = reader["governorate"].ToString(),
                    email = reader["email"].ToString(),
                    branch = new Branch { id = int.Parse(reader["branch_id"].ToString()) },
                    //currentlyWorking = bool.Parse(reader["is_currently_working"].ToString())
                };
                volunteers.Add(volunteer);
            }
            reader.Close();
            return volunteers;

        }

        public Volunteer findByID(string id)
        {
            try
            {
                command = new OracleCommand();
                command.Connection = connection;

                command.CommandText = "find_volunteer_by_id";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("ssn", OracleDbType.Varchar2, 100).Direction = ParameterDirection.Output;
                command.Parameters.Add("name", OracleDbType.Varchar2, 100).Direction = ParameterDirection.Output;
                command.Parameters.Add("mobile", OracleDbType.Varchar2, 100).Direction = ParameterDirection.Output;
                command.Parameters.Add("birth_date", OracleDbType.Date).Direction = ParameterDirection.Output;
                command.Parameters.Add("gender", OracleDbType.Char, 1).Direction = ParameterDirection.Output;
                command.Parameters.Add("address_line1", OracleDbType.Varchar2, 100).Direction = ParameterDirection.Output;
                command.Parameters.Add("address_line2", OracleDbType.Varchar2, 100).Direction = ParameterDirection.Output;
                command.Parameters.Add("city", OracleDbType.Varchar2, 100).Direction = ParameterDirection.Output;
                command.Parameters.Add("governorate", OracleDbType.Varchar2, 100).Direction = ParameterDirection.Output;
                command.Parameters.Add("email", OracleDbType.Varchar2, 100).Direction = ParameterDirection.Output;
                command.Parameters.Add("branch_id", OracleDbType.Int32).Direction = ParameterDirection.Output;
                command.Parameters.Add("is_currently_working", OracleDbType.Decimal, 100).Direction = ParameterDirection.Output;

                command.ExecuteNonQuery();
                    Volunteer volunteer = new Volunteer
                    {
                        SSN = command.Parameters["ssn"].ToString(),
                        name = command.Parameters["name"].ToString(),
                        mobile = command.Parameters["mobile"].ToString(),
                        birthDate = Convert.ToDateTime(command.Parameters["birth_date"]),
                        gender = char.Parse(command.Parameters["gender"].ToString()),
                        addressLine1 = command.Parameters["address_line1"].ToString(),
                        addressLine2 = command.Parameters["address_line2"].ToString(),
                        city = command.Parameters["city"].ToString(),
                        governorate = command.Parameters["governorate"].ToString(),
                        email = command.Parameters["email"].ToString(),
                        branch = new Branch { id = int.Parse(command.Parameters["branch_id"].ToString()) },
                        currentlyWorking = bool.Parse(command.Parameters["is_currently_working"].ToString())
                    };
                return volunteer;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public Volunteer save(Volunteer model)
        {
            command = new OracleCommand();
            command.Connection = connection;

            command.CommandText = "save_volunteer";
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add("ssn", model.SSN);
            command.Parameters.Add("volunteer_name", model.name);
            command.Parameters.Add("volunteer_mobile", model.mobile);
            command.Parameters.Add("birth_date", model.birthDate);
            command.Parameters.Add("gender", model.gender);
            command.Parameters.Add("address_line1", model.addressLine1);
            command.Parameters.Add("address_line2", model.addressLine2);
            command.Parameters.Add("city", model.city);
            command.Parameters.Add("governorate", model.governorate);
            command.Parameters.Add("email", model.email);
            command.Parameters.Add("branch_id", model.branch.id);
            command.Parameters.Add("currently_working", 1);
            int check = command.ExecuteNonQuery();
            //should return volunteer
            return null;
        }

        public bool update(Volunteer newModel)
        {
            command = new OracleCommand();
            command.Connection = connection;

            command.CommandText = "update_volunteer";
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add("ssn", newModel.SSN);
            command.Parameters.Add("volunteer_name", newModel.name);
            command.Parameters.Add("volunteer_mobile", newModel.mobile);
            command.Parameters.Add("birth_date", newModel.birthDate);
            command.Parameters.Add("gender", newModel.gender);
            command.Parameters.Add("address_line1", newModel.addressLine1);
            command.Parameters.Add("address_line2", newModel.addressLine2);
            command.Parameters.Add("city", newModel.city);
            command.Parameters.Add("governorate", newModel.governorate);
            command.Parameters.Add("email", newModel.email);
            command.Parameters.Add("branch_id", newModel.branch.id);
            command.Parameters.Add("currently_working", 1);
            int check = command.ExecuteNonQuery();
            if (check == -1)
            {
                return false;
            }
            return true;
        }
    }
}
