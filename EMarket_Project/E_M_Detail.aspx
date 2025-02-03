<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="E_M_Detail.aspx.cs" Inherits="EMarket_Project.E_M_Detail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body {
            margin: 100px;
            padding: 100px;
            background-color: bisque;
        }

        h3 {
            background-color: deeppink;
            color: white;
        }

        #form {
            border: 2px solid;
        }

        #tblsubyard, #tblsubyard th, #tblsubyard td {
            border: 1px solid;
            text-align: center;
        }

        .auto-style2 {
            width: 1610px;
        }




        .auto-style4 {
            width: 445px;
            height: 16px;
        }




        .auto-style5 {
            width: 5px;
            height: 16px;
        }




        .auto-style10 {
            width: 569px;
        }

        #btnSubmit {
            background-color: forestgreen;
            color: white;
            border: none;
            padding: 5px 10px;
            text-align: center;
            font-size: 20px;
            margin: 4px 2px;
            border-radius: 15px;
        }

        button:hover {
            background-color: darkolivegreen;
        }

        #btnCancel {
            background-color: brown;
            color: white;
            border: none;
            padding: 5px 10px;
            text-align: center;
            font-size: 20px;
            margin: 4px 2px;
            border-radius: 15px;
        }


        #Button1 {
            background-color: forestgreen;
            color: white;
            border: none;
            padding: 5px 10px;
            text-align: center;
            font-size: 17px;
            margin: 4px 2px;
            border-radius: 15px;
        }

        #Button2 {
            background-color: brown;
            color: white;
            border: none;
            padding: 5px 10px;
            text-align: center;
            font-size: 17px;
            margin: 4px 2px;
            border-radius: 15px;
        }

        .update {
            background-color: dodgerblue;
            color: white;
            border: none;
            padding: 10px 20px;
            text-align: center;
            font-size: 15px;
            margin: 4px 2px;
            border-radius: 10px;
        }

        .cancel {
            background-color: brown;
            color: white;
            border: none;
            padding: 10px 20px;
            text-align: center;
            font-size: 15px;
            margin: 4px 2px;
            border-radius: 10px;
        }

        #Market {
            text-align: center;
            font-size: 28px;
        }


        #inpform {
            border: 1px solid;
        }

        h3 {
            text-align: center;
            font-size: 28px;
        }

        h4 {
            text-align: center;
            font-size: 28px;
            color: black;
        }

        .blue-text {
            color: blue;
            font-weight: bold;
        }

        .auto-style12 {
            width: 406px;
            height: 16px;
        }

        .auto-style13 {
            width: 406px;
        }

        .auto-style14 {
            width: 445px;
        }

        #subyards {
            border: 2px solid;
            margin-left: 20px;
            padding-left: 20px;
            color: black
        }

        .ChildGrid {
            border: 2px solid;
            margin-left: 20px;
            padding-left: 70px;
            color: black;
            text-align: center;
        }

            .ChildGrid th {
                border: 1px;
            }

            .ChildGrid tr {
                border: 1px;
            }

            .ChildGrid td {
                border: 1px
            }


       
    </style>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />

    <script>
        function showYardTable() {
            document.getElementById('DisplayGrid').style.display = 'block';
        }
    </script>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            $(document).on("click", "[src*=Plus]", function () {
                var $currentRow = $(this).closest("tr");
                var $detailsContent = $currentRow.find("[id*=subyadrdata]").html();
                $currentRow.after("<tr class='child-row'><td colspan='999'>" + $detailsContent + "</td></tr>");


                $currentRow.find("[src*=minus]").show();
                $(this).hide();
            });
            $(document).on("click", "[src*=Minus]", function () {
                var $currentRow = $(this).closest("tr");
                $currentRow.next(".child-row").remove();
                $currentRow.find("[src*=plus]").show();
                $(this).hide();
            });
        });
</script>

</head>

<body>
    <div id="form">
        <form id="form1" runat="server">
            <div>

                <h4>
                    <asp:Image ID="Govtlogo" runat="server" ImageUrl="~/Logo/LogoTS1.png" Width="80px" Height="75px" />
                    &nbsp; &nbsp;<b>Government Of India</b>


                </h4>


                <h3 id="Market"><b>Market</b> </h3>
                <div id="inpform">
                    <table>
                        
                        <tr>
                            <td class="auto-style13"><b>District :</b>  </td>
                            
                            <td class="auto-style6">
                                <asp:DropDownList ID="DropDownDistrict" runat="server" OnSelectedIndexChanged="DropDownDistrict_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList>
                                <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                                <asp:RequiredFieldValidator
                                    ID="rfvDropDownDistrict"
                                    runat="server"
                                    ControlToValidate="DropDownDistrict"
                                    InitialValue=""
                                    ErrorMessage="Please select a district."
                                    ForeColor="Red" Display="Dynamic" ValidationGroup="Validation">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style13"><b>Code :</b>
                                <td class="auto-style14">
                                    <asp:TextBox ID="txtCode" runat="server" placeholder="Enter Code"></asp:TextBox>
                                    <asp:RequiredFieldValidator
                                        ID="rfvDropDownDistrict0"
                                        runat="server"
                                        ControlToValidate="txtCode"
                                        InitialValue=""
                                        ErrorMessage="Please Enter code"
                                        ForeColor="Red" Display="Dynamic" ValidationGroup="Validation">*</asp:RequiredFieldValidator>
                                </td>
                        </tr>
                        <tr>
                            <td class="auto-style12"><b>MarketName :</b> </td>
                            <td class="auto-style4">
                                <asp:TextBox ID="txtMarketN" runat="server" placeholder="Enter Market Name"></asp:TextBox>
                                <asp:RequiredFieldValidator
                                    ID="rfvDropDownDistrict1"
                                    runat="server"
                                    ControlToValidate="txtMarketN"
                                    InitialValue=""
                                    ErrorMessage="Please Enter Marketname"
                                    ForeColor="Red" Display="Dynamic" ValidationGroup="Validation">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>

                        <tr>
                            <td class="auto-style13"><b>Address :</b> &nbsp;&nbsp;&nbsp; </td>
                            <td class="auto-style14">
                                <asp:TextBox ID="txtAddress" runat="server" placeholder="Enter Address"></asp:TextBox>
                                <asp:RequiredFieldValidator
                                    ID="rfvDropDownDistrict2"
                                    runat="server"
                                    ControlToValidate="txtAddress"
                                    InitialValue=""
                                    ErrorMessage="Please EnterAddress"
                                    ForeColor="Red" Display="Dynamic" ValidationGroup="Validation">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style13"><b>Email :</b> </td>
                            <td class="auto-style14">
                                <asp:TextBox ID="txtEmail" runat="server" OnTextChanged="txtEmail_TextChanged" AutoPostBack="True" placeholder="Enter Email"></asp:TextBox>
                                <asp:Label ID="lblEmailError" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                                <asp:RequiredFieldValidator
                                    ID="rfvDropDownDistrict3"
                                    runat="server"
                                    ControlToValidate="txtEmail"
                                    InitialValue=""
                                    ErrorMessage="Please enter email."
                                    ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="Validation">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator
                                    ID="RegularExpressionValidator1"
                                    runat="server"
                                    ControlToValidate="txtEmail"
                                    ErrorMessage="Please enter a valid email address."
                                    ForeColor="Red"
                                    Display="Dynamic"
                                    ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" ValidationGroup="Validation">*</asp:RegularExpressionValidator>
                            </td>
                        </tr>

                        <tr>
                            <td class="auto-style13"><b>Account No :</b> </td>
                            <td class="auto-style14">
                                <asp:TextBox ID="txtAccountNo" runat="server" placeholder="Enter Your Account No"></asp:TextBox>
                                <asp:RequiredFieldValidator
                                    ID="rfvDropDownDistrict4"
                                    runat="server"
                                    ControlToValidate="txtAccountNo"
                                    InitialValue=""
                                    ErrorMessage="Please enter account number."
                                    ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="Validation">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>

                        <tr>
                            <td class="auto-style13"><b>IFSC Code :</b> </td>
                            <td class="auto-style14">
                                <asp:TextBox ID="txtIfsc" runat="server" placeholder="Enter IFSC Code"></asp:TextBox>
                                <asp:RequiredFieldValidator
                                    ID="rfvDropDownDistrict5"
                                    runat="server"
                                    ControlToValidate="txtIfsc"
                                    InitialValue=""
                                    ErrorMessage="Please Enter Ifsc"
                                    ForeColor="Red" Display="Dynamic" ValidationGroup="Validation">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style13"><b>Beneficiary Name :</b> </td>
                            <td class="auto-style14">
                                <asp:TextBox ID="txtBenifecName" runat="server" placeholder="Enter Beneficiary Name"></asp:TextBox>
                                <asp:RequiredFieldValidator
                                    ID="rfvDropDownDistrict6"
                                    runat="server"
                                    ControlToValidate="txtBenifecName"
                                    InitialValue=""
                                    ErrorMessage="Please Enter BeneficiaryName"
                                    ForeColor="Red" Display="Dynamic" ValidationGroup="Validation">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style13"><b>Is Market Fee : </b></td>
                            <td>
                                <asp:RadioButton ID="RadioTrader" runat="server" GroupName="MarketFee" Text="Trader" CssClass="Radio" />
                                &nbsp;<asp:RadioButton ID="RadioCommissionAgent" runat="server" GroupName="MarketFee" Text="Commision Agent" CssClass="Radio" />
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style13"><b>IsThak Patti :</b></td>
                            <td class="auto-style14">
                                <asp:CheckBox ID="CheckBoxSecretary" runat="server" Text="Secretary" />
                                &nbsp;</td>
                        </tr>

                    </table>
                </div>
                <asp:Label ID="lblMessage" runat="server" Text="Message"></asp:Label>
                <br />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" HeaderText="Fill All The *  Symbole" ValidationGroup="Validation" />
                <br />
                <a href="#" onclick="showYardTable()">Add Yard Details </a>
                <br />
                <div id="DisplayGrid" style="display: none">
                   
                            <asp:GridView ID="subyardGrid" runat="server" AutoGenerateColumns="False" Width="300px">

                                <Columns>
                                    <asp:TemplateField HeaderText="subyard Name">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtsubyardName" runat="server" placeholder="Enter SubyardName"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="subyard Code">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtsubyardCode" runat="server" placeholder="Enter SubyardCode"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Button ID="addrow" runat="server" CausesValidation="false" OnClick="btnAddNewRow_Click1" Text="+" />


                                        </HeaderTemplate>
                                        <ItemTemplate>

                                            <asp:ImageButton ID="imgDelete2" runat="server" ImageUrl="~/Logo/RecialbinLogo2.jpeg" Width="35px" Height="35px" OnClick="imgDelete2_Click1" />
                                        </ItemTemplate>
                                    </asp:TemplateField>



                                </Columns>

                            </asp:GridView>
                        
                </div>

            </div>
            <br />

            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" ValidationGroup="Validation" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />

            <div>
                <br />
                <h3>
                    <b>Market Details</b>  </h3>
                <table class="auto-style2">
                    <tr>
                        <td class="auto-style5">&nbsp;</td>
                        <td id="search" class="auto-style10">
                            <asp:TextBox ID="txtSeartch" runat="server" OnTextChanged="txtSeartch_TextChanged"></asp:TextBox>
                            &nbsp;
                        <asp:DropDownList ID="DropDownListDistictSeartch" runat="server" OnSelectedIndexChanged="DropDownListDistictSeartch_SelectedIndexChanged">
                        </asp:DropDownList>
                            &nbsp;
                        <asp:Button ID="Button1" runat="server" Text="SEARCH" OnClick="Button1_Click" />
                            &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="CLEAR" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">&nbsp;</td>
                        <td class="auto-style10">
                           
                           <asp:ScriptManager ID="scriptManager1" runat="server"></asp:ScriptManager> 
                            <asp:UpdatePanel ID="updatePannel1" runat="server">
                                <ContentTemplate>

                                
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="5"
                                nPageIndexChanging="GridView1_PageIndexChanging"
                                DataKeyNames="MarketId" OnRowEditing="GridView1_RowEditing"
                                OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit"
                                OnRowDataBound="GridView1_RowDataBound1" BorderColor="Black">
                                <Columns>

                                    <asp:TemplateField HeaderText="SubYard">
                                        <ItemTemplate>

                                            <img alt="" style="cursor: pointer; height: 20px;" src="./Logo/Plus.jpg" />
                                            <img alt="" style="cursor: pointer; height: 20px; display: none" src="./Logo/Minus.jpg" />
                                            <asp:Panel ID="subyadrdata" runat="server" Style="display: none">
                                                
                                                <asp:GridView ID="subyards" runat="server" AutoGenerateColumns="false" CssClass="ChildGrid">
                                                    <Columns>
                                                        <asp:BoundField ItemStyle-Width="150px" DataField="subyardName" HeaderText="Subyard" />
                                                        <asp:BoundField ItemStyle-Width="150px" DataField="subyardCode" HeaderText="Subyard Code" />
                                                    </Columns>
                                                </asp:GridView>
                                            </asp:Panel>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="District">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDistrict" Text='<%# Eval("DistrictName") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtgridDistNAme" Text='<%# Bind("DistrictName") %>' runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Market Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMarketName" Text='<%# Eval("MarketName") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtgridMArketName" Text='<%# Bind("MarketName") %>' runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Code">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCode" Text='<%# Eval("Code") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtgridCode" Text='<%# Bind("Code") %>' runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Address">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAddress" Text='<%# Eval("Address") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtgridaddress" Text='<%# Bind("Address") %>' runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Email">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmail" Text='<%# Eval("Email") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtgridemail" Text='<%# Bind("Email") %>' runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" CommandName="Edit" runat="server" ImageUrl="~/Logo/edit2.jpg" Width="30px" Height="30px" />

                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Button ID="Update" Text="Update" CommandName="Update" runat="server" class="update" />
                                            <asp:Button ID="Cancel" Text="Cancel" CommandName="Cancel" runat="server" class="cancel" />

                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
    </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="RowUpdating"/>
                                    <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="RowCancelingEdit" />
                                </Triggers>
</asp:UpdatePanel>

                            <br />
                        </td>
                    </tr>

                </table>

            </div>

        </form>
    </div>
</body>
</html>
