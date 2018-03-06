using Mono.Data.Sqlite;
using System.Data;
using System.IO;
using UnityEngine;

namespace Assets.Scripts
{
    class DataBaseController
    {
        string ConnectionString;
        string filepath;

        public DataBaseController()
        {
            ConnectionString = string.Format("URI=file:{0}/StreamingAssets/SQL/AR_IDEA.sqlite", Application.dataPath);
            filepath = string.Format(Application.persistentDataPath + "/DataBase/AR_IDEA.sqlite");
        }

        public string GetDimensions(string name)
        {
            return GetString(name, string.Format("SELECT Dimensions FROM Products WHERE Name='{0}';", name));
        }

        public string GetDescribe(string name)
        {
            return GetString(name, string.Format("SELECT Describe FROM Products WHERE Name='{0}';", name));
        }

        public string GetNumber(string name)
        {
            return GetString(name, string.Format("SELECT Number FROM Products WHERE Name='{0}';", name));
        }

        public double GetPrice(string name)
        {
            return GetDouble(name, string.Format("SELECT Price FROM Products WHERE Name='{0}';", name));
        }

        public double GetDouble(string name, string queryCommand)
        {
            //CheckDBExist();
            //string sqlQuery = string.Format("SELECT Price FROM Products WHERE Name='{0}';", name);
            double result = 0;
            using (IDbConnection dbConnection = new SqliteConnection(ConnectionString))
            {
                dbConnection.Open();
                using (IDbCommand dbCmd = dbConnection.CreateCommand())
                {
                    dbCmd.CommandText = queryCommand;
                    using (IDataReader dataReader = dbCmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            result = dataReader.GetDouble(0);
                        }
                        dbConnection.Close();
                        dataReader.Close();
                    }
                }
            }

            return result;
        }



        public string GetString(string name, string queryCommand)
        {
            //CheckDBExist();
            string result = "";
            //ConnectionString = string.Format("URI=file:{0}/DataBase/AR_IDEA.sqlite", Application.dataPath);
            using (IDbConnection dbConnection = new SqliteConnection(ConnectionString))
            {
                dbConnection.Open();
                using (IDbCommand dbCmd = dbConnection.CreateCommand())
                {
                    //string sqlQuery = string.Format("SELECT Describe FROM Products WHERE Name='{0}';", name);
                    dbCmd.CommandText = queryCommand;
                    using (IDataReader dataReader = dbCmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            result = dataReader.GetString(0);
                        }
                        dbConnection.Close();
                        dataReader.Close();


                    }
                }
            }

            return result;
        }

        //private void CheckDBExist()
        //{
        //    if (!File.Exists(filepath))

        //    {

        //        // if it doesn't ->

        //        // open StreamingAssets directory and load the db ->

        //        WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/DataBase/AR_IDEA.sqlite");  // this is the path to your StreamingAssets in android

        //        while (!loadDB.isDone) { }  // CAREFUL here, for safety reasons you shouldn't let this while loop unattended, place a timer and error check

        //        // then save to Application.persistentDataPath

        //        File.WriteAllBytes(filepath, loadDB.bytes);

        //        ConnectionString = "URI=file:" + filepath;
        //    }
        //}
    }
}
