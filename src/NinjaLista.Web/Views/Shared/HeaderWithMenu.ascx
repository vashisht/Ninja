<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<div id="header-main">
 
    <div id="logo"> <a href="/"><img src="/img/ninjalista-logo.png" width="173" height="123" alt="logo" /></a> </div>
    <div id="header-right">
      <div id="add-top"><a href="#"><img src="/img/ad-top.gif" width="468" height="60" alt="add" /></a></div>
    <ul id="navbar">
   <li> <%= Html.RouteLink("Home", new {Controller = "Home", Action = "Index"})%></>
    <li><%= Html.RouteLink("Links Úteis", new {Controller = "Home", Action = "Linksuteisemlondres"})%></li>
  <!--  <li><%= Html.RouteLink("Parceiros", new {Controller = "Home", Action = "Partners"}) %></li> -->
    <li><%= Html.RouteLink("Contato", new {Controller = "Home", Action = "Contato"}) %></li>
    <li class="ad-bt-nav"><%= Html.RouteLink("Anuncie grátis", new {Controller = "Home", Action = "PostAd"})%></li>
    
</ul>
    </div>
</div>


