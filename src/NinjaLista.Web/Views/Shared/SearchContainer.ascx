<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl"  %>

  <div id="search-container">

<% using (Html.BeginForm("SearchResults", "Home", FormMethod.Post, new { enctype = "multipart/form-data",id="search-form" })) %>
    <%{%>

      <div id="searchbox">
        <p>Procurar por:</p>        <input type="text" id="keyword" name="keyword" value="<%=TempData["keyword"] %>" placeholder="e.g. dentista" class="search-fields"/>

        <%--<p>em</p>  <input type="text" placeholder="Battersea London" class="search-fields"/>--%>
        <input type="submit" title="button" value="buscar" class="button" />
      </div>
      <%} %>
    </div>

    <script type="text/javascript">
        $('#search-form').submit(function (e) {
            e.preventDefault();
            window.location.href = "/search/" + $('#keyword').val();
            return false;

        });
    </script>