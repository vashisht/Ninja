<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<NinjaLista.Views.Models.AdvertListModel>" %>
<%
    
 %>
    <div class="refine">
  
    
   
    <h2>Outras categorias</h2>
    <ul>
    <%if (Model.subcatlist != null && Model.subcatlist.Count > 0)  %>
      <%{
            foreach (var item in Model.subcatlist)
            {
            %>
            
            <li><a href="/<%= item.CategoryName.ToLower().Replace(" ","-") + "/" + item.SubCategoryName.ToLower().Replace(" ", "-") + "/" + item.SubCategoryId %>"><%=item.SubCategoryName  %></a></li>
        
        <%    
            }
          %>
      
    <%} %>
        <li><a href="/">Mais ++</a></li>
    </ul>
    
    </div>


 