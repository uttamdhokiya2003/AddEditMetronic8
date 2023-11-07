using AddEditMetronic8.Areas.LOC_Country.Models;
using AddEditMetronic8.BAL;
using AddEditMetronic8.DAL;
using MetronicAddressBook.BAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics.Metrics;

namespace AddEditMetronic8.Areas.LOC_Country.Controllers
{
    [CheckAccess]
    [Area("LOC_Country")]
    [Route("[Controller]/[action]")]
    public class LOC_CountryController : Controller
    {
        LOC_DAL dalLOC = new LOC_DAL();

        #region SelectAll
        public IActionResult Index()
        {
            DataTable dt = dalLOC.dbo_PR_LOC_Country_SelectAll();
            List<LOC_CountryModel> Country = new List<LOC_CountryModel>();
            foreach (DataRow dr in dt.Rows)
            {
                LOC_CountryModel CountryModel = new LOC_CountryModel();
                CountryModel.CountryID = Convert.ToInt32(dr["CountryID"]);
                CountryModel.CountryName = dr["CountryName"].ToString();
                CountryModel.StateCount = Convert.ToInt32(dr["StateCount"]);
                CountryModel.CityCount = Convert.ToInt32(dr["CityCount"]);
                CountryModel.Created = Convert.ToDateTime(dr["Created"]);
                CountryModel.Modified = Convert.ToDateTime(dr["Modified"]);
                Country.Add(CountryModel);
            }
            ViewBag.Country = Country;
            return View("LOC_CountryList");
        }
        #endregion

        #region Delete
        public IActionResult Delete(int CountryID)
        {
            DataTable dt = dalLOC.dbo_PR_LOC_Country_Delete(CountryID);
            TempData["success"] = "Record Delete Successfully ! ";

            //return View("EMP_EmployeeList");
            return RedirectToAction("Index");
        }
        #endregion

        #region Add
        public IActionResult Add(string? CountryID)
        {
            if (CountryID != null)
            {

                SqlInt32 decryptedID = CommonFunctions.DecryptBase64Int32(CountryID);
                int id = decryptedID.Value;
                TempData["Action"] = "Edit";
                DataTable dt = dalLOC.dbo_PR_LOC_Country_SelectByPK(id);

                LOC_CountryModel modelLOC_Country = new LOC_CountryModel();

                foreach (DataRow dr in dt.Rows)
                {
                    modelLOC_Country.CountryID = Convert.ToInt32(dr["CountryID"]);
                    modelLOC_Country.CountryName = dr["CountryName"].ToString();

                }
                return View("LOC_CountryAddEdit", modelLOC_Country);
            }

            return View("LOC_CountryAddEdit");
        }
        #endregion

        #region Save
        [HttpPost]
        public IActionResult Save(LOC_CountryModel modelLOC_Country,string CountryID)
        {
            if (modelLOC_Country.CountryID == null)
            {
                if (CountryID == null)
                {
                    #region Insert
                    DataTable dt = dalLOC.dbo_PR_LOC_Country_Insert(modelLOC_Country);

                    TempData["success"] = "Record Inserted Successfully ! ";
                    #endregion
                }
                else
                {
                    SqlInt32 decryptedID = CommonFunctions.DecryptBase64Int32(CountryID);
                    int id = decryptedID.Value;
                    #region Update
                    DataTable dt = dalLOC.dbo_PR_LOC_Country_Update(modelLOC_Country,id);

                    TempData["success"] = "Record Updated Successfully ! ";
                    #endregion
                }
            }
            return RedirectToAction("Index");
            //return View("LOC_CountryAddEdit");
        }
        #endregion

        #region filter 
        public IActionResult Filter(string CountryName)
        {
            DataTable dt = dalLOC.dbo_PR_LOC_Country_SelectByCountryName(CountryName);
            List<LOC_CountryModel> Country = new List<LOC_CountryModel>();
            foreach (DataRow dr in dt.Rows)
            {
                LOC_CountryModel CountryModel = new LOC_CountryModel();
                CountryModel.CountryID = Convert.ToInt32(dr["CountryID"]);
                CountryModel.CountryName = dr["CountryName"].ToString();
                CountryModel.StateCount = Convert.ToInt32(dr["StateCount"]);
                CountryModel.CityCount = Convert.ToInt32(dr["CityCount"]);
                CountryModel.Created = Convert.ToDateTime(dr["Created"]);
                CountryModel.Modified = Convert.ToDateTime(dr["Modified"]);
                Country.Add(CountryModel);
            }
            ViewBag.Country = Country;
            return View("LOC_CountryList");
        }
		#endregion

		#region Function: Delete Multiple
		[HttpPost]
		public IActionResult DeleteMultiple(int[] Ids)
		{
			string result = string.Empty;
			if (Ids.Count() > 0)
			{
				foreach (int id in Ids)
				{
					dalLOC.dbo_PR_LOC_Country_Delete(id);
				}
				TempData["success"] = "Records Deleted Successfully.";
				result = "success";
			}
			return new JsonResult(result);
		}
		#endregion


	}
}
