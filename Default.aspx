<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="VideoLibrary.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Video Library Project</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <meta content="text/html; charset=ISO-8859-1" http-equiv="content-type"/>
    <!-- Bootstrap -->
    <link href="~/css/bootstrap.css" rel="stylesheet"/>
    <link href="~/css/bootstrap.css.map" rel="stylesheet"/>
    <link href="~/css/bootstrap.min.css" rel="stylesheet"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <link href="~/css/skin.css" rel="stylesheet"/>
    <link href="~/css/skin/skin.css" rel="stylesheet"/>
    <link href="~/css/mediaQuery.css" rel="stylesheet"/>
    <!-- extra add -->
    <script src="js/modernizr.custom.js"></script>
    <style type="text/css">
        .stream-btn {
            height: 80px;
        }
    </style>
</head>
<body>
    

        <div class="row top-bar">
            <div class="container">

                <div class="col-sm-4">
                    <div class="logo">
                        <img src="images/logo/promax.png">
                    </div>
                    <div class="stream-btn">
                        <a href="#">
                            <button data-toggle="modal" style="height: 43px;" data-target="#myModal">Add Stream</button>
                        </a>
                    </div>
                </div>

                <div class="col-sm-8">
                    <div class="main clearfix">
                        <div class="column">
                            <div id="sb-search" class="sb-search" >
                                <form method="get" runat="server">
                                    <input  class="sb-search-input" placeholder="Search Hall Name"  runat="server" type="text" id="txtSearch" name="txtSearch"/>
                                   <%-- <asp:TextBox ID="txtSearchtop" Name="txtSearchtop" runat="server" CssClass="sb-search-input" placeholder="Search Hall Name"></asp:TextBox>--%>
                                      <input class="sb-search-submit" type="submit" value=""/>
                                      <span class="sb-icon-search"><img src="images/icon/search.ico" onclick="btn_search" /></span>
                                     <asp:Button ID="btnsearch" runat="server" Text="Button" OnClick="btnsearch_Click" />
                                </form>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
                <div class="row">
                    <asp:ImageMap ID="ImageMap1" runat="server"></asp:ImageMap>    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <div class="row">
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <div class="full-width" runat="server" id="video1">
                                    <%--<video width="100%" runat="server" id="video1" controls>
                                       
                                    </video>--%>
<%--                                    <object width='640' height='377' id='SampleMediaPlayback' name='SampleMediaPlayback' type='application/x-shockwave-flash' classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' ><param name='movie' value='swfs/SampleMediaPlayback.swf' /> <param name='quality' value='high' /> <param name='bgcolor' value='#000000' /> <param name='allowfullscreen' value='true' /> <param name='flashvars' value= '&src=http://192.168.1.51:8000/stream.flv&autoHideControlBar=true&streamType=vod&autoPlay=true&verbose=true'/><embed src='swfs/SampleMediaPlayback.swf' width='640' height='377' id='SampleMediaPlayback' quality='high' bgcolor='#000000' name='SampleMediaPlayback' allowfullscreen='true' pluginspage='http://www.adobe.com/go/getflashplayer' flashvars='&src=http://192.168.1.51:8000/stream.flv&autoHideControlBar=true&streamType=vod&autoPlay=true&verbose=true' type='application/x-shockwave-flash'> </embed></object>--%>
                                </div>
                               
                            </div>

                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <div class="stream-video" runat="server" id="stream">
                                    <%--<video width="100%" controls autoplay>
                                        <source src="video/Ellie-Goulding.mp4" type="video/mp4">
                                    </video>--%>
                                </div>
                            </div>



                        </div>
     

                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" runat="server" id="pnlYogesh">
                           <%-- <div class="col-sm-3" runat="server" id="cam1">
                                <%--<video width="100%" controls autoplay>
                                    <source src="video/Ellie-Goulding.mp4" type="video/mp4">
                                </video>--%>
                           <%-- </div>--%>

                           <%-- <div class="col-sm-3" runat="server" id="cam2">
                                <%--<video width="100%" controls autoplay>
                                    <source src="video/Ellie-Goulding.mp4" type="video/mp4">
                                </video>
                            </div>

                           <%-- <div class="col-sm-3" runat="server" id="cam3">
                                <%--<video width="100%" controls autoplay>
                                    <source src="video/Ellie-Goulding.mp4" type="video/mp4">
                                </video>
                            </div>

                            <%-- %><div class="col-sm-3" runat="server" id="cam4">
                                <%--<video width="100%" controls autoplay>
                                    <source src="video/Ellie-Goulding.mp4" type="video/mp4">
                                </video>
                                </div>--%>
                            </div>
                         </div>
                    </div>
        <section class="video-conatiner">
            <div class="container">
                </div>
        </section>
    
        <div class="footer">
            <div class="row">
                <div class="col-md-4 col-sm-4 col-xs-12">
                    <img src="images/logo/promax.png" />
                </div>
                <div class="col-md-8 col-sm-8 col-xs-12">
                    <p>Developed by - ProMax Scientific Developers Pvt. Ltd.</p>
                </div>
            </div>
        </div>

        <!-- Trigger the modal with a button -->

        <!-- Modal -->
        <div id="myModal" class="modal fade" role="dialog">
            <div class="modal-dialog">

                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                    </div>
                    <div class="modal-body">
                        <form>
                            <div class="form-group">
                                <label for="name">Video Name</label>
                                <input class="form-control" id="txt_VideoName" type="text" runat="server" />
                            </div>
                            <div class="form-group poster-upload">
                                <label for="upload">Poster Upload</label>
                                <input type="file" class="form-control" id="upload" onserverclick ="btn_upload_poster"/>
                                 <button id="btnuploadPoster" style="height: 39px;margin-top: 10px;" type="submit" runat="server" class="btn btn-default">Upload Poster</button>
                            </div>
                            <div class="form-group">
                                <label for="url">RTA Video Stream URL</label>
                                <input type="url" class="form-control" id="url"/>
                            </div>

                            <button type="submit" class="btn btn-default" style="height: 46px;">Save</button>
                        </form>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" style="height: 46px;" data-dismiss="modal">Close</button>
                    </div>
                </div>

            </div>
        </div>




        <script src="js/classie.js"></script>
        <script src="js/uisearch.js"></script>
        <script>
            new UISearch(document.getElementById('sb-search'));
        </script>

        <script type="text/javascript" src="https://code.jquery.com/jquery.js"></script>
        <script type="text/javascript" src="js/bootstrap.min.js"></script>
    
</body>
</html>
