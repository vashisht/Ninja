﻿<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<NinjaLista.Views.Models.AdvertListModel>" %>
<%@ Import Namespace = "NinjaLista" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="robots" content="noindex">
    <link sizes="57x57" href="/img/icon.png" rel="apple-touch-icon-precomposed" />
    <link sizes="114x114" href="/img/icon-pc-hd.png" rel="apple-touch-icon-precomposed" />
    <title>Ninjalista | Classificados para a comunidade de língua portuguesa no Reino Unido |Resultados</title>
   <link rel="stylesheet" type="text/css" href="<%= Url.Content("~/Content/default.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%= Url.Content("~/Content/geral.css") %>" />
    <script type="text/javascript" src="/Scripts/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="/Scripts/jquery.validate.js"></script>
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
      <p>Você está em:</p> 
      <p><a href="/">Home </a>></p>
      <p><%=Model.CurrentCategory%></p>
    </div>
    <!--End Breadcrumb--> 
        
<!--content-left-->
    <div id="content-left">
    
    
    <%Html.RenderPartial("PopularCategoriesSideBar", Model); %>
      
      <div class="site-add"><a href="#"><img src="img/add.jpg" width="164" height="600" /></a>
        <p>advertisement</p>
      </div>
      
    </div>
    <!--End content-left--> 
       
       
   <!--content-right-->
    <div id="content-right">
      <div class="gen-box">
        <h1><%=Model.CurrentCategory %></h1>
        
        <!--Results-->
        <div id="results">
        <!--featured post-->
        <%foreach (var m in Model.adverts) %>
        <%{ %>
          <div class="post-standard">
            <div class="post-inner-lft">
              <div class="post-img"><a href="<%=Url.DetailsUrl(m.Title,Model.CurrentCategory,m.SubCategory,m.AdId)%>"><img src="/FixedSizeImage?image=<%=(ConfigurationManager.AppSettings["DirAddImages"] + m.Image1)%>&width=80&height=50" /></a></div>
              <div class="post-title">
                <h3><a href="<%=Url.DetailsUrl(m.Title,m.Category,m.SubCategory,m.AdId)%>"><%=Html.Encode(m.Title) %></a></h3>               
              </div>
              <div class="post-loc">
                <p><%=Html.Encode(m.Location) %></p>
              </div>
            </div>
            <div class="post-inner-right">
              <div class="post-date">
                <p><%=m.PostedDate.ToShortDateString() %></p>
              </div>
            </div>
            </div>
            <%} %>
          
         </div>
        <!--end-results--> 
        
        
        <!--pagination-->
        <div class="pagination">
        <%= Html.PageLinks(Model.PagingInfo, Model.Id, Model.CurrentCategory)%>
        
        </div>
        <!--end pagination-->
        
      </div>
    </div>
    <!--end content-right-->  
    
    
 
</div>
<!--End content-main--> 

<!--Footer-->
<%Html.RenderPartial("Footer"); %>
<!--End Footer-->
</body>
</html>
