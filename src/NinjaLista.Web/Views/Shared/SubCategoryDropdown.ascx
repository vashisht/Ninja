<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Ninjalista.DAL.Entities.SubCategoryDetails>" %>


<%=Html.DropDownListFor(x => x.SubCateogryId, new SelectList(Model.SubCategories, "SubCategoryId", "SubCategoryName"))%>


