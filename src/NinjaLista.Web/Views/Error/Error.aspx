<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/error.css") %>"/>
<title>Error</title>
</head>
<body id="error">
<div class="error-page">
<p> SOMETHING WENT WRONG!</p>
<H2>LEFT IN THE DARK?</H2>
<p> <a href="/">CLICK HERE</a> TO GO BACK TO THE HOME PAGE</p>
</div>
</body>
</html>
