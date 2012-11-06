using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Ninjalista.DAL.Entities;

namespace Ninjalista.DAL.Repositories
{
    public class AdminRepository : IAdminRepository

            {
        private static string ConnectionString;
        public AdminRepository()
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
                @"SELECT ID,Title,Location,PostedDate,Image1,Image2,Image3 FROM AdvertisementDetails where SubCategoryId=@SubCategoryId Order by Id Desc";

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
                            details.Image1  = !(DBNull.Value.Equals(reader["Image1"]))?(string) reader["Image1"]:string.Empty;
                            details.Image2 = !(DBNull.Value.Equals(reader["Image2"]))? (string)reader["Image2"]: string.Empty;
                            details.Image2 = !(DBNull.Value.Equals(reader["Image3"]))?(string)reader["Image3"]:string.Empty;
                            advertisementDetails.Add(details);


                        }
                    }
                }

                return advertisementDetails;
            }
        }

        public List<AdvertismentDetails> FetchAllPostAds()
        {

            const string commandString =
               @"SELECT ID,Title,Location,PostedDate,Image1,Image2,Image3,Categories.CategoryName,SubCategories.SubCategoryName,AdvertisementDetails.Active FROM AdvertisementDetails,Categories,SubCategories
                    where AdvertisementDetails.CategoryID=Categories.CategoryId AND  AdvertisementDetails.SubCategoryID=SubCategories.SubCategoryId Order by Id Desc";

            //const string connectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\kommanap\Gustin\Gustin\App_Data\Gustin.mdf;Integrated Security=True;User Instance=True";
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = GetCommand(commandString, connection, CommandType.Text);
                var advertisementDetails = new List<AdvertismentDetails>();
                
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var details = new AdvertismentDetails();
                            details.AdId = (int)reader["ID"];
                            details.Title = (string)reader["Title"];
                            details.PostedDate = (DateTime)reader["PostedDate"];
                            details.Location = (string)reader["Location"];
                            details.Category = !(DBNull.Value.Equals(reader["CategoryName"])) ? (string)reader["CategoryName"] : string.Empty;
                            details.SubCategory = !(DBNull.Value.Equals(reader["SubCategoryName"])) ? (string)reader["SubCategoryName"] : string.Empty;
                            details.Image1 = !(DBNull.Value.Equals(reader["Image1"])) ? (string)reader["Image1"] : string.Empty;
                            details.Image2 = !(DBNull.Value.Equals(reader["Image2"])) ? (string)reader["Image2"] : string.Empty;
                            details.Image2 = !(DBNull.Value.Equals(reader["Image3"])) ? (string)reader["Image3"] : string.Empty;
                            details.Active  = Convert.ToBoolean(reader["Active"]);
                            advertisementDetails.Add(details);


                        }
                    }
                

                return advertisementDetails;
            }
        }


        public AdvertismentDetails GetAdvertDetails(int id)
        {

//            const string commandString =
//               @"SELECT ID,Title,Location,PostedDate,Email,Description,Cat.CategoryName,Ad.Image1,Ad.Image2,Ad.Image3
//FROM AdvertisementDetails Ad Join Categories cat on Cat.CategoryId = Ad.CategoryId where Id = @id";

            const string commandString =
             @"SELECT ID,Title,Location,PostedDate,Image1,Image2,Image3,Categories.CategoryName,SubCategories.SubCategoryName,AdvertisementDetails.Active,AdvertisementDetails.Description,AdvertisementDetails.Email
                FROM AdvertisementDetails,Categories,SubCategories
                    where AdvertisementDetails.CategoryID=Categories.CategoryId AND  AdvertisementDetails.SubCategoryID=SubCategories.SubCategoryId AND AdvertisementDetails.ID = @id";

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
                            details.SubCategory = (string)reader["SubCategoryName"];
                            details.Image1 = !(DBNull.Value.Equals(reader["Image1"])) ? (string)reader["Image1"] : string.Empty;
                            details.Image2 = !(DBNull.Value.Equals(reader["Image2"])) ? (string)reader["Image2"] : string.Empty;
                            details.Image3 = !(DBNull.Value.Equals(reader["Image3"])) ? (string)reader["Image3"] : string.Empty;
                            details.Active = Convert.ToBoolean(reader["Active"]);
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
                                                FROM SubCategories Order by ordr";
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


        public List<SubCategory> GetSubCategoriesByCategoryId(int CategoryId)
        {
            const string commandString =
               @"SELECT SubCategoryID, SubCategoryName, CategoryID,Active
                                                FROM SubCategories WHERE CategoryID = @CategoryId order by ordr";
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = GetCommand(commandString, connection, CommandType.Text);
                var subCategories = new List<SubCategory>();
                {

                    command.Parameters.Add("@CategoryId", CategoryId);
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var subCategory = new SubCategory();
                            subCategory.SubCategoryId = (int)reader["SubCategoryID"];
                            subCategory.SubCategoryName = (string)reader["SubCategoryName"];
                            subCategory.CategoryId = (int)reader["CategoryID"];
                            subCategory.Active = Convert.ToBoolean(reader["Active"]);
                            subCategories.Add(subCategory);
                        }

                    }
                    }
                }
                return subCategories;
            }
        }

        public SubCategory GetSubCategorybyId(int SubCategoryId)
        {
            const string commandString =
               @"SELECT SubCategoryID, SubCategoryName, CategoryID,Active,Ordr
                                                FROM SubCategories WHERE SubCategoryID = @SubCategoryId order by ordr";
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = GetCommand(commandString, connection, CommandType.Text);
                var subCategory = new SubCategory();
                {

                    command.Parameters.Add("@SubCategoryId", SubCategoryId);
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                
                                subCategory.SubCategoryId = (int)reader["SubCategoryID"];
                                subCategory.SubCategoryName = (string)reader["SubCategoryName"];
                                subCategory.CategoryId = (int)reader["CategoryID"];
                                subCategory.Active = Convert.ToBoolean(reader["Active"]);
                                subCategory.Ordr = Convert.ToDecimal(reader["Ordr"]);
                            }

                        }
                    }
                }
                return subCategory;
            }
        }


        public Category GetCategorybyId(int CategoryId)
        {
            const string commandString =
                @"SELECT CategoryId, CategoryName, Active,Ordr FROM Categories WHERE CategoryID = @CategoryId order by Ordr";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = GetCommand(commandString, connection, CommandType.Text);

                var category = new Category();
                {

                    command.Parameters.Add("@CategoryId", CategoryId);
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                category.CategoryId = (int)reader["CategoryId"];
                                category.CategoryName = (string)reader["CategoryName"];
                                category.Active = Convert.ToBoolean(reader["Active"]);
                                category.Ordr = Convert.ToDecimal(reader["Ordr"]);
                            }

                        }
                    }
                }

                return category;
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


        public void UpdateCategory(Category category)
        {
            const string commandString = @"Update Categories SET Active = @Active WHERE CategoryId=@CategoryId";
                        

            // const string connectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\kommanap\Gustin\Gustin\App_Data\Gustin.mdf;Integrated Security=True;User Instance=True";

            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    var command = new SqlCommand(commandString, connection);
                    command.Parameters.Add("@CategoryId", category.CategoryId );
                    command.Parameters.Add("@Active", category.Active );
                  
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
        }

        public void UpdateCategory_1(Category category)
        {
            const string commandString = @"Update Categories SET Active = @Active,CategoryName = @CategoryName ,Ordr=@Ordr WHERE CategoryId=@CategoryId";


            // const string connectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\kommanap\Gustin\Gustin\App_Data\Gustin.mdf;Integrated Security=True;User Instance=True";

            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    var command = new SqlCommand(commandString, connection);
                    command.Parameters.Add("@CategoryId", category.CategoryId);
                    command.Parameters.Add("@Active", category.Active );
                    command.Parameters.Add("@CategoryName", category.CategoryName );
                    command.Parameters.Add("@Ordr", category.Ordr );

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
        }

        public void AddCategory(Category category)
        {
            


            const string commandString = @"INSERT INTO Categories
                         (CategoryName,Active,Ordr) VALUES (@CategoryName,@Active,@Ordr)";

            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    var command = new SqlCommand(commandString, connection);
                    command.Parameters.Add("@CategoryName", category.CategoryName );
                    command.Parameters.Add("@Active", true );
                    command.Parameters.Add("@Ordr", category.Ordr );

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
        }

        public void UpdateSubCategory(SubCategory subcategory)
        {
            const string commandString = @"Update SubCategories SET Active = @Active WHERE SubCategoryId=@SubCategoryId";


            // const string connectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\kommanap\Gustin\Gustin\App_Data\Gustin.mdf;Integrated Security=True;User Instance=True";

            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    var command = new SqlCommand(commandString, connection);
                    command.Parameters.Add("@SubCategoryId", subcategory.SubCategoryId);
                    command.Parameters.Add("@Active", subcategory.Active);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
        }

        public void UpdateSubCategory_1(SubCategory subcategory)
        {
            const string commandString = @"Update SubCategories SET Active = @Active,CategoryId=@CategoryId,SubCategoryName = @SubCategoryName , Ordr = @Ordr  WHERE SubCategoryId=@SubCategoryId";


            // const string connectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\kommanap\Gustin\Gustin\App_Data\Gustin.mdf;Integrated Security=True;User Instance=True";

            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    var command = new SqlCommand(commandString, connection);
                    command.Parameters.Add("@SubCategoryId", subcategory.SubCategoryId);
                    command.Parameters.Add("@Active", subcategory.Active);
                    command.Parameters.Add("@SubCategoryName", subcategory.SubCategoryName );
                    command.Parameters.Add("@CategoryId", subcategory.CategoryId);
                    command.Parameters.Add("@Ordr", subcategory.Ordr);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
        }

        public void AddSubCategory(SubCategory subcategory)
        {



            const string commandString = @"INSERT INTO SubCategories
                         (SubCategoryName,Active,CategoryId,Ordr) VALUES (@SubCategoryName,@Active,@CategoryId,@Ordr)";

            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    var command = new SqlCommand(commandString, connection);
                    command.Parameters.Add("@SubCategoryName", subcategory.SubCategoryName);
                    command.Parameters.Add("@Active", true);
                    command.Parameters.Add("@CategoryId", subcategory.CategoryId);
                    command.Parameters.Add("@Ordr", subcategory.Ordr );

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
        }

        public void SaveAd(AdvertismentDetails advertismentDetails)
        {
            const string commandString = @"INSERT INTO AdvertisementDetails
                         (SubCategoryId,Title,Description,Location,Email,PostedDate,CategoryId,Image1,Image2,Image3) VALUES (@subcategoryId,@title,@description,@location,@email,@postedDate,@categoryId,@Image1,@Image2,@Image3)";

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
                    command.Parameters.Add("@Image1", advertismentDetails.Image1);
                    command.Parameters.Add("@Image2", advertismentDetails.Image2);
                    command.Parameters.Add("@Image3", advertismentDetails.Image3);
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


        public void UpdateAddStatus(AdvertismentDetails advertismentdetails)
        {
            const string commandString = @"Update AdvertisementDetails SET Active = @Active WHERE ID=@AdId";


            // const string connectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\kommanap\Gustin\Gustin\App_Data\Gustin.mdf;Integrated Security=True;User Instance=True";

            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    var command = new SqlCommand(commandString, connection);
                    command.Parameters.Add("@AdId", advertismentdetails.AdId);
                    command.Parameters.Add("@Active", advertismentdetails.Active);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
        }


        public void UpdateUserStatus(User user)
        {
            const string commandString = @"Update Users SET Active = @Active WHERE UserId=@UserId";

            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    var command = new SqlCommand(commandString, connection);
                    command.Parameters.Add("@UserId", user.Userid );
                    command.Parameters.Add("@Active", user.Active);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
        }

        public User getUserById(int Userid)
        {
            const string commandString =
                @"SELECT Userid, UserName, Active,FirstName,LastName,Password FROM Users WHERE UserId = @UserId";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = GetCommand(commandString, connection, CommandType.Text);

                var user = new User();
                {

                    command.Parameters.Add("@UserId", Userid);
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                user.Userid = (int)reader["Userid"];
                                user.UserName = (string)reader["UserName"];
                                user.Password = (string)reader["Password"];
                                user.FirstName = (string)reader["FirstName"];
                                user.LastName = (string)reader["LastName"];

                                user.Active = Convert.ToBoolean(reader["Active"]);
                                
                            }

                        }
                    }
                }

                return user;
            }
        }

        public User getUserByName(string username,string password)
        {
            const string commandString =
                @"SELECT Userid, UserName, Active,FirstName,LastName,Password FROM Users WHERE UserName = @UserName AND Password =@Password";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = GetCommand(commandString, connection, CommandType.Text);

                var user = new User();
                {

                    command.Parameters.Add("@UserName", username );
                    command.Parameters.Add("@Password", password);
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                user.Userid = (int)reader["Userid"];
                                user.UserName = (string)reader["UserName"];
                                user.Password = (string)reader["Password"];
                                user.FirstName = (string)reader["FirstName"];
                                user.LastName = (string)reader["LastName"];

                                user.Active = Convert.ToBoolean(reader["Active"]);

                            }

                        }
                    }
                }

                return user;
            }
        }


        public List<User> getAllusers()
        {
            const string commandString =
                @"SELECT Userid, UserName, Active,FirstName,LastName,Password FROM Users ";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = GetCommand(commandString, connection, CommandType.Text);

                var users = new List<User>();
                {

                    
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var user = new User();
                                user.Userid = (int)reader["Userid"];
                                user.UserName = (string)reader["UserName"];
                                user.Password = (string)reader["Password"];
                                user.FirstName = (string)reader["FirstName"];
                                user.LastName = (string)reader["LastName"];

                                user.Active = Convert.ToBoolean(reader["Active"]);
                                users.Add(user);
                            }

                        
                    }
                }

                return users;
            }
        }

        public List<Category> GetAllCategory()
        {
            const string commandString =
                @"SELECT CategoryId, CategoryName,Active ,ordr FROM Categories order by ordr";

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
                            category.Active = Convert.ToBoolean(reader["Active"]);
                            category.Ordr = Convert.ToDecimal(reader["Ordr"]);
                            categories.Add(category);
                        }
                    }
                }

                return categories;
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

        public void UpdateUser(User user)
        {
            const string commandString = @"Update Users SET Active = @Active WHERE UserId=@UserId";

            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    var command = new SqlCommand(commandString, connection);
                    command.Parameters.Add("@UserId", user.Userid);
                    command.Parameters.Add("@Active", user.Active);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
        }

        public void AddUser(User user)
        {
            const string commandString = @"Update Users SET Active = @Active WHERE UserId=@UserId";

            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    var command = new SqlCommand(commandString, connection);
                    command.Parameters.Add("@UserId", user.Userid);
                    command.Parameters.Add("@Active", user.Active);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
        }

        private SqlCommand GetCommand(string commandString, SqlConnection connection, CommandType commandType)
        {
            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = commandType;
            command.CommandText = commandString;
            return command;
        }



        public void UpdateLinkStatus(PopularLink popularlink)
        {
            const string commandString = @"Update PopularLinks SET Active = @Active WHERE PopularLinkId=@PopularLinkId";

            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    var command = new SqlCommand(commandString, connection);
                    command.Parameters.Add("@PopularLinkId", popularlink.PopularLinkId );
                    command.Parameters.Add("@Active", popularlink.Active);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
        }

        public PopularLink GetPopularLinkById(int popularlinkId)
        {
            const string commandString =
                @"SELECT PopularLinkId, Title, Active,Link FROM PopularLinks WHERE PopularLinkId = @PopularLinkId";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = GetCommand(commandString, connection, CommandType.Text);

                var obj = new PopularLink();
                {

                    command.Parameters.Add("@PopularLinkId", popularlinkId);
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                obj.PopularLinkId = (int)reader["PopularLinkId"];
                                obj.Title = (string)reader["Title"];
                                obj.Link = (string)reader["Link"];
                                obj.Active = Convert.ToBoolean(reader["Active"]);

                            }

                        }
                    }
                }

                return obj;
            }
        }




        public List<PopularLink> GetAllPopularLinks()
        {
            const string commandString =
                @"SELECT PopularLinkId, Title, Active,Link FROM PopularLinks";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = GetCommand(commandString, connection, CommandType.Text);

                var objlist = new List<PopularLink>();
                {


                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var obj = new PopularLink();
                            obj.PopularLinkId = (int)reader["PopularLinkId"];
                            obj.Title = (string)reader["Title"];
                            obj.Link = (string)reader["Link"];
                            obj.Active = Convert.ToBoolean(reader["Active"]);
                            objlist.Add(obj);
                        }


                    }
                }

                return objlist;
            }
        }




        public void UpdatePopularLink(PopularLink popularlink)
        {
            const string commandString = @"Update PopularLinks SET Active = @Active,Title =@Title, Link = @Link WHERE PopularLinkId=@PopularLinkId";

            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    var command = new SqlCommand(commandString, connection);
                    command.Parameters.Add("@Title", popularlink.Title );
                    command.Parameters.Add("@Link", popularlink.Link);
                    command.Parameters.Add("@Active", popularlink.Active);
                    command.Parameters.Add("@PopularLinkId", popularlink.PopularLinkId);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
        }

        public void AddPopularLink(PopularLink popularlink)
        {
            const string commandString = @"INSERT INTO PopularLinks
                         (Title,Active,Link) VALUES (@Title,@Active,@Link)";

            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    var command = new SqlCommand(commandString, connection);
                    command.Parameters.Add("@Title", popularlink.Title);
                    command.Parameters.Add("@Link", popularlink.Link);
                    command.Parameters.Add("@Active", popularlink.Active);
                    

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
        }

        //pages




        public void UpdatePageStatus(Page page)
        {
            const string commandString = @"Update Pages SET Active = @Active WHERE PageId=@PageId";

            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    var command = new SqlCommand(commandString, connection);
                    command.Parameters.Add("@PageId", page.PageId );
                    command.Parameters.Add("@Active", page.Active);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
        }

        public Page GetPageById(int pageid)
        {
            const string commandString =
                @"SELECT Detail, Title, Active,PageId,LinkTitle FROM pages WHERE PageId = @PageId";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = GetCommand(commandString, connection, CommandType.Text);

                var obj = new Page();
                {

                    command.Parameters.Add("@PageId", pageid );
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                obj.PageId   = (int)reader["pageId"];
                                obj.Title = (string)reader["Title"];
                                obj.Detail = (string)reader["Detail"];
                                obj.LinkTitle = (string)reader["LinkTitle"];
                                obj.Active = Convert.ToBoolean(reader["Active"]);

                            }

                        }
                    }
                }

                return obj;
            }
        }




        public List<Page> GetAllPages()
        {
            const string commandString =
                @"SELECT PageId, Title, Active,Detail,Title,LinkTitle FROM Pages";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = GetCommand(commandString, connection, CommandType.Text);

                var objlist = new List<Page>();
                {


                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var obj = new Page();
                            obj.PageId  = (int)reader["PageId"];
                            obj.Title = (string)reader["Title"];
                            obj.Detail = (string)reader["Detail"];
                            obj.LinkTitle = (string)reader["LinkTitle"];
                            obj.Active = Convert.ToBoolean(reader["Active"]);
                            objlist.Add(obj);
                        }


                    }
                }

                return objlist;
            }
        }




        public void UpdatePage(Page page)
        {
            const string commandString = @"Update Pages SET Active = @Active,Title =@Title, Detail = @Detail,LinkTitle= @LinkTitle WHERE PageId=@PageId";

            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    var command = new SqlCommand(commandString, connection);
                    command.Parameters.Add("@Title", page.Title);
                    command.Parameters.Add("@Detail", page.Detail );
                    command.Parameters.Add("@Active", page.Active);
                    command.Parameters.Add("@PageId", page.PageId  );
                    command.Parameters.Add("@LinkTitle", page.LinkTitle);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
        }

        public void AddPage(Page page)
        {
            const string commandString = @"INSERT INTO Pages
                         (Title,Active,Detail,LinkTitle) VALUES (@Title,@Active,@Detail,@LinkTitle)";

            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    var command = new SqlCommand(commandString, connection);
                    command.Parameters.Add("@Title", page.Title);
                    command.Parameters.Add("@Detail", page.Detail);
                    command.Parameters.Add("@Active", page.Active);
                    command.Parameters.Add("@LinkTitle", page.LinkTitle);


                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
        }

    }
}
