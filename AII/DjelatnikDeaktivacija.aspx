<%@ Page Title="" Language="C#" MasterPageFile="~/DjelatnikMaster.Master" AutoEventWireup="true" CodeBehind="DjelatnikDeaktivacija.aspx.cs" Inherits="AII.DjelatnikDeaktivacija" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">

 <form runat="server" class="form_size">
           <div class="form-inline" runat="server">
               <div class="site_description">
                        <i class='fas fa-user-circle'></i>
                   <asp:Label Text="Deaktivacija" runat="server" meta:resourcekey="LabelResource1" />
                             <asp:DropDownList ID="ddlDjelatnik" 
             ForeColor="#293241" 
            CssClass="form-control list_podaci mb-3 ml-4"
            BackColor="#E0FBFC" 
            BorderColor="#293241" 
            runat="server" 
            Width="300px" AutoPostBack="True" OnSelectedIndexChanged="DdlDjelatnik_SelectedIndexChanged" meta:resourcekey="ddlDjelatnikResource1">
        </asp:DropDownList> 
               </div>
          </div> 

        <div class="row position_center">
            <div class="col-md-11 box position_center">
               <div class="boundaries_fp">

                   

<div class="position_center"> <asp:Label
    ID="lblAktivan"
                            CssClass="label"
                         ForeColor="#EE6C4D"
                            runat="server" meta:resourcekey="lblAktivanResource1" /> </div> 

                  <div class="position_center">
                       <asp:Button ID="btnDeAktiviraj"  OnClick="BtnDeAktiviraj_Click"  CssClass="btn_o" ForeColor="#293241" BackColor="#EE6C4D" BorderColor="#EE6C4D"   runat="server" meta:resourcekey="btnDeAktivirajResource1" />

                  </div>
               
                    </div>
            </div>

        </div>
   <asp:ScriptManager ID="ToolkitScriptManager1" runat="server">
</asp:ScriptManager>
                   <asp:HiddenField ID="HiddenField1" runat="server" />
                    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" BehaviorID="mpe" runat="server"
    PopupControlID="pnlPopup" TargetControlID="HiddenField1" BackgroundCssClass="modalBackground" CancelControlID = "btnNeSpremi" DynamicServicePath="" 
                       ></ajaxToolkit:ModalPopupExtender>

<asp:Panel id="pnlPopup" class="popUp_background" runat="server" Style="display: none" meta:resourcekey="pnlPopupResource1">
     <div id="p_header" class="p_header position_center"> <asp:Label id="lblheader" runat="server" meta:resourcekey="lblheaderResource1" /></div>
     <div id="p_main" class="p_main position_center">
         <asp:Label id="lbl_main" runat="server" meta:resourcekey="lbl_mainResource1" /></div>
     <div class="position_center pb-3">
          <div ><asp:Button id="BtnDaSpremi" ForeColor="#293241" BackColor="#EE6C4D" BorderColor="#EE6C4D" OnClick="BtnDaSpremi_Click" runat="server" text="Da" class="btn_o" meta:resourcekey="BtnDaSpremiResource1" /></div>
          <div ><asp:Button id="BtnNeSpremi"  ForeColor="#293241" BackColor="#EE6C4D" BorderColor="#EE6C4D"  runat="server" text="Ne"  class="btn_o" meta:resourcekey="BtnNeSpremiResource1"  /></div>
     </div>
</asp:Panel>

    </form>





</asp:Content>
