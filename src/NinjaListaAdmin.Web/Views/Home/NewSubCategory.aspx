<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<NinjaListaAdmin.Web.Views.Models.SubCategoryModel>" %>
<%@ Import Namespace="NinjaListaAdmin" %>
<asp:Content ID="indexContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

<form method="post" enctype="multipart/form-data" id="form0" action="/Home/SaveSubCategory">
<input type="hidden" name="SubCategoryId" id="SubCategoryId" value='<%= ((Model != null && Model.subcategry !=null) ? Model.subcategry.SubCategoryId.ToString() : "0")%>' />
<div class="gen-box grey2">
    <h1>Anuncie grátis</h1>
    <!--Form post an ad-->
    
    <div class="post-ad-form">
    
      <label> <span>Categoria *</span>
      <select id="CategoryId" name="CategoryId">
      <% if (Model.subcategry == null)  %>
      <%{ %>
      <% foreach (var item in Model.categories) %>
      <%{ %>
      <option value="<%=item.CategoryId%>"><%=item.CategoryName  %></option>
      
        
      <%} %>

             
      <%} %>

       <% else  %>
      <%{ %>
      <% foreach (var item in Model.categories) %>
      <%{ %>
      <% if (Model.subcategry.CategoryId == item.CategoryId) %>
      <%{ %>
      <option value="<%=item.CategoryId%>" selected="selected"><%=item.CategoryName%></option>
      <%} %>

         <% else %>
      <%{ %>
      <option value="<%=item.CategoryId%>" ><%=item.CategoryName%></option>
      <%} %>
        
      

        <%} %>     
      <%} %>

      </select>
      </label>
      <label> <span>Subcategorias *</span><input  type="text" name="SubCategoryName" id="SubCategoryName" value='<%= ((Model != null && Model.subcategry !=null) ? Model.subcategry.SubCategoryName : "")%>' /></label>
      <label> <span>Order *</span><input  type="text" name="Ordr" id="Ordr" value='<%= ((Model != null && Model.subcategry !=null) ? Model.subcategry.Ordr.ToString() : "1")%>' /></label>
     <label> <span>Status *</span>
     <%if (Model != null && Model.subcategry != null && Model.subcategry.Active == false) %>
     <%{ %>
     <input  type="checkbox" id="Active" name="Active" style="float:left; width:20px;" value="true" />

           <%}%>
           <%else%>
            <%{ %>
     <input  type="checkbox" id="Checkbox1" name="Active" checked="checked"  style="float:left; width:20px;" value="true"  />

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
                  'SubCategoryName': {
                      required: true
                  },
                  'Ordr': {
                      required: true,
                      number:true
                  }

              },
              messages: {
                  'SubCategoryName': {
                      required: 'Please enter Sub Category Name'
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

              window.location = "/Home/ManageSubCategories";

          });


      });



</script>
</asp:Content>
