<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Naslovna.aspx.cs" Inherits="AII.Naslovna1" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="Scripts/jquery-3.0.0.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Scripts/Naslovna.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Balsamiq+Sans&family=Francois+One&family=Roboto&display=swap" rel="stylesheet" />

    <title></title>
</head>
<body class="body_s">

   
        <div class="center_naslovna" id="show_menu" runat="server">
            <div class="col-sm-9">
                <div class="text-center">
                  <asp:HyperLink NavigateUrl="GlavniIzbornik.aspx" runat="server" Style="text-decoration: none" meta:resourcekey="HyperLinkResource2" > 
                      <img src="https://image.flaticon.com/icons/svg/744/744480.svg" width="224" height="224" alt="Globe free icon" title="Globe free icon" />
         </asp:HyperLink>              <div class="text_destination">
                  <asp:HyperLink NavigateUrl="GlavniIzbornik.aspx" runat="server" CssClass="text_destination" Style="text-decoration: none" meta:resourcekey="HyperLinkResource1" >    
                   Izaberi svoju destinaciju
</asp:HyperLink></div></div></div></div></body></html>