<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<ul id="navbar">
   <li> <% Html.RouteLink("Home", new {Controller = "Home", Action = "Index"});%></>
    <li><% Html.RouteLink("Links Úteis", new {Controller = "Home", Action = "Linksuteisemlondres"});%></li>
    <li><% Html.RouteLink("Parceiros", new {Controller = "Home", Action = "Partners"}); %></li> 
    <li><% Html.RouteLink("Contato", new {Controller = "Home", Action = "Contato"});%></li>
    <li class="ad-bt-nav"><% Html.RouteLink("Anuncie grátis", new {Controller = "Home", Action = "PostAd"});%></li>
    
</ul>