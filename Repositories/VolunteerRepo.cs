using charity_management_system.Models;
using charity_management_system.Utils;
using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }

        public Volunteer findByID(string id)
        {
            throw new NotImplementedException();
        }

        public Volunteer save(Volunteer model)
        {
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
            command.Parameters.Add("currently_working", model.currentlyWorking);
            int check = command.ExecuteNonQuery();
            //should return volunteer
            return null;
        }

        public bool update(Volunteer newModel)
        {
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
            command.Parameters.Add("currently_working", newModel.currentlyWorking);
            int check = command.ExecuteNonQuery();
            if (check == -1)
            {
                return false;
            }
            return true;
        }
    }
}
