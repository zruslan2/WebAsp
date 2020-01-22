using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsEmpty.Implementation;
using WebFormsEmpty.Interfaces;
using WebFormsEmpty.Models;

namespace WebFormsEmpty
{
    public partial class Index : System.Web.UI.Page
    {
        // private readonly CountryService countryService;
        private readonly ICountryService countryService;
        public Index()
        {
            countryService = new CountryServiceDb();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //countryService.Add(new Country() { Name="Norwey", Capital="Oslo" });
            //countryService.Delete(3);
            //var session = Session["countSession"] as CountSession;

            //Response.Write("открытых сессий: " + session.Count);
            //Response.Write("открытых сессий: " + Session["cnt"].ToString());

            //Response.Write("<br>");
            //Response.Write(Session["Date_now"]);
            Country country = countryService.getById(1);
            GV_Refresh();
        }

        void GV_Refresh()
        {
            GV.DataSource = countryService.getAll_2();
            GV.DataBind();
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            countryService.Add(new Country()
            {
                Id = Int32.Parse(tbxId.Text),
                Name = tbxCountry.Text,
                Capital = tbxCapital.Text
            });

            GV_Refresh();
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            var countryID = Int32.Parse(GV.SelectedRow.Cells[1].Text);
            countryService.Delete(countryID);

            GV_Refresh();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var cntr = new Country()
            {                
                Name = tbxCountry.Text,
                Capital = tbxCapital.Text
            };

            var countryID = Int32.Parse(GV.SelectedRow.Cells[1].Text);

            countryService.Update_2(countryID, cntr);

            GV_Refresh();
        }

        protected void btnFind_Click(object sender, EventArgs e)
        {
           
            if (tbxId.Text != "")
            {
                var cntr = countryService.getById(Int32.Parse(tbxId.Text));
                tbxId.Text = (cntr.Id).ToString();
                tbxCountry.Text = cntr.Name;
                tbxCapital.Text = cntr.Capital;
            }
            else if (tbxCountry.Text != "")
            {
                var cntr = countryService.getByName(tbxCountry.Text);

                GV.DataSource = cntr;
                GV.DataBind();
            }        
        }
    }
}