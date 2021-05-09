<%@ Page Title="" Language="C#" MasterPageFile="~/ProjektMaster.Master" AutoEventWireup="true" CodeBehind="ProjektUnos.aspx.cs" Inherits="AII.ProjektUnos" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server" class="form_size">
        <div class="form-inline" runat="server">
            <div class="site_description">
                <i class='fas fa-clipboard '></i>
                <asp:Label Text="Unos" runat="server" meta:resourcekey="LabelResource1" />
  
            </div>
            <div>
                <asp:Button Text="Unesi" OnClick="BtnUnesi_Click" class="btn_o" ForeColor="#293241" BackColor="#EE6C4D" BorderColor="#EE6C4D" runat="server" meta:resourcekey="ButtonResource1" />
                <asp:Button Text="Odustani" OnClick="BtnOdustani_Click" CssClass="btn_o" ForeColor="#293241" BackColor="#EE6C4D" BorderColor="#EE6C4D" runat="server" meta:resourcekey="ButtonResource2" />
            </div>
        </div>

        <div class="row position_center">
            <div class="col-md-5 box">
                <div class="boundaries">
                    <div class="position_center"><i class='fas fa-clipboard icon_custom mb-5'></i></div>
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
                    <div class="form-inline">
                        <asp:Label Text="Klijent:"
                            CssClass="label"
                            ForeColor="#EE6C4D"
                            runat="server" meta:resourcekey="LabelResource3" />
                        <asp:DropDownList ID="ddlKlijent"
                            ForeColor="#293241"
                            CssClass="form-control list_podaci flex-fill"
                            BackColor="#E0FBFC"
                            BorderColor="#293241"
                            runat="server"
                            Width="300px" meta:resourcekey="ddlKlijentResource1">
                        </asp:DropDownList>
                    </div>
                    <div class="form-inline">
                        <asp:RequiredFieldValidator ErrorMessage="Datum otvaranja - Obavezno" ControlToValidate="tbDatumOtvaranja" ForeColor="#98C1D9" CssClass="error" Text="*" runat="server" meta:resourcekey="RequiredFieldValidatorResource2" />
                        <asp:Label Text="Datum otvaranja:"
                            CssClass="label"
                            ForeColor="#EE6C4D"
                            runat="server" meta:resourcekey="LabelResource4" />
                        <asp:TextBox ID="tbDatumOtvaranja"
                            TextMode="Date"
                            ForeColor="#293241"
                            CssClass="form-control textbox_podaci flex-fill"
                            BackColor="#E0FBFC"
                            BorderColor="#293241"
                            runat="server" meta:resourcekey="tbDatumOtvaranjaResource1" />
                    </div>
                    <div class="form-inline">
                        <asp:Label Text="Voditelj projekta:"
                            CssClass="label"
                            ForeColor="#EE6C4D"
                            runat="server" meta:resourcekey="LabelResource5" />
                        <asp:DropDownList ID="ddlVoditeljProjekta"
                            ForeColor="#293241"
                            CssClass="form-control list_podaci flex-fill"
                            BackColor="#E0FBFC"
                            BorderColor="#293241"
                            runat="server"
                            Width="300px" meta:resourcekey="ddlVoditeljProjektaResource1">
                        </asp:DropDownList>
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
                    <div class="position_center label"><i class='fas fa-user-circle  icon_projekt'></i>
                        <asp:Label Text="Djelatnik" runat="server" meta:resourcekey="LabelResource6" /></div>

                    <asp:ListBox ID="lbDjelatnik" runat="server" ForeColor="#293241" Rows="7" CssClass="form-control label listbox flex-fill" BackColor="#E0FBFC" meta:resourcekey="lbDjelatnikResource1"></asp:ListBox>
                    <div class="form-inline ">
                        <asp:DropDownList ID="ddlDjelatnici"
                            CssClass="form-control list_podaci  mt-5"
                            ForeColor="#293241"
                            BackColor="#E0FBFC"
                            BorderColor="#293241"
                            runat="server"
                            Width="300px" meta:resourcekey="ddlDjelatniciResource1">
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

    </form>
</asp:Content>
