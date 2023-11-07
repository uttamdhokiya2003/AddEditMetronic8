using AddEditMetronic8.Areas.LOC_City.Models;
using AddEditMetronic8.Areas.LOC_Country.Models;
using AddEditMetronic8.Areas.LOC_State.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using AddEditMetronic8.DAL;
using System.Data;
using System.Data.Common;
using System.Runtime.Intrinsics.Arm;
using AddEditMetronic8.BAL;

namespace AddEditMetronic8.DAL
{
    public class LOC_DALBase: DAL_Helper
    {
        #region Country Table
        #region dbo.PR_LOC_Country_SelectAll
        public DataTable dbo_PR_LOC_Country_SelectAll( )
        {
            try
            {

                SqlDatabase sqlDB=new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_LOC_Country_SelectAll");
				sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());

				DataTable dt=new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex) 
            {
                return null;
            }
            
        }
        #endregion

        #region dbo.PR_LOC_Country_SelectByPK
        public DataTable dbo_PR_LOC_Country_SelectByPK(int? CountryID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_LOC_Country_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "CountryID", SqlDbType.Int, CountryID);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion

        #region dbo.PR_LOC_Country_Insert
        public DataTable dbo_PR_LOC_Country_Insert(LOC_CountryModel modelLOC_Country)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_LOC_Country_Insert");
                sqlDB.AddInParameter(dbCMD, "CountryName", SqlDbType.NVarChar, modelLOC_Country.CountryName);
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion

        #region dbo.PR_LOC_Country_Update
        public DataTable dbo_PR_LOC_Country_Update(LOC_CountryModel modelLOC_Country,int CountryID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_LOC_Country_Update");
                sqlDB.AddInParameter(dbCMD, "CountryID ", SqlDbType.Int,CountryID);
                sqlDB.AddInParameter(dbCMD, "CountryName", SqlDbType.NVarChar, modelLOC_Country.CountryName);
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion

        #region dbo.PR_LOC_Country_Delete
        public DataTable dbo_PR_LOC_Country_Delete(int? CountryID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_LOC_Country_Delete");
                sqlDB.AddInParameter(dbCMD, "CountryID", SqlDbType.Int, CountryID);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion

        #region dbo.PR_LOC_Country_SelectByCountryName
        public DataTable dbo_PR_LOC_Country_SelectByCountryName(string CountryName)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_LOC_Country_SelectByCountryName");
                DataTable dt = new DataTable();
                sqlDB.AddInParameter(dbCMD, "CountryName", SqlDbType.NVarChar, CountryName);

                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion
        #endregion

        #region State Table
        #region dbo.PR_LOC_State_SelectAll
        public DataTable dbo_PR_LOC_State_SelectAll(LOC_StateModel modelLOC_State)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_LOC_State_SelectAll");
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());

                DataTable dt = new DataTable();
                if (modelLOC_State.CountryID != null || modelLOC_State.StateName != null || modelLOC_State.UserID!= null)
                {
                    dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_State_SelectByCountryNameStateName");
                    sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());

                    if (modelLOC_State.CountryID != null)
                        sqlDB.AddInParameter(dbCMD, "CountryID", SqlDbType.Int, modelLOC_State.CountryID);
                    else
                        sqlDB.AddInParameter(dbCMD, "CountryID", SqlDbType.Int, "");


                    if (modelLOC_State.StateName != null)
                        sqlDB.AddInParameter(dbCMD, "StateName", SqlDbType.NVarChar, modelLOC_State.StateName);
                    else
                        sqlDB.AddInParameter(dbCMD, "StateName", SqlDbType.NVarChar, "");

                }
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion

        #region dbo.PR_LOC_State_SelectByPK
        public DataTable dbo_PR_LOC_State_SelectByPK(int? StateID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_LOC_State_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "StateID", SqlDbType.Int, StateID);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion

        #region dbo.PR_LOC_State_Insert
        public DataTable dbo_PR_LOC_State_Insert(LOC_StateModel modelLOC_State)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_LOC_State_Insert");
                sqlDB.AddInParameter(dbCMD, "CountryID ", SqlDbType.Int, modelLOC_State.CountryID);
                sqlDB.AddInParameter(dbCMD, "StateName", SqlDbType.NVarChar, modelLOC_State.StateName);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion

        #region dbo.PR_LOC_State_Update
        public DataTable dbo_PR_LOC_State_Update(LOC_StateModel modelLOC_State)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_LOC_State_Update");
                sqlDB.AddInParameter(dbCMD, "StateID", SqlDbType.Int, modelLOC_State.StateID);
                sqlDB.AddInParameter(dbCMD, "CountryID ", SqlDbType.Int, modelLOC_State.CountryID);
                sqlDB.AddInParameter(dbCMD, "StateName", SqlDbType.NVarChar, modelLOC_State.StateName);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion

        #region dbo.PR_LOC_State_Delete
        public DataTable dbo_PR_LOC_State_Delete(int? StateID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_LOC_State_Delete");
                sqlDB.AddInParameter(dbCMD, "StateID", SqlDbType.Int, StateID);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion

        #region dbo.PR_LOC_State_SelectByStateNameCountryName
        public DataTable dbo_PR_LOC_State_SelectByStateNameCountryName(string CountryName, string StateName)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_LOC_State_SelectByStateNameCountryName");
                DataTable dt = new DataTable();
                sqlDB.AddInParameter(dbCMD, "CountryName", SqlDbType.NVarChar, CountryName);
                sqlDB.AddInParameter(dbCMD, "StateName", SqlDbType.NVarChar, StateName);

                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion

        #region dbo.PR_LOC_State_SelectByStateNameCountryID
        public DataTable dbo_PR_LOC_State_SelectByStateNameCountryID(int CountryID, string StateName)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_LOC_State_SelectByStateNameCountryID");
                DataTable dt = new DataTable();
                sqlDB.AddInParameter(dbCMD, "CountryID", SqlDbType.Int, CountryID);
                sqlDB.AddInParameter(dbCMD, "StateName", SqlDbType.NVarChar, StateName);

                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion
        #endregion

        #region City Table
        #region dbo.PR_LOC_City_SelectAll
        public DataTable dbo_PR_LOC_City_SelectAll(LOC_CityModel modelLOC_City)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_LOC_City_SelectAll");

                DataTable dt = new DataTable();
                if (modelLOC_City.CountryID != null || modelLOC_City.StateID != null || modelLOC_City.CityName != null)
                {
                    dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_City_SelectByCountryNameStateNameCityName");

                    if (modelLOC_City.CountryID != null)
                        sqlDB.AddInParameter(dbCMD, "CountryID", SqlDbType.Int, modelLOC_City.CountryID);
                    else
                        sqlDB.AddInParameter(dbCMD, "CountryID", SqlDbType.Int, "");


                    if (modelLOC_City.StateID != null)
                        sqlDB.AddInParameter(dbCMD, "StateID", SqlDbType.Int, modelLOC_City.StateID);
                    else
                        sqlDB.AddInParameter(dbCMD, "StateID", SqlDbType.Int, "");

                    if (modelLOC_City.CityName != null)
                        sqlDB.AddInParameter(dbCMD, "CityName", SqlDbType.NVarChar, modelLOC_City.CityName);
                    else
                        sqlDB.AddInParameter(dbCMD, "CityName", SqlDbType.NVarChar, "");

                }
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion

        #region dbo.PR_LOC_City_SelectByPK
        public DataTable dbo_PR_LOC_City_SelectByPK(int? CityID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_LOC_City_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "CityID", SqlDbType.Int, CityID);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion

        #region dbo.PR_LOC_City_Insert
        public DataTable dbo_PR_LOC_City_Insert(LOC_CityModel modelLOC_City)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_LOC_City_Insert");
                sqlDB.AddInParameter(dbCMD, "CountryID", SqlDbType.Int, modelLOC_City.CountryID);
                sqlDB.AddInParameter(dbCMD, "StateID", SqlDbType.Int, modelLOC_City.StateID);
                sqlDB.AddInParameter(dbCMD, "CityName", SqlDbType.NVarChar, modelLOC_City.CityName);
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion

        #region dbo.PR_LOC_City_Update
        public DataTable dbo_PR_LOC_City_Update(LOC_CityModel modelLOC_City)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_LOC_City_Update");
                sqlDB.AddInParameter(dbCMD, "CityID", SqlDbType.Int, modelLOC_City.CityID);
                sqlDB.AddInParameter(dbCMD, "StateID", SqlDbType.Int, modelLOC_City.StateID);
                sqlDB.AddInParameter(dbCMD, "CountryID ", SqlDbType.Int, modelLOC_City.CountryID);
                sqlDB.AddInParameter(dbCMD, "CityName", SqlDbType.NVarChar, modelLOC_City.CityName);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion

        #region dbo.PR_LOC_City_Delete
        public DataTable dbo_PR_LOC_City_Delete(int? CityID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_LOC_City_Delete");
                sqlDB.AddInParameter(dbCMD, "CityID", SqlDbType.Int, CityID);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion
        #endregion



    }
}
