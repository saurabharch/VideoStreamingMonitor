using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using VideoLibrary.Logic.SQLBal;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;

namespace VideoLibrary
{
    public partial class Default : System.Web.UI.Page
    {
        IPHostEntry localIP;
       // string host = "?";
        string host = "http://localhost:8777/";
        SQlbal cl_vd = new SQlbal();

        protected string GetIPAddress()
        {
            localIP = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in localIP.AddressList)
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    host = ip.ToString();
                }

            return host;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
          //  GetIPAddress();
            HtmlGenericControl saurabh = new HtmlGenericControl("div");
           
            StringBuilder builder = new StringBuilder();
           // saurabh.Attributes.Add("", "");
            //saurabh.Attributes.Add("scrolling", "yes");
            //saurabh.Attributes.Add("style", "videoWrapper iframe width:100%; height: 100%; float: left; color: #FFF; background:#ed8719; line-height:100%; font-size:100%; font-family: sans-serif");
          //  saurabh.Attributes.Add("class", "flowplayer");
            //StringBuilder builder1 = new StringBuilder();
           // builder.Append("<iframe width='670' height='340' class='' src='http://192.168.1.53/preview.cgi?channel=2' autoplay control='controls' type='video/webm' frameborder='0' allowfullscreen>");
          //  builder.Append("<embed id='vlc' width='90%' height='90%' target='http://192.168.1.51:8000/stream.flv' version='VideoLAN.VLCPlugin.0.1.4' pluginspage='http://www.videolan.org' type='application/x-vlc-plugin'>");
          //  builder.Append("<a href='http://192.168.1.51:8000/stream.flv' style='display: block; width: 384px; height: 288px;' id='player'>");
            // builder.Append(" <video width='100%' controls autoplay>");
          //  builder.Append(" <source src='http://192.168.26.51/preview.cgi?channel=1' autoplay control='controls' type='video/webm'>");
         //   builder.Append(" </iframe>");
            builder.Append("<object width='640' height='377' id='SampleMediaPlayback' name='SampleMediaPlayback' type='application/x-shockwave-flash' classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' ><param name='movie' value='swfs/SampleMediaPlayback.swf' /> <param name='quality' value='high' /> <param name='bgcolor' value='#000000' /> <param name='allowfullscreen' value='true' /> <param name='flashvars' value= '&src=http://192.168.1.51:8000/stream.flv&autoHideControlBar=true&streamType=vod&autoPlay=true&verbose=true'/><embed src='swfs/SampleMediaPlayback.swf' width='640' height='377' id='SampleMediaPlayback' quality='high' bgcolor='#000000' name='SampleMediaPlayback' allowfullscreen='true' pluginspage='http://www.adobe.com/go/getflashplayer' flashvars='&src=http://192.168.1.51:8000/stream.flv&autoHideControlBar=true&streamType=vod&autoPlay=true&verbose=true' type='application/x-shockwave-flash'> </embed></object>");
            //<embed id='vlc' width='90%' height='90%' target='rtsp://192.168.1.53:554/stream.sdp' version='VideoLAN.VLCPlugin.0.1.4' pluginspage='http://www.videolan.org' type='application/x-vlc-plugin'>
            video1.InnerHtml = builder.ToString();
            //stream.InnerHtml = builder.ToString();
            if(!IsPostBack)
            {
                try
                {
                    GetCameraStream();
                    btn_search();
                }
                catch (Exception)
                {
                    
                    
                }
                //btn_search();
            }
            //cam1.InnerHtml = builder.ToString();
            //cam2.InnerHtml = builder.ToString();
            //cam3.InnerHtml = builder.ToString();
            //cam4.InnerText = builder.ToString();
           // HtmlGenericControl saurabh = new HtmlGenericControl("div");
            
           
            
           //for(int h=1;h<9;h++)
           //{
           //    //saurabh.Attributes.Add("class", "myClass");
           //    saurabh.Attributes.Add("class", "col-sm-3");
           //    saurabh.Attributes.Add("style", "style='padding-left: 15px;padding-right: 15px;'");
           //    saurabh.Attributes.Add("ID", ""+Convert.ToString(h)+"");
           //    builder1.Append(" <video width='247.500px' height='139.188px' controls autoplay>");
           //    builder1.Append(" <source src='video/Ellie-Goulding.mp4' type='video/webm'>");
           //    builder1.Append(" </video>");
           //    pnlYogesh.InnerHtml = builder1.ToString();
           //}

            
        }

        public void GetCameraStream()
        {
           // GetIPAddress();
            DataSet ds = cl_vd.GetAllCameraVideo();
            if (ds.Tables[0].Rows.Count > 0)
            {
                HtmlGenericControl saurabh = new HtmlGenericControl("div");
                StringBuilder builder1 = new StringBuilder();
                pnlYogesh.InnerHtml = builder1.ToString();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    saurabh.Attributes.Add("class", "col-sm-3");
                    saurabh.Attributes.Add("ID", "" + Convert.ToString(i) + "");
                    saurabh.Attributes.Add("style", "style='padding-left: 15px;padding-right: 15px;'");
                    builder1.Append(" <video width='247.500px' height='139.188px' controls poster='"+ds.Tables[0].Rows[i][3]+"' title='" + ds.Tables[0].Rows[i][1] + "' style='  padding-top: 0px;padding-bottom: 0px;padding-left: 8px;padding-right: 8px;margin-left: 4px; margin-right: 4px;margin-top: 32px;margin-bottom: 32px;'>");
                    builder1.Append(" <source src='" + host + ds.Tables[0].Rows[i][2] + "' type='video/webm'>");
                    builder1.Append(" </video>");
                    pnlYogesh.InnerHtml = builder1.ToString();
                    //sb.Append("<video src='" + host + ds.Tables[0].Rows[i][2] + "' height='230' width='200' controls='controls' type=video/webm frameborder='0' title='" + ds.Tables[0].Rows[i][1] + "'>");
                    //sb.Append("</video><br/>");

                }
                
            }
        }
        protected void btn_search()
        {
           // GetIPAddress();
            string searchId = txtSearch.Value;
            StringBuilder builder = new StringBuilder();
            System.Data.DataTable dt = Manager.GetHall_SheduleByVenueid(searchId);
            System.Data.DataTable dp = Manager.GetPoster_SheduleByVenueid(searchId);
            if (dt.Rows.Count > 0)
            {
                string fileAdd = host + (dt.Rows[0]["Path"].ToString());
                if (dt.Rows.Count > 0)
                {
                    string PosterPath = host + (dt.Rows[0]["PosterPath"].ToString());

                    builder.Append(" <video width='100%' controls autoplay poster='" + PosterPath + "'>");
                    builder.Append(" <source src='" + fileAdd + "' type='video/webm'>");
                    builder.Append(" </video>");
                    video1.InnerHtml = builder.ToString();

                }
                //sb.Append("<iframe src='"+fileAdd+"' height='480' width='680' controls='controls' type=video/webm autoplay frameborder='1'>");
                //sb.Append("</iframe><br/>");
                //  Panel1.Controls.Add(new Literal { Text = sb.ToString() });
                //  System.Data.DataTable dtt = Manager.GetHall_SheduleByStreamid("1");
                if (dt.Rows.Count > 0)
                {
                    string StreamFeed = dt.Rows[0]["StreamURL"].ToString();
                    builder.Append("<iframe src='" + StreamFeed + "' height='480' width='925' controls='controls' type=video/webm autoplay frameborder='0'>");
                    builder.Append("</iframe>");
                }
                else
                {

                }
            }
            else if (dp.Rows.Count > 0)
            {

                string StreamFeed = dp.Rows[0]["StreamURL"].ToString();
                builder.Append("<iframe src='" + StreamFeed + "' height='480' width='925' controls='controls' type=video/webm autoplay frameborder='0'>");
                builder.Append("</iframe>");

            }
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            //btn_search();
           // GetIPAddress();
            string searchId = txtSearch.Value;
            StringBuilder builder = new StringBuilder();
            System.Data.DataTable dt = Manager.GetHall_SheduleByVenueid(searchId);
            System.Data.DataTable dp = Manager.GetPoster_SheduleByVenueid(searchId);
            if (dt.Rows.Count > 0)
            {
                string fileAdd = host + (dt.Rows[0]["Path"].ToString());
                if (dt.Rows.Count > 0)
                {
                    string PosterPath = host + (dt.Rows[0]["PosterPath"].ToString());

                    builder.Append(" <video width='100%' controls autoplay poster='" + PosterPath + "'>");
                    builder.Append(" <source src='" + fileAdd + "' type='video/webm'>");
                    builder.Append(" </video>");
                    video1.InnerHtml = builder.ToString();

                }
                //sb.Append("<iframe src='"+fileAdd+"' height='480' width='680' controls='controls' type=video/webm autoplay frameborder='1'>");
                //sb.Append("</iframe><br/>");
                //  Panel1.Controls.Add(new Literal { Text = sb.ToString() });
                //  System.Data.DataTable dtt = Manager.GetHall_SheduleByStreamid("1");
                if (dt.Rows.Count > 0)
                {
                    string StreamFeed = dt.Rows[0]["StreamURL"].ToString();
                    builder.Append("<iframe src='" + StreamFeed + "' height='480' width='925' controls='controls' type=video/webm autoplay frameborder='0'>");
                    builder.Append("</iframe>");
                }
                else
                {

                }
            }
            else if (dp.Rows.Count > 0)
            {

                string StreamFeed = dp.Rows[0]["StreamURL"].ToString();
                builder.Append("<iframe src='" + StreamFeed + "' height='480' width='925' controls='controls' type=video/webm autoplay frameborder='0'>");
                builder.Append("</iframe>");

            }
        }
}
}