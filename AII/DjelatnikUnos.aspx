<%@ Page Title="" Language="C#" MasterPageFile="~/DjelatnikMaster.Master" AutoEventWireup="true" CodeBehind="DjelatnikUnos.aspx.cs" Inherits="AII.DjelatnikUnos" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>


<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <form runat="server" class="form_size">
        <div class="form-inline" runat="server">
            <div class="site_description">
                <i class='fas fa-user-circle'></i>
                <asp:Label Text="Unos" runat="server" meta:resourcekey="LabelResource1" />
            </div>

            <div>

                <asp:Button Text="Unesi" class="btn_o" ForeColor="#293241" BackColor="#EE6C4D" BorderColor="#EE6C4D" ID="BtnUnesi" OnClick="BtnUnesi_Click" runat="server" meta:resourcekey="BtnUnesiResource1" />

                <asp:Button Text="Odustani" CssClass="btn_o" ForeColor="#293241" BackColor="#EE6C4D" BorderColor="#EE6C4D" ID="BtnOdustani" OnClick="BtnOdustani_Click" runat="server" meta:resourcekey="BtnOdustaniResource1" />


            </div>

        </div>

        <div class="row position_center">
            <div class="col-md-5 box">
                <div class="boundaries">
                    <div class="position_center"><i class='fas fa-user-circle icon_custom'></i></div>
                    <div class="form-inline ">
                        <asp:RequiredFieldValidator ErrorMessage="Ime - Obavezno" ControlToValidate="tbIme" ForeColor="#98C1D9" CssClass="error" Text="*" runat="server" meta:resourcekey="RequiredFieldValidatorResource1" />
                        <asp:Label Text="Ime:"
                            CssClass="label"
                            ForeColor="#EE6C4D"
                            runat="server" meta:resourcekey="LabelResource2" />
                        <asp:TextBox ID="tbIme"
                            ForeColor="#293241"
                            CssClass="form-control textbox_podaci flex-fill"
                            BackColor="#E0FBFC"
                            BorderColor="#293241"
                            runat="server" meta:resourcekey="tbImeResource1"></asp:TextBox>
                    </div>
                    <div class="form-inline">
                        <asp:RequiredFieldValidator ErrorMessage="Prezime - Obavezno" ControlToValidate="tbPrezime" ForeColor="#98C1D9" CssClass="error" Text="*" runat="server" meta:resourcekey="RequiredFieldValidatorResource2" />
                        <asp:Label Text="Prezime:"
                            CssClass="label"
                            ForeColor="#EE6C4D"
                            runat="server" meta:resourcekey="LabelResource3" />
                        <asp:TextBox ID="tbPrezime"
                            ForeColor="#293241"
                            CssClass="form-control textbox_podaci flex-fill"
                            BackColor="#E0FBFC"
                            BorderColor="#293241"
                            runat="server" meta:resourcekey="tbPrezimeResource1"></asp:TextBox>
                    </div>
                    <div class="form-inline">
                        <asp:RequiredFieldValidator ErrorMessage="Email adresa - Obavezno" ControlToValidate="tbEmail" ForeColor="#98C1D9" CssClass="error" Text="*" runat="server" meta:resourcekey="RequiredFieldValidatorResource3" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                            ControlToValidate="tbEmail" Display="Dynamic"
                            ErrorMessage="Email adresa nije u ispravno upisana!" ForeColor="#E0FBFC" CssClass="error"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" meta:resourcekey="RegularExpressionValidator1Resource1">*</asp:RegularExpressionValidator>
                        <asp:Label Text="Email:"
                            CssClass="label"
                            ForeColor="#EE6C4D"
                            runat="server" meta:resourcekey="LabelResource4" />
                        <asp:TextBox ID="tbEmail"
                            ForeColor="#293241"
                            CssClass="form-control textbox_podaci flex-fill"
                            BackColor="#E0FBFC"
                            BorderColor="#293241"
                            runat="server" meta:resourcekey="tbEmailResource1"></asp:TextBox>
                    </div>
                    <div class="form-inline">
                        <asp:RequiredFieldValidator ErrorMessage="Lozinka- Obavezno" ControlToValidate="tbLozinka" ForeColor="#98C1D9" CssClass="error" Text="*" runat="server" meta:resourcekey="RequiredFieldValidatorResource4" />
                        <asp:Label Text="Lozinka:"
                            CssClass="label"
                            ForeColor="#EE6C4D"
                            runat="server" meta:resourcekey="LabelResource5" />
                        <asp:TextBox ID="tbLozinka"
                            ForeColor="#293241"
                            CssClass="form-control textbox_podaci flex-fill"
                            BackColor="#E0FBFC"
                            BorderColor="#293241"
                            runat="server" meta:resourcekey="tbLozinkaResource1"></asp:TextBox>
                    </div>
                    <div class="form-inline">
                        <asp:RequiredFieldValidator ErrorMessage="Datum zaposlenja - Obavezno" ControlToValidate="tbDatumZaposlenja" ForeColor="#98C1D9" CssClass="error" Text="*" runat="server" meta:resourcekey="RequiredFieldValidatorResource5" />
                        <asp:Label Text="Datum zaposlenja:"
                            CssClass="label"
                            ForeColor="#EE6C4D"
                            runat="server" meta:resourcekey="LabelResource6" />
                        <asp:TextBox ID="tbDatumZaposlenja"
                            TextMode="Date"
                            ForeColor="#293241"
                            CssClass="form-control textbox_podaci flex-fill"
                            BackColor="#E0FBFC"
                            BorderColor="#293241"
                            runat="server" meta:resourcekey="tbDatumZaposlenjaResource1"></asp:TextBox>
                    </div>
                    <div class="form-inline">
                        <asp:Label Text="Tip djelatnika:"
                            CssClass="label"
                            ForeColor="#EE6C4D"
                            runat="server" meta:resourcekey="LabelResource7" />
                        <asp:DropDownList ID="ddlTipDjelatnika"
                            ForeColor="#293241"
                            CssClass="form-control list_podaci flex-fill"
                            BackColor="#E0FBFC"
                            BorderColor="#293241"
                            runat="server"
                            Width="300px" meta:resourcekey="ddlTipDjelatnikaResource1">
                        </asp:DropDownList>
                    </div>
                    <div class="form-inline">
                        <asp:Label Text="Tim:"
                            CssClass="label"
                            ForeColor="#EE6C4D"
                            runat="server" meta:resourcekey="LabelResource8" />
                        <asp:DropDownList ID="ddlTim"
                            ForeColor="#293241"
                            CssClass="form-control list_podaci flex-fill"
                            BackColor="#E0FBFC"
                            BorderColor="#293241"
                            runat="server"
                            Width="300px" meta:resourcekey="ddlTimResource1">
                        </asp:DropDownList>
                    </div>
                    <div>
                        <asp:ValidationSummary Height="130px" runat="server" class="error" meta:resourcekey="ValidationSummaryResource1" />
                    </div>
                </div>

            </div>
            <div class="col-md-1">
            </div>
            <div class="col-md-5 box">
                <div class="boundaries">
                    <div class="position_center label"><i class='fas fa-clipboard  icon_projekt'></i>
                        <asp:Label Text="Projekt" runat="server" meta:resourcekey="LabelResource9" /></div>

                    <asp:ListBox ID="lbProjekti" runat="server" ForeColor="#293241" Rows="6" CssClass="form-control label listbox flex-fill" BackColor="#E0FBFC" meta:resourcekey="lbProjektiResource1"></asp:ListBox>

                    <div class="form-inline ">
                        <asp:DropDownList ID="ddlProjekti"
                            CssClass="form-control list_podaci  mt-5"
                            ForeColor="#293241"
                            BackColor="#E0FBFC"
                            BorderColor="#293241"
                            runat="server"
                            Width="300px" meta:resourcekey="ddlProjektiResource1">
                        </asp:DropDownList>
                        <asp:Button Text="Dodaj" ID="BtnDodaj" OnClick="BtnDodaj_Click" class="btn_o mt-5" ForeColor="#293241" BackColor="#EE6C4D" BorderColor="#EE6C4D" runat="server" meta:resourcekey="BtnDodajResource1" />

                        <asp:Button Text="Ukloni" ID="BtnUkloni" OnClick="BtnUkloni_Click" CssClass="btn_o mt-5" ForeColor="#293241" BackColor="#EE6C4D" BorderColor="#EE6C4D" runat="server" meta:resourcekey="BtnUkloniResource1" />
                    </div>
                </div>
            </div>

        </div>
        <asp:ScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" BehaviorID="mpe" runat="server"
            PopupControlID="pnlPopup" TargetControlID="HiddenField1" BackgroundCssClass="modalBackground" CancelControlID="btnNeUnesi">
        </ajaxToolkit:ModalPopupExtender>

        <asp:Panel ID="pnlPopup" class="popUp_background" runat="server" Style="display: none" meta:resourcekey="pnlPopupResource1">
            <div id="p_header" class="p_header position_center">
                <asp:Label ID="lblheader" runat="server" meta:resourcekey="lblheaderResource1" />
            </div>
            <div id="p_main" class="p_main position_center">
                <asp:Label ID="lbl_main" runat="server" meta:resourcekey="lbl_mainResource1" />
            </div>
            <div class="position_center pb-3">
                <div>
                    <asp:Button ID="btnDaUnesi" ForeColor="#293241" BackColor="#EE6C4D" BorderColor="#EE6C4D" OnClick="BtnDaUnesi_Click" runat="server" Text="Da" class="btn_o" meta:resourcekey="btnDaUnesiResource1" />
                </div>
                <div>
                    <asp:Button ID="btnNeUnesi" ForeColor="#293241" BackColor="#EE6C4D" BorderColor="#EE6C4D" runat="server" Text="Ne" class="btn_o" meta:resourcekey="btnNeUnesiResource1" />
                </div>
            </div>
        </asp:Panel>


    </form>

</asp:Content>
