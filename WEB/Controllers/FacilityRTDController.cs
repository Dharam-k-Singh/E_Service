using iTextSharp.text;
using iTextSharp.text.pdf;
using Model.Models;
using Model.Models.FacilityRTD;
using Model.Models.ListOfValue;
using Model.Models.UserDetail;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.APIHelper;
using WEB.Helper;

namespace WEB.Controllers
{
    public class FacilityRTDController : BaseController
    {
        // GET: Facility
        public ActionResult Index()
        {
            return View();
        }


        private void GetMaters()
        {

            //int userId = 0;
            //if (Session != null)
            //{
            //    UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
            //    userId = userdetail.UDID;


            //}

            //DateTime date = DateTime.UtcNow.Date;

            //PassIdModel model = new PassIdModel();

            //model.Currentdate = date;

            

            //List<WeeksListModel> org = WebAPIHelper.CallApi<List<WeeksListModel>>(HttpMethods.Post, "GetWeeksList", "FacilityRTD", model);
            //ViewBag.Weeks = new SelectList(org, "WeekId", "WeekId");

            List<WeeksModel> org = WebAPIHelper.CallApi<List<WeeksModel>>(HttpMethods.Get, "GetWeeksList", "FacilityRTD" );
            ViewBag.Weeks = new SelectList(org, "WeekId", "WeekId");

            //List<WeeksListModel> org = WebAPIHelper.CallApi<List<WeeksListModel>>(HttpMethods.Get, "GetWeeksList", "FacilityRTD");
            //ViewBag.Weeks = new SelectList(org, "WeekId", "WeekId");

            int id = 0;
            List<ListOfValueModel> lists = WebAPIHelper.CallApi<List<ListOfValueModel>>(HttpMethods.Get, "GetListOfValueRTD", "ListOfValue" ,null , id);
            ViewBag.category = new SelectList(lists, "LOVId", "LOVName");

            List<ListOfYearModel> decadeYear = WebAPIHelper.CallApi<List<ListOfYearModel>>(HttpMethods.Get, "GetListOfYear", "ListOfValue", null, 0);
            ViewBag.decadeYear = new SelectList(decadeYear, "Year", "Year");

            List<ListOfYearModel> consecutiveYear = WebAPIHelper.CallApi<List<ListOfYearModel>>(HttpMethods.Get, "GetListOfYear", "ListOfValue", null, 0);
            ViewBag.consecutiveYear = new SelectList(consecutiveYear, "Id", "Year");

            int MonthId = (int)Model.CommonEnum.LOVRTD.LOVId.MonthName;
            List<ListOfValueModel> month = WebAPIHelper.CallApi<List<ListOfValueModel>>(HttpMethods.Get, "GetListOfValueRTD", "ListOfValue", null, MonthId);
            ViewBag.month = new SelectList(month, "LOVId", "LOVName");



        }


        [HttpPost]
        public ActionResult GetWeeksDetails(int year, int weekId)
        {
            
            var model = DateHelper.GetDatesInWeek(year, weekId);

           

            //WeeksListModel model1 = WebAPIHelper.CallApi<WeeksListModel>(HttpMethods.Get, "GetWeeksDetails", "FacilityRTD", null, weekId);


            return Json(model, JsonRequestBehavior.AllowGet);
            
        }


        public ActionResult AddFood()
        {
            GetMaters();
            return View();
        }

        [HttpPost]
        public ActionResult SaveFooddetails(FoodDetailsModel objMain,string Save)
        {

            int userId = 0;
            if (Session != null)
            {
                UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
                userId = userdetail.UDID;
                objMain.Createdby = userId;

            }
            ResponseInfo SavedId = new ResponseInfo();
         
            ResponseInfo si = WebAPIHelper.CallApi<ResponseInfo>(HttpMethods.Post, "Save", "FacilityRTD", objMain);

             objMain.FDId = Convert.ToInt32(si.ID);
             SavedId.ID = si.ID;
             SavedId.Msg = si.Msg;

                   
            GetMaters();


            if (objMain.FDId == 0)
            {

                TempData["Success"] = SavedId.Msg;
                //ModelState.Clear();
                // return View("AddLFZRequest");
                return RedirectToAction("List");
            }
            else
            {
                TempData["Success"] = SavedId.Msg;
                //ModelState.Clear();
                return RedirectToAction("List");
            }
        }

        [HttpGet]
        public ActionResult List()
        {
           
            GetMaters();
            List<WeeksListModel> model = WebAPIHelper.CallApi<List<WeeksListModel>>(HttpMethods.Get, "GetListFoodDetails", "FacilityRTD");
           

            return View(model);

        }

        public ActionResult EditFood(int yearId, int weekId)
        {
            //UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];

            EditFoodDetailsModel GetUserEdit = WebAPIHelper.CallApi<EditFoodDetailsModel>(HttpMethods.Get, "GetEditFoodDetails", "FacilityRTD", null, yearId, weekId);
           
            GetMaters();

            return View("EditFood", GetUserEdit);
        }


        public ActionResult ViewFood(int yearId, int weekId)
        {
            GetMaters();
            //UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
        
            ViewFoodDetailsModel GetUserEdit = WebAPIHelper.CallApi<ViewFoodDetailsModel>(HttpMethods.Get, "GetViewFoodDetails", "FacilityRTD", null, yearId, weekId);


            return View("ViewFood", GetUserEdit);
        }







        public ActionResult MenuView()
        {
            DateTime date = DateTime.UtcNow.Date;

            PassIdModel model = new PassIdModel();

            model.Currentdate = date;

            ViewFoodDetailsModel GetUserEdit = WebAPIHelper.CallApi<ViewFoodDetailsModel>(HttpMethods.Post, "GetMenuViewDetails", "FacilityRTD", model);

            

            return View("MenuView", GetUserEdit);
        }

        public ActionResult AddMeterDetails()
        {
            GetMaters();

            return View();
        }

        [HttpPost]
        public ActionResult GetSubCategoryId(string CategoryId)
        {

            int categoryid;
            List<SelectListItem> CategoryNames = new List<SelectListItem>();
            if (!string.IsNullOrEmpty(CategoryId))
            {
                categoryid = Convert.ToInt32(CategoryId);
                List<ListOfValueModel> actionid = WebAPIHelper.CallApi<List<ListOfValueModel>>(HttpMethods.Get, "GetListOfValueRTD", "ListOfValue", null, categoryid);

                actionid.ForEach(x =>
                {
                    CategoryNames.Add(new SelectListItem { Text = x.LOVName, Value = x.LOVId.ToString() });
                });
            }
            return Json(CategoryNames, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveMeterDetails(MeterReadingModel objMain, string Save)
        {

            int userId = 0;
            if (Session != null)
            {
                UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
                userId = userdetail.UDID;
                objMain.Createdby = userId;

            }
            ResponseInfo SavedId = new ResponseInfo();

            ResponseInfo si = WebAPIHelper.CallApi<ResponseInfo>(HttpMethods.Post, "SaveMeterDetails", "FacilityRTD", objMain);

            objMain.MId = Convert.ToInt32(si.ID);
            SavedId.ID = si.ID;
            SavedId.Msg = si.Msg;


            GetMaters();


            if (objMain.MId == 0)
            {

                TempData["Success"] = SavedId.Msg;
                //ModelState.Clear();
                // return View("AddLFZRequest");
                return RedirectToAction("ListMeterDetails");
            }
            else
            {
                TempData["Success"] = SavedId.Msg;
                //ModelState.Clear();
                return RedirectToAction("ListMeterDetails");
            }
        }

        [HttpGet]
        public ActionResult ListMeterDetails(int? Id)
        {

            GetMaters();
            List<MeterReadingListModel> model = WebAPIHelper.CallApi<List<MeterReadingListModel>>(HttpMethods.Get, "GetListMeterDetails", "FacilityRTD" ,null,Id);


            return View(model);

        }
        public ActionResult ExcelMeterDetails(int ExportType , int? Id)
        {
            //int userId = 0;
            //if (Session != null)
            //{
            //    UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
            //    userId = userdetail.UDID;

            //}
          
            List<MeterReadingListModel> model = WebAPIHelper.CallApi<List<MeterReadingListModel>>(HttpMethods.Get, "GetListMeterDetails", "FacilityRTD", null, Id);
          

            DataTable dt = ToDataTable(model);
            if (ExportType == 1)
            {
                DownloadXLS(dt, "Meter Details");
            }
            //if (ExportType == 2)
            //{
            //    DownloadCSV(dt, "Invoice List");
            //}
            //if (ExportType == 3)
            //{
            //    exportpdf(dt, "Invoice List");
            //}
            return RedirectToAction("ListMeterDetails");
        }
        public ActionResult EditMeterDetails(int id)
        {
            //UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];

            EditMeterReadingModel GetUserEdit = WebAPIHelper.CallApi<EditMeterReadingModel>(HttpMethods.Get, "GetEditMeterDetails", "FacilityRTD", null, id);

            GetMaters();

            return View("EditMeterDetails", GetUserEdit);
        }
        //------------------------------File Export Starts---------------------------------------------- 


        #region Create Datatable For Export
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
        #endregion

        #region CSV-PDF-Xls
        public void DownloadCSV(DataTable dt, string FileName)
        {

            StringBuilder sb = new StringBuilder();

            var CSVresult = new StringBuilder();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                CSVresult.Append(dt.Columns[i].ColumnName);
                CSVresult.Append(i == dt.Columns.Count - 1 ? "\n" : ",");
            }
            foreach (DataRow row in dt.Rows)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {

                    CSVresult.Append(row[i].ToString());
                    CSVresult.Append(i == dt.Columns.Count - 1 ? "\n" : ",");
                }
            }

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=" + FileName + ".csv");
            Response.ContentType = "text/csv";
            Response.Charset = "";

            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
            Response.Output.Write(CSVresult.ToString());
            Response.Flush();
            Response.End();
            //return RedirectToAction("EmployeeList");
        }

        public void DownloadXLS(DataTable dt, string FileName)
        {
            var gv = new GridView();
            gv.DataSource = dt;
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=" + FileName + ".xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";

            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
            gv.RenderControl(objHtmlTextWriter);
            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();
            //return RedirectToAction("EmployeeList");
        }

        private void exportpdf(DataTable dt, string FileName)
        {

            // creating document object  
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            Rectangle rec = new Rectangle(PageSize.A3.Rotate());
            //rec.BackgroundColor = new BaseColor(System.Drawing.Color.Olive);
            Document doc = new Document(rec);
            doc.SetPageSize(PageSize.A3.Rotate());

            PdfWriter writer = PdfWriter.GetInstance(doc, ms);
            doc.Open();

            //Creating paragraph for header  
            BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntHead = new iTextSharp.text.Font(bfntHead, 10, 1, iTextSharp.text.BaseColor.BLUE);
            Paragraph prgHeading = new Paragraph();
            prgHeading.Alignment = Element.ALIGN_LEFT;
            prgHeading.Add(new Chunk(FileName.ToUpper(), fntHead));
            doc.Add(prgHeading);

            //Adding paragraph for report generated by  
            Paragraph prgGeneratedBY = new Paragraph();
            BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntAuthor = new iTextSharp.text.Font(btnAuthor, 8, 1, iTextSharp.text.BaseColor.BLUE);
            prgGeneratedBY.Alignment = Element.ALIGN_RIGHT;
            //prgGeneratedBY.Add(new Chunk("Report Generated by : ASPArticles", fntAuthor));  
            //prgGeneratedBY.Add(new Chunk("\nGenerated Date : " + DateTime.Now.ToShortDateString(), fntAuthor));  
            doc.Add(prgGeneratedBY);

            //Adding a line  
            Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            doc.Add(p);

            //Adding line break  
            doc.Add(new Chunk("\n", fntHead));

            //Adding  PdfPTable  
            PdfPTable table = new PdfPTable(dt.Columns.Count);
            //table.HorizontalAlignment = 0;
            //table.TotalWidth = 1600f;
            //table.LockedWidth = true;
            //float[] widths = new float[] { 20f, 50f, 50f, 50f, 50f, 50f, 50f, 50f, 50f , 50f, 50f, 50f, 50f, 50f, 50f, 50f, 50f, 50f, 50f, 50f, 50f, 50f, 50f, 50f, 50f, 50f, 50f, 50f, 50f, 50f,  };
            //table.SetWidths(widths);
            //table.SetWidthPercentage(widths, PageSize.A3.Rotate());

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                string cellText = Server.HtmlDecode(dt.Columns[i].ColumnName);
                PdfPCell cell = new PdfPCell();
                //cell.Phrase = new Phrase(cellText, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10, 1, new BaseColor(System.Drawing.ColorTranslator.FromHtml("#000000"))));
                cell.Phrase = new Phrase(cellText, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 8, 1, new BaseColor(System.Drawing.ColorTranslator.FromHtml("#000000"))));

                cell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#C8C8C8"));
                //cell.Phrase = new Phrase(cellText, new Font(Font.FontFamily.TIMES_ROMAN, 10, 1, new BaseColor(grdStudent.HeaderStyle.ForeColor)));  
                //cell.BackgroundColor = new BaseColor(grdStudent.HeaderStyle.BackColor);  
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                // cell.Column.FilledWidth = 40;
                cell.PaddingBottom = 2;
                table.AddCell(cell);
                // table.WidthPercentage = 100f;

            }

            //writing table Data  
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    table.AddCell(dt.Rows[i][j].ToString());
                }
            }

            doc.Add(table);
            doc.Close();

            byte[] result = ms.ToArray();
            //System.IO.File.WriteAllBytes("hello.pdf", result);

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=" + FileName + ".pdf");
            Response.ContentType = "application/pdf";
            Response.Charset = "";

            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
            //Response.Output.Write(result);
            Response.BinaryWrite(result);
            Response.Flush();
            Response.End();

            //return result;

        }
        #endregion
        //------------------------------File Export Ends---------------------------------------------- 

    }
}