<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<NinjaLista.Views.Models.CategoryModel>" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="robots" content="noindex">
    <link sizes="57x57" href="/img/icon.png" rel="apple-touch-icon-precomposed" />
    <link sizes="114x114" href="/img/icon-pc-hd.png" rel="apple-touch-icon-precomposed" />
    <title>Ninjalista | Classificados para a comunidade de língua portuguesa no Reino Unido</title>
    <link rel="stylesheet" type="text/css" href="<%= Url.Content("~/Content/default.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%= Url.Content("~/Content/Home.css") %>" />
    <script type="text/javascript" src="/Scripts/jquery-1.4.1.min.js"></script>
<script type="text/javascript" src="/Scripts/jquery.validate.js"></script>
    <meta name="description" content="O Ninjalista é o maior site de classificados gratuitos da comunidade de língua portuguesa em Londres e no Reino Unido. Encontre serviços por categorias, ofertas de empregos, acomodação para Brasileiros e Portugueses e muito mais." />
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
    <link rel="icon" href="/img/favicon.ico" />
</head>
<body>
    <% Html.RenderPartial("Login"); %>
    <!--Header area-->
    <% Html.RenderPartial("HeaderWithMenu");%>
    <!--End Header area-->
    <!--Content-->
    <div id="content-main">
        <!--Search-container-->
        <% Html.RenderPartial("SearchContainer"); %>
        <!--End search-container-->
        <!--Breadcrumb-->
        <div class="breadcrumb">
            <p>
                Você está em:
            </p>
           
            <p>
                Home</p>
                <p><%=TempData["error"]%></p>
        </div>
        <!--End Breadcrumb-->
        <!--content-left-->
        <div id="content-left">
            <div class="promo-box">
                <a href="http://www.facebook.com/ninjalista" target="_blank">
                    <img src="/img/fb-like.png" width="180" /></a></div>
            <div class="site-add">
                <a href="#">
                    <img src="/img/add.jpg" width="164" height="600" /></a>
                <p>
                    Anúncios</p>
            </div>
        </div>
        <!--End content-left-->
        <!--content-right-->
        <div id="content-right">
        <div class="column-1">
        <%foreach (var item in Model.catlist) %>
        <%{ %>
        <% if(item.Ordr < Convert.ToDecimal(2) ) %>
        <%{ %>
        
                <h2 class="<%=item.CategoryName.ToLower()%>">
                   <a href="/cat/<%=item.CategoryName.ToLower().Replace(" ","-") + "/" + item.CategoryId %>"><%=item.CategoryName  %></a> </h2>
                   <% if (item.subcategoylist != null && item.subcategoylist.Count > 0) %>
                   <%{ %>
                   <ul>
                   <% foreach (var dtl in item.subcategoylist) %>
                   <%{ %>
                   <li><a href="/<%= dtl.CategoryName.ToLower().Replace(" ","-") + "/" + dtl.SubCategoryName.ToLower().Replace(" ", "-") + "/" + dtl.SubCategoryId %>"><%=dtl.SubCategoryName  %></a></li>

                   <%} %>

                   
                   </ul>
                   <%} %>
                   

        <%} %>
        <%} %>
        </div>

        <div class="column-2">
        <%foreach (var item in Model.catlist) %>
        <%{ %>
        <% if(item.Ordr > Convert.ToDecimal(2)  && item.Ordr < Convert.ToDecimal(3)) %>
        <%{ %>
        
                <h2 class="<%=item.CategoryName.ToLower() %>">
                   <a href="/cat/<%=item.CategoryName.ToLower().Replace(" ","-") + "/" + item.CategoryId %>"><%=item.CategoryName%></a> </h2>
                   <% if (item.subcategoylist != null && item.subcategoylist.Count > 0) %>
                   <%{ %>
                   <ul>
                   <% foreach (var dtl in item.subcategoylist) %>
                   <%{ %>
                   <li><a href="/<%= dtl.CategoryName.ToLower().Replace(" ","-") + "/" + dtl.SubCategoryName.ToLower().Replace(" ", "-") + "/" + dtl.SubCategoryId %>"><%=dtl.SubCategoryName  %></a></li>

                   <%} %>

                   
                   </ul>
                   <%} %>
                   

        <%} %>
        <%} %>
        </div>

        <div class="column-3">
        <%foreach (var item in Model.catlist) %>
        <%{ %>
        <% if(item.Ordr > Convert.ToDecimal(3)  ) %>
        <%{ %>
        
                <h2 class="<%=item.CategoryName.ToLower() %>">
                   <a href="/cat/<%=item.CategoryName.ToLower().Replace(" ","-") + "/" + item.CategoryId %>"><%=item.CategoryName%></a> </h2>
                   <% if (item.subcategoylist != null && item.subcategoylist.Count > 0) %>
                   <%{ %>
                   <ul>
                   <% foreach (var dtl in item.subcategoylist) %>
                   <%{ %>
                   <li><a href="/<%= dtl.CategoryName.ToLower().Replace(" ","-") + "/" + dtl.SubCategoryName.ToLower().Replace(" ", "-") + "/" + dtl.SubCategoryId %>"><%=dtl.SubCategoryName %></a></li>

                   <%} %>

                   
                   </ul>
                   <%} %>
                   

        <%} %>
        <%} %>
        </div>
        
        
            
            <!--Adds-->
            <!--
            <div id="ad-bottom">
                <div class="wrapper">
                    <div class="list-carousel">
                        <ul id="carousel">
                            <li><a href="#">
                                <img src="/img/logo-thumb.jpg" width="118" height="105" /></a></li>
                            <li><a href="#">
                                <img src="/img/logo-thumb.jpg" width="118" height="105" /></a></li>
                            <li><a href="#">
                                <img src="img/logo-thumb.jpg" width="118" height="105" /></a></li>
                            <li><a href="#">
                                <img src="img/logo-thumb.jpg" width="118" height="105" /></a></li>
                            <li><a href="#">
                                <img src="/img/logo-thumb.jpg" width="118" height="105" /></a></li>
                            <li><a href="#">
                                <img src="/img/logo-thumb.jpg" width="118" height="105" /></a></li>
                            <li><a href="#">
                                <img src="/img/logo-thumb.jpg" width="118" height="105" /></a></li>
                            <li><a href="#">
                                <img src="/img/logo-thumb.jpg" width="118" height="105" /></a></li>
                            <li><a href="#">
                                <img src="/img/logo-thumb.jpg" width="118" height="105" /></a></li>
                            <li><a href="#">
                                <img src="/img/logo-thumb.jpg" width="118" height="105" /></a></li>
                        </ul>
                        <div class="clearfix">
                        </div>
                        <a id="prev" class="prev" href="#">&lt;</a> <a id="next" class="next" href="#">&gt;</a>
                    </div>
                    <br />
                </div>
            </div> -->
            <!--End Adds-->
             <%Html.RenderPartial("PopularCategories", Model); %>
        </div>
        <!--End content-right-->
        <!--End content-main-->
   
    
    </div>
    <!--Footer-->
    <%Html.RenderPartial("Footer");%>
    <!--End Footer-->
    
</body>
</html>
