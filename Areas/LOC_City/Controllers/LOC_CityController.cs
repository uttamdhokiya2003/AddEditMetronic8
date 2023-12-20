using AddEditMetronic8.Areas.LOC_City.Models;
using AddEditMetronic8.Areas.LOC_Country.Models;
using AddEditMetronic8.Areas.LOC_State.Models;
using AddEditMetronic8.DAL;
using AddEditMetronic8.BAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AddEditMetronic8.Areas.LOC_City.Controllers
{
    [CheckAccess]
    [Area("LOC_City")]
    [Route("[Controller]/[action]")]
    public class LOC_CityController : Controller
    {
        LOC_DAL dalLOC = new LOC_DAL();

        #region SelectAll
        public IActionResult Index(LOC_CityModel modelLOC_City)
        {
            #region Select For Country Dropdown
            DataTable dt1 = dalLOC.dbo_PR_LOC_Country_SelectByDropdown();
            List<Countrydropdown> List = new List<Countrydropdown>();
            foreach (DataRow dr1 in dt1.Rows)
            {
                Countrydropdown vlst = new Countrydropdown();
                vlst.CountryID = Convert.ToInt32(dr1["CountryID"]);
                vlst.CountryName = dr1["CountryName"].ToString();
                List.Add(vlst);
            }
            ViewBag.CountryList = List;

            #endregion

            #region Select For State Dropdown
            DataTable dt2 = dalLOC.dbo_PR_LOC_State_SelectByDropdown();
            List<Statedropdown> List1 = new List<Statedropdown>();
            foreach (DataRow dr2 in dt2.Rows)
            {
                Statedropdown vlst1 = new Statedropdown();
                vlst1.StateID = Convert.ToInt32(dr2["StateID"]);
                vlst1.StateName = dr2["StateName"].ToString();
                List1.Add(vlst1);
            }
            ViewBag.StateList = List1;

            #endregion

            DataTable dt = dalLOC.dbo_PR_LOC_City_SelectAll(modelLOC_City);
            List<LOC_CityModel> City = new List<LOC_CityModel>();
            foreach (DataRow dr in dt.Rows)
            {
                LOC_CityModel CityModel = new LOC_CityModel();
                CityModel.CountryName = dr["CountryName"].ToString();
                CityModel.StateName = dr["StateName"].ToString();
                CityModel.CityName = dr["CityName"].ToString();
                CityModel.CityID = Convert.ToInt32(dr["CityID"]);
                CityModel.Created = Convert.ToDateTime(dr["Created"]);
                CityModel.Modified = Convert.ToDateTime(dr["Modified"]);
                City.Add(CityModel);
            }
            ViewBag.City = City;
            return View("LOC_CityList");
        }
        #endregion

        #region Delete
        public IActionResult Delete(int CityID)
        {
            DataTable dt = dalLOC.dbo_PR_LOC_City_Delete(CityID);

            //return View("EMP_EmployeeList");
            return RedirectToAction("Index");
        }
        #endregion

        #region Add
        public IActionResult Add(int? CityID)
        {
            #region Select For Country Dropdown
            DataTable dt1 = dalLOC.dbo_PR_LOC_Country_SelectByDropdown();
            List<Countrydropdown> List = new List<Countrydropdown>();
            foreach (DataRow dr1 in dt1.Rows)
            {
                Countrydropdown vlst = new Countrydropdown();
                vlst.CountryID = Convert.ToInt32(dr1["CountryID"]);
                vlst.CountryName = dr1["CountryName"].ToString();
                List.Add(vlst);
            }
            ViewBag.CountryList = List;
            #endregion

            #region Select For State Dropdown
            DataTable dt2 = dalLOC.dbo_PR_LOC_State_SelectByDropdown();
            List<Statedropdown> List1 = new List<Statedropdown>();
            foreach (DataRow dr2 in dt2.Rows)
            {
                Statedropdown vlst1 = new Statedropdown();
                vlst1.StateID = Convert.ToInt32(dr2["StateID"]);
                vlst1.StateName = dr2["StateName"].ToString();
                List1.Add(vlst1);
            }
            ViewBag.StateList = List1;

            #endregion

            TempData["Action"] = "Add";
            if (CityID != null)
            {
                @TempData["Action"] = "Edit";
                DataTable dt = dalLOC.dbo_PR_LOC_City_SelectByPK(CityID);

                LOC_CityModel modelLOC_City = new LOC_CityModel();

                foreach (DataRow dr in dt.Rows)
                {
                    modelLOC_City.CityID = Convert.ToInt32(dr["CityID"]);
                    modelLOC_City.StateID = Convert.ToInt32(dr["StateID"]);
                    modelLOC_City.CountryID = Convert.ToInt32(dr["CountryID"]);
                    modelLOC_City.CityName = dr["CityName"].ToString();

                }
                return View("LOC_CityAddEdit", modelLOC_City);
            }

            return View("LOC_CityAddEdit");
        }
        #endregion

        #region Save
        [HttpPost]
        public IActionResult Save(LOC_CityModel modelLOC_City)
        {
            if (modelLOC_City.CityID == null)
            {
                #region Insert
                DataTable dt = dalLOC.dbo_PR_LOC_City_Insert(modelLOC_City);

                TempData["CityInsertMsg"] = "Record Inserted Successfully ! ";
                #endregion
            }
            else
            {
                #region Update
                DataTable dt = dalLOC.dbo_PR_LOC_City_Update(modelLOC_City);

                TempData["CityInsertMsg"] = "Record Updated Successfully ! ";
                #endregion
            }

            return RedirectToAction("ADD");
            //return View("LOC_CityAddEdit");
        }
        #endregion

        #region DropDownByCountry 

        public IActionResult DropDownByCountry(int CountryID)
        {
            #region State Dropdwon

            DataTable dt2 = dalLOC.PR_LOC_State_SelectDropdownByCountryID(CountryID);

            List<Statedropdown> List2 = new List<Statedropdown>();
            foreach (DataRow dr2 in dt2.Rows)
            {
                Statedropdown vlst2 = new Statedropdown();
                vlst2.StateID = Convert.ToInt32(dr2["StateID"]);
                vlst2.StateName = dr2["StateName"].ToString();
                List2.Add(vlst2);
            }
            var vModel = List2;
            return Json(vModel);
            #endregion

        }
        #endregion
    }
}
