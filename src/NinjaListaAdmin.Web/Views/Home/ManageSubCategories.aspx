<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<NinjaListaAdmin.Web.Views.Models.CategoryModel>" %>
<%@ Import Namespace = "NinjaListaAdmin" %>



<asp:Content ID="indexContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
<div style="padding-left:25px; padding-bottom:2px;"><%=Html.ActionLink("Add Sub Category", "NewSubCategory", "Home",  new { @class = "button" })%></div>
<div style="clear:both; height:20px; "></div>
<form id="frm1" method="post" enctype="multipart/form-data">
<label> <span style=" padding-left:25px;">Categoria *</span> <%=Html.DropDownListFor(x => x.CateogryId, new SelectList(Model.Categories , "CategoryId", "CategoryName"))%></label>
<div id="sublist">
       <% Html.RenderAction("SubcatList", "Home"); %>
       </div>
</form>
       
<script type="text/javascript">

    $(function () {


        
//        oTable = $('#tbllist').dataTable({
//            "bJQueryUI": true
////            "sPaginationType": "full_numbers"

//        });

        $('#CateogryId').change(function () {

            var catid = $('#CateogryId').val();

           

            $('#sublist').load('/Home/SubcatList', $('#frm1').serialize(), function () {

            });

           

        });

    });

  

</script>
       
</asp:Content>
