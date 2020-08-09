using ComplianceRepository.Data;
using Npgsql;
using System.Collections.Generic;

namespace DbRepository
{
    public class RepositoryChd : IRepositoryDb
    {
        public RepositoryChd(string connectString)
        {
            _connectString = connectString;
        }

        #region PrivateField
        private readonly string _connectString;

        private const string TABLE_PEOPLE = "public.compliance_people";
        private const string TABLE_CATEGORIES = "public.compliance_categories";
        private const string TABLE_RELATIVES = "public.compliance_relatives";
        private const string TABLE_CONTACTS = "public.compliance_contacts";

        #endregion PrivateField

        #region PublicMethod

        public void AddCategories(int idPerson, IEnumerable<string> categorie)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connectString))
            {
                conn.Open();

                string query = $"INSERT INTO {TABLE_CATEGORIES} (people_black_list_id, category) VALUES(@id, @category)";

                foreach (var item in categorie)
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.Add(new NpgsqlParameter<int>("id", idPerson));
                        cmd.Parameters.Add(new NpgsqlParameter<string>("category", item));

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public void AddPeoples(IEnumerable<People> peoples)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connectString))
            {
                conn.Open();

                string query = $"INSERT INTO {TABLE_PEOPLE} (" +
                    $"black_list_id," +
                    $"all_names," +
                    $"name_raw_source," +
                    $"birth_date," +
                    $"birth_date_extra," +
                    $"birth_place," +
                    $"birth_place_extra," +
                    $"document_number," +
                    $"address_raw_source," +
                    $"updated_at_sec" +
                    $")" +
                    $" VALUES(" +
                    $"@black_list_id," +
                    $"@all_names," +
                    $"@name_raw_source," +
                    $"@birth_date," +
                    $"@birth_date_extra," +
                    $"@birth_place," +
                    $"@birth_place_extra," +
                    $"@document_number," +
                    $"@address_raw_source," +
                    $"@updated_at_sec" +
                    $")";

                foreach (var item in peoples)
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.Add(new NpgsqlParameter<int>("black_list_id", item.BlacklistId));
                        cmd.Parameters.Add(new NpgsqlParameter<string>("all_names", item.AllNames));
                        cmd.Parameters.Add(new NpgsqlParameter<string>("name_raw_source", item.NameRawSource));
                        cmd.Parameters.Add(new NpgsqlParameter<string>("birth_date", item.BirthDate));
                        cmd.Parameters.Add(new NpgsqlParameter<string>("birth_date_extra", item.BirthDateExtra));
                        cmd.Parameters.Add(new NpgsqlParameter<string>("birth_place", item.BirthPlace));
                        cmd.Parameters.Add(new NpgsqlParameter<string>("birth_place_extra", item.BirthPlaceExtra));
                        cmd.Parameters.Add(new NpgsqlParameter<string>("document_number", item.DocumentNumber));
                        cmd.Parameters.Add(new NpgsqlParameter<string>("address_raw_source", item.AddressRawSource));
                        cmd.Parameters.Add(new NpgsqlParameter<int>("updated_at_sec", item.UpdatedAtSec));

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public void AddRelatives(int idPerson, IEnumerable<Relative> relatives)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connectString))
            {
                conn.Open();

                string query = $"INSERT INTO {TABLE_RELATIVES} (people_black_list_id, relative_black_list_id, type_relationship_id) VALUES(@id, @relative, @type)";

                foreach (var item in relatives)
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.Add(new NpgsqlParameter<int>("id", idPerson));
                        cmd.Parameters.Add(new NpgsqlParameter<int>("relative", item.Id));
                        cmd.Parameters.Add(new NpgsqlParameter<int>("type", item.TypeRelationshipId));

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public int GetLastUpdateAtSec()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connectString))
            {
                conn.Open();

                string query = $"SELECT updated_at_sec FROM {TABLE_PEOPLE} ORDER by updated_at_sec DESC LIMIT 1";

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    return cmd.ExecuteScalar() is int lastUpdate ? lastUpdate : 0;
                }
            }
        }

        public void AddContacts(int idPerson, IEnumerable<Contact> contacts)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connectString))
            {
                conn.Open();

                string query = $"INSERT INTO {TABLE_CONTACTS} (people_black_list_id, contact, type) VALUES(@id, @contact, @type)";

                foreach (var item in contacts)
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.Add(new NpgsqlParameter<int>("id", idPerson));
                        cmd.Parameters.Add(new NpgsqlParameter<string>("contact", item.ContactInfo));
                        cmd.Parameters.Add(new NpgsqlParameter<string>("type", item.Type));

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        #endregion PublicMethod
    }
}