<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<div id="header-main">
 
    <div id="logo"> <a href="/"><img src="/img/ninjalista-logo.png" width="173" height="123" alt="logo" /></a> </div>
    <div id="header-right">
      
    <ul id="navbar">
    <li><%= Html.RouteLink("Categories", new {Controller = "Home", Action = "ManageCategories"})%></li>
    <li><%= Html.RouteLink("Sub Categories", new {Controller = "Home", Action = "ManageSubCategories"}) %></li> 
    <li><%= Html.RouteLink("Ads", new {Controller = "Home", Action = "ManageAds"}) %></li>
    <li><%= Html.RouteLink("Popular Links", new { Controller = "Home", Action = "ManagePopularLinks" })%></li>
    <li><%= Html.RouteLink("Pages", new { Controller = "Home", Action = "ManagePages" })%></li>
    
    
</ul>
    </div>
</div>


