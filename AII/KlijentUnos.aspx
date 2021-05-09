<%@ Page Title="" Language="C#" MasterPageFile="~/KlijentMaster.Master" AutoEventWireup="true" CodeBehind="KlijentUnos.aspx.cs" Inherits="AII.KlijentUnos" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <form runat="server" class="form_size">
        <div class="form-inline" runat="server">
            <div class="site_description">
                <i class='far fa-id-card'></i>
                <asp:Label Text="Unos" runat="server" meta:resourcekey="LabelResource1" />
                   <asp:Button Text="Unesi" OnClick="BtnUnesi_Click" class="btn_o" ForeColor="#293241" BackColor="#EE6C4D" BorderColor="#EE6C4D" runat="server" meta:resourcekey="ButtonResource1" />
                <asp:Button Text="Odustani" OnClick="BtnOdustani_Click" CssClass="btn_o" ForeColor="#293241" BackColor="#EE6C4D" BorderColor="#EE6C4D" runat="server" meta:resourcekey="ButtonResource2" />
                <div>
                </div>
            </div>
        </div>
        <div class="row position_center">
            <div class="col-md-5 box">
                <div class="boundaries">
                    <div class="position_center"><i class='far fa-id-card icon_custom mb-5'></i></div>
                    <div class="form-inline">
                         <asp:RequiredFieldValidator ErrorMessage="Naziv - Obavezno" ControlToValidate="tbNaziv" ForeColor="#98C1D9" CssClass="error" Text="*" runat="server" meta:resourcekey="RequiredFieldValidatorResource1" />
                        <asp:Label Text="Naziv:"
                            CssClass="label"
                            ForeColor="#EE6C4D"
                            runat="server" meta:resourcekey="LabelResource2" />
                        <asp:TextBox ID="tbNaziv"
                            ForeColor="#293241"
                            CssClass="form-control textbox_podaci flex-fill"
                            BackColor="#E0FBFC"
                            BorderColor="#293241"
                            runat="server" meta:resourcekey="tbNazivResource1" />
                    </div>
                    <div>
                        <asp:ValidationSummary runat="server" class="error" meta:resourcekey="ValidationSummaryResource1" />
                    </div>
                </div>
            </div>
            <div class="col-md-1">
            </div>
            <div class="col-md-5 box">
                <div class="boundaries">
                    <div class="position_center label"><i class='fas fa-clipboard  icon_projekt'></i>
                        <asp:Label Text="Projekt" runat="server" meta:resourcekey="LabelResource3" /></div>

                    <asp:ListBox ID="lbProjekti" runat="server" ForeColor="#293241" Rows="7" CssClass="form-control label listbox flex-fill" BackColor="#E0FBFC" meta:resourcekey="lbProjektiResource1"></asp:ListBox>


                    <div class="form-inline ">
                        <asp:DropDownList ID="ddlProjekti"
                            CssClass="form-control list_podaci  mt-5"
                            ForeColor="#293241"
                            BackColor="#E0FBFC"
                            BorderColor="#293241"
                            runat="server"
                            Width="300px" meta:resourcekey="ddlProjektiResource1">
                        </asp:DropDownList>
                        <asp:Button Text="Dodaj" OnClick="BtnDodaj_Click" class="btn_o mt-5" ForeColor="#293241" BackColor="#EE6C4D" BorderColor="#EE6C4D" runat="server" meta:resourcekey="ButtonResource3" />

                        <asp:Button Text="Ukloni" OnClick="BtnUkloni_Click" CssClass="btn_o mt-5" ForeColor="#293241" BackColor="#EE6C4D" BorderColor="#EE6C4D" runat="server" meta:resourcekey="ButtonResource4" />
                    </div>
                </div>
            </div>

        </div>
        <asp:ScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" BehaviorID="mpe" runat="server"
            PopupControlID="pnlPopup" TargetControlID="HiddenField1" BackgroundCssClass="modalBackground" CancelControlID="btnNeUnesi" DynamicServicePath="">
        </ajaxToolkit:ModalPopupExtender>

        <asp:Panel ID="pnlPopup" class="popUp_background" runat="server" Style="display: none" meta:resourcekey="pnlPopupResource1">
            <div id="p_header" class="p_header position_center">
                <asp:Label ID="lblheader" runat="server" meta:resourcekey="lblheaderResource1" /></div>
            <div id="p_main" class="p_main position_center">
                <asp:Label ID="lbl_main" runat="server" meta:resourcekey="lbl_mainResource1" />
            </div>
            <div class="position_center pb-3">
                <div>
                    <asp:Button ID="btnDaUnesi" ForeColor="#293241" BackColor="#EE6C4D" BorderColor="#EE6C4D" OnClick="BtnDaUnesi_Click" runat="server" Text="Da" class="btn_o" meta:resourcekey="btnDaUnesiResource1" /></div>
                <div>
                    <asp:Button ID="btnNeUnesi" ForeColor="#293241" BackColor="#EE6C4D" BorderColor="#EE6C4D" runat="server" Text="Ne" class="btn_o" meta:resourcekey="btnNeUnesiResource1" /></div>
            </div>
        </asp:Panel>
        <asp:HiddenField ID="HiddenField2" runat="server" />
        <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender2" BehaviorID="mpe1" runat="server"
            PopupControlID="pnlPopup2" TargetControlID="HiddenField2" BackgroundCssClass="modalBackground" OkControlID="btnOk" DynamicServicePath="">
        </ajaxToolkit:ModalPopupExtender>

        <asp:Panel ID="pnlPopup2" class="popUp_background" runat="server" Style="display: none" meta:resourcekey="pnlPopup2Resource1">
            <div id="p_h" class="p_header position_center">
                <asp:Label ID="Label1" Text="Pogreška!" runat="server" meta:resourcekey="Label1Resource1" /></div>
            <div id="p_m" class="p_main position_center">
                <asp:Label ID="Label2" Text="Potrebno je unijeti djelatnika kako bi mu pridružili projekte" runat="server" meta:resourcekey="Label2Resource1" />
            </div>
            <div class="position_center pb-3">
                <div>
                    <asp:Button ID="btnOk" ForeColor="#293241" BackColor="#EE6C4D" BorderColor="#EE6C4D" runat="server" Text="Ok" class="btn_o" meta:resourcekey="btnOkResource1" /></div>
            </div>
        </asp:Panel>

    </form>

</asp:Content>
