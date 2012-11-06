<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<!--Footer-->
<div id="footer-main">
  <% using (Html.BeginForm("SignupNewsLetter", "Home", FormMethod.Post, new { enctype = "multipart/form-data", id = "singup-form" })) %>
    <%{%>
    <div id="newsletter">
      <p>Cadastre-se em nossa newsletter e receba nossos informativos:</p>
      <input type="text" id="singup-email" name="email" class="required email" title="Please enter valid Email." placeholder="Seu email aqui">
      <input type="submit" value="cadastrar" class="submit-nl">
      <p id="Message-Signup" style="color:White; padding-bottom:10px;padding-left:458px;"> </p>
    </div>
    <%} %>
    <div id="footer-nav">
         <ul>
       <li><a href="/">Home</a></li>
      <li><a href="/Linksuteisemlondres">Links Úteis</a></li>
      <li><a href="/partners">Parceiros</a></li>
      <li><a href="/contato">Contato</a></li>
      <li><a href="/page/termos-e-condicoes">Termos e condições</a></li>
      <li><a href="/page/politica-de-privacidade">Política de privacidade</a></li>
      <li><a href="/postAd">Anuncie grátis</a></li>

      </ul>
      <a href="http://www.twitter.com/theninjalista"target="_blank"><img src="/img/tw.jpg" width="16" height="16" alt="tw" /></a><a href="http://www.facebook.com/ninjalista" target="_blank"><img src="/img/fb.jpg" width="16" height="16" alt="tw" /></a>  </div>
    <div id="copy">
      <p><strong>&copy; Copyright 2012 NinjaLista.com</strong> Todos os direitos reservados. Problemas em acessar nosso site? Entre em contato conosco via email <a href="mailto:webmaster@ninjalista.com">webmaster@ninjalista.com</a> </p>
    </div>
  
</div>
<!--End Footer-->

<script type="text/javascript">
    $(document).ready(function () {
        var submitted = false;
        $('#singup-form').validate({

            showErrors: function (errorMap, errorList) {
                if (submitted) {
                    var summary = "";
                    $.each(errorList, function () { summary += " * " + this.message + "<br/>"; });

                    //alert(summary);
                    submitted = false;
                    $('#Message-Signup').html(summary);
                    $('#newsletter').css('height', '45px');
                }
                //this.defaultShowErrors();
            },
            invalidHandler: function (form, validator) {
                submitted = true;
            }

        });
    });

</script>