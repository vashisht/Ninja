<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<NinjaListaAdmin.Web.Views.Models.PageModel>" %>
<%@ Import Namespace="NinjaListaAdmin" %>
<asp:Content ID="indexContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

<form method="post" enctype="multipart/form-data" id="form0" action="/Home/SavePage">
<input type="hidden" name="PageId" id="PageId" value='<%= ((Model != null) ? Model.page.PageId.ToString() : "0")%>' />
<div class="gen-box grey2">
    <h1>Anuncie grátis</h1>
    <!--Form post an ad-->
    
    <div class="post-ad-form">
    
      <label> <span>Tille *</span><input  type="text" name="Title" id="Title" value='<%= ((Model != null) ? Model.page.Title : "")%>' /></label>
      <label> <span>Link *</span><input  type="text" name="LinkTitle" id="LinkTitle" value='<%= ((Model != null) ? Model.page.LinkTitle : "")%>' /></label>
       <label> <span>Detail *</span><div style="float:right;"><textarea id="Detail" name="Detail"  class="cleditor" ><%= ((Model != null) ? Model.page.Detail : "")%></textarea></div></label>
     <label> <span>Status *</span>
     <%if (Model != null && Model.page != null && Model.page.Active == false) %>
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
          //WYSIWYG Editor
          $(".cleditor").cleditor();

          var submitted = false;
          $('#form0').validate({
              rules: {
                  'Title': {
                      required: true
                  },
                  'LinkTitle': {
                      required: true
                      
                  },
                   'Detail': {
                      required: true
                      
                  }
                  
              },
              messages: {
                  'Title': {
                      required: 'Please enter Title'
                  }
                  ,
                  'LinkTitle': {
                      required: 'Please Enter Link'
                      
                  }
                  ,
                  'Detail': {
                      required: "Please enter Detail"
                      
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

              window.location = "/Home/ManagePages";

          });


      });



</script>
</asp:Content>
