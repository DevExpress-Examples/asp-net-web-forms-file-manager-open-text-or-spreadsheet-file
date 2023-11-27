Imports DevExpress.Web
Imports DevExpress.Web.ASPxRichEdit
Imports DevExpress.Web.ASPxSpreadsheet
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web.Office
Imports System.IO

Partial Public Class _Default
	Inherits System.Web.UI.Page

	Protected Sub PopupWithDocument_WindowCallback(ByVal source As Object, ByVal e As DevExpress.Web.PopupWindowCallbackArgs)
		Dim fullFileName As String = e.Parameter

		Dim format As Object = DocumentFormatHelper.GetFormat(fullFileName)
		If format Is Nothing Then
			Return
		End If

		Dim isSpreadsheet As Boolean = TypeOf format Is DevExpress.Spreadsheet.DocumentFormat
		ASPxSpreadsheet1.Visible = isSpreadsheet
		ASPxRichEdit1.Visible = Not isSpreadsheet

		Dim docId = Guid.NewGuid().ToString()
		Dim docPath = Server.MapPath(fullFileName)

		If isSpreadsheet Then
			ASPxSpreadsheet1.Open(docId, DirectCast(format, DevExpress.Spreadsheet.DocumentFormat), Function() File.ReadAllBytes(docPath))
		Else
			ASPxRichEdit1.Open(docId, DirectCast(format, DevExpress.XtraRichEdit.DocumentFormat), Function() File.ReadAllBytes(docPath))
		End If
	End Sub
End Class