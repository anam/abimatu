<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMaster.master" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" Runat="Server">
<asp:GridView ID="gvTRANS" runat="server" CssClass="innergrid" BorderStyle="None" GridLines="None" AutoGenerateColumns="false" ShowHeader="true">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Transaction Date" ControlStyle-Width="150px">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTransactionDate"  Font-Bold="false" runat="server" Text='<%#Eval("CREATEDON","{0:MM/dd/yyyy}") %>'>
                                                                        </asp:Label>
                                                  
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                <asp:TemplateField HeaderText="Reference Code" ControlStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblReferenceCode"  Font-Bold="false" runat="server" Text='<%#Eval("REFCODE") %>'>
                                                                        </asp:Label>
                                                   
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Amount" ControlStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSendingAmount"  Font-Bold="false" runat="server" Text='<%#Eval("TRANSAMOUNT","{0:C}") %>'>
                                                                        </asp:Label>
                                                   
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Fees" ControlStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblServiceCharge"  Font-Bold="false" runat="server" Text='<%#Eval("TRANSFEES","{0 :C}") %>'>
                                                                        </asp:Label>
                                                   
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Discount" ControlStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDiscount"  Font-Bold="false" runat="server" Text='<%#Eval("TRANSPROMO","{0 :C}") %>'>
                                                                        </asp:Label>
                                                   
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Total Amount" ControlStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTotalCharge"  Font-Bold="false" runat="server" Text='<%#Eval("TRANSTOTALAMOUNT","{0 :C}") %>'>
                                                                        </asp:Label>
                                                   
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                    </Columns>
                                                    <HeaderStyle BackColor="#AFA582" Font-Bold="True" ForeColor="White" CssClass="gridHeaderClass" />
                                                </asp:GridView>
</asp:Content>

