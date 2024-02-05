using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Drawing.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AasxServerStandardBib.Logging;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;

namespace AasxDatabaseServer
{
    public class DatabaseServer
    {
        // DB 서버 주소. 로컬일 경우 localhost
        //private string _server = "aas-database.cjhnbi27czq0.ap-northeast-2.rds.amazonaws.com";
        //private string _server = "localhost";
        // DB 서버 포트
        //private int _port = 3306;
        // DB 이름
        //private string _database = "aas_db_test";
        // 계정 아이디
        //private string _id = "admin";
        //private string _id = "root";
        // 계정 비밀번호
        //private string _pw = "whdgkqtjfrP";
        //private string _pw = "0000";

        private string _connectionAddress = "";

        private static ILogger _logger = ApplicationLogging.CreateLogger("DatabaseServer");


        public DatabaseServer(string sServer = "host.docker.internal",
            int iPort = 3306,
            string sDatabase = "aas_db_test",
            string sId = "root",
            string sPw = "0000") {

            _connectionAddress = string.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4}",
                sServer, iPort, sDatabase, sId, sPw);
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

        // insert into table Property
        public bool insertSubmodelPropertyTbl(string submodelIdentifier, string idShortPath, ISubmodelElement newSme)
        {
            try
            {
                if(newSme is Property property)
                {
                    using (MySqlConnection mysql = new MySqlConnection(_connectionAddress))
                    {
                        mysql.Open();

                        string insertQuery = string.Format("INSERT INTO property (submodel_id,id_short_path,category,id_short,value_type,value,model_type)" +
                            " VALUES ('{0}','{1}','{2}','{3}','{4}',{5},'{6}');",
                            submodelIdentifier, idShortPath, property.Category, property.IdShort, property.ValueType, property.Value, "Property");

                        MySqlCommand cmd = new MySqlCommand(insertQuery, mysql);
                        if (cmd.ExecuteNonQuery() != 1)
                        {
                            _logger.LogWarning($"Failed to insert to table 'property'");
                            return false;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            _logger.LogInformation($"Success insert to table 'property'");
            return true;
        }

        // insert into table Property Log
        public bool insertSubmodelPropertyLogTbl(string submodelIdentifier, string idShortPath, ISubmodelElement newSme)
        {
            try
            {
                if (newSme is Property property)
                {
                    using (MySqlConnection mysql = new MySqlConnection(_connectionAddress))
                    {
                        mysql.Open();

                        string insertQuery = string.Format("INSERT INTO property_log (submodel_id,id_short_path,category,id_short,value_type,value,model_type)" +
                            " VALUES ('{0}','{1}','{2}','{3}','{4}',{5},'{6}');",
                            submodelIdentifier, idShortPath, property.Category, property.IdShort, property.ValueType, property.Value, "Property");
                        _logger.LogDebug(insertQuery);

                        MySqlCommand cmd = new MySqlCommand(insertQuery, mysql);
                        if (cmd.ExecuteNonQuery() != 1)
                        {
                            _logger.LogWarning($"Failed to insert to table 'property_log'");
                            return false;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            _logger.LogInformation($"Success insert to table 'property_log'");
            return true;
        }
        #endregion

        // TODO: SELECT command for MySql server
        #region // SELECT
        // select from table Property by submodel id and idShort
        public bool selectSubmodelPropertyTblBySubmodelIdAndIdShor(string submodelIdentifier, string idShortPath)
        {
            try
            {
                using (MySqlConnection mysql = new MySqlConnection(_connectionAddress))
                {
                    mysql.Open();

                    string updateQuery = string.Format("SELECT * FROM property" +
                        " WHERE submodel_id='{0}' AND id_short_path='{1}';",
                        submodelIdentifier, idShortPath);

                    MySqlCommand cmd = new MySqlCommand(updateQuery, mysql);
                    MySqlDataReader table = cmd.ExecuteReader();

                    bool fieldCnt = table.HasRows;
                    if (!fieldCnt)
                    {
                        _logger.LogWarning($"Result of SELECT has NO rows");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            _logger.LogInformation($"Result of SELECT has rows");
            return true;
        }

        // select from table Property by submodel id and idShort during time
        public bool selectSubmodelPropertyLogTblDuringTimeBySubmodelIdAndIdShort(string submodelIdentifier, string idShortPath, DateTime timeSince)
        {
            try
            {
                using (MySqlConnection mysql = new MySqlConnection(_connectionAddress))
                {
                    mysql.Open();

                    string selectQuery = string.Format("SELECT * FROM property_log" +
                        " WHERE submodel_id='{0}' AND id_short_path='{1}'" +
                        " AND timestamp > '{2}';",
                        submodelIdentifier, idShortPath, timeSince.ToString("yyyy-MM-dd HH:mm:ss"));
                    _logger.LogDebug(selectQuery);

                    MySqlCommand cmd = new MySqlCommand(selectQuery, mysql);
                    MySqlDataReader table = cmd.ExecuteReader();

                    bool fieldCnt = table.HasRows;
                    if (!fieldCnt)
                    {
                        _logger.LogWarning($"Result of SELECT has NO rows");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            _logger.LogInformation($"Result of SELECT has rows");
            return true;
        }

        // select average during [time] of property's value by submodel id and idShort.
        public int selectValueAvgFromPropertyLogTblDuringTimeBySubmodelIdAndIdShort(string submodelIdentifier, string idShortPath, DateTime timeSince)
        {
            try
            {
                using (MySqlConnection mysql = new MySqlConnection(_connectionAddress))
                {
                    mysql.Open();

                    string selectQuery = string.Format("SELECT AVG(value) AS AVG FROM property_log" +
                        " WHERE submodel_id='{0}' AND id_short_path='{1}'" +
                        " AND timestamp > '{2}';",
                        submodelIdentifier, idShortPath, timeSince.ToString("yyyy-MM-dd HH:mm:ss"));
                    _logger.LogDebug(selectQuery);

                    MySqlCommand cmd = new MySqlCommand(selectQuery, mysql);
                    MySqlDataReader table = cmd.ExecuteReader();

                    if (table.Read())
                    {
                        int avg = Convert.ToInt32(Math.Round(Convert.ToDouble(table["AVG"])));
                        _logger.LogInformation($"Result of SELECT has rows. AVG is {avg}");
                        return avg;
                    }
                    else
                    {
                        _logger.LogWarning($"Result of SELECT has NO rows");
                        return -1;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }
        #endregion

        #region // UPDATE
        // update table Property by submodel id and idShort
        public bool updateSubmodelPropertyTblBySubmodelIdAndIdShor(string submodelIdentifier, string idShortPath, ISubmodelElement newSme)
        {
            try
            {
                using (MySqlConnection mysql = new MySqlConnection(_connectionAddress))
                {
                    mysql.Open();

                    if (newSme is Property property)
                    {
                        var category = property.Category;
                        var idShort = property.IdShort;
                        var valueType = property.ValueType;
                        var value = property.Value;
                        string modelType = "Property";

                        string updateQuery = string.Format("UPDATE property SET submodel_id='{0}',id_short_path='{1}',category='{2}',id_short='{3}',value_type='{4}',value='{5}',model_type='{6}',timestamp='{7}'" +
                        " WHERE submodel_id='{0}' AND id_short_path='{1}';",
                        submodelIdentifier, idShortPath, category, idShort, valueType, value, modelType, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                        MySqlCommand cmd = new MySqlCommand(updateQuery, mysql);
                        if (cmd.ExecuteNonQuery() != 1)
                        {
                            _logger.LogWarning($"Failed to update table 'property'");
                            return false;
                        }
                    }
                    else
                    {
                        _logger.LogWarning($"Failed to update table 'property' becuase newSme is NOT property");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            _logger.LogInformation($"Success to update table 'property'");
            return true;
        }
        #endregion
    }
}
