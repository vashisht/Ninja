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

        public List<AdvertismentDetails> GetSearchResults(string keyword)
        {

            string[] pram = keyword.Split(" ".ToCharArray());
            string detail = "";
            string or = "";
            int cnt = 1;
            foreach (var item in pram)
            {
                detail = detail + " AD.Description like '%" + item + "%' OR AD.Title like '%" + item + "%' OR AD.Location like '%" + item + "%'";
                //detail = detail + " AD.Description in ('" + item + "') OR AD.Title in ('" + item + "') OR AD.Location in ('" + item + "')";
                if (cnt < pram.Length)
                {
                    or = " OR ";
                    detail = detail + or;    
                }
                cnt++;
                
            }
            string commandString =
               @"SELECT ID,Title,Location,PostedDate,Image1,Image2,Image3 ,CategoryName,SubCategoryName
                    FROM AdvertisementDetails AD INNER JOIN SubCategories SC ON AD.SubCategoryId = SC.SubCategoryId
                    AND AD.SubCategoryId=SC.SubCategoryId And AD.Active=1
                    INNER JOIN Categories C ON C.CategoryId = AD.CategoryId
                    WHERE " + detail + " Order by Id Desc";

            //@"SELECT ID,Title,Location,PostedDate,Image1,Image2,Image3 FROM AdvertisementDetails where SubCategoryId=@SubCategoryId And Active=1 Order by Id Desc";

            //const string connectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\kommanap\Gustin\Gustin\App_Data\Gustin.mdf;Integrated Security=True;User Instance=True";
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = GetCommand(commandString, connection, CommandType.Text);
                var advertisementDetails = new List<AdvertismentDetails>();
                //command.Parameters.Add("@subcategoryId", subCategory);
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var details = new AdvertismentDetails();
                            details.AdId = (int)reader["ID"];
                            details.Title = (string)reader["Title"];
                            details.PostedDate = (DateTime)reader["PostedDate"];
                            details.Location = (string)reader["Location"];
                            details.SubCategory = (string)reader["SubCategoryName"];
                            details.Category = (string)reader["CategoryName"];
                            details.Image1 = !(DBNull.Value.Equals(reader["Image1"])) ? (string)reader["Image1"] : string.Empty;
                            details.Image2 = !(DBNull.Value.Equals(reader["Image2"])) ? (string)reader["Image2"] : string.Empty;
                            details.Image2 = !(DBNull.Value.Equals(reader["Image3"])) ? (string)reader["Image3"] : string.Empty;
                            advertisementDetails.Add(details);


                        }
                    }
                }

                return advertisementDetails;
            }
        }

        public List<AdvertismentDetails> GetAllPostAds(int subCategory)
        {

            const string commandString =
               @"SELECT ID,Title,Location,PostedDate,Image1,Image2,Image3 ,CategoryName,SubCategoryName
                    FROM AdvertisementDetails AD INNER JOIN SubCategories SC ON AD.SubCategoryId = SC.SubCategoryId
                    INNER JOIN Categories C ON C.CategoryId = AD.CategoryId
                    where AD.SubCategoryId=@SubCategoryId And AD.Active=1 Order by Id Desc";

                 //@"SELECT ID,Title,Location,PostedDate,Image1,Image2,Image3 FROM AdvertisementDetails where SubCategoryId=@SubCategoryId And Active=1 Order by Id Desc";

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
                            details.SubCategory = (string)reader["SubCategoryName"];
                            details.Category = (string)reader["CategoryName"];
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

        public List<AdvertismentDetails> GetAllPostAdsByCategory(int category)
        {

            const string commandString =
               @"SELECT ID,Title,Location,PostedDate,Image1,Image2,Image3 ,CategoryName,SubCategoryName
                    FROM AdvertisementDetails AD INNER JOIN SubCategories SC ON AD.SubCategoryId = SC.SubCategoryId
                    INNER JOIN Categories C ON C.CategoryId = AD.CategoryId
                    where AD.CategoryId=@CategoryId And AD.Active=1 Order by Id Desc";

            //@"SELECT ID,Title,Location,PostedDate,Image1,Image2,Image3 FROM AdvertisementDetails where SubCategoryId=@SubCategoryId And Active=1 Order by Id Desc";

            //const string connectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\kommanap\Gustin\Gustin\App_Data\Gustin.mdf;Integrated Security=True;User Instance=True";
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = GetCommand(commandString, connection, CommandType.Text);
                var advertisementDetails = new List<AdvertismentDetails>();
                command.Parameters.Add("@categoryId", category);
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var details = new AdvertismentDetails();
                            details.AdId = (int)reader["ID"];
                            details.Title = (string)reader["Title"];
                            details.PostedDate = (DateTime)reader["PostedDate"];
                            details.Location = (string)reader["Location"];
                            details.SubCategory = (string)reader["SubCategoryName"];
                            details.Category = (string)reader["CategoryName"];
                            details.Image1 = !(DBNull.Value.Equals(reader["Image1"])) ? (string)reader["Image1"] : string.Empty;
                            details.Image2 = !(DBNull.Value.Equals(reader["Image2"])) ? (string)reader["Image2"] : string.Empty;
                            details.Image2 = !(DBNull.Value.Equals(reader["Image3"])) ? (string)reader["Image3"] : string.Empty;
                            advertisementDetails.Add(details);


                        }
                    }
                }

                return advertisementDetails;
            }
        }


        public SubCategory GetSubCategorybyId(int SubCategoryId)
        {
            const string commandString =
               @"SELECT SC.SubCategoryID, SC.SubCategoryName, C.CategoryName,SC.CategoryID,SC.Active,SC.Ordr
FROM SubCategories SC INNER JOIN Categories C ON C.CategoryId = SC.CategoryId
 WHERE SubCategoryID = @SubCategoryId order by ordr";
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
                                subCategory.CategoryName = (string)reader["CategoryName"];
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
               @"SELECT CategoryID, CategoryName,Active,Ordr
                                                FROM Categories WHERE CategoryID = @CategoryId order by ordr";
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = GetCommand(commandString, connection, CommandType.Text);
                var Category = new Category();
                {

                    command.Parameters.Add("@CategoryId", CategoryId);
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                Category.CategoryId = (int)reader["CategoryID"];
                                Category.CategoryName = (string)reader["CategoryName"];
                                Category.Active = Convert.ToBoolean(reader["Active"]);
                                Category.Ordr = Convert.ToDecimal(reader["Ordr"]);
                            }

                        }
                    }
                }
                return Category;
            }
        }

        public AdvertismentDetails GetAdvertDetails(int id)
        {

            const string commandString =
               @"SELECT ID,Title,Location,PostedDate,Email,Description,Cat.CategoryName,Sc.SubCategoryName,Ad.Image1,Ad.Image2,Ad.Image3,Ad.CategoryId,Ad.SubCategoryId
                FROM AdvertisementDetails Ad 
                Inner Join Categories cat on Cat.CategoryId = Ad.CategoryId 
                Inner Join SubCategories SC on Sc.SubCategoryId = Ad.SubCategoryId
                where Id =@id and Ad.Active = 1
                ";

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
                            details.CateogryId = (int)reader["CategoryID"];
                            details.SubCateogryId = (int)reader["SubCategoryID"];
                            details.Image1 = !(DBNull.Value.Equals(reader["Image1"])) ? (string)reader["Image1"] : string.Empty;
                            details.Image2 = !(DBNull.Value.Equals(reader["Image2"])) ? (string)reader["Image2"] : string.Empty;
                            details.Image3 = !(DBNull.Value.Equals(reader["Image3"])) ? (string)reader["Image3"] : string.Empty;

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


        public List<SubCategory> GetSubCategoriesByCategoryId(int CategoryId)
        {
            const string commandString =
               @"SELECT SubCategoryID, SubCategoryName, CategoryID
                                                FROM SubCategories WHERE CategoryID = @CategoryId order by SubCategoryName";
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
                            subCategories.Add(subCategory);
                        }

                    }
                    }
                }
                return subCategories;
            }
        }

        public List<SubCategory> GetActiveSubCategoriesByCategoryId(int CategoryId)
        {
            const string commandString =
               @"SELECT SubCategoryID, SubCategoryName, CategoryID
                                                FROM SubCategories WHERE CategoryID = @CategoryId AND Active = 1 order by SubCategoryName";
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
                                subCategories.Add(subCategory);
                            }

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

        public List<Category> GetAllActiveCategory()
        {
            const string commandString =
                @"SELECT CategoryId, CategoryName, Active ,Ordr FROM Categories WHERE Active = 1 Order by Ordr";

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
                         (SubCategoryId,Title,Description,Location,Email,PostedDate,CategoryId,Image1,Image2,Image3) " +
                        "VALUES (@subcategoryId,@title,@description,@location,@email,@postedDate,@categoryId,@Image1,@Image2,@Image3);" +
                        " SELECT SCOPE_IDENTITY()";
            
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
                    advertismentDetails.AdId = Convert.ToInt32(command.ExecuteScalar());
                    //command.ExecuteNonQuery();
                    
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

        public List<Category> GetActiveCatagoryList()
        {

            var cat = new Category();
            
                                 
             const string commandString =
                @"select C.CategoryId,C.CategoryName,C.Ordr,SC.SubCategoryId,SC.SubCategoryName,SC.Ordr
                FROM Categories C,SubCategories SC
                WHERE C.Active = 1 AND SC.Active = 1 AND C.CategoryId = SC.CategoryId
                ORDER BY C.Ordr,SC.Ordr";

             int Categoryid = 0;

             using (var connection = new SqlConnection(ConnectionString))
             {
                 connection.Open();
                 var command = GetCommand(commandString, connection, CommandType.Text);
                 var Catlist = new List<Category>();
                 {


                     using (var reader = command.ExecuteReader())
                     {
                         while (reader.Read())
                         {

                             if (Categoryid != (int)reader["CategoryID"])
                             {

                                 
                                  cat = new Category();
                                 cat.CategoryId = (int)reader["CategoryID"];
                                 cat.CategoryName = (string)reader["CategoryName"];
                                 cat.Ordr = Convert.ToDecimal(reader["Ordr"]);
                                 Categoryid = (int)reader["CategoryID"];
                                 if (Categoryid != 0)
                                 {
                                     Catlist.Add(cat);

                                 }
                             }


                             var subcat = new SubCategory();


                             subcat.CategoryId = (int)reader["CategoryID"];
                             subcat.SubCategoryId  = (int)reader["SubCategoryID"];
                             subcat.CategoryName = (string)reader["CategoryName"];
                             subcat.SubCategoryName = (string)reader["SubCategoryName"];
                             subcat.Ordr = Convert.ToDecimal(reader["Ordr"]);
                             cat.subcategoylist.Add(subcat);

                             
                         }
                     }
                 }
                 return Catlist;
             }
            
           
        }
        public List<PopularLink> GetActivePopularLinkList()
        {
            const string commandString =
              @"SELECT  PopularLinkId, Link, Active ,Title FROM PopularLinks WHERE Active = 1 Order by PopularLinkId";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = GetCommand(commandString, connection, CommandType.Text);

                var pllist = new List<PopularLink>();
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var obj = new PopularLink();

                            obj.Link = (string)reader["Link"];
                            obj.Title = (string)reader["Title"];
                            obj.Active = Convert.ToBoolean(reader["Active"]);
                            obj.PopularLinkId = (int)reader["PopularLinkId"];
                            
                            pllist.Add(obj);
                        }
                    }
                }

                return pllist;
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

        public List<Page> GetAllActivePages()
        {
            const string commandString =
                @"SELECT PageId, Title, Active,Detail,LinkTitle FROM Pages WHERE Active = 1";

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
                            obj.PageId = (int)reader["PageId"];
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

        public Page GetPageByName(string LinkTitle)
        {
            const string commandString =
                @"SELECT Detail, Title, Active,PageId,LinkTitle FROM pages WHERE LinkTitle = @LinkTitle";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = GetCommand(commandString, connection, CommandType.Text);

                var obj = new Page();
                {

                    command.Parameters.Add("@LinkTitle", LinkTitle);
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                obj.PageId = (int)reader["pageId"];
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

        private SqlCommand GetCommand(string commandString, SqlConnection connection, CommandType commandType)
        {
            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = commandType;
            command.CommandText = commandString;
            return command;
        }

        public List<SubCategory> GetPopularCategoriesList()
        {


            const string commandString =
               @"select top 10 C.CategoryId,C.CategoryName,C.Ordr,SC.SubCategoryId,SC.SubCategoryName,SC.Ordr,COUNT(AD.Id) No
                    FROM Categories C,SubCategories SC, AdvertisementDetails AD
                    WHERE C.Active = 1 AND SC.Active = 1 AND C.CategoryId = SC.CategoryId
                    AND AD.Active = 1 AND AD.CategoryId = C.CategoryId AND AD.SubCategoryId = SC.SubCategoryId
                    GROUP BY C.CategoryId,C.CategoryName,C.Ordr,SC.SubCategoryId,SC.SubCategoryName,SC.Ordr
                    ORDER BY COUNT(AD.Id) Desc";

            
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = GetCommand(commandString, connection, CommandType.Text);
                var Catlist = new List<SubCategory>();
                {

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var subcat = new SubCategory();

                            subcat.CategoryId = (int)reader["CategoryID"];
                            subcat.SubCategoryId = (int)reader["SubCategoryID"];
                            subcat.CategoryName = (string)reader["CategoryName"];
                            subcat.SubCategoryName = (string)reader["SubCategoryName"];
                            subcat.Ordr = Convert.ToDecimal(reader["Ordr"]);
                            Catlist.Add(subcat);


                        }
                    }
                }
                return Catlist;
            }


        }
    }
}
