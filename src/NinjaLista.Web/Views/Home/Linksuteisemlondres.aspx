<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="robots" content="noindex">
    <link sizes="57x57" href="/img/icon.png" rel="apple-touch-icon-precomposed" />
    <link sizes="114x114" href="/img/icon-pc-hd.png" rel="apple-touch-icon-precomposed" />
    <title>Endereços e telefones úteis para brasileiros no Reino Unido</title>
    <link rel="stylesheet" type="text/css" href="<%= Url.Content("~/Content/default.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%= Url.Content("~/Content/geral.css") %>" />
    <script type="text/javascript" src="/Scripts/jquery-1.4.1.min.js"></script>
<script type="text/javascript" src="/Scripts/jquery.validate.js"></script>
   
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
                Você está em:
            </p>
           
            <p>
                Links Úteis</p>
        </div>
        <!--End Breadcrumb-->
        <!--content-left-->
        <div id="content-left">
            <div class="promo-box">
               <a href="http://www.facebook.com/ninjalista" target="_blank">
                    <img src="/img/fb-like.png" width="180" /></a></div>
            <div class="site-add">
                <a href="#">
                    <img src="/img/add.jpg" width="164" height="600" /></a>
                <p>
                    Anúncios</p>
            </div>
        </div>
        <!--End content-left-->
        <!--content-right-->
        <div id="content-right">
            <div class="gen-box">
                <h1>
                    Endereços e telefones úteis em Londres</h1>
                <div class="partners-intro">
                    <p>
                        Nesta página você encontrará endereços e telefones úteis para facilitar a sua vida
                        em Londres ou no Reino Unido. Sinta-se à vontade em sugerir novos links para esta
                        seção, que tem como intuito ajudar Portugueses e Brasileiros que moram ou somente estejam de passagem
                        pela terra da rainha.</p><br />

                    <p>
                        A comunidade de língua portuguesa em Londres e no Reino Unido agradece!</p>
                </div>
                <!--useful links-->
                <div class="useful-links-box">
                    <h3>
                        Consulado Português em Londres</h3>
                    <p>
                        <strong>URL:</strong> <a href="http://www.secomunidades.pt/web/londres" target="_blank">www.secomunidades.pt/web/londres</a></p>
                   
                        <strong>Endereço:</strong> 3, Portland Place London W1B 1HR 
                    </p>
                    <p>
                        <strong>Telefone:</strong> +44 (0) 207 291 3770
                    </p>
                    <p>
                        <strong>Fax:</strong> +44 (0) 207 291 3779
                    </p>
                </div>
                <!--useful links-->
                
                <!--useful links-->
                <div class="useful-links-box">
                    <h3>
                        Consulado Brasileiro em Londres</h3>
                    <p>
                        <strong>URL:</strong> <a href="http://www.consuladobrasillondres.com" target="_blank">www.consuladobrasillondres.com</a></p>
                    <p>
                        <strong>Email: </strong><a href="mailto:assistencia@consbraslondres.com">assistencia@consbraslondres.com</a></p>
                    <p>
                        <strong>Endereço:</strong> 3 Vere Street, London, W1G 0DG
                    </p>
                    <p>
                        <strong>Telefone:</strong> +44(20) 7659 1550
                    </p>
                    <p>
                        <strong>Fax:</strong> +44(20) 7659 1554
                    </p>
                </div>
                <!--useful links-->
                <!--useful links-->
                <div class="useful-links-box">
                    <h3>
                        Banco do Brasil em Londres</h3>
                    <p>
                        <strong>URL:</strong> <a href="http://www.bb.com.br" target="_blank">www.bb.com.br</a></p>
                    <p>
                        <strong>Email: </strong><a href="mailto:london@bb.com.br">london@bb.com.br</a></p>
                    <p>
                        <strong>Endereço:</strong> London Branch, Pinners Hall, 105-108 Old Broad Street,EC2N
                        1EX, 4th floor London United Kingdom
                    </p>
                    <p>
                        <strong>Telefone:</strong> +44 + 20 + 76067101
                    </p>
                    <p>
                        <strong>Número gratuito:</strong> 0800 35 888 10 (Grátis somente dentro do Reino
                        Unido)</p>
                    <p>
                        <strong>Fax:</strong> +44 + 20 + 76062877
                    </p>
                </div>
                <!--useful links-->
                <!--useful links-->
                <div class="useful-links-box">
                    <h3>
                        Embratel – Ligações a cobrar para o Brasil do exterior</h3>
                    <p>
                        <strong>URL:</strong> <a href="http://www.embratel.com.br/hotsites/brasildireto/" target="_blank">embratel.com.br/hotsites/brasildireto</a></p>
                    <p>
                        <strong>Telefones:</strong> 0800 89 00 55 ou 0800 056 74 42</p>
                </div>
                <!--useful links-->
                <!--useful links-->
                <div class="useful-links-box">
                    <h3>
                        The Home Office - Departamento de Imigração</h3>
                    <p>
                        <strong>URL:</strong> <a href="http://www.ukba.homeoffice.gov.uk/" target="_blank">www.ukba.homeoffice.gov.uk/</a></p>
                    <p>
                        <strong>Endereço:</strong> Lunar House, 40 Wellesley Road, Croydon CR9 2BY</p>
                    <p>
                        <strong>Telefone:</strong> 0870 606 7766</p>
                </div>
                <!--useful links-->
                <!--useful links-->
                <div class="useful-links-box">
                    <h3>
                        Transport for London</h3>
                    <p>
                        Planeje sua jornada dentro de londres, seja de ônibus, metrô, trem, bonde ou DLR.</p>
                    <p>
                        <strong>URL:</strong> <a href="http://www.tfl.gov.uk/" target="_blank">www.tfl.gov.uk/</a></p>
                    <p>
                        <strong>Telefone:</strong> 0843 222 1234</p>
                </div>
                <!--useful links-->
                <!--useful links-->
                <div class="useful-links-box">
                    <h3>
                        NHS - Sistema de saúde britânico</h3>
                    <p>
                        <strong>URL:</strong> <a href="http://www.nhs.uk" target="_blank">www.nhs.uk</a></p>
                    <p>
                        <strong>Telefone:</strong> 0845 4647</p>
                </div>
                <!--useful links-->
                <!--useful links-->
                <div class="useful-links-box">
                    <h3>
                        Números de emergência</h3>
                    <p>
                        <strong>URL:</strong> <a href="http://www.­met.­police.­uk" target="_blank">www.­met.­police.­uk</a></p>
                    <p>
                        <strong>Telefone:</strong> 999 - Para emergências</p>
                    <p>
                        <strong>Telefone:</strong> 101 - Para denunciar um crime que não necessite uma ação
                        urgente.</p>
                </div>
                <!--useful links-->
            </div>
        </div>
        <!--End content-right-->
    </div>
    <!--End content-main-->
    <!--Footer-->
    <%Html.RenderPartial("Footer"); %>
</body>
</html>
