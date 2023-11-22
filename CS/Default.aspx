<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxRichEdit.v15.1, Version=15.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxRichEdit" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxSpreadsheet.v15.1, Version=15.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxSpreadsheet" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript">
        function OnSelectedFileChanged(s, e) {
        	if (e.file != null) {
                PopupWithDocument.Show();
                PopupWithDocument.PerformCallback(e.file.GetFullName());
            }
        }
        function OnEndCallback(s, e) {
        	s.Show();
        }
    </script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dx:ASPxFileManager ID="MyFileManager" ClientInstanceName="MyFileManager" runat="server">
                <Settings RootFolder="~\Content" ThumbnailFolder="~\Thumb\" />
                <SettingsUpload Enabled="false" />
                <ClientSideEvents SelectedFileChanged="OnSelectedFileChanged" />
            </dx:ASPxFileManager>
            <dx:ASPxPopupControl AllowResize="true" ID="PopupWithDocument" ClientInstanceName="PopupWithDocument" runat="server" OnWindowCallback="PopupWithDocument_WindowCallback" PopupHorizontalAlign="WindowCenter" AllowDragging="true" CloseAction="CloseButton" >
               <ClientSideEvents  EndCallback="OnEndCallback" />
                 <ContentCollection>
                    <dx:PopupControlContentControl runat="server">
                        <dx:ASPxSpreadsheet ID="ASPxSpreadsheet1" runat="server" Visible="false"></dx:ASPxSpreadsheet>
                        <dx:ASPxRichEdit ID="ASPxRichEdit1" runat="server" Visible="false"></dx:ASPxRichEdit>
                    </dx:PopupControlContentControl>
                </ContentCollection>
            </dx:ASPxPopupControl>
        </div>
    </form>
</body>
</html>
