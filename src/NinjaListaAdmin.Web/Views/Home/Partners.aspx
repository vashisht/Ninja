<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="robots" content="noindex">
<link sizes="57x57" href="/img/icon.png" rel="apple-touch-icon-precomposed" />
<link sizes="114x114" href="/img/icon-pc-hd.png" rel="apple-touch-icon-precomposed" />

<title>partners</title>
  <link rel="stylesheet" type="text/css" href="<%= Url.Content("~/Content/default.css") %>"/>
  <link rel="stylesheet" type="text/css" href="<%= Url.Content("~/Content/geral.css") %>"/>
<script type="text/javascript">

    var _gaq = _gaq || [];
    _gaq.push(['_setAccount', 'UA-31478694-1']);
    _gaq.push(['_trackPageview']);

    (function () {
        var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
        ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
        var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
    })();

</script>
</head>
<body>
    <!--Login area-->
    <%Html.RenderPartial("Login"); %>
    <!--End Login area-->
    <!--Header area-->
    <%Html.RenderPartial("HeaderWithMenu"); %>
    <!--End Header area-->
    <!--Content-->
    <div id="content-main">
        <!--Search-container-->
        <%Html.RenderPartial("SearchContainer"); %>
        <!--End search-container-->
        <!--Breadcrumb-->
        <div class="breadcrumb">
            <p>
                You are in:
            </p>
            <p>
                <a href="#">Home ></a></p>
            <p>
                Home</p>
        </div>
        <!--End Breadcrumb-->
        <!--content-left-->
        <div id="content-left">
            <div class="promo-box">
                <a href="#">
                    <img src="/img/fb-like2.png" width="180" /></a></div>
            <div class="site-add">
                <a href="#">
                    <img src="/img/add.jpg" width="164" height="600" /></a>
                <p>
                    advertisement</p>
            </div>
            <div class="site-add">
                <a href="#">
                    <img src="/img/add2.jpg" width="164" height="271" /></a>
                <p>
                    advertisement</p>
            </div>
        </div>
        <!--End content-left-->
        <!--content-right-->
        <div id="content-right">
            <!--Partners-->
            <div class="gen-box">
                <h1>
                    Partners (Parceiros)</h1>
                <div class="partners-intro">
                    <p>
                        Lorem Ipsum is simply dummy text of the <strong>printing and typesetting industry</strong>.
                        Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when
                        an unknown printer took a galley of type and scrambled it to <a href="#">make a type
                            specimen</a> book. It has survived not only five centuries, but also the <a href="#">
                                leap into electronic</a> typesetting, remaining essentially unchanged.</p>
                </div>
                <!--partners preview-->
                <div class="partners-preview">
                    <div class="partner-thumb">
                        <a href="partners-single.html">
                            <img src="/img/partners-thumb.png" /></a></div>
                    <div class="partner-info-preview">
                        <h3>
                            <a href="partners-single.html">Partner restaurant name</a></h3>
                        <p>
                            435 Battersea park road</p>
                        <p>
                            SW11 5DS</p>
                        <p>
                            London UK</p>
                        <p>
                            Site: <a href="#">www.google.com</a></p>
                        <p>
                            Email: <a href="#">info@google.com</a></p>
                    </div>
                </div>
                <div class="partners-preview">
                    <div class="partner-thumb">
                        <a href="partners-single.html">
                            <img src="/img/partners-thumb.png" /></a></div>
                    <div class="partner-info-preview">
                        <h3>
                            <a href="partners-single.html">Partner restaurant name</a></h3>
                        <p>
                            435 Battersea park road</p>
                        <p>
                            SW11 5DS</p>
                        <p>
                            London UK</p>
                        <p>
                            Site: <a href="#">www.google.com</a></p>
                        <p>
                            Email: <a href="#">info@google.com</a></p>
                    </div>
                </div>
                <div class="partners-preview">
                    <div class="partner-thumb">
                        <a href="partners-single.html">
                            <img src="/img/partners-thumb.png" /></a></div>
                    <div class="partner-info-preview">
                        <h3>
                            <a href="partners-single.html">Partner restaurant name</a></h3>
                        <p>
                            435 Battersea park road</p>
                        <p>
                            SW11 5DS</p>
                        <p>
                            London UK</p>
                        <p>
                            Site: <a href="#">www.google.com</a></p>
                        <p>
                            Email: <a href="#">info@google.com</a></p>
                    </div>
                </div>
                <div class="partners-preview">
                    <div class="partner-thumb">
                        <a href="partners-single.html">
                            <img src="/img/partners-thumb.png" /></a></div>
                    <div class="partner-info-preview">
                        <h3>
                            <a href="partners-single.html">Partner restaurant name</a></h3>
                        <p>
                            435 Battersea park road</p>
                        <p>
                            SW11 5DS</p>
                        <p>
                            London UK</p>
                        <p>
                            Site: <a href="#">www.google.com</a></p>
                        <p>
                            Email: <a href="#">info@google.com</a></p>
                    </div>
                </div>
                <div class="partners-preview">
                    <div class="partner-thumb">
                        <a href="partners-single.html">
                            <img src="/img/partners-thumb.png" /></a></div>
                    <div class="partner-info-preview">
                        <h3>
                            <a href="partners-single.html">Partner restaurant name</a></h3>
                        <p>
                            435 Battersea park road</p>
                        <p>
                            SW11 5DS</p>
                        <p>
                            London UK</p>
                        <p>
                            Site: <a href="#">www.google.com</a></p>
                        <p>
                            Email: <a href="#">info@google.com</a></p>
                    </div>
                </div>
                <div class="partners-preview">
                    <div class="partner-thumb">
                        <a href="partners-single.html">
                            <img src="/img/partners-thumb.png" /></a></div>
                    <div class="partner-info-preview">
                        <h3>
                            <a href="partners-single.html">Partner restaurant name</a></h3>
                        <p>
                            435 Battersea park road</p>
                        <p>
                            SW11 5DS</p>
                        <p>
                            London UK</p>
                        <p>
                            Site: <a href="#">www.google.com</a></p>
                        <p>
                            Email: <a href="#">info@google.com</a></p>
                    </div>
                </div>
                <div class="partners-preview">
                    <div class="partner-thumb">
                        <a href="partners-single.html">
                            <img src="/img/partners-thumb.png" /></a></div>
                    <div class="partner-info-preview">
                        <h3>
                            <a href="partners-single.html">Partner restaurant name</a></h3>
                        <p>
                            435 Battersea park road</p>
                        <p>
                            SW11 5DS</p>
                        <p>
                            London UK</p>
                        <p>
                            Site: <a href="#">www.google.com</a></p>
                        <p>
                            Email: <a href="#">info@google.com</a></p>
                    </div>
                </div>
                <div class="partners-preview">
                    <div class="partner-thumb">
                        <a href="partners-single.html">
                            <img src="/img/partners-thumb.png" /></a></div>
                    <div class="partner-info-preview">
                        <h3>
                            <a href="partners-single.html">Partner restaurant name</a></h3>
                        <p>
                            435 Battersea park road</p>
                        <p>
                            SW11 5DS</p>
                        <p>
                            London UK</p>
                        <p>
                            Site: <a href="#">www.google.com</a></p>
                        <p>
                            Email: <a href="#">info@google.com</a></p>
                    </div>
                </div>
                <div class="partners-preview">
                    <div class="partner-thumb">
                        <a href="partners-single.html">
                            <img src="/img/partners-thumb.png" /></a></div>
                    <div class="partner-info-preview">
                        <h3>
                            <a href="partners-single.html">Partner restaurant name</a></h3>
                        <p>
                            435 Battersea park road</p>
                        <p>
                            SW11 5DS</p>
                        <p>
                            London UK</p>
                        <p>
                            Site: <a href="#">www.google.com</a></p>
                        <p>
                            Email: <a href="#">info@google.com</a></p>
                    </div>
                </div>
                <div class="partners-preview">
                    <div class="partner-thumb">
                        <a href="partners-single.html">
                            <img src="/img/partners-thumb.png" /></a></div>
                    <div class="partner-info-preview">
                        <h3>
                            <a href="partners-single.html">Partner restaurant name</a></h3>
                        <p>
                            435 Battersea park road</p>
                        <p>
                            SW11 5DS</p>
                        <p>
                            London UK</p>
                        <p>
                            Site: <a href="#">www.google.com</a></p>
                        <p>
                            Email: <a href="#">info@google.com</a></p>
                    </div>
                </div>
                <div class="partners-preview">
                    <div class="partner-thumb">
                        <a href="partners-single.html">
                            <img src="/img/partners-thumb.png" /></a></div>
                    <div class="partner-info-preview">
                        <h3>
                            <a href="partners-single.html">Partner restaurant name</a></h3>
                        <p>
                            435 Battersea park road</p>
                        <p>
                            SW11 5DS</p>
                        <p>
                            London UK</p>
                        <p>
                            Site: <a href="#">www.google.com</a></p>
                        <p>
                            Email: <a href="#">info@google.com</a></p>
                    </div>
                </div>
                <div class="partners-preview">
                    <div class="partner-thumb">
                        <a href="partners-single.html">
                            <img src="/img/partners-thumb.png" /></a></div>
                    <div class="partner-info-preview">
                        <h3>
                            <a href="partners-single.html">Partner restaurant name</a></h3>
                        <p>
                            435 Battersea park road</p>
                        <p>
                            SW11 5DS</p>
                        <p>
                            London UK</p>
                        <p>
                            Site: <a href="#">www.google.com</a></p>
                        <p>
                            Email: <a href='mailto:info@google.com'>info@google.com</a></p>
                           
                    </div>
                </div>
                <!--partners preview-->
          </div>
            <!--Partners-->
        </div>
        <!--End content-right-->
    </div>
    <!--End content-main-->
    <!--Footer-->
    <%Html.RenderPartial("Footer"); %>
    <!--End Footer-->
</body>
</html>
