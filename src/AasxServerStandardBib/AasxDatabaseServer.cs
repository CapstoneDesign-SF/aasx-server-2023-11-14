using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Drawing.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AasxDatabaseServer
{
    public class DatabaseServer
    {
        // DB 서버 주소. 로컬일 경우 localhost
        private string _server = "localhost";
        // DB 서버 포트
        private int _port = 3306;
        // DB 이름
        private string _database = "aas_db_test";
        // 계정 아이디
        private string _id = "root";
        // 계정 비밀번호
        private string _pw = "0000";

        private string _connectionAddress = "";
        

        public DatabaseServer() {
            _connectionAddress = string.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4}", _server, _port, _database, _id, _pw);
        }

        // Method to check MySql server is availlable.
        public bool testConnection()
        {
            try
            {
                using (MySqlConnection mysql = new MySqlConnection(_connectionAddress))
                {
                    mysql.Open();

                    string selectVersion = string.Format("SELECT version()");

                    MySqlCommand cmd = new MySqlCommand(selectVersion, mysql);
                    MySqlDataReader table = cmd.ExecuteReader();

                    while (table.Read())
                    {
                        Console.WriteLine("MySql version = " + table["version()"].ToString());
                    }
                    table.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;
        }

        #region // INSERT
        // insert into table AssetAdministrationShell
        public bool insertIntoAASTbl(string sCategory, string sIdShort, string sId, DateTime oTimeStampCreate, DateTime oTimeStamp, DateTime oTimeStampTree)
        {
            try
            {
                using (MySqlConnection mysql = new MySqlConnection(_connectionAddress)) {
                    mysql.Open();

                    string insertQuery = string.Format("INSERT INTO asset_administration_shell (category,id_short,aas_id,time_stamp_create,time_stamp,time_stamp_tree)" +
                        " VALUES ('{0}','{1}','{2}','{3}','{4}','{5}');", sCategory, sIdShort, sId,
                        oTimeStampCreate.ToString("yyyy-MM-dd HH:mm:ss"), oTimeStamp.ToString("yyyy-MM-dd HH:mm:ss"), oTimeStampTree.ToString("yyyy-MM-dd HH:mm:ss"));

                    MySqlCommand cmd = new MySqlCommand(insertQuery, mysql);
                    if (cmd.ExecuteNonQuery() != 1)
                    {
                        return false;
                    }

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;
            
        }

        // insert into table AssetInformation
        public bool insertIntoAssetInformationTbl(string sAasId, AssetKind oAssetKind, string sGlobalAssetId, string sAssetType)
        {
            try
            {
                using (MySqlConnection mysql = new MySqlConnection(_connectionAddress))
                {
                    mysql.Open();

                    string insertQuery = string.Format("INSERT INTO asset_information (asset_kind,global_asset_id,asset_type,aas_id)" +
                        " VALUES ('{0}','{1}','{2}','{3}');", oAssetKind, sGlobalAssetId, sAssetType, sAasId);

                    MySqlCommand cmd = new MySqlCommand(insertQuery, mysql);
                    if (cmd.ExecuteNonQuery() != 1)
                    {
                        return false;
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;

        }

        // insert into table Resource
        public bool insertIntoResourceTbl(string sId, string sPath, string sContentType)
        {
            try
            {
                using (MySqlConnection mysql = new MySqlConnection(_connectionAddress))
                {
                    mysql.Open();

                    string insertQuery = string.Format("INSERT INTO resource (path,contentType,aas_id)" +
                        " VALUES ('{0}','{1}','{2}');", sPath, sContentType, sId);

                    MySqlCommand cmd = new MySqlCommand(insertQuery, mysql);
                    if (cmd.ExecuteNonQuery() != 1)
                    {
                        return false;
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;

        }

        // insert into table Reference
        public bool insertIntoReferenceTbl(string sAasId, int iRefId, ReferenceTypes sType)
        {
            try
            {
                using (MySqlConnection mysql = new MySqlConnection(_connectionAddress))
                {
                    mysql.Open();

                    string insertQuery = string.Format("INSERT INTO reference (type,id,aas_id)" +
                        " VALUES ('{0}','{1}','{2}');", sType, iRefId, sAasId);

                    MySqlCommand cmd = new MySqlCommand(insertQuery, mysql);
                    if (cmd.ExecuteNonQuery() != 1)
                    {
                        return false;
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;

        }

        // insert into table Key
        public bool insertIntoReferenceKeyTbl(string sAasId, int iRefId, int iKeyId, KeyTypes oType, string sValue)
        {
            try
            {
                using (MySqlConnection mysql = new MySqlConnection(_connectionAddress))
                {
                    mysql.Open();

                    string insertQuery = string.Format("INSERT INTO reference_key (type,value,id,reference_id,reference_aas_id)" +
                        " VALUES ('{0}','{1}',{2},{3},'{4}');", oType, sValue, iKeyId, iRefId, sAasId);

                    MySqlCommand cmd = new MySqlCommand(insertQuery, mysql);
                    if (cmd.ExecuteNonQuery() != 1)
                    {
                        return false;
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;

        }

        // insert into table Submodel
        public bool insertIntoSubmodelTbl(string sIdShort, string sId, DateTime oTimeStampCreate, DateTime oTimeStamp, DateTime oTimeStampTree)
        {
            try
            {
                using (MySqlConnection mysql = new MySqlConnection(_connectionAddress))
                {
                    mysql.Open();

                    string insertQuery = string.Format("INSERT INTO submodel (submodel_id_short,submodel_id,time_stamp_create,time_stamp,time_stamp_tree)" +
                        " VALUES ('{0}','{1}','{2}','{3}','{4}');", sIdShort, sId,
                        oTimeStampCreate.ToString("yyyy-MM-dd HH:mm:ss"), oTimeStamp.ToString("yyyy-MM-dd HH:mm:ss"), oTimeStampTree.ToString("yyyy-MM-dd HH:mm:ss"));

                    MySqlCommand cmd = new MySqlCommand(insertQuery, mysql);
                    if (cmd.ExecuteNonQuery() != 1)
                    {
                        return false;
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;

        }

        // insert into table Submodel Element
        public bool insertIntoSubmodelElementTbl(string sCategory, string sIdShort, string sValueType, float fValue, string sModelType, int iId, string sSubId)
        {
            try
            {
                using (MySqlConnection mysql = new MySqlConnection(_connectionAddress))
                {
                    mysql.Open();

                    string insertQuery = string.Format("INSERT INTO submodel_element (category,id_short,value_type,value,model_type,id,submodel_submodel_id)" +
                        " VALUES ('{0}','{1}','{2}',{3},'{4}',{5},'{6}');", 
                        sCategory, sIdShort, sValueType, fValue, sModelType, iId, sSubId);

                    MySqlCommand cmd = new MySqlCommand(insertQuery, mysql);
                    if (cmd.ExecuteNonQuery() != 1)
                    {
                        return false;
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;

        }

        // insert into table Operational data
        #endregion

        // TODO: SELECT command for MySql server
        #region // SELECT

        #endregion

        #region // UPDATE
        /*public bool updateOperationalData(string inputData)
        {
            try
            {
                using (MySqlConnection mysql = new MySqlConnection(_connectionAddress))
                {
                    mysql.Open();

                    string updateQuery = string.Format("UPDATE submodel_element SET (category,id_short,value_type,value,model_type,id,submodel_submodel_id)" +
                        " VALUES ('{0}','{1}','{2}',{3},'{4}',{5},'{6}');",
                        sCategory, sIdShort, sValueType, fValue, sModelType, iId, sSubId);

                    MySqlCommand cmd = new MySqlCommand(insertQuery, mysql);
                    if (cmd.ExecuteNonQuery() != 1)
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;
        }*/
        #endregion
    }
}
