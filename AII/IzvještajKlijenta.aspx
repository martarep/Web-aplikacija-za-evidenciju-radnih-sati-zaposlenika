<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IzvještajKlijenta.aspx.cs" Inherits="AII.IzvještajKlijenta" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="Scripts/jquery-3.0.0.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Scripts/Naslovna.css" rel="stylesheet" />
<script src='https://kit.fontawesome.com/a076d05399.js'></script>
     <link href="https://fonts.googleapis.com/css2?family=Balsamiq+Sans&family=Francois+One&family=Roboto&display=swap" rel="stylesheet"/>
   <script src="http://cdnjs.cloudflare.com/ajax/libs/jquery/2.0.3/jquery.min.js"></script>
    <script src="http://www.jqueryscript.net/demo/jQuery-Plugin-To-Convert-HTML-Table-To-CSV-tabletoCSV/jquery.tabletoCSV.js"></script>

    <title></title>
</head>
<body class="body_s" >
      <nav class="navbar navbar_custom">
  <span class="nav-item navbar_description">
      <asp:Label Text="Izvještaj klijenta" runat="server" meta:resourcekey="LabelResource1" /></span>
         
      <asp:HyperLink NavigateUrl="~/IzvještajKlijenta.aspx" runat="server" CssClass=" navbar_item" meta:resourcekey="HyperLinkResource1" >
<i class='fas fa-file-alt'></i>  Pregled
      </asp:HyperLink>

           <asp:HyperLink NavigateUrl="GlavniIzbornik.aspx" runat="server" CssClass="navbar_item menu_k" meta:resourcekey="HyperLinkResource2" >
  <i class='fa fa-bars '></i>
      </asp:HyperLink>
</nav>
    <form id="form1" runat="server" class="form_size">
         <div class="form-inline" runat="server">
               <div class="site_description">
                        <i class='far fa-id-card'></i>
                   <asp:Label Text="  Klijent" runat="server" meta:resourcekey="LabelResource2" />
        <asp:DropDownList 
            ID="ddlKlijent" 
             ForeColor="#293241" 
            CssClass="form-control list_podaci mb-3 ml-4"
            BackColor="#E0FBFC" 
            BorderColor="#293241" 
            runat="server" 
            Width="300px" 
            AutoPostBack="True"
            meta:resourcekey="ddlKlijentResource1" >
        </asp:DropDownList> 
               </div>
              <div class="mt-4 ml-5">
                  <asp:Label Text="Od:"
                        CssClass="label align-bottom pl-5"
                            ForeColor="#EE6C4D"
                            runat="server" meta:resourcekey="LabelResource3" />
                        <asp:TextBox ID="tbDatumOd" 
                         TextMode="Date"
             ForeColor="#293241" 
            CssClass="form-control textbox_podaci"
            BackColor="#E0FBFC" 
            BorderColor="#293241"  
            runat="server" meta:resourcekey="tbDatumZaposlenjaResource1"  /> 
             <asp:Label Text="Do:"
                        CssClass="label align-bottom pl-5"
                            ForeColor="#EE6C4D"
                            runat="server" meta:resourcekey="LabelResource4" />
                        <asp:TextBox  ID="tbDatumDo" 
                       TextMode="Date"
             ForeColor="#293241" 
            CssClass="form-control textbox_podaci "
            BackColor="#E0FBFC" 
            BorderColor="#293241" 
                       
            runat="server" meta:resourcekey="TextBox1Resource1" />
              </div>
             <div class="ml-5">  <asp:Button OnClick="BtnPrikazi_Click" Text="Prikaži" class="btn_o ml-5" ForeColor="#293241" BackColor="#EE6C4D" BorderColor="#EE6C4D" ID="btnPrikazi"  runat="server" meta:resourcekey="btnPrikaziResource1" />

                     <asp:Button id="export" data-export="export" Text="Izvezi"  CssClass="btn_o ml-5" ForeColor="#293241" BackColor="#EE6C4D" BorderColor="#EE6C4D" runat="server" meta:resourcekey="btnIzveziResource1" />      </div>
          </div> 

          <div class="row position_center">
            <div class="col-md-11 box position_center">
               <div class="boundaries_fp">
            <div class="position_center table_custom">  
                <table>
                        <thead>
                      
                        <tr>  
                            <td class="table_label"> <asp:Label Text="Klijent" runat="server"  />
                                </td>
                            <td class="table_header"> <asp:Label id="idKlijent" runat="server"  /> </td>
                            <td class="table_label">
                                <asp:Label Text="Od" runat="server" /> <asp:Label id="idDatumOd" CssClass="table_header" runat="server"  /> </td>
                            <td class="table_label">
                                <asp:Label Text="Do" runat="server"/>
                          <asp:Label CssClass="table_header" id="idDatumDo" runat="server"  /></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td class="table_header td_projekt">
                                <asp:Label Text="Naziv projekta" runat="server" /></td>
                               <td class="table_header">
                                <asp:Label Text="Radni sati" runat="server" /></td>
                          <td></td>
                            </tr>
                  
                    </thead>
                    <tbody id="idtbody" runat="server">

                    </tbody>
                </table>
            </div> 
                    </div>
            </div>

        </div>

    </form>

</body>
</html>

<script>
    $("#export").click(function () {
        $("table").tableToCSV();
    });
</script>