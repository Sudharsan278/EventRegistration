<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="EventReg.Registration" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registered Events</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f8f9fa;
            margin: 0;
            padding: 0;
        }

        h2 {
            text-align: center;
            margin-top: 20px;
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

        .grid-container {
            overflow-x: auto;
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Your Registered Events</h2>
        <div class="grid-container">
            <asp:GridView ID="GridView1" runat="server" CssClass="gridview" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="EventId" HeaderText="Event Id" SortExpression="EventId" />
                    <asp:BoundField DataField="EventName" HeaderText="Event Name" SortExpression="EventName" />
                    <asp:BoundField DataField="Venue" HeaderText="Venue" SortExpression="Venue" />
                    <asp:BoundField DataField="EventDate" HeaderText="Event Date" SortExpression="EventDate" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
