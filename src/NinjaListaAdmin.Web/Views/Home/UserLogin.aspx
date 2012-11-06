<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Logon.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="NinjaListaAdmin" %>
<asp:Content ID="indexContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

<form method="post" enctype="multipart/form-data" id="form0">

<div class="gen-box grey2">
    <h1>Anuncie grátis</h1>
    <!--Form post an ad-->
    
    <div class="post-ad-form">
    
      <label> <span>UserName *</span><input  type="text" name="UserName" id="UserName" style="width:250px; float:left;"  /></label>
       <label> <span>Password *</span><input  type="password" name="Password" id="Password" style="width:250px;float:left;" /></label>
     
      
      
    </div>
  </div>
  <!--Form post an ad--> 
  <!--image upload-->
  
  <div class="submit-post">
    <p id="Message" style="color:Red; padding-bottom:10px;"> </p>
    <p id="errormsg" style="color:Red; padding-bottom:10px;"></p>
    <input type="button" value="Logon"  class="button" id="btnsave" />
    <input type="button" value="pré-visualização"   class="button"  id="btncancel" style="display:none;" />
  </div>

  </form>

  <script type="text/javascript">

      $(document).ready(function () {


          var submitted = false;
          $('#form0').validate({
              rules: {
                  'UserName': {
                      required: true
                  },
                  'Password': {
                      required: true

                  }

              },
              messages: {
                  'UserName': {
                      required: 'Please enter User Name'
                  },
                  'Password': {
                      required: "Please enter Password"

                  }
              }
//              ,
//              showErrors: function (errorMap, errorList) {
//                  if (submitted) {
//                      var summary = "";
//                      $.each(errorList, function () { summary += " * " + this.message + "<br/>"; });

//                      
//                      submitted = false;
//                      $('#Message').html(summary);
//                  }
//                  this.defaultShowErrors();
//              },
//              invalidHandler: function (form, validator) {
//                  submitted = true;
//              }



          });



          $('#btncancel').click(function () {



          });

          $('#btnsave').click(function () {

              submitted = false;
              if ($('#form0').validate().form()) {

                  $.blockUI();

                  $.post('/Home/LoginUser', $('#form0').serialize(), function (data) {
                      if (data.Success) {
                          $.unblockUI();
                          window.location = "/Home/Index";

                      }

                      else {
                          $.unblockUI();
                          $('#Message').html('');
                          $('#Message').html(data.Message);
                      }

                  });


              }

          });
      });



</script>
</asp:Content>
