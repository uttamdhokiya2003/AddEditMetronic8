﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AddEditMetronic8.BAL
{
    
    public static class CV
    {
        private static IHttpContextAccessor _httpContextAccessor;
        public static Boolean IsURLEncryption = true;

		#region CV
		static CV()
        {
            _httpContextAccessor = new HttpContextAccessor();
        }
		#endregion

		#region UserName
		public static string? UserName()
        {
            string? UserName = null;

            if (_httpContextAccessor.HttpContext.Session.GetString("UserName") != null)
            {
                UserName = _httpContextAccessor.HttpContext.Session.GetString("UserName").ToString();
            }
            return UserName;
        }
		#endregion

		#region UserID
		public static int? UserID()
        {
            int? UserID = null;
            if (_httpContextAccessor.HttpContext.Session.GetString("UserID") != null)
            {
                UserID = Convert.ToInt32(_httpContextAccessor.HttpContext.Session.GetString("UserID"));
            }
            return UserID;
        }
		#endregion

		#region Email
		public static string? Email()
        {
            string? Email = null;

            if (_httpContextAccessor.HttpContext.Session.GetString("EmailAddress") != null)
            {
                Email = _httpContextAccessor.HttpContext.Session.GetString("EmailAddress").ToString();
            }
            return Email;
        }
        #endregion

        #region Password
        public static string? Password()
        {
            string? Password = null;

            if(_httpContextAccessor.HttpContext.Session.GetString("Password") != null)
            {
                Password = _httpContextAccessor.HttpContext.Session.GetString("Password").ToString();
            }
            return Password;
        }
        #endregion


    }
}
