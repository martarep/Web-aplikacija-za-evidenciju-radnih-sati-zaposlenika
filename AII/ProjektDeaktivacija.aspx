<%@ Page Title="" Language="C#" MasterPageFile="~/ProjektMaster.Master" AutoEventWireup="true" CodeBehind="ProjektDeaktivacija.aspx.cs" Inherits="AII.ProjektDeaktivacija" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server" class="form_size">
        <div class="form-inline" runat="server">
            <div class="site_description">
                <i class='fas fa-clipboard '></i>
                <asp:Label Text="Deaktivacija" runat="server" meta:resourcekey="LabelResource1" />
                    <asp:DropDownList ID="ddlProjekt"
                        ForeColor="#293241"
                        CssClass="form-control list_podaci mb-3 ml-4"
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
            <div class="col-md-11 box position_center">
                <div class="boundaries_fp">
                    <div class="position_center">
                        <asp:Label
                            ID="lblAktivan"
                            CssClass="label"
                            ForeColor="#EE6C4D"
                            runat="server" meta:resourcekey="lblAktivanResource1" />
                    </div>
                    <div class="position_center">
                        <asp:Button ID="btnDeAktiviraj" OnClick="BtnDeAktiviraj_Click" Text="Aktiviraj" CssClass="btn_o" ForeColor="#293241" BackColor="#EE6C4D" BorderColor="#EE6C4D" runat="server" meta:resourcekey="btnDeAktivirajResource1" />

                    </div>
                </div>
            </div>
        </div>
        <asp:ScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" BehaviorID="mpe" runat="server"
            PopupControlID="pnlPopup" TargetControlID="HiddenField1" BackgroundCssClass="modalBackground" CancelControlID="btnNe" DynamicServicePath="">
        </ajaxToolkit:ModalPopupExtender>

        <asp:Panel ID="pnlPopup" class="popUp_background" runat="server" Style="display: none" meta:resourcekey="pnlPopupResource1">
            <div id="p_header" class="p_header position_center">
                <asp:Label ID="lblheader" runat="server" meta:resourcekey="lblheaderResource1" /></div>
            <div id="p_main" class="p_main position_center">
                <asp:Label ID="lbl_main" runat="server" meta:resourcekey="lbl_mainResource1" />
            </div>
            <div class="position_center pb-3">
                <div>
                    <asp:Button ID="btnDaDeaktiviraj" ForeColor="#293241" BackColor="#EE6C4D" BorderColor="#EE6C4D" OnClick="BtnDaDeaktiviraj_Click" runat="server" Text="Da" class="btn_o" meta:resourcekey="btnDaDeaktivirajResource1" /></div>
                <div>
                    <asp:Button ID="btnNe" ForeColor="#293241" BackColor="#EE6C4D" BorderColor="#EE6C4D" runat="server" Text="Ne" class="btn_o" meta:resourcekey="btnNeResource1" /></div>
            </div>
        </asp:Panel>

    </form>
</asp:Content>
