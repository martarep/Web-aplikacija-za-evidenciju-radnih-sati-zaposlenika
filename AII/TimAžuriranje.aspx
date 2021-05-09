<%@ Page Title="" Language="C#" MasterPageFile="~/TimMaster.Master" AutoEventWireup="true" CodeBehind="TimAžuriranje.aspx.cs" Inherits="AII.TimAžuriranje" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>




<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <form runat="server" class="form_size">
        <div class="form-inline" runat="server">
            <div class="site_description">
                <i class='fas fa-users'></i>
                <asp:Label Text="Ažuriranje" runat="server" meta:resourcekey="LabelResource1" />
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
            <div>
                <asp:Button Text="Spremi" OnClick="BtnSpremi_Click" class="btn_o" ForeColor="#293241" BackColor="#EE6C4D" BorderColor="#EE6C4D" runat="server" meta:resourcekey="ButtonResource1" />

                <asp:Button Text="Odustani" OnClick="BtnOdustani_Click" CssClass="btn_o" ForeColor="#293241" BackColor="#EE6C4D" BorderColor="#EE6C4D" runat="server" meta:resourcekey="ButtonResource2" />

            </div>
        </div>

        <div class="row position_center">
            <div class="col-md-5 box">
                <div class="boundaries">



                    <div class="position_center"><i class='fas fa-users icon_custom mb-5'></i></div>
                    <div class="form-inline">
                        <asp:RequiredFieldValidator ErrorMessage="Naziv - Obavezno" ControlToValidate="tbNaziv" ForeColor="#98C1D9" CssClass="error" Text="*" runat="server" meta:resourcekey="RequiredFieldValidatorResource1" />
                        <asp:Label Text="Naziv:"
                            CssClass="label"
                            ForeColor="#EE6C4D"
                            runat="server" meta:resourcekey="LabelResource2" />
                        <asp:TextBox ID="tbNaziv"
                            Text="Tim 1"
                            ForeColor="#293241"
                            CssClass="form-control textbox_podaci flex-fill"
                            BackColor="#E0FBFC"
                            BorderColor="#293241"
                            runat="server" meta:resourcekey="tbNazivResource1" />
                    </div>
                    <div class="form-inline">
                        <asp:Label Text="Voditelj tima:"
                            CssClass="label"
                            ForeColor="#EE6C4D"
                            runat="server" meta:resourcekey="LabelResource3" />
                        <asp:DropDownList ID="ddlVoditeljTima"
                            ForeColor="#293241"
                            CssClass="form-control list_podaci flex-fill"
                            BackColor="#E0FBFC"
                            BorderColor="#293241"
                            runat="server"
                            Width="300px" meta:resourcekey="ddlVoditeljTimaResource1">
                        </asp:DropDownList>
                    </div>
                    <div class="form-inline">
                        <asp:RequiredFieldValidator ErrorMessage="Datum kreiranja - Obavezno" ControlToValidate="tbDatumKreiranja" ForeColor="#98C1D9" CssClass="error" Text="*" runat="server" meta:resourcekey="RequiredFieldValidatorResource2" />
                        <asp:Label Text="Datum kreiranja:"
                            CssClass="label"
                            ForeColor="#EE6C4D"
                            runat="server" meta:resourcekey="LabelResource4" />
                        <asp:TextBox ID="tbDatumKreiranja"
                            TextMode="Date"
                            ForeColor="#293241"
                            CssClass="form-control textbox_podaci flex-fill"
                            BackColor="#E0FBFC"
                            BorderColor="#293241"
                            runat="server" meta:resourcekey="tbDatumKreiranjaResource1" />
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
                        <asp:Label Text="Djelatnici" runat="server" meta:resourcekey="LabelResource5" /></div>

                    <asp:ListBox ID="lbDjelatnici" runat="server" ForeColor="#293241" Rows="7" CssClass="form-control label listbox flex-fill" BackColor="#E0FBFC" meta:resourcekey="lbDjelatniciResource1"></asp:ListBox>

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
            PopupControlID="pnlPopup" TargetControlID="HiddenField1" BackgroundCssClass="modalBackground" CancelControlID="btnNeSpremi" DynamicServicePath="">
        </ajaxToolkit:ModalPopupExtender>

        <asp:Panel ID="pnlPopup" class="popUp_background" runat="server" Style="display: none" meta:resourcekey="pnlPopupResource1">
            <div id="p_header" class="p_header position_center">
                <asp:Label ID="lblheader" runat="server" meta:resourcekey="lblheaderResource1" /></div>
            <div id="p_main" class="p_main position_center">
                <asp:Label ID="lbl_main" runat="server" meta:resourcekey="lbl_mainResource1" />
            </div>
            <div class="position_center pb-3">
                <div>
                    <asp:Button ID="BtnDaSpremi" ForeColor="#293241" BackColor="#EE6C4D" BorderColor="#EE6C4D" OnClick="BtnDaSpremi_Click" runat="server" Text="Da" class="btn_o" meta:resourcekey="BtnDaSpremiResource1" /></div>
                <div>
                    <asp:Button ID="BtnNeSpremi" ForeColor="#293241" BackColor="#EE6C4D" BorderColor="#EE6C4D" runat="server" Text="Ne" class="btn_o" meta:resourcekey="BtnNeSpremiResource1" /></div>
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
                <asp:Label ID="Label2" Text="Nije moguće ukloniti postojećeg djelatnika!" runat="server" meta:resourcekey="Label2Resource1" />
            </div>
            <div class="position_center pb-3">
                <div>
                    <asp:Button ID="btnOk" ForeColor="#293241" BackColor="#EE6C4D" BorderColor="#EE6C4D" runat="server" Text="Ok" class="btn_o" meta:resourcekey="btnOkResource1" /></div>
            </div>
        </asp:Panel>


    </form>
</asp:Content>
