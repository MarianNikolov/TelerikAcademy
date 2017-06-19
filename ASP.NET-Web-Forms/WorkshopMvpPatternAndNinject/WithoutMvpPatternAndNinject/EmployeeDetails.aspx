<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeDetails.aspx.cs" Inherits="WithoutMvpPatternAndNinject.EmployeeDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="EmployeeDetailsForm" runat="server">
        <div>
            <asp:DetailsView runat="server" ID="DetailsView"   />
        </div>
    </form>
</body>
</html>
