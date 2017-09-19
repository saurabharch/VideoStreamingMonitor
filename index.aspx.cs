using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VideoLibrary.Logic.SQLBal;

namespace VideoLibrary
{
    public partial class index : System.Web.UI.Page
    {
        SQlbal cl_vd = new SQlbal();
        StringBuilder builder = new StringBuilder();
        int col = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetCameraStream(4,210);
                //  Response.Redirect("/index1.aspx");
            }
        }

        protected void btnSubmit(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                if (txtName.Text != null)
                {
                    cl_vd.Name = txtName.Text;
                    txtName.Text = "";
                }
                if (txtupload.InnerText != null)
                {
                    cl_vd.PosterPath = txtupload.InnerText;
                    txtupload.InnerText = "";
                }
                if (manager.Text != null)
                {
                    cl_vd.StreamName = manager.Text;
                    manager.Text = "";
                }
                if (txturl.Text != null)
                {
                    cl_vd.Path = txturl.Text;
                    txturl.Text = "";
                }
                int i = cl_vd.Save_Video();
                if (i > 0)
                {
                    lblStatus.Text = "Successfully Inserted";
                }
                GetCameraStream(4, 210);
            }

        }

        //*---------Load add Stream on Main page From save RTMP URL --------------//
        public void GetCameraStream(int col,int he)
        {
            
            DataSet ds = cl_vd.GetAllCameraVideo();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    
                    builder.Append("<div class='col-sm-"+ col +"' id='obj" + Convert.ToString(i) + "'>");
                    builder.Append("<object id='SampleMediaPlayback' name='SampleMediaPlayback' type='application/x-shockwave-flash' classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000'>");
                    builder.Append("<param name='movie' value='swfs/SampleMediaPlayback.swf' />");
                    builder.Append("<param name='quality' value='high'/>");
                    builder.Append("<param name='bgcolor' value='#000000'/>");
                    builder.Append("<param name='allowfullscreen' value='true'/>");
                    builder.Append("<param name ='flashvars' value='&src=" + ds.Tables[0].Rows[i][2].ToString() + "/stream.flv&autoHideControlBar=true&streamType=live&autoPlay=true&verbose=true'/>");
                    builder.Append("<embed height='"+he+"' src = 'swfs/SampleMediaPlayback.swf' id='SampleMediaPlayback' quality='high' name='SampleMediaPlayback' allowfullscreen='true' pluginspage ='http://www.adobe.com/go/getflashplayer' flashvars ='&src=" + ds.Tables[0].Rows[i][2].ToString().Trim() + "/stream.flv&autoHideControlBar=true&streamType=live&autoPlay=true&verbose=true' type ='application/x-shockwave-flash' title='" + ds.Tables[0].Rows[i][1] + "'>");
                    builder.Append("</embed>");
                    builder.Append("</object>");
                    builder.Append("<div class='caption'>");
                    builder.Append("<blockquote class='pull-left'>");
                    builder.Append("<h4 style='color:dodgerblue;'>" + ds.Tables[0].Rows[i][1] + "</h4>");
                    builder.Append("<h6>" + ds.Tables[0].Rows[i][3] + " and managged by \n\r -  " + ds.Tables[0].Rows[i][4] + "</h6>");
                    //builder.Append("<small>Powerd by <cite style='color:red;'>Promax</cite></small>");
                    builder.Append("<small>Stream ID :  " + ds.Tables[0].Rows[i][0] + " and Powerd by <cite style='color:red;'>Promax</cite></small>");
                    builder.Append("</blockqoute></div>");
                    builder.Append("</div>");
                }
                vlog.InnerHtml = builder.ToString();
                //Panel2.Controls.Add(new Literal { Text = sb.ToString() });
               
            }
            
        }
        protected void lnkbtn1_click(object sender, EventArgs e)
        {
            GetCameraStream(12, 560);
        }
        protected void lnkbtn2_click(object sender, EventArgs e)
        {
            GetCameraStream(6, 310);
        }
        protected void lnkbtn3_click(object sender, EventArgs e)
        {
            GetCameraStream(4,210);
        }
        protected void lnkbtn4_click(object sender, EventArgs e)
        {
            GetCameraStream(3, 170);
        }
        //protected void lnkbtn5_click(object sender, EventArgs e)
        //{

        //}
        protected void lnkbtn6_click(object sender, EventArgs e)
        {
            GetCameraStream(2, 120);
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtID.Text))
            {
                cl_vd.ID = Convert.ToInt32(txtID.Text);
                int i = cl_vd.Del();
                if (i > 0)
                {
                    lblStatus.Text = "Successfully Delete";
                    Response.Redirect("index.aspx");
                }
            }
        }
    }
}