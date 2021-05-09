<%@ Page Title="" Language="C#" MasterPageFile="~/DjelatnikMaster.Master" AutoEventWireup="true" CodeBehind="DjelatnikPregle.aspx.cs" Inherits="AII.DjelatnikPregle" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

 

<asp:Content ContentPlaceHolderID="content" ID="content1" runat="server">
  
    <form runat="server" class="form_size">
           <div class="form-inline" runat="server">
               <div class="site_description">
                        <i class='fas fa-user-circle'></i>
                   <asp:Label Text="Pregled " runat="server" meta:resourcekey="LabelResource1" />
        <asp:DropDownList ID="ddlDjelatnik" 
             ForeColor="#293241" 
            CssClass="form-control list_podaci ml-5"
            BackColor="#E0FBFC" 
            BorderColor="#293241" 
            runat="server" 
            Width="300px"
       AutoPostBack="True"
            OnSelectedIndexChanged="ddlDjelatnik_SelectedIndexChanged" meta:resourcekey="ddlDjelatnikResource1"
            >
        </asp:DropDownList> 
               </div>
          </div> 

        <div class="row position_center">
            <div class="col-md-5 box">
                <div class="boundaries">
  <div class="position_center"> <i class='fas fa-user-circle icon_custom' ></i> </div> 
                 <div class="form-inline">
                        <asp:Label Text="Ime:"
                            CssClass="label"
                         ForeColor="#EE6C4D"
                            runat="server" meta:resourcekey="LabelResource2" />
                        <asp:Label ID="lblIme"
                            CssClass="content_label"
                            Text="Marta"
                            ForeColor="#E0FBFC"
                            runat="server" meta:resourcekey="lblImeResource1" />
                    </div>
                   <div class="form-inline">
                        <asp:Label Text="Prezime:"
                        CssClass="label"
                            ForeColor="#EE6C4D"
                            runat="server" meta:resourcekey="LabelResource3" />
                        <asp:Label ID="lblPrezime" 
                            Text="Rep"
                            CssClass="content_label"
                            ForeColor="#E0FBFC"
                            runat="server" meta:resourcekey="lblPrezimeResource1" />
                    </div>
                 <div class="form-inline">
                        <asp:Label Text="Email:"
                            CssClass="label"
                         ForeColor="#EE6C4D"
                            runat="server" meta:resourcekey="LabelResource4" />
                        <asp:Label ID="lblEmail"
                            CssClass="content_label"
                            Text="marta@email.com"
                            ForeColor="#E0FBFC"
                            runat="server" meta:resourcekey="lblEmailResource1" />
                    </div>
                   <div class="form-inline">
                        <asp:Label Text="Lozinka:"
                        CssClass="label"
                            ForeColor="#EE6C4D"
                            runat="server" meta:resourcekey="LabelResource5" />
                        <asp:Label ID="lblLozinka" 
                            Text="lozinka123"
                            CssClass="content_label"
                            ForeColor="#E0FBFC"
                            runat="server" meta:resourcekey="lblLozinkaResource1" />
                    </div>
                <div class="form-inline">
                        <asp:Label Text="Datum zaposlenja:"
                        CssClass="label"
                            ForeColor="#EE6C4D"
                            runat="server" meta:resourcekey="LabelResource6" />
                        <asp:Label ID="lblDatumZaposlenja" 
                            Text="01.01.2016"
                            CssClass="content_label"
                            ForeColor="#E0FBFC"
                            runat="server" meta:resourcekey="lblDatumZaposlenjaResource1" />
                    </div>
                <div class="form-inline">
                        <asp:Label Text="Tip djelatnika:"
                        CssClass="label"
                            ForeColor="#EE6C4D"
                            runat="server" meta:resourcekey="LabelResource7" />
                        <asp:Label ID="lblTipDjelatnika" 
                            Text="Zaposlenik"
                            CssClass="content_label"
                            ForeColor="#E0FBFC"
                            runat="server" meta:resourcekey="lblTipDjelatnikaResource1" />
                    </div>
               <div class="form-inline">
                        <asp:Label Text="Tim:"
                        CssClass="label"
                            ForeColor="#EE6C4D"
                            runat="server" meta:resourcekey="LabelResource8" />
                        <asp:Label ID="lblTim" 
                            Text="Tim1"
                            CssClass="content_label"
                            ForeColor="#E0FBFC"
                            runat="server" meta:resourcekey="lblTimResource1" />
                    </div>
                    </div>
            </div>
                 <div class="col-md-1">

                 </div>
             <div class="col-md-5 box">
                 <div class="boundaries">
                        <div class="position_center label"> <i class='fas fa-clipboard  icon_projekt' ></i>  <asp:Label Text="Projekt" runat="server" meta:resourcekey="LabelResource9" /></div>
                 
                 <asp:ListBox id="lbProjekti" runat="server" ForeColor="#E0FBFC"  Rows="10" CssClass="form-control label listbox"  BackColor="#293241" meta:resourcekey="lbProjektiResource1" >
                  
                 </asp:ListBox>
                 
             </div>
                 </div>
                 
              </div>
 

    </form>
 
</asp:Content>