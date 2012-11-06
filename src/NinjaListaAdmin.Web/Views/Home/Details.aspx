<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<Ninjalista.DAL.Entities.AdvertismentDetails>" %>
<%@ Import Namespace = "NinjaLista" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="robots" content="noindex">
    <link sizes="57x57" href="/img/icon.png" rel="apple-touch-icon-precomposed" />
    <link sizes="114x114" href="/img/icon-pc-hd.png" rel="apple-touch-icon-precomposed" />
    <title>Details</title>
   <link rel="stylesheet" type="text/css" href="<%= Url.Content("~/Content/default.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%= Url.Content("~/Content/geral.css") %>" />
    <script type="text/javascript" src="/Scripts/jquery-1.4.1.min.js"></script>
    <script type="text/javascript">

        var _gaq = _gaq || [];
        _gaq.push(['_setAccount', 'UA-31478694-1']);
        _gaq.push(['_trackPageview']);

        (function () {
            var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
            ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
        })();

    </script>
</head>
<body>
    
<!--Login area-->
<%Html.RenderPartial("Login"); %>
<!--End Login area--> 

<!--Header area-->
<%Html.RenderPartial("HeaderWithMenu"); %>
<!--End Header area--> 

<!--Content-->
<div id="content-main"> 
    
    <!--Search-container-->
<%Html.RenderPartial("SearchContainer"); %>
    <!--End search-container--> 
    
    <!--Breadcrumb-->
    <div class="breadcrumb">
      <p>You are in: </p> 
      <p><a href="/">Home </a>><a href="<%=Url.ResultsUrl(Model.Category ,"1")%>"><%=Model.Category %></a> >
      </p>
      <p><%=Model.Title%></p>
    </div>
    <!--End Breadcrumb--> 
          <!--content-left-->
 <div id="content-left">
        <div class="site-add"><a href="#"><img src="/img/add.jpg" width="164" height="600" /></a>
            <p>advertisement</p>
        </div>
    </div>  
    <!--end content-left-->
     <!--content-right-->
     <div id="content-right">
        <div class="gen-box">
            <h1><%=Model.Title    %></h1>
            <p class="back-results"><a href="<%=Url.ResultsUrl(Model.Category,"1") %>"> < Back to results</a></p>
            <div class="ad-details">
                <div class="ad-content">
                    <p><%=Model.Description %></p>
                    <p>&nbsp;</p>
                    <p>Location: <%=Model.Location %></p>
                    
                    <p>email: <a href="#"><%=Html.Encode(Model.Email)%></a></p>
                    <div class="reply-ad-bt"><%=Html.ActionLink("responda ao anúncio", "ReplyAd", "Home", new { id = Model.AdId}, new { @class = "button" })%></div>
                </div>
                <div class="ad-gallery">
                    <div class="ad-main-image"><img src="/FixedSizeImage?image=<%=(ConfigurationManager.AppSettings["DirAddImages"] +  Model.Image1)%>&width=266&height=176"  id="mainimage" /></div>
                    <div class="ad-thumb" ><a id="aimg1"><img src="/FixedSizeImage?image=<%=(ConfigurationManager.AppSettings["DirAddImages"] + Model.Image1)%>&width=80&height=50" id="image1" src1="/FixedSizeImage?image=<%=(ConfigurationManager.AppSettings["DirAddImages"] + Model.Image1)%>&width=266&height=176" /></a></div>
                    <div class="ad-thumb" ><a id="aimg2"><img src="/FixedSizeImage?image=<%=(ConfigurationManager.AppSettings["DirAddImages"] + Model.Image2)%>&width=80&height=50" id="image2" src1="/FixedSizeImage?image=<%=(ConfigurationManager.AppSettings["DirAddImages"] + Model.Image2)%>&width=266&height=176" /></a></div>
                    <div class="ad-thumb"><a id="aimg3"><img src="/FixedSizeImage?image=<%=(ConfigurationManager.AppSettings["DirAddImages"] + Model.Image3)%>&width=80&height=50" id="image3" src1="/FixedSizeImage?image=<%=(ConfigurationManager.AppSettings["DirAddImages"] + Model.Image3)%>&width=266&height=176" /></a></div>
                    
                </div>
                <div class="ad-footer">
                    <p><a href="#">Report this ad</a></p>
                    <div class="ad-date">Posted on: <span><%=Model.PostedDate.ToShortDateString()%></span></div>
                </div>
            </div>
        </div>
    </div>
    <!--End content-right--> 
</div>
<!--End content-main--> 

<!--Footer-->
<%Html.RenderPartial("Footer"); %>
<!--End Footer-->
</body>
</html>
<script type="text/javascript">
    $('#aimg1').click(function () {
        var src = $('#image1').attr('src1');

        
        $('#mainimage').attr('src', src);



    });

    $('#aimg2').click(function () {

        var src = $('#image2').attr('src1');
        $('#mainimage').attr('src', src);



    });

    $('#aimg3').click(function () {

        var src = $('#image3').attr('src1');
        $('#mainimage').attr('src', src);



    });
</script>
