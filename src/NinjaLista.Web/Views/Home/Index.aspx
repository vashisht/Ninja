<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="robots" content="noindex">
    <link sizes="57x57" href="/img/icon.png" rel="apple-touch-icon-precomposed" />
    <link sizes="114x114" href="/img/icon-pc-hd.png" rel="apple-touch-icon-precomposed" />
    <title>Ninjalista | Classificados para a Comunidade Brasileira em Londres</title>
    <link rel="stylesheet" type="text/css" href="<%= Url.Content("~/Content/default.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%= Url.Content("~/Content/Home.css") %>" />
    <meta name="description" content="O Ninjalista é o maior site de classificados gratuitos da comunidade Brasileira em Londres e no Reino Unido. Encontre serviços por categorias, ofertas de empregos, acomodação para Brasileiros e muito mais." />
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
    <link rel="icon" href="/img/favicon.ico" />
</head>
<body>
    <% Html.RenderPartial("Login"); %>
    <!--Header area-->
    <% Html.RenderPartial("HeaderWithMenu");%>
    <!--End Header area-->
    <!--Content-->
    <div id="content-main">
        <!--Search-container-->
        <% Html.RenderPartial("SearchContainer"); %>
        <!--End search-container-->
        <!--Breadcrumb-->
        <div class="breadcrumb">
            <p>
                You are in:
            </p>
            <p>
                <a href="/">Home ></a></p>
            <p>
                Home</p>
        </div>
        <!--End Breadcrumb-->
        <!--content-left-->
        <div id="content-left">
            <div class="promo-box">
                <a href="#">
                    <img src="/img/fb-like.png" width="180" /></a></div>
            <div class="site-add">
                <a href="#">
                    <img src="/img/add.jpg" width="164" height="600" /></a>
                <p>
                    advertisement</p>
            </div>
        </div>
        <!--End content-left-->
        <!--content-right-->
        <div id="content-right">
            <div class="column-1">
                <h2 class="servicos">
                   <a href="/Servicos">Serviços</a> </h2>
                <ul>
                    <li><a href="/Agencias de viagem">Agências de viagem</a></li>
                    <li><a href="/Baba">Bába</a></li>
                    <li><a href="/Comida brasileira">Comida brasileira</a></li>
                    <li><a href="/Construção e reformas">Construção e reformas</a></li>
                    <li><a href="/Cursos escolas e aulas">Cursos, escolas e aulas</a></li>
                    <li><a href="/Dinheiro e finanças">Dinheiro e finanças</a></li>
                    <li><a href="/Espiritualidade e esoterismo">Espiritualidade e esoterismo</a></li>
                    <li><a href="/Organização de festas e eventos">Organização de festas e eventos</a></li>
                    <li><a href="/Serviços de informática">Serviços de informática</a></li>
                    <li><a href="/Transporte e mudanças">Transporte e mudanças</a></li>
                    <li><a href="/Oficinas mecânicas">Oficinas mecânicas</a></li>
                    <li><a href="/Publicidade e propaganda">Publicidade e propaganda</a></li>
                    <li><a href="/Roupas e acessórios">Roupas e acessórios</a></li>
                    <li><a href="/Salões de beleza">Salões de beleza</a></li>
                </ul>
            </div>
            <div class="column-2">
                <h2 class="acomodacao">
                 <a href="/Acomodacao">Acomodação</a>   </h2>
                <ul>
                    <li><a href="/Casas para aluguel">Casas para aluguel</a></li>
                    <li><a href="/Apartamentos para aluguel">Apartamentos para aluguel</a></li>
                    <li><a href="/Quartos para aluguel">Quartos para aluguel</a></li>
                    <li><a href="/Escritórios e imóveis comerciais">Escritórios e imóveis comerciais</a></li>
                </ul>
                <h2 class="comunidade">
                 <a href="/Comunidade">Comunidade</a></h2>
                <ul>
                    <li><a href="/Baladas">Baladas</a></li>
                    <li><a href="/Bares e restaurantes">Bares e restaurantes</a></li>
                    <li><a href="/Concertos e shows">Concertos e shows</a></li>
                    <li><a href="/Eventos">Eventos</a></li>
                    <li><a href="/Grupos de apoio">Grupos de apoio</a></li>
                    <li><a href="/Grupos e encontros">Grupos e encontros</a></li>
                    <li><a href="/Ingrejas e religião">Ingrejas e religião</a></li>
                </ul>
            </div>
            <div class="column-3">
                <h2 class="empregos">
                  <a href="/Empregos">Empregos</a>  </h2>
                <ul>
                    <li><a href="/Ofertas de emprego">Ofertas de emprego</a></li>
                    <li><a href="/Buscando trabalho">Buscando trabalho</a></li>
                    <li><a href="/Trabalhos temporários">Trabalhos temporários</a></li>
                </ul>
                <h2 class="relacionamento">
                  <a href="/Relacionamento">Relacionamento</a>  </h2>
                <ul>
                    <li><a href="/Homens à procura de mulheres">Homens à procura de mulheres</a></li>
                    <li><a href="/Mulheres à procura de homens">Mulheres à procura de homens</a></li>
                    <li><a href="/Relacionamento casual">Relacionamento casual</a></li>
                    <li><a href="/Relacionamento sério">Relacionamento sério</a></li>
                    <li><a href="/Novas amizades">Novas amizades</a></li>
                    <li><a href="/Conexões perdidas">Conexões perdidas</a></li>
                    <li><a href="/Desabafo">Desabafo</a></li>
                </ul>
            </div>
            <!--Adds-->
            <div id="ad-bottom">
                <div class="wrapper">
                    <div class="list-carousel">
                        <ul id="carousel">
                            <li><a href="#">
                                <img src="/img/logo-thumb.jpg" width="118" height="105" /></a></li>
                            <li><a href="#">
                                <img src="/img/logo-thumb.jpg" width="118" height="105" /></a></li>
                            <li><a href="#">
                                <img src="img/logo-thumb.jpg" width="118" height="105" /></a></li>
                            <li><a href="#">
                                <img src="img/logo-thumb.jpg" width="118" height="105" /></a></li>
                            <li><a href="#">
                                <img src="/img/logo-thumb.jpg" width="118" height="105" /></a></li>
                            <li><a href="#">
                                <img src="/img/logo-thumb.jpg" width="118" height="105" /></a></li>
                            <li><a href="#">
                                <img src="/img/logo-thumb.jpg" width="118" height="105" /></a></li>
                            <li><a href="#">
                                <img src="/img/logo-thumb.jpg" width="118" height="105" /></a></li>
                            <li><a href="#">
                                <img src="/img/logo-thumb.jpg" width="118" height="105" /></a></li>
                            <li><a href="#">
                                <img src="/img/logo-thumb.jpg" width="118" height="105" /></a></li>
                        </ul>
                        <div class="clearfix">
                        </div>
                        <a id="prev" class="prev" href="#">&lt;</a> <a id="next" class="next" href="#">&gt;</a>
                    </div>
                    <br />
                </div>
            </div>
            <!--End Adds-->
             <%Html.RenderPartial("PopularCategories"); %>
        </div>
        <!--End content-right-->
        <!--End content-main-->
   
    
    </div>
    <!--Footer-->
    <%Html.RenderPartial("Footer");%>
    <!--End Footer-->
    
</body>
</html>
