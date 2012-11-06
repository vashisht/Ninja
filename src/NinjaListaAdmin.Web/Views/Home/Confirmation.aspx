<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="robots" content="noindex">
    <link sizes="57x57" href="/img/icon.png" rel="apple-touch-icon-precomposed" />
    <link sizes="114x114" href="/img/icon-pc-hd.png" rel="apple-touch-icon-precomposed" />
    <title>Account confirmation</title>
    <link rel="stylesheet" type="text/css" href="<%= Url.Content("~/Content/default.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%= Url.Content("~/Content/geral.css") %>" />
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
            <p>
                You are in:
            </p>
            <p>
                <a href="#">Postar anúncio </a>
            </p>
            <p>
                Confirmação</p>
        </div>
        <!--End Breadcrumb-->
        <div class="gen-box">
            <h1 class="green">
                Anúncio postado!</h1>
            <div class="partners-intro">
                <p>
                    <strong>Parabéns, o seu anúncio foi postado!</strong>
                </p>
                <p>
                    Um email de confirmação foi enviado para o seu email fornecido, e seu anúncio estara
                    disponível em nosso site dentro de alguns minutos.</p>
                <br />
                <p>
                    <a href="/">Retornar a home page</a></p>
            </div>
        </div>
    </div>
    <!--End content-main-->
    <!--Footer-->
    <%Html.RenderPartial("Footer"); %>
    <!--End Footer-->
</body>
</html>
