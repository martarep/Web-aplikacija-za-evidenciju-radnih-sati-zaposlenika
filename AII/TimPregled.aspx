<%@ Page Title="" Language="C#" MasterPageFile="~/TimMaster.Master" AutoEventWireup="true" CodeBehind="TimPregled.aspx.cs" Inherits="AII.TimPregled" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>





<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <form runat="server" class="form_size">
        <div class="form-inline" runat="server">
            <div class="site_description">
                <i class='fas fa-users'></i>
                <asp:Label Text="Pregled" runat="server" meta:resourcekey="LabelResource1" />
                             <asp:DropDownList ID="ddlTim"
                                 ForeColor="#293241"
                                 CssClass="form-control list_podaci mb-3 ml-4"
                                 BackColor="#E0FBFC"
                                 BorderColor="#293241"
                                 runat="server"
                                 Width="300px"
                                 AutoPostBack="True"
                                 OnSelectedIndexChanged="DdlTim_SelectedIndexChanged" meta:resourcekey="ddlTimResource1">
                             </asp:DropDownList>
            </div>
        </div>
        
        <div class="row position_center">
            <div class="col-md-5 box">
                <div class="boundaries">



                    <div class="position_center"><i class='fas fa-users icon_custom mb-5'></i></div>
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
                        <asp:Label Text="Voditelj tima:"
                            CssClass="label"
                            ForeColor="#EE6C4D"
                            runat="server" meta:resourcekey="LabelResource3" />
                        <asp:Label ID="lblVoditelj"
                            CssClass="content_label"
                            ForeColor="#E0FBFC"
                            runat="server" meta:resourcekey="lblVoditeljResource1" />
                    </div>
                    <div class="form-inline">
                        <asp:Label Text="Datum kreiranja:"
                            CssClass="label"
                            ForeColor="#EE6C4D"
                            runat="server" meta:resourcekey="LabelResource4" />
                        <asp:Label ID="lblDatumKreiranja"
                            CssClass="content_label"
                            Text="22.02.2020"
                            ForeColor="#E0FBFC"
                            runat="server" meta:resourcekey="lblDatumKreiranjaResource1" />
                    </div>

                </div>
            </div>
            <div class="col-md-1">
            </div>
            <div class="col-md-5 box">
                <div class="boundaries">
                    <div class="position_center label"><i class='fas fa-user-circle  icon_projekt'></i>
                        <asp:Label Text="Djelatnik" runat="server" meta:resourcekey="LabelResource5" /> </div>

                    <asp:ListBox ID="lbClanoviTima" runat="server" ForeColor="#E0FBFC" Rows="10" CssClass="form-control label listbox" BackColor="#293241" meta:resourcekey="lbClanoviTimaResource1"></asp:ListBox>

                </div>
            </div>
        </div>


    </form>


</asp:Content>
