<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EventReg.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Event Registration</title>
    <style>

        .body{
            margin : 0;
            height : 100%
        }

        .center-container{
            display:flex;
            flex-direction:column;
            justify-content : center;
            align-items : center;
            height:100vh;
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

        input[type="password"], input[type="email"] {
            width: 100%;
            padding: 8px;
            font-size: 14px;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
        }

        h1, h3 {
            text-align: center;
            margin-bottom: 20px;
            color: #333;
        }

        label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
        }

        input[type="password"], input[type="email"] {
            width: 100%;
            padding: 8px;
            font-size: 14px;
            border: 1px solid #ccc;
            border-radius: 4px;
            margin-bottom: 15px;
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
        <form class="form" runat="server">
        <h1>Event Registration</h1>
        <h3>Login</h3>
           
                <asp:Label ID="Label1" runat="server" Text="Email"></asp:Label>
                <asp:TextBox ID="TextBox1" type="email" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                <asp:TextBox ID="TextBox2" type="password" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="Button1" class="btn-submit" runat="server" Text="Login" OnClick="Button1_Click" />
                <br />
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Didn&#39;t have an account? Sign Up</asp:LinkButton>
        </form>
    </div>
    <p>
        &nbsp;</p>
</body>
</html>
