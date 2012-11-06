<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<Ninjalista.DAL.Entities.EmailDetails>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="robots" content="noindex">
<link sizes="57x57" href="/img/icon.png" rel="apple-touch-icon-precomposed" />
<link sizes="114x114" href="/img/icon-pc-hd.png" rel="apple-touch-icon-precomposed" />
<title>contact</title>
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
    
     <script type="text/javascript" src="/Scripts/MicrosoftAjax.js"></script>
    <script type="text/javascript" src="/Scripts/MicrosoftMvcValidation.js"></script>
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="/Scripts/jquery.uploadify-3.1.js"></script>
    <link rel="stylesheet" type="text/css" href="<%= Url.Content("~/Content/default.css") %>"/>
    <link rel="stylesheet" type="text/css" href="<%= Url.Content("~/Content/geral.css") %>"/>
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
                <a href="/">Home </a>></p>
            <p>
                Contato</p>
        </div>
        <!--End Breadcrumb-->
        <!--content-left-->
        <div id="content-left">
            <div class="promo-box">
                <a href="#">
                    <img src="/img/fb-like.png" width="180" /></a></div>
            <div class="site-add">
                <a href="#">
                    <img src="/img/add.jpg" width="164" height="600" /></a>
                <p>
                    advertisement</p>
            </div>
        </div>
        <!--End content-left-->
        <!--content-right-->
        <div id="content-right">
            <!--Partners-->
            <div class="gen-box">
                <h1>
                    Contact</h1>
                <div class="partners-intro">
                    <p>
                        Lorem Ipsum is simply dummy text of the <strong>printing and typesetting industry</strong>.
                        Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.</p>
                </div>
                <%Html.EnableClientValidation(); %>
                    <% using (Html.BeginForm("Contato", "Home", FormMethod.Post, new { enctype = "multipart/form-data" })) %>
            <%{%>
                <div class="contact-ad-form">
             
                    <label>
                        <span>Your name *</span>
                        <%=Html.TextBoxFor(x=>x.Name) %>
                    </label>
                    <label>
                        <span>Your email address *</span>
                        <%=Html.TextBoxFor(x=>x.EmailAddress) %>
                    </label>
                    <label>
                    <span>Subject *</span>
                    <%=Html.DropDownListFor(x => x.SelectedSubject, new SelectList((List<SelectListItem>)ViewData["Subjects"], "Value", "Text"), new { @class = "select" })%>
                    </label>
                    <label>
                        <span>Your message *</span>
                        <%=Html.TextAreaFor(x => x.Message, new { @class = "contact-ad-form message" })%>
                    </label>
                    <%=Html.ValidationSummary() %>
                    <input type="submit" class="button" value="enviar" title="button" id="contact-bt" />                   
                </div>
                 <%} %>
               
            </div>
            <!--Partners-->
        </div>
        <!--End content-right-->
    </div>
    <!--End content-main-->
    <!--Footer-->
    <%Html.RenderPartial("Footer"); %>
    <!--End Footer-->
</body>
</html>
