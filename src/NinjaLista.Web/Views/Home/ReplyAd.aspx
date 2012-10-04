<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<NinjaLista.Models.ReplyAdDetails>" %>
<%@ Import Namespace = "NinjaLista" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="robots" content="noindex">
<link sizes="57x57" href="/img/icon.png" rel="apple-touch-icon-precomposed" />
<link sizes="114x114" href="/img/icon-pc-hd.png" rel="apple-touch-icon-precomposed" />
<title>Reply Advertisement</title>
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
                <a href="/">Home ></a></p>
            <p> <a href="<%=Url.ResultsUrl(Model.Category,"1") %>"><%=Model.Category %> </a></p>
             <p> > <%=Model.AdTitle %></p> 
        </div>  
        <!--End Breadcrumb-->
         <%Html.EnableClientValidation(); %>
        <% using (Html.BeginForm("ReplyAd", "Home", FormMethod.Post, new { enctype = "multipart/form-data" })) %>
            <%{%>
    <div class="reply-ad">
        <div class="gen-box">
            <h1><%=Model.AdTitle %></h1>
         <p class="back-results"><a href="<%=Url.DetailsUrl(Model.AdTitle,Model.Category,Model.AdId)%>"> < Back to ad</a></p>
              <div class="asterisk2">Campos marcados com <span class="asterisk">*</span> são mandatórios.</div> 
       <div class="reply-ad-form"> 
           <%= Html.HiddenFor(x => x.AdId) %>
           <%= Html.HiddenFor(x => x.AdTitle) %>
           <%= Html.HiddenFor(x => x.Category) %>
           <%= Html.HiddenFor(x => x.ToEmailAddress) %>
            <label><span>Seu nome *</span> <%=Html.TextBoxFor(x=>x.Name) %>
           
            </label>          
            
            <label> <span>Seu email *</span> <%=Html.TextBoxFor(x=>x.FromEmail) %>            </label>
            
            
            <label> <span>Número de telefone </span><%=Html.TextBoxFor(x=>x.TelephoneNum) %> </label>
            
             <label> <span>Sua mensagem *</span><%=Html.TextAreaFor(x => x.Message, new { @class = "message"})%> </label>        
             <%=Html.ValidationSummary() %>
              <div class="ad-bt"><input type="submit" class="button" value="responda ao anúncio" title="button" id="reply-ad-button" />
               </div>  
                
          </div>
        <div class="" style="border:1px solid #c8c8c8; padding:5px; background-color:#fff; float:left; width:223px; margin: 20px 0 0 100px; padding:10px;">
 <h3>Dicas de segurança</h3><br />

 <p>Nunca passe seus dados pessoais como número de cartão ou conta bancaria para desconhecidos.</p>
  <br />
<p>Nunca leve quantidades grandes de dinheiro com você.</p>
<br />
<p> Segure-se de que a pessoa é confiável e encontros cara a cara são sempre a melhor opção, mas sempre em lugares públicos e com alguém lhe acompanhando.</p>


 
 </div>                    
         <%} %>

    </div>
    </div>
    <!--Footer-->
    <%Html.RenderPartial("Footer"); %>
    <!--End Footer-->
    </body>
</html>
