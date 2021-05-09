<%@ Page Title="" Language="C#" MasterPageFile="~/KlijentMaster.Master" AutoEventWireup="true" CodeBehind="KlijentPregled.aspx.cs" Inherits="AII.KlijentPregled" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <form runat="server" class="form_size">
        <div class="form-inline" runat="server">
            <div class="site_description">
                <i class='far fa-id-card'></i>
                <asp:Label Text="Pregled" runat="server" meta:resourcekey="LabelResource1" />
                             <asp:DropDownList ID="ddlKlijent"
                                 ForeColor="#293241"
                                 CssClass="form-control list_podaci mb-3 ml-4"
                                 BackColor="#E0FBFC"
                                 BorderColor="#293241"
                                 runat="server"
                                 Width="300px"
                                 AutoPostBack="True"
                                 OnSelectedIndexChanged="DdlKlijent_SelectedIndexChanged" meta:resourcekey="ddlKlijentResource1">
                             </asp:DropDownList>
            </div>
        </div>

        <div class="row position_center">
            <div class="col-md-5 box">
                <div class="boundaries">



                    <div class="position_center"><i class='far fa-id-card icon_custom mb-5'></i></div>
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

                </div>
            </div>
            <div class="col-md-1">
            </div>
            <div class="col-md-5 box">
                <div class="boundaries">
                    <div class="position_center label"><i class='fas fa-clipboard  icon_projekt'></i>
                        <asp:Label Text="Projekt" runat="server" meta:resourcekey="LabelResource3" /> </div>

                    <asp:ListBox ID="lbProjekti" runat="server" ForeColor="#E0FBFC" Rows="10" CssClass="form-control label listbox" BackColor="#293241" meta:resourcekey="lbProjektiResource1"></asp:ListBox>

                </div>
            </div>
        </div>


    </form>


</asp:Content>
