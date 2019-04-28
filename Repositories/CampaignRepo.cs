using charity_management_system.Models;
using charity_management_system.Utils;
using System;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Collections.Generic;

namespace charity_management_system.Repositories
{
    class CampaignRepo : IRepository<Campaign>
    {
        private OracleConnection connection;
        private OracleCommand command;

        public CampaignRepo()
        {
            connection = DBManager.instance.connection;
            command = new OracleCommand();
            command.Connection = connection;
        }
        public bool delete(Campaign model)
        {
            command.CommandText = "delete from Campaign where id =:campaign_id";
            command.CommandType = System.Data.CommandType.Text;
            command.Parameters.Add("campaign_id", model.id);
            int check = command.ExecuteNonQuery();

            if (check == -1)
            {
                return false;
            }
            return true;
        }

        public List<Campaign> find(string column, string value)
        {
            command.CommandText = "select * from campaign where :columnName =:value";
            command.CommandType = System.Data.CommandType.Text;
            command.Parameters.Add("columnName", column);
            command.Parameters.Add("value", value);

            OracleDataReader reader = command.ExecuteReader();
            List<Campaign> Campaigns = new List<Campaign>();
            while (reader.Read())
            {
                Campaign campaign = new Campaign(
                                        reader["name"].ToString(),
                                        Convert.ToDateTime(reader["start_date"].ToString()),
                                        Convert.ToDateTime(reader["end_date"].ToString()));
                campaign.id = int.Parse(reader["id"].ToString());
                campaign.description = reader["description"].ToString();
                campaign.goal = reader["goal"].ToString();
                Campaigns.Add(campaign);
            }
            reader.Close();
            return Campaigns;

        }

        public List<Campaign> findAll()
        {
            command.CommandText = "select * from campaign";
            command.CommandType = System.Data.CommandType.Text;

            OracleDataReader reader = command.ExecuteReader();
            List<Campaign> Campaigns = new List<Campaign>();
            while (reader.Read())
            {
                Campaign campaign = new Campaign(
                                        reader["name"].ToString(),
                                        Convert.ToDateTime(reader["start_date"].ToString()),
                                        Convert.ToDateTime(reader["end_date"].ToString()));
                campaign.id = int.Parse(reader["id"].ToString());
                campaign.description = reader["description"].ToString();
                campaign.goal = reader["goal"].ToString();
                Campaigns.Add(campaign);

            }
            reader.Close();
            return Campaigns;
        }

        public Campaign findByID(string id)
        {
            command.CommandText = "select * from campaign where id=:campaign_id";
            command.CommandType = System.Data.CommandType.Text;
            command.Parameters.Add("campaign_id", id);

            OracleDataReader reader = command.ExecuteReader();
            Campaign campaign;
            if (reader.Read())
            {
                campaign = new Campaign(reader["name"].ToString(),
                                        Convert.ToDateTime(reader["start_date"].ToString()),
                                        Convert.ToDateTime(reader["end_date"].ToString()));
                campaign.id = int.Parse(reader["id"].ToString());
                campaign.description = reader["description"].ToString();
                campaign.goal = reader["goal"].ToString();
            }
            else
            {
                reader.Close();
                return null;
            }
            reader.Close();
            return campaign;

        }
        //insert
        public Campaign save(Campaign model)
        {
            command.CommandText = "insert into campaign values (:id, :name, :start_date, :end_date, :description, :goal)";
            command.CommandType = System.Data.CommandType.Text;
            command.Parameters.Add("id", model.id);
            command.Parameters.Add("name", model.name);
            command.Parameters.Add("start_date", model.startDate);
            command.Parameters.Add("end_date", model.endDate);
            command.Parameters.Add("description", model.description);
            command.Parameters.Add("goal", model.goal);

            int check = command.ExecuteNonQuery();
            if (check != -1)
            {
                return model;
            }
            return null;
        }

        public bool update(Campaign newModel)
        {
            command.CommandText = "update campaign set name =:name, start_date =:start_date, end_date =:end_date, description =:description, goal =:goal where id =: campaign_id";
            command.CommandType = System.Data.CommandType.Text;
            command.Parameters.Add("campaign_id", newModel.id);
            command.Parameters.Add("name", newModel.name);
            command.Parameters.Add("start_date", newModel.startDate);
            command.Parameters.Add("end_date", newModel.endDate);
            command.Parameters.Add("description", newModel.description);
            command.Parameters.Add("goal", newModel.goal);

            int check = command.ExecuteNonQuery();
            if (check == -1)
            {
                return false;
            }
            return true;

        }
    }
}
