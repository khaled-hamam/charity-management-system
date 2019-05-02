using charity_management_system.Models;
using charity_management_system.Utils;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charity_management_system.Repositories
{
    public class ActivityRepo : IRepository<Activity>
    {
        private OracleConnection connection;
        private OracleCommand command;

        public ActivityRepo()
        {
            connection = DBManager.instance.connection;
            command = new OracleCommand();
            command.Connection = connection;
        }

        public bool delete(Activity model)
        {
            throw new NotImplementedException();
        }

        public List<Activity> find(string column, string value)
        {
            throw new NotImplementedException();
        }

        public List<Activity> findAll()
        {
            command = new OracleCommand();
            command.Connection = connection;

            command.CommandText = "select * from campaign_volunteer";
            command.CommandType = CommandType.Text;

            OracleDataReader reader = command.ExecuteReader();
            List<Activity> activities = new List<Activity>();
            while (reader.Read())
            {
                Activity activity = new Activity
                {
                    campaign = new Campaign() { id = (int)Convert.ToDecimal(reader["campaign_id"].ToString()) },
                    volunteer = new Volunteer() { SSN = reader["volunteer_ssn"].ToString() },
                    description = reader["description"].ToString()
                };
                activities.Add(activity);
            }

            reader.Close();
            return activities;
        }

        public Activity findByID(string id)
        {
            throw new NotImplementedException();
        }

        public Activity save(Activity model)
        {
            throw new NotImplementedException();
        }

        public bool update(Activity newModel)
        {
            throw new NotImplementedException();
        }
    }
}
