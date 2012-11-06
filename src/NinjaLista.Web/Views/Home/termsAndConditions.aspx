<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="robots" content="noindex">
<link sizes="57x57" href="img/icon.png" rel="apple-touch-icon-precomposed" />
<link sizes="114x114" href="img/icon-pc-hd.png" rel="apple-touch-icon-precomposed" />
<title>Termos e condições</title>
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

</script></head>
<body>
   
<%Html.RenderPartial("Login"); %>
<%Html.RenderPartial("HeaderWithMenu"); %>
<div id="content-main"> 
    <%Html.RenderPartial("SearchContainer"); %>
    
  <div class="breadcrumb"><p>Você está em: </p> 
      <p><a href="/">Home </a>> Termos e condições</p>
    </div>
    <div class="gen-box">
    <h1>Termos e condições</h1>
   
      
    <div class="sample-page">
      <h3>Considerações iniciais</h3>
     <br />

      <p> Bem vindo ao site NinjaLista, o maior site de <strong>classificados para a comunidade Brasileira no
Reino Unido</strong> e em especial na região de <strong>Londres</strong>.
Ao utilizar o site NinjaLista, o usuário automaticamente aceita e concorda 
em seguir as seguintes condições dispostas nesta página de nossos
Termos e condições (T&amp;C). Caso contrário, deverá cessar o uso deste site imediatamente.</p> 
      <br />

      <p>O site NinjaLista reserva-se o direito de fazer alterações que forem
          necessárias deste T&C  periodicamente, e o usuário reconhece e aceita que é de sua 
      responsabilidade se manter atualizado de acordo com as regras aqui citadas.</p>
          
      <br />

      <h3>Política de uso:</h3>

<br />

<p>O NinjaLista é um site de classificados virtuais, onde hospeda 
conteúdo de terceiros. Desta forma, não se resposabiliza pela veracidade dos 
anúncios aqui presentes.</p>
<br />


<p>O usuário concorda que é de sua inteira resposabilidade o uso de qualquer
serviço ou anúncio postado neste site.</p>
<br />

<p>Anúncios não são modificados, editados ou monitorados pelo ninjalista que
não assume qualquer responsabilidade pelo conteúdo de tais, e por qualquer negociação feita entre usuários.</p>
<br />

<p>NinjaLista reserva-se o direito de remover qualquer anúncio ou conteúdo
sem aviso prévio que acredite não ser apropriado ou que seja ilegal.</p>

<p>Isto pode incluir os seguintes, mas não está limitado a:</p>
<br />

<ul class="list-item">
<li>Conteúdo que infrija direitos autorais;</li>
<li>Conteúdo falso ou com o intuito de enganar outros usúarios;</li>
<li>Spam, ou esquemas de pirâmide;</li>
<li>Conteúdo pornográfico, abusivo ou difamátorio;</li>
<li>Conteúdo que apresente qualquer risco a menores;</li>
<li>Conteúdo que inclua informações de terceiros sem as devidas autorizações;</li>
<li>Conteúdo que divulgue serviços ilegais ou que sejam proibidos por leis locais;</li>
<li>Conteúdo que induza atitudes discriminatórias seja de raça, sexo, crenças, ou qualquer
outra forma de descriminação ou racismo;</li>
</ul>
<br />

<p>
O conteúdo disponível neste website pode conter links para sites externos
sem qualquer ligação com o ninjalista.</p>
<p>Qualquer informação contidas em websites externos não é de nenhuma forma responsabilidade
da ninjalista. O usuário compromete-se a assumir qualquer responsabilidade
ao clicar em tais links.</p>

<br />

<p>O usuário compromete-se	a não:</p>
<br />

<ul class="list-item">
<li>Divulgar o mesmo anúncio repetidas vezes na mesma categoria, ou em diferentes categorias;</li>
<li>Divulgar anúncios que contenham spiders, crawlers ou robôs e qualquer outra forma de captação de dados do site;</li>
<li>Divulgar anúncios que contenham vírus ou qualquer outra forma de código malicioso;</li>
<li>Divulgar material que sejam inexatos, falsos, ou que representem promoção enganosa; </li>
<li>Obter ou divulgar dados pessoais de outros usuários para fins comerciais ou ilícitos;</li>
<li>Tentar obter acesso não autorizado ao sistema do Ninjalista;</li>
<li>Se envolver em qualquer atividade ilícita que reduza, prejudique ou danifique partes ou o site como um todo; </li>
</ul>
<br />




<p>Trabalhamos para que conteúdo ofensivo ou ilegal não esteja presente em nosso site
. Por favor informe-nos sobre qualquer conteúdo offensivo ou que não esteja de acordo com
as regras aqui estipuladas usando o nosso sistema disponível no site.
</p>
<br />
  
<p>  O Ninjalista se exime de qualquer responsabilidade sobre o site estar
fora do ar por motivos além do nosso alcance. No entanto, todos os esforços 
são feitos para que tais situações sejam evitadas.</p>
<br />

<p>  O nosso intuito é prestar um serviço de qualidade a <strong>comunidade brasileira em Londres</strong> e no Reino Unido em geral da melhor forma possível.</p> 

 
        </div>       
  </div>
  <%Html.RenderPartial("Footer"); %>
</body>
</html>
