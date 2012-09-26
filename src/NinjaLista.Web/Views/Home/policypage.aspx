<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="robots" content="noindex">
<link sizes="57x57" href="images/icon.png" rel="apple-touch-icon-precomposed" />
<link sizes="114x114" href="images/icon-pc-hd.png" rel="apple-touch-icon-precomposed" />

<title>Política de privacidade</title>
<link rel="stylesheet" type="text/css" href="<%=Url.Content("/content/default.css") %>"/>
<link rel="stylesheet" type="text/css" href="<%=Url.Content("/content/geral.css") %>"/>
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
   <%Html.RenderPartial("Login"); %>
<%Html.RenderPartial("HeaderWithMenu"); %>
<div id="content-main"> 
    <%Html.RenderPartial("SearchContainer"); %>
     <div class="breadcrumb">
      <p>You are in: </p>
      <p><a href="#">Home ></a></p>
       
      <p>Política de privacidade</p>
    </div>
    <div class="gen-box">
    <h1>Política de privacidade</h1>
   

      
    <div class="sample-page">
    
    <p>O Ninjalista se empenha em promover e garantir a segurança e a privacidade de cada usuário.</p><br>

<p>Tomamos as medidas possíveis para manter a confidencialidade e a proteção dos dados disponibilizados por nossos utilizadores, entretando, não responderemos por prejuízo que possa ser derivado da violação dessas medidas por parte de terceiros que utilizem as redes públicas ou a internet, com o intuito de violar e ou quebrar barreiras de segurança para acessar informações de usuários anunciantes.</p><br><br>



      <h3>Cookies</h3>
     <p><strong>O que são cookies</strong></p>
 <p> Cookies sao pequenos arquivos enviados ao seu computador atravéz do navegador que ajudam a traçar o perfil do usuário. Eles podem ser usados para armazenar as prefências selecionadas pelo usuário, remetendo a você um conteúdo específico de acordo com suas necessidades e interesses.</p>
  <p>Esses dados coletados auxiliam a entender como o usuário utiliza o nosso site, por exemplo, em quais botões o usuário clicou ou quais páginas foram visitadas.</p><br>
<p><strong>Controle o Acesso dos Cookies:</strong></p>

<p>Todas as versões mais recentes dos navegadores mais populares lhe dão a opção de controlar o uso de cookies. O usuário tem a opção de aceitar ou rejeitar cookies de todos os sites que visita, ou de apenas alguns ao seu critério.</p><br>

<p>Mas informações sobre como controlar ou deletar cookies no seu sistema operacional e navegador podem ser encontrados aqui (link em inglês): <a href="http://www.aboutcookies.org" target="_blank">aboutcookies.org</a> </p><br><br>


<h3>Endereço IP</h3>

<p>O endereço IP (Internet Protocol) é um número único de identificação de cada dispositivo que se conecta a internet.</p>
<p>O Ninjalista utiliza o endereço IP para compreender como o usuário utiliza o nosso site fazendo com que possamos oferecer uma melhor experiência ao visitante, por exemplo oferecendo conteúdo relevante a localidade de cada usuário.
</p><br><br>




<h3>Coleta e Tratamento dos Dados:</h3>

 <p>A transmissão ou o envio de dados ao Ninjalista é voluntária, podendo ter caráter obrigatório quando o usuário optar por utilizar-se de determinadas ações, conteúdos restritos, produtos e/ou serviços, cujas naturezas não permitam a falta de certos dados.</p><br>

 
<p> Em alguns pontos do site são coletadas informações de identificação geral ou individual (como nome, email, informação de localidade, comentários ou mensagens, telefone, etc.) necessárias à navegação ou utilização do site. Em certos casos, podemos usar essas informações para entrar em contato por meio de emails promocionais, com ofertas, serviços ou outras informações que julgarmos ser de seu interesse.
 </p><br>

 
<p>Essas informações coletadas são manipuladas apenas por pessoal autorizado e não são distribuidas ou vendidas a terceiros sem a permissão do usuário.</p>
<br>
<br>








<h3>Links para websites externos</h3>
<p>O Ninjalista contém links para websites externos, que são acessíveis atravéz de nosso site. Não possuimos qualquer controle ou responsabilidade pelo conteúdo de sites externos.  Esteja ciente que estes outros sites podem estar colhendo informações  a seu respeito. Ao acessar tais websites fora do Ninjalista, toda informação que você vier a compartilhar estará fora do nosso controle e portando nossa responsabilidade.
</p><br>
<br>




<h3>Alterações na política de privacidade</h3>
<p>Informamos desde já que poderemos alterar esta política de privacidade a qualquer momento sem aviso prévio. Toda alteração feita na presente Política de Privacidade será veiculada nesta página. É de sua responsabilidade a verificação deste espaço para a versão mais atualizada deste documento.
</p>
      <br />
</div></div></div>
  <%Html.RenderPartial("Footer"); %>

</body>
</html>
