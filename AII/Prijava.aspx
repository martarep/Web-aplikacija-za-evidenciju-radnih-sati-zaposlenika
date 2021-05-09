<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prijava.aspx.cs" Inherits="AII.Prijava" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Src="~/Clock.ascx" TagPrefix="uc1" TagName="Clock" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="Scripts/jquery-3.0.0.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Scripts/Prijava.css" rel="stylesheet" />
    <script src="Scripts/Prijava.js"></script>
    <link href="https://fonts.googleapis.com/css2?family=Balsamiq+Sans&family=Francois+One&family=Roboto&display=swap" rel="stylesheet" />
    <title></title>
</head>
<body>
    <div class="container_prijava center">
            <div class="col-md-4 col-sm-10 text-center">
            <p class="quote">
                <asp:Label Text="Svaki sat korisnog rada je dragocjen." runat="server" meta:resourcekey="LabelResource1" />  
            </p>
            <p class="author">
                William Lyon Mackenzie King 
            </p>
        </div>

        <div class="col-sm-10 col-md-3 login center">
            <form method="post" name="login" runat="server">
                <p class="text-center naslov">
                    <asp:Label Text="Prijavi se i započni s radom!" runat="server" meta:resourcekey="LabelResource2" /></p>
                <div class="form-group mb-4 ">
                        <asp:Label Text="Email adresa " class="label" runat="server" meta:resourcekey="LabelResource3" />
                    <asp:RequiredFieldValidator ErrorMessage="Unos email adrese je obavezan!" ControlToValidate="tbEmail" ForeColor="#293241" CssClass="error" Text="*" runat="server" meta:resourcekey="RequiredFieldValidatorResource1" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                        ControlToValidate="tbEmail" Display="Dynamic"
                        ErrorMessage="Email adresa nije u ispravno upisana!" ForeColor="#293241" CssClass="error"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" meta:resourcekey="RegularExpressionValidator1Resource1">*</asp:RegularExpressionValidator>
                    <asp:TextBox ForeColor="#293241" ID="tbEmail" AutoCompleteType="Disabled" CssClass="form-control" BackColor="#EE6C4D" BorderColor="#293241" TextMode="Email" placeholder="Ime@email.com" runat="server" meta:resourcekey="tbEmailResource1" />
                </div>
                <div class=" form-group mb-4">
                    <label class="label">Lozinka</label>
                    <asp:RequiredFieldValidator ErrorMessage="Unos lozinke je obavezan!" ControlToValidate="tbLozinka" ForeColor="#293241" CssClass="error" Text="*" runat="server" meta:resourcekey="RequiredFieldValidatorResource2" />
                    <asp:TextBox ForeColor="#293241" ID="tbLozinka" AutoCompleteType="Disabled" CssClass="form-control" BackColor="#EE6C4D" BorderColor="#293241" TextMode="Password" placeholder="Lozinka" runat="server" meta:resourcekey="tbLozinkaResource1" />

                </div>
                <asp:CustomValidator ID="CustomValidatorPrijava" runat="server"
                    ClientValidationFunction="UneseniPodaci_Provjera"
                    ControlToValidate="tbLozinka" 
                    ForeColor="#293241" CssClass="error"
                    ErrorMessage="Korisničko ime i lozinka nisu ispravno uneseni"
                    OnServerValidate="CustomValidatorPrijava_ServerValidate" meta:resourcekey="CustomValidatorPrijavaResource1"></asp:CustomValidator>
                <div class=" text-center mb-5">

                    <asp:Button OnClick="BtnPrijaviSe_Click" Text="Prijavi se" ForeColor="#E0FBFC" BorderColor="#293241" BackColor="#293241" CssClass=" btn_custom" runat="server" meta:resourcekey="ButtonResource1" />
                    <div>
                        <asp:ValidationSummary runat="server" class="error" meta:resourcekey="ValidationSummaryResource1" />
                    </div>
                </div>
            </form>
        </div>

        <div class="col-md-4 col-sm-10 center">
            <uc1:Clock runat="server" ID="Clock" />
        </div>
    </div>
</body>
</html>

