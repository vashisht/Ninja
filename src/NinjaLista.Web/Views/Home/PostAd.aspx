<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<Ninjalista.DAL.Entities.AdvertismentDetails>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="robots" content="noindex">
    <link sizes="57x57" href="/img/icon.png" rel="apple-touch-icon-precomposed" />
    <link sizes="114x114" href="/img/icon-pc-hd.png" rel="apple-touch-icon-precomposed" />
    <link href="/Content/fileuploader.css" rel="stylesheet" type="text/css">
    <title>Post an ad</title>
    <script type="text/javascript" src="/Scripts/MicrosoftAjax.js"></script>
    <script type="text/javascript" src="/Scripts/MicrosoftMvcValidation.js"></script>
    <%--    <script type="text/javascript" src="http://code.jquery.com/jquery-1.7.2.min.js"></script>--%>
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

        $(function(){
        $('#btnpreview').click(){
        });
        }
    </script>
    <link rel="stylesheet" type="text/css" href="<%= Url.Content("~/Content/default.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%= Url.Content("~/Content/geral.css") %>" />
</head>
<body>
    <%=Html.Partial("Login")%>
    <%=Html.Partial("HeaderWithMenu")%>
    <div id="content-main">
        <%=Html.Partial("SearchContainer")%>
        <div class="breadcrumb">
            <p>
                You are in:
            </p>
            <p>
                <a href="#">Home ></a></p>
            <p>
                Post an ad</p>
        </div>
        <div class="gen-box grey2">
            <h1>
                Post an ad - It's free</h1>
            <!--Form post an ad-->
            <%Html.EnableClientValidation(); %>
              <% using (Html.BeginForm("PostAd", "Home", FormMethod.Post, new { enctype = "multipart/form-data" })) %>
            <%{%>
            <div class="post-ad-form">
                <label>
                    <span>Category *</span>
                    <%=Html.DropDownListFor(x => x.CateogryId, new SelectList(Model.Categories, "CategoryId", "CategoryName"))%></label>
                <label>
                    <span>Sub category *</span>
                    <%=Html.DropDownListFor(x => x.SubCateogryId, new SelectList(Model.SubCategories, "SubCategoryId", "SubCategoryName"))%>
                </label>
                <label>
                    <span>Title *</span><%=Html.TextBoxFor(x => x.Title)%></label><%=Html.ValidationMessageFor(x=>x.Title) %>
                <label>
                    <span>Description *</span><%=Html.TextAreaFor(x=>x.Description)%></label><%=Html.ValidationMessageFor(x => x.Description)%>
                <label>
                    <span>Location *</span><%=Html.TextBoxFor(x=>x.Location)%></label><%=Html.ValidationMessageFor(x => x.Location)%>
                <label>
                    <span>Email para contato *</span><%=Html.TextBoxFor(x=>x.Email)%></label><%=Html.ValidationMessageFor(x => x.Email)%>
            </div>
            <!--Form post an ad-->
            <!--image upload-->
            <div class="img-upload">
                <h2>
                    Adicione imagens ao seu anúncio</h2>
                <p>
                    Anúncios com imagens atraem mais visitas, não perca a oportunidade de se destacar
                    na página de resultados.</p>
                <div class="uploader">
                    <div id="file-uploader-demo1">
                        <noscript>
                            <p>
                                Please enable JavaScript to use file uploader.</p>
                            <!-- or put a simple form for upload here -->
                        </noscript>
                    </div>
                    <div class="qq-upload-extra-drop-area">
                        Drop 1</div>
                    <div class="uploader-img">
                        <img src="/img/thumb.jpg"><a href="#">Defina como imagem principal</a> | <a href="#">
                            Remover</a></div>
                </div>
            </div>
            <!--end image upload-->
          
            <div class="submit-post">
                 <input type="submit" value="postar esse anúncio"  class="button" />
                  <input type="submit" value="pré-visualização"   class="button" /></div>
              
           
            <% }%>
           
        </div>
    </div>
    <%=Html.Partial("Footer")%>
    <script src="/Scripts/fileuploader.js" type="text/javascript"></script>
    <script>
        function createUploader() {
            var uploader = new qq.FileUploader({
                element: document.getElementById('file-uploader-demo1'),
                action: '/Home/UploadImage',
                debug: true,
                allowedExtensions: ['jpg', 'jpeg'],
                sizeLimit: 1000000, // max size
                minSizeLimit: 1024, // min size
                uploadButtonText: "",
                onComplete: function (id, fileName, responseJSON) {
                    
                },
                extraDropzones: [qq.getByClass(document, 'qq-upload-extra-drop-area')[0]]
                                              
            });
        }

        // in your app create uploader as soon as the DOM is ready
        // don't wait for the window to load  
        window.onload = createUploader;     
    </script>
</body>
</html>
