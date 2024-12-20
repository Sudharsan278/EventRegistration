<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="EventReg.Home" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Event Registration</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f8f9fa;
            margin: 0;
            padding: 0;
            color: #333;
        }

        form {
            width: 80%;
            margin: 20px auto;
            background-color: #ffffff;
            border: 1px solid #ddd;
            border-radius: 8px;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
            padding: 20px;
        }

        h1, h3 {
            text-align: center;
            margin-bottom: 20px;
            color: #007BFF;
        }

        p {
            text-align: center;
            font-size: 16px;
            margin-bottom: 20px;
        }

        .labels-container {
            display: flex;
            justify-content: center;
            gap: 30px;
        }

        .labels-container label {
            font-weight: bold;
        }

        .grid-container {
            margin: 20px 0;
        }

        .gridview {
            width: 100%;
            border-collapse: collapse;
        }

        .gridview th {
            background-color: #007BFF;
            color: #ffffff;
            text-align: left;
            padding: 8px;
        }

        .gridview td {
            padding: 8px;
            border-bottom: 1px solid #ddd;
            text-align: left;
        }

        .gridview tr:nth-child(even) {
            background-color: #f2f2f2;
        }

        .gridview tr:hover {
            background-color: #e9ecef;
        }

        .form-group {
            margin: 10px 0;
            text-align: center;
        }

        label {
            display: inline-block;
            margin-bottom: 8px;
            font-weight: bold;
        }

        input[type="text"] {
            width: 50%;
            padding: 8px;
            border: 1px solid #ccc;
            border-radius: 4px;
            font-size: 14px;
        }

        button {
            background-color: #007BFF;
            color: #ffffff;
            padding: 8px 16px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 14px;
            margin-top: 10px;
        }

        button:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Event Registration</h1>
        <h3>Available Events</h3>

        <div class="labels-container">
            <asp:Label ID="Label2" runat="server" Text="Label2"></asp:Label>
            <asp:Label ID="Label3" runat="server" Text="Label3"></asp:Label>
            <asp:Label ID="Label4" runat="server" Text="Label4"></asp:Label>
        </div>

        <div class="grid-container">
            <asp:GridView ID="GridView1" runat="server" CssClass="gridview"></asp:GridView>
        </div>

        <div class="form-group">
            <asp:Label ID="Label1" runat="server" Text="Event Id:"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" placeholder="Enter Event Id"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Register" />
        </div>
    </form>
</body>
</html>
