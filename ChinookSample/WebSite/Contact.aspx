<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your contact page.</h3>
    <address>
        Allan Anderson<br />
        NAIT<br />
        <abbr title="Phone">P:</abbr>
        780.378.5275
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:Support@example.com">Support@example.com</a><br />
        <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@example.com</a>
    </address>

    <h2>Remember to to remove these lines before production!</h2>
    <p>This is the login for the Web Master: userid = Webmaster&nbsp;&nbsp;&nbsp;password = Pa$$word1</p>
    
</asp:Content>
