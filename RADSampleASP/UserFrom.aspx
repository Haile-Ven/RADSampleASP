<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserFrom.aspx.cs" Inherits="RADSampleASP.UserFrom" EnableEventValidation="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Form</title>
    <link rel="stylesheet" href="style.css" />
    <script src="script.js" type="text/javascript" ></script>
</head>
<body>
    <div id="msgDiv"></div>
    <form id="userForm" runat="server">
<asp:HiddenField ID="delCon" runat="server" />
        <h2>User Information Form</h2>
        <div>
            <label for="userId">User ID:</label>
           <asp:TextBox runat="server" ID="usrIDTxtBx" CssClass="form-control" onClientClick="removeResponse(); return false;" ClientIDMode="Static"></asp:TextBox>
        </div>

        <div>
            <label for="userName">User Name:</label>
            <asp:TextBox runat="server" ID="usrNmTxtBx" CssClass="form-control" onClientClick="removeResponse(); return false;" ClientIDMode="Static"></asp:TextBox>
        </div>

        <div id="saveBtnDiv">
            <asp:Button ID="saveBtn" runat="server" Text="Save" OnClick="saveBtn_Click" />
        </div>

        <div id="userGridViewContainer">
            <asp:GridView ID="userGridView" runat="server" AutoGenerateColumns="False" OnRowCommand="userGridView_RowCommand">
                <Columns>
                    <asp:BoundField DataField="UserID" HeaderText="User ID" />
                    <asp:BoundField DataField="UserName" HeaderText="User Name" />
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="updateBtn"  runat="server" UseSubmitBehavior="false" CommandName="updateCmd" Text="Update" CommandArgument='<%# Container.DataItemIndex %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="deleteBtn" runat="server" onclientclick="confirmDelete()" CommandName="deleteCmd" Text="Delete" CommandArgument='<%# Container.DataItemIndex %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
    </body>
</html>