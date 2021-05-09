<%@ Page Title="" Language="C#" MasterPageFile="~/ProjektMaster.Master" AutoEventWireup="true" CodeBehind="ProjektPregled.aspx.cs" Inherits="AII.ProjektPregled" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server" class="form_size">
        <div class="form-inline" runat="server">
            <div class="site_description">
                <i class='fas fa-clipboard '></i>
                <asp:Label Text="Pregled" runat="server" meta:resourcekey="LabelResource1" /> 
        <asp:DropDownList ID="ddlProjekt"
            ForeColor="#293241"
            CssClass="form-control list_podaci ml-5"
            BackColor="#E0FBFC"
            BorderColor="#293241"
            runat="server"
            Width="300px"
            AutoPostBack="True"
            OnSelectedIndexChanged="DdlProjekt_SelectedIndexChanged" meta:resourcekey="ddlProjektResource1">
        </asp:DropDownList>
            </div>
        </div>

        <div class="row position_center">
            <div class="col-md-5 box">
                <div class="boundaries">
                    <div class="position_center"><i class='fas fa-clipboard icon_custom mb-5'></i></div>
                    <div class="form-inline">
                        <asp:Label Text="Naziv:"
                            CssClass="label"
                            ForeColor="#EE6C4D"
                            runat="server" meta:resourcekey="LabelResource2" />
                        <asp:Label ID="lblNaziv"
                            CssClass="content_label"
                            ForeColor="#E0FBFC"
                            runat="server" meta:resourcekey="lblNazivResource1" />
                    </div>
                    <div class="form-inline">
                        <asp:Label Text="Klijent:"
                            CssClass="label"
                            ForeColor="#EE6C4D"
                            runat="server" meta:resourcekey="LabelResource3" />
                        <asp:Label ID="lblKlijent"
                            CssClass="content_label"
                            ForeColor="#E0FBFC"
                            runat="server" meta:resourcekey="lblKlijentResource1" />
                    </div>
                    <div class="form-inline">
                        <asp:Label Text="Datum otvaranja:"
                            CssClass="label"
                            ForeColor="#EE6C4D"
                            runat="server" meta:resourcekey="LabelResource4" />
                        <asp:Label ID="lblDatumOtvaranja"
                            CssClass="content_label"
                            ForeColor="#E0FBFC"
                            runat="server" meta:resourcekey="lblDatumOtvaranjaResource1" />
                    </div>
                    <div class="form-inline">
                        <asp:Label Text="Voditelj projekta:"
                            CssClass="label"
                            ForeColor="#EE6C4D"
                            runat="server" meta:resourcekey="LabelResource5" />
                        <asp:Label ID="lblVoditeljProjekta"
                            CssClass="content_label"
                            ForeColor="#E0FBFC"
                            runat="server" meta:resourcekey="lblVoditeljProjektaResource1" />
                    </div>

                </div>
            </div>
            <div class="col-md-1">
            </div>
            <div class="col-md-5 box">
                <div class="boundaries">
                    <div class="position_center label"><i class='fas fa-user-circle  icon_projekt'></i>
                        <asp:Label Text="Djelatnik" runat="server" meta:resourcekey="LabelResource6" /></div>

                    <asp:ListBox ID="lbDjelatnici" runat="server" ForeColor="#E0FBFC" Rows="10" CssClass="form-control label listbox" BackColor="#293241" meta:resourcekey="lbDjelatniciResource1"></asp:ListBox>

                </div>
            </div>

        </div>


    </form>
</asp:Content>
