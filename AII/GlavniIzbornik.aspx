<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GlavniIzbornik.aspx.cs" Inherits="AII.Naslovna" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="Scripts/jquery-3.0.0.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Scripts/Naslovna.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Balsamiq+Sans&family=Francois+One&family=Roboto&display=swap" rel="stylesheet"/> 
    <title></title>
</head>
<body class="body_gi">
   <form runat="server" class="form_size">
    <div class="form-inline">
          <asp:Button Text="Engleski" OnClick="BtnEngleski_Click" ForeColor="#A6C9DE" BackColor="#293241" BorderColor="#293241"  CssClass="btn_o" runat="server" meta:resourcekey="ButtonResource1" /> 
         <asp:Button Text="Hrvatski" OnClick="BtnHrvatski_Click"  ForeColor="#A6C9DE" BackColor="#293241" BorderColor="#293241"   CssClass="btn_o" runat="server" meta:resourcekey="ButtonResource2" /> 

             <div class="odjava">
             <asp:Button Text="Odjava" OnClick="BtnOdjava_Click" ForeColor="#A6C9DE" BackColor="#293241" BorderColor="#293241" CssClass="btn_o mr-4" runat="server" meta:resourcekey="ButtonResource3" /> 
        </div>
    </div>

    <div class="center"> 

        <div class="col-sm-3">
      
           <div class="menu_title text-center">
               <asp:Label Text="Administracija" runat="server" meta:resourcekey="LabelResource1" /></div>
           <asp:HyperLink NavigateUrl="~/DjelatnikPregle.aspx" runat="server" meta:resourcekey="HyperLinkResource1" >      <div class="menu_item"> Djelatnik </div>  </asp:HyperLink>
           <asp:HyperLink NavigateUrl="~/TimPregled.aspx" runat="server" meta:resourcekey="HyperLinkResource2" >       <div class="menu_item"> Tim </div> </asp:HyperLink>
           <asp:HyperLink NavigateUrl="~/ProjektPregled.aspx" runat="server" meta:resourcekey="HyperLinkResource3" ><div class="menu_item"> Projekt </div>  </asp:HyperLink>
           <asp:HyperLink NavigateUrl="~/KlijentPregled.aspx" runat="server" meta:resourcekey="HyperLinkResource4" >      <div class="menu_item"> Klijent </div>  </asp:HyperLink>
          
 
        </div>
          <div class="col-sm-2">

          </div>

        <div class="col-sm-3 ">
                <div class="menu_title text-center" >
                    <asp:Label Text="Izvještavanje" runat="server" meta:resourcekey="LabelResource2" /></div>
             <asp:HyperLink NavigateUrl="~/IzvještajTima.aspx" runat="server" meta:resourcekey="HyperLinkResource5" >   <div class="menu_item"> Izvještaj tima </div> </asp:HyperLink>
             <asp:HyperLink NavigateUrl="~/IzvještajKlijenta.aspx" runat="server" meta:resourcekey="HyperLinkResource6" >    <div class="menu_item"> Izvještaj klijenta </div> </asp:HyperLink>
          
             <div class="menu_item_fix"></div>

        </div>

 </div>
           
 

</form>
</body>
</html>
