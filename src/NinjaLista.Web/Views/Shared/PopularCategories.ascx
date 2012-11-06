<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<NinjaLista.Views.Models.CategoryModel>" %>
    <div class="column-4">
      <h2>Pesquisas populares</h2>
      <%if (Model.poplinklist != null && Model.poplinklist.Count > 0)  %>
      <%{ %>
      <% int count = 0; int Count1 = 0; int count3 = Model.poplinklist.Count;   %>
       <%  count =  (int)Math.Ceiling(Convert.ToDecimal(Model.poplinklist.Count/3.00));%>
       
       <% Count1 = count + count; %>
       <ul>
         <% for( int i=0; i < count; i++)  %>

         <%{ %>
         <li><a href="<%=Model.poplinklist[i].Link %>"><%=Model.poplinklist[i].Title  %></a></li>

          
       <%} %>
       </ul>

       <ul>
       <%if(Model.poplinklist.Count > Count1 ) %>

       <%{ %>
         <% for( int j=count; j < Count1; j++)  %>

         <%{ %>
         <li><a href="<%=Model.poplinklist[j].Link %>"><%=Model.poplinklist[j].Title  %></a></li>

          
       <%} %>

       <%} %>

       </ul>

       <ul>

       

       
         <% for (int k = Count1;   k < Model.poplinklist.Count ; k++)  %>

         <%{ %>
         <li><a href="<%=Model.poplinklist[k].Link %>"><%=Model.poplinklist[k].Title  %></a></li>

          
       <%} %>
       
       
       </ul>

      <%} %>
      
    </div>


 