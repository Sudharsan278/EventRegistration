<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="EventReg.Signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Event Registration</title>

        <style>
        html, body {
            margin: 0;
            height: 100%;
        }

        .center-container {
            display: flex;
            justify-content: center; 
            align-items: center;     
            height: 100vh;          
        }

        form {
            padding: 20px;
            border: 1px solid #ddd;
            border-radius: 8px;
            box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.1);
            width: 300px;
        }

        form p {
            margin-bottom: 15px;
        }

        label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
        }

        input[type="text"], input[type="password"], input[type="email"] {
            width: 100%;
            padding: 8px;
            font-size: 14px;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
        }

        .btn-submit {
            background-color: #007bff;
            color: white;
            padding: 10px;
            border: none;
            border-radius: 4px;
            width: 100%;
            font-size: 16px;
            cursor: pointer;
        }

        .btn-submit:hover {
            background-color: #0056b3;
        }
    </style>
</head>
    <body>
    <div class="center-container">

        <form id="form1" runat="server">
        
            <div style="text-align: center;">

                <h1>Event Registration</h1>
                <h3>Sign Up Form</h3>
            
            </div>
            <p>
                <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </p>
            
            <p>
                <asp:Label ID="Label2" runat="server" Text="Email"></asp:Label>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="Label3" runat="server" Text="College"></asp:Label>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="Label4" runat="server" Text="Password"></asp:Label>
                <asp:TextBox ID="TextBox4" runat="server" TextMode="Password"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="SubmitButton" runat="server" Text="Submit" CssClass="btn-submit" OnClick="SubmitButton_Click" />
            </p>
            <p>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Login??</asp:LinkButton>
            </p>
        </form>
    </div>
</body>
</html>
