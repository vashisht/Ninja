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

//        $(function(){
//        $('#btnpreview').click(){


//        });
//        });
    </script>
    <link rel="stylesheet" type="text/css" href="<%= Url.Content("~/Content/default.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%= Url.Content("~/Content/geral.css") %>" />

    
    <style type="text/css">
         
        .field-validation-error
        {
            color:Red;
        }
        
    
        div.message{
    /*background: transparent url(msg_arrow.gif) no-repeat scroll left center;*/
    padding-left: 7px;
}

.error{
    background-color:#F3E6E6;
    border-color: #924949;
   /* border-style: solid solid solid none;*/
    border-width: 2px;
    padding: 5px;
    color:Red;
}

</style>



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
                  <%--  <%=Html.DropDownListFor(x => x.SubCateogryId, new SelectList(Model.SubCategories, "SubCategoryId", "SubCategoryName"))%>--%>
                   <div id="subcatdiv">
                    <%Html.RenderAction("SubCategoryDropdown", "Home");%>
                    
                    
                    </div>
                </label>
                <label>
                    <span>Title *</span><%=Html.TextBoxFor(x => x.Title)%></label>
                <label>
                    <span style=" margin-right:109px;">Description *</span><%=Html.TextAreaFor(x=>x.Description)%></label>
                <label>
                    <span>Location *</span><%=Html.TextBoxFor(x=>x.Location)%></label>
                <label>
                    <span>Email para contato *</span><%=Html.TextBoxFor(x=>x.Email)%></label>

                  <div style="background-color:#EAEAEA; float:left;" >
                    <h2 style="background-color: #EAEAEA;">
                    Adicione imagens ao seu anúncio</h2>
                <p style="background-color: #EAEAEA;">
                    Anúncios com imagens atraem mais visitas, não perca a oportunidade de se destacar
                    na página de resultados.</p>

                    
                    <label>
                    <span>Images</span>
                    
                    <input  type="file"  id="Image1" name="Image1" title="Adicionar imagem" value="Adicionar imagem" style="display:none;"   onchange="readURL(this);" />
                    
                    <input  type="file"  id="Image2" name="Image2" style="display:none;"  onchange="readURL2(this);"/>
                    <input  type="file"  id="Image3" name="Image3" style="display:none;"  onchange="readURL3(this);"/>


                    
                            
                            
                            </label>

                            <div class="img-upload" style=" margin-left:245px;">
                
                    
                    <div class="uploader-img" >
                        <img src="/img/thumb.jpg" id="imgsrc1">
                            <a href="#" id="upfile1" style="cursor:pointer" >Adicionar imagem</a>  <a href="#" id="delimg1">Remover</a>
                            </div>
                            <div class="uploader-img">
                        <img src="/img/thumb.jpg" id="imgsrc2">
                            <a href="#" id="upfile2" style="cursor:pointer" >Adicionar imagem</a> 
                            <a href="#" id="delimg2">
                            Remover</a></div>
                            <div class="uploader-img">
                            <img src="/img/thumb.jpg" id="imgsrc3">
                            <a href="#" id="upfile3" style="cursor:pointer" >Adicionar imagem</a> 
                            <a href="#" id="delimg3">
                            Remover</a>
                            </div>
             
            </div>
                            </div>

                             <div class="img-upload" style="background-color:white; margin-left:245px;">
                             <div style="display: block; float:left; width: 100%; margin-bottom: 10px;">
                <img style="border:0px none; height: 80px; float:left;" src="/Captcha" id="captchaImg"  />
                <a href="javascript:;" id="change-captcha-link" title="Change Image" style="margin-top: 35px; height: 26px; width: 27px;">
                </a></div>
                <br />
                
                Enter the code shown above:<br /><input type="text" name="captchaString" id="captchaString" style="width: 150px; float:left;"/>
                            
                            </div>
                            

                            

                            </div>
                    


                

            </div>
            <!--Form post an ad-->
            <!--image upload-->
            
            <!--end image upload-->
          
            <div class="submit-post">
            <p id="Message" style="color:Red; padding-bottom:10px;">
            
            
            </p>
                 <input type="submit" value="postar esse anúncio"  class="button" />
                  <input type="submit" value="pré-visualização"   class="button"  style="display:none;" /></div>
              
           
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
  
  <script type="text/javascript" >

      function readURL(input) {
          if (input.files && input.files[0]) {
              var reader = new FileReader();

              reader.onload = function (e) {
                  $('#imgsrc1').attr('src', e.target.result);
              }
              $('#delimg1').show();
              


              reader.readAsDataURL(input.files[0]);
          }
      }
      function readURL2(input) {
          if (input.files && input.files[0]) {
              var reader = new FileReader();

              reader.onload = function (e) {
                  $('#imgsrc2').attr('src', e.target.result);
              }
              $('#delimg2').show();
              reader.readAsDataURL(input.files[0]);
          }
      }
      function readURL3(input) {
          if (input.files && input.files[0]) {
              var reader = new FileReader();

              reader.onload = function (e) {
                  $('#imgsrc3').attr('src', e.target.result);
              }
              $('#delimg3').show();
              reader.readAsDataURL(input.files[0]);
          }
      }
  
  </script>

  <script type="text/javascript">
      $('#delimg1').click(function (e) {
          e.preventDefault();
          $('#imgsrc1').attr('src', "/img/thumb.jpg");
          $('#Image1').val('');

          $('#delimg1').hide();
          
          
      });

      $('#delimg2').click(function (e) {
          e.preventDefault();
          $('#imgsrc2').attr('src', "/img/thumb.jpg");
          $('#Image2').val('');

       
          $('#delimg2').hide();
          



      });

      $('#delimg3').click(function (e) {
          e.preventDefault();
          $('#imgsrc3').attr('src', "/img/thumb.jpg");
          $('#Image3').val('');

          $('#delimg3').hide();



      });


      

</script>
  <script type="text/javascript">


      $('#CateogryId').change(function () {

          //alert($('#CateogryId').val());
          $('#subcatdiv').load('/SubCategoryDropdown', $('#form0').serialize(), function () {

          });

      });

  

</script>

<script type="text/javascript">
    $("#upfile1").click(function (e) {
        e.preventDefault();
        $("#Image1").trigger('click');
    });
    $("#upfile2").click(function (e) {
        e.preventDefault();
        $("#Image2").trigger('click');
    });
    $("#upfile3").click(function (e) {
        e.preventDefault();
        $("#Image3").trigger('click');
    });
    $(document).ready(function () {

        $('#delimg1').hide();
        $('#delimg2').hide();
        $('#delimg3').hide();

        var submitted = false;
        $('#form0').validate({
            rules: {
                'Title': {
                    required: true
                },
                'Description': {
                    required: true
                },
                'Location': {
                    required: true
                },
                'Email': {
                    required: true,
                    email: true
                },
                'captchaString': {
                    required: true,
                    remote: {
                        url: "/ValidateCaptcha",
                        type: "post",
                        data: {
                            captchaString: function () {
                                //alert($("#captchaString").val());
                                return $("#captchaString").val();
                            }
                        }
                    }
                }

            },
            messages: {
                'Title': {
                    required: 'Please enter Title'
                },
                'Description': {
                    required: 'Please enter Description'
                },
                'Location': {
                    required: 'Please enter Location'
                },
                'Email': {
                    required: 'Please enter Email'
                },
                'captchaString': {
                    required: 'Please enter verification code above in image',
                    remote: 'Please enter valid verification code in the image above'
                }
            },
            showErrors: function (errorMap, errorList) {
                if (submitted) {
                    var summary = "";
                    $.each(errorList, function () { summary += " * " + this.message + "<br/>"; });

                    //alert(summary);
                    submitted = false;
                    $('#Message').html(summary);
                }
                //this.defaultShowErrors();
            },
            invalidHandler: function (form, validator) {
                submitted = true;
            }



        });
        //        });



        var cptcount = 1;

        $('#change-captcha-link').click(function () {
            $('#captchaImg').attr('src', '/Captcha/?newId=' + cptcount);
            $('#captchaString').val('');
            cptcount++;
            return false;
        });


    });



</script>