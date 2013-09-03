
function MM_reloadPage(init) {  //reloads the window if Nav4 resized
  if (init==true) with (navigator) {if ((appName=="Netscape")&&(parseInt(appVersion)==4)) {
    document.MM_pgW=innerWidth; document.MM_pgH=innerHeight; onresize=MM_reloadPage; }}
  else if (innerWidth!=document.MM_pgW || innerHeight!=document.MM_pgH) location.reload();
}
MM_reloadPage(true);

function open_help(){
 window.open('webhelp/index.htm','','toolbar=no,status=no,scrollbars=yes,location=no');			
}
function open_news_letter_submit(){
var b_tip
var b_news
var b_mail
var s_value;
 b_tip = tips.checked;
 b_news = news.checked;
 b_mail = email.value;
 s_value = 'newslettersubmit.asp?news='+b_news+'&tip='+b_tip+'&mail='+b_mail;
  window.open(s_value,'','top=10,left=10,width=300,height=200,toolbar=no,status=no,scrollbars=no,location=no');			
}
