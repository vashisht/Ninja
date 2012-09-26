using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Ninjalista.DAL.Entities;

namespace Ninjalista.DAL.Repositories
{
    public class Repository : IRepository
    {
        private static string ConnectionString;
        public Repository()
        {
            ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }

        public void AddPicture(string guid)
        {    
            using(var connection = new SqlConnection(ConnectionString))
            {
                using(var trans = connection.BeginTransaction())
                {
                    connection.Open();
                    var insertQuery = "Insert into Pictures (Guid) VALUES (@guid)";
                    var sqlCommand = new SqlCommand(insertQuery, connection);


                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Parameters.Add("guid", guid);
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }


        public List<AdvertismentDetails> GetAllPostAds(int subCategory)
        {

             const string commandString =
                @"SELECT ID,Title,Location,PostedDate FROM AdvertisementDetails where SubCategoryId=@SubCategoryId";

            //const string connectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\kommanap\Gustin\Gustin\App_Data\Gustin.mdf;Integrated Security=True;User Instance=True";
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = GetCommand(commandString, connection, CommandType.Text);
                var advertisementDetails = new List<AdvertismentDetails>();
                command.Parameters.Add("@subcategoryId", subCategory);
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var details = new AdvertismentDetails();
                            details.AdId = (int)reader["ID"];
                            details.Title = (string)reader["Title"];
                            details.PostedDate = (DateTime)reader["PostedDate"];
                            details.Location=(string)reader["Location"];
                            advertisementDetails.Add(details);


                        }
                    }
                }

                return advertisementDetails;
            }
        }


        public AdvertismentDetails GetAdvertDetails(int id)
        {

            const string commandString =
               @"SELECT ID,Title,Location,PostedDate,Email,Description,Cat.CategoryName
FROM AdvertisementDetails Ad Join Categories cat on Cat.CategoryId = Ad.CategoryId where Id = @id";

            //const string connectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\kommanap\Gustin\Gustin\App_Data\Gustin.mdf;Integrated Security=True;User Instance=True";
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = GetCommand(commandString, connection, CommandType.Text);
                var details = new AdvertismentDetails();
                command.Parameters.Add("@id", id);
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            details.AdId = (int)reader["ID"];
                            details.Title = (string)reader["Title"];
                            details.PostedDate = (DateTime)reader["PostedDate"];
                            details.Location = (string)reader["Location"];
                            details.Description =(string)reader["Description"];
                            details.Email = (string)reader["Email"];
                            details.Category = (string)reader["CategoryName"];

                        }
                    }
                }

                return details;

            }
        }

        public List<SubCategory> GetAllSubCategories()
        {
            const string commandString =
               @"SELECT SubCategoryID, SubCategoryName, CategoryID
                                                FROM SubCategories";
             using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = GetCommand(commandString, connection, CommandType.Text);
                var subCategories = new List<SubCategory>();
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var subCategory = new SubCategory();
                            subCategory.SubCategoryId = (int)reader["SubCategoryID"];
                            subCategory.SubCategoryName = (string)reader["SubCategoryName"];
                            subCategory.CategoryId = (int)reader["CategoryID"];
                            subCategories.Add(subCategory);
                        }
                    }
                }
                return subCategories;
            }
        }

        public List<Category> GetAllCategory()
        {
            const string commandString =
                @"SELECT CategoryId, CategoryName FROM Categories";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = GetCommand(commandString, connection, CommandType.Text);
                
                var categories = new List<Category>();
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var category = new Category();
                            category.CategoryId = (int)reader["CategoryId"];
                            category.CategoryName = (string)reader["CategoryName"];
                            categories.Add(category);
                        }
                    }
                }

                return categories;
            }
        }

        public List<string> GetSubjects()
        {
            const string commandString =
                @"SELECT Subject  FROM SubjectValues";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = GetCommand(commandString, connection, CommandType.Text);

                var subjects = new List<string>();
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            subjects.Add((string)reader["Subject"]);
                        }
                    }
                }

                return subjects;
            }
        }


        public void SaveAd(AdvertismentDetails advertismentDetails)
        {
            const string commandString = @"INSERT INTO AdvertisementDetails
                         (SubCategoryId,Title,Description,Location,Email,PostedDate,CategoryId) VALUES (@subcategoryId,@title,@description,@location,@email,@postedDate,@categoryId)";

            // const string connectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\kommanap\Gustin\Gustin\App_Data\Gustin.mdf;Integrated Security=True;User Instance=True";

            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    var command = new SqlCommand(commandString, connection);
                    command.Parameters.Add("@subcategoryId", advertismentDetails.SubCateogryId);
                    command.Parameters.Add("@title", advertismentDetails.Title);
                    command.Parameters.Add("@description", advertismentDetails.Description);
                    command.Parameters.Add("@location", advertismentDetails.Location);
                    command.Parameters.Add("@email", advertismentDetails.Email);
                    command.Parameters.Add("@postedDate", DateTime.Now.Date);
                    command.Parameters.Add("@categoryId", advertismentDetails.CateogryId);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
        }
        public int GetSubCategoryId(string subCategory)
        {
           using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "up_GetSubCategoryId";
                command.Parameters.Add("@subCategory", subCategory);
                int subCategoryId = 0;
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            subCategoryId = (int)reader["SubCategoryId"];
                        }
                    }
                }
                return subCategoryId;
            }
        }
        public int GetCategoryId(string category)
        {
           string storedProcedure = "up_GetCategoryId";
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
               
                var command = new SqlCommand();
                command.Connection = connection;
                command.CommandType= CommandType.StoredProcedure;
                command.CommandText = storedProcedure;
                command.Parameters.Add("@category", category);
                int categoryId = 0;
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categoryId = (int)reader["CategoryId"];
                        }
                    }
                }
                return categoryId;
            }
        }

        public void SaveEmailAddress(string emailAddress)
        {
            const string commandString = @"INSERT INTO EmailAddressData
                         (EmailAddress) VALUES (@email)";

            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    var command = new SqlCommand(commandString, connection);
                    command.Parameters.Add("@email", emailAddress);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
        }

        //public AdvertismentDetails GetAdDetails(int id)
        //{
        //    const string commandString = "select title,subcatergory from AdvertisementDetails ad" +
        //                                     " JOIN SubCategories sc on  where ID = @ID";
        //    try
        //    {
        //        using (var connection = new SqlConnection(ConnectionString))
        //        {
        //            connection.Open();
        //            var command = new SqlCommand(commandString,connection);
        //            command.Parameters.AddWithValue("@ID", id);
        //            command.ExecuteReader();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.ToString());
        //    }
        //}

        private SqlCommand GetCommand(string commandString, SqlConnection connection, CommandType commandType)
        {
            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = commandType;
            command.CommandText = commandString;
            return command;
        }
    }
}
