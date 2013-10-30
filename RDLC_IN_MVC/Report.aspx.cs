using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RDLC_IN_MVC
{
    public partial class Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void LoadReport()
        {
            DataSet ds = new DataSet("DataSet1");
            DataTable dt = new DataTable("DataSet1");

            dt.Columns.Add("Product");
            dt.Columns.Add("Price");
            dt.Columns.Add("Quantity");


            DataRow row;
            for (int iIndex = 0; iIndex < 99; iIndex++)
            {
                row = dt.NewRow();
                row["Product"] = "100" + iIndex.ToString();
                row["Price"] = "K" + iIndex.ToString();
                row["Quantity"] = (iIndex * 32678).ToString();
                dt.Rows.Add(row);
            }
            ds.Tables.Add(dt);


            rptvReport.Visible = true;
            rptvReport.LocalReport.ReportPath = Server.MapPath("Views/Home/Report.rdlc");
            ReportDataSource datasource = new ReportDataSource(ds.DataSetName, ds.Tables[0]);
            rptvReport.LocalReport.DataSources.Clear();
            
            rptvReport.LocalReport.DataSources.Add(datasource);
            
            rptvReport.LocalReport.Refresh();
            
        }
    }
}