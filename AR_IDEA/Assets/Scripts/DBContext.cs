using Mono.Data.Sqlite;
using System.Data;
using UnityEngine;

namespace Assets.Scripts
{
    class DBContext
    {
        string ConnectionString;

        public DBContext(string conectionString)
        {
            ConnectionString = conectionString;
        }


        public double GetPrice(string name)
        {
            double price = 0;
            //ConnectionString = string.Format("URI=file:{0}/DataBase/AR_IDEA.sqlite", Application.dataPath);
            using (IDbConnection dbConnection = new SqliteConnection(ConnectionString))
            {
                dbConnection.Open();
                using (IDbCommand dbCmd = dbConnection.CreateCommand())
                {
                    string sqlQuery = string.Format("SELECT Price FROM Products WHERE Name='{0}';", name);
                    dbCmd.CommandText = sqlQuery;
                    using (IDataReader dataReader = dbCmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            price = dataReader.GetDouble(0);
                        }
                        dbConnection.Close();
                        dataReader.Close();
                    }
                }
            }

            return price;
        }

        public string GetDescribe(string name)
        {
            string describe = "";
            //ConnectionString = string.Format("URI=file:{0}/DataBase/AR_IDEA.sqlite", Application.dataPath);
            using (IDbConnection dbConnection = new SqliteConnection(ConnectionString))
            {
                dbConnection.Open();
                using (IDbCommand dbCmd = dbConnection.CreateCommand())
                {
                    string sqlQuery = string.Format("SELECT Describe FROM Products WHERE Name='{0}';", name);
                    dbCmd.CommandText = sqlQuery;
                    using (IDataReader dataReader = dbCmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            describe = dataReader.GetString(0);
                        }
                        dbConnection.Close();
                        dataReader.Close();


                    }
                }
            }

            return describe;
        }

        public string GetDimensions(string name)
        {
            string dimensions = "";
            //ConnectionString = string.Format("URI=file:{0}/DataBase/AR_IDEA.sqlite", Application.dataPath);
            using (IDbConnection dbConnection = new SqliteConnection(ConnectionString))
            {
                dbConnection.Open();
                using (IDbCommand dbCmd = dbConnection.CreateCommand())
                {
                    string sqlQuery = string.Format("SELECT Dimensions FROM Products WHERE Name='{0}';", name);
                    dbCmd.CommandText = sqlQuery;
                    using (IDataReader dataReader = dbCmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            dimensions = dataReader.GetString(0);
                        }
                        dbConnection.Close();
                        dataReader.Close();


                    }
                }
            }

            return dimensions;
        }

        public string GetNumber(string name)
        {
            string number = "";
            //ConnectionString = string.Format("URI=file:{0}/DataBase/AR_IDEA.sqlite", Application.dataPath);
            using (IDbConnection dbConnection = new SqliteConnection(ConnectionString))
            {
                dbConnection.Open();
                using (IDbCommand dbCmd = dbConnection.CreateCommand())
                {
                    string sqlQuery = string.Format("SELECT Number FROM Products WHERE Name='{0}';", name);
                    dbCmd.CommandText = sqlQuery;
                    using (IDataReader dataReader = dbCmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            number = dataReader.GetString(0);
                        }
                        dbConnection.Close();
                        dataReader.Close();


                    }
                }
            }

            return number;
        }
    }
}
