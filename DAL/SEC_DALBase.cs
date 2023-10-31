using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using System.Net.Mail;
using AddEditMetronic8.Areas.SEC_User.Models;

namespace AddEditMetronic8.DAL
{
    public class SEC_DALBase: DAL_Helper
	{
        #region Method: dbo_PR_SEC_User_SelectByPK
        public DataTable dbo_PR_SEC_User_SelectByPK(int? UserID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_SEC_User_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, UserID);

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

        #region Method: dbo_PR_SEC_User_SelectByPK
        public DataTable dbo_PR_SEC_User_SelectByUserNamePassword(string UserName,string Password)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_SEC_User_SelectByUserNamePassword");
                sqlDB.AddInParameter(dbCMD, "UserName", SqlDbType.VarChar, UserName);   
                sqlDB.AddInParameter(dbCMD, "Password", SqlDbType.VarChar, Password);

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

		#region Function: dbo_PR_SEC_User_Insert
		public bool? dbo_PR_SEC_User_Insert(SEC_UserModel modelSEC_User)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(ConnectionStr);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SEC_User_Insert");
				sqlDB.AddInParameter(dbCMD, "@UserName", SqlDbType.NVarChar, modelSEC_User.UserName);
				sqlDB.AddInParameter(dbCMD, "@Password", SqlDbType.NVarChar, modelSEC_User.Password); // This should be the hashed password
				sqlDB.AddInParameter(dbCMD, "@FirstName", SqlDbType.NVarChar, modelSEC_User.FirstName);
				sqlDB.AddInParameter(dbCMD, "@LastName", SqlDbType.NVarChar, modelSEC_User.LastName);
				sqlDB.AddInParameter(dbCMD, "@EmailAddress", SqlDbType.NVarChar, modelSEC_User.EmailAddress);
				sqlDB.AddInParameter(dbCMD, "PhotoPath", SqlDbType.VarChar, modelSEC_User.PhotoPath);

				int result = sqlDB.ExecuteNonQuery(dbCMD);
				return (result == -1 ? false : true);
			}
			catch (Exception ex)
			{
				return null;
			}
		}
		#endregion

	}
}
