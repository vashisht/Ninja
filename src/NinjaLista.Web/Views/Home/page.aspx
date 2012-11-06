<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<NinjaLista.Views.Models.PageModel>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="robots" content="noindex">
    <link sizes="57x57" href="images/icon.png" rel="apple-touch-icon-precomposed" />
    <link sizes="114x114" href="images/icon-pc-hd.png" rel="apple-touch-icon-precomposed" />
    <title>Política de privacidade</title>
    <link rel="stylesheet" type="text/css" href="<%=Url.Content("/content/default.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%=Url.Content("/content/geral.css") %>" />
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
    <%Html.RenderPartial("Login"); %>
    <%Html.RenderPartial("HeaderWithMenu"); %>
    <div id="content-main">
        <%Html.RenderPartial("SearchContainer"); %>
        <div class="breadcrumb">
            <p>
                Você está em:
            </p>
            <p>
                <a href="#">Home ></a></p>
            <p>
                <%=Model.page.Title %></p>
        </div>
        <!--content-left-->
        <div id="content-left">
            <div class="promo-box">
                <a href="#">
                    <img src="/img/fb-like.png" width="180" /></a></div>
            <div class="site-add">
                <a href="#">
                    <img src="/img/add.jpg" width="164" height="600" /></a>
                <p>
                    Anúncios</p>
            </div>
        </div>
        <!--End content-left-->
        <div id="content-right">
            <div class="gen-box">
                <h1>
                    <%=Model.page.Title %></h1>
            

                <div class="sample-page">
                    <%= MvcHtmlString.Create(Model.page.Detail)%>

                </div>
                
            
            
            </div>
        </div>
    </div>
    <%Html.RenderPartial("Footer"); %>
</body>
</html>
