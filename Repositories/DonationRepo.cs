using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using charity_management_system.Models;
using charity_management_system.Utils;
using Oracle.DataAccess.Client;

namespace charity_management_system.Repositories {
   public class DonationRepo : IRepository<Donation> {
        private OracleConnection connection;
        private OracleCommand command;

        public DonationRepo () {
            connection = DBManager.instance.connection;
            command = new OracleCommand ();
            command.Connection = connection;
        }

        public bool delete (Donation model) {
            command.CommandText = "delete from donations where campaign_id = :campaign_id and donor_id = donor_id and donation_date = donationDate";
            command.CommandType = System.Data.CommandType.Text;
            command.Parameters.Add ("campaign_id", model.campaign.id);
            command.Parameters.Add ("donor_id", model.donor.id);
            command.Parameters.Add ("donation_date", model.date);

            int check = command.ExecuteNonQuery ();

            if (check == -1) {
                return false;
            }
            return true;
        }

        public List<Donation> find (string column, string value) {
            command.CommandText = "select * from donation where :columnName = :value";
            command.CommandType = CommandType.Text;
            command.Parameters.Add ("columnName", column);
            command.Parameters.Add ("value", value);

            OracleDataReader reader = command.ExecuteReader ();
            List<Donation> donations = new List<Donation> ();
            while (reader.Read ()) {
                Donation donation = new Donation {
                    // date: reader["donation_date"],
                    type = reader["donation_type"].ToString (),
                    value = int.Parse (reader["value"].ToString ()),
                    campaign = new Campaign (int.Parse (reader["campaign_id"].ToString ())),
                    donor = new Donor (int.Parse (reader["donor_id"].ToString ()))
                };

                donations.Add (donation);
            }
            reader.Close ();
            return donations;
        }

        public List<Donation> findAll () {
            command.CommandText = "select * from donation";
            command.CommandType = CommandType.Text;

            OracleDataReader reader = command.ExecuteReader ();
            List<Donation> donations = new List<Donation> ();
            while (reader.Read ()) {
                Donation donation = new Donation {
                    // date: reader["donation_date"],
                    type = reader["donation_type"].ToString (),
                    value = int.Parse (reader["value"].ToString ()),
                    campaign = new Campaign (int.Parse (reader["campaign_id"].ToString ())),
                    donor = new Donor (int.Parse (reader["donor_id"].ToString ()))
                };

                donations.Add (donation);
            }
            reader.Close ();
            return donations;
        }

        public Donation findByID (string id) {
            throw new NotImplementedException ();
        }

        public Donation save (Donation model) {
            command.CommandText = "insert into donations values (:value, :type, :date, :campaign_id, :donor_id)";
            command.CommandType = System.Data.CommandType.Text;
            command.Parameters.Add ("value", model.value);
            command.Parameters.Add ("type", model.type);
            command.Parameters.Add ("date", model.date);
            command.Parameters.Add ("campaign_id", model.campaign.id);
            command.Parameters.Add ("donor_id", model.donor.id);

            int check = command.ExecuteNonQuery ();
            //if (check != -1)
            //{
            //    return model;
            //}
            return null;
        }

        public bool update (Donation newModel) {
            command.CommandText = "update donation set value =:value, type =:type where campaign_id = :campaign_id and donor_id = donor_id and date = :date";

            command.CommandType = System.Data.CommandType.Text;

            command.Parameters.Add ("value", newModel.value);
            command.Parameters.Add ("type", newModel.type);
            command.Parameters.Add ("campaign_id", newModel.campaign.id);
            command.Parameters.Add ("donor_id", newModel.donor.id);
            command.Parameters.Add ("donation_date", newModel.date);

            int check = command.ExecuteNonQuery ();
            if (check == -1) {
                return false;
            }
            return true;
        }
    }
}