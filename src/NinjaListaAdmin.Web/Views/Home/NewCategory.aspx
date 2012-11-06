<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<NinjaListaAdmin.Web.Views.Models.CategoryModel>" %>
<%@ Import Namespace="NinjaListaAdmin" %>
<asp:Content ID="indexContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

<form method="post" enctype="multipart/form-data" id="form0" action="/Home/SaveCategory">
<input type="hidden" name="CategoryId" id="CategoryId" value='<%= ((Model != null) ? Model.objcategory.CategoryId.ToString() : "0")%>' />
<div class="gen-box grey2">
    <h1>Anuncie grátis</h1>
    <!--Form post an ad-->
    
    <div class="post-ad-form">
    
      <label> <span>Categoria *</span><input  type="text" name="CategoryName" id="CategoryName" value='<%= ((Model != null) ? Model.objcategory.CategoryName : "")%>' /></label>
       <label> <span>Order *</span><input  type="text" name="Ordr" id="Ordr" value='<%= ((Model != null) ? Model.objcategory.Ordr.ToString() : "1")%>' /></label>
     <label> <span>Status *</span>
     <%if (Model != null && Model.objcategory != null && Model.objcategory.Active == false) %>
     <%{ %>
     <input  type="checkbox" id="Active" name="Active" style="float:left; width:20px;" value="true" />

           <%}%>
           <%else %>
            <%{ %>
     <input  type="checkbox" id="Active" name="Active" checked="checked"  style="float:left; width:20px;" value="true" />

           <%}%>
           
     <p>Active</p></label>
      
      
    </div>
  </div>
  <!--Form post an ad--> 
  <!--image upload-->
  
  <div class="submit-post">
    <p id="Message" style="color:Red; padding-bottom:10px;"> </p>
    <input type="submit" value="Save"  class="button" />
    <input type="button" value="Cancel"   class="button"  id="btncancel" />
  </div>

  </form>

  <script type="text/javascript">

      $(document).ready(function () {


          var submitted = false;
          $('#form0').validate({
              rules: {
                  'CategoryName': {
                      required: true
                  },
                  'Ordr': {
                      required: true,
                      number: true
                  }

              },
              messages: {
                  'CategoryName': {
                      required: 'Please enter Category Name'
                  },
                  'Ordr': {
                      required: "Please enter Order",
                      number: "Please enter Only Number"
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



          $('#btncancel').click(function () {

              window.location = "/Home/ManageCategories";

          });


      });



</script>
</asp:Content>
