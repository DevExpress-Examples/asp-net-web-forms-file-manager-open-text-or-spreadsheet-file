Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Web

Public Module DocumentFormatHelper
	Private RichEditFormatRegistry As Dictionary(Of String, Object)
	Private SpreadsheetFormatRegistry As Dictionary(Of String, Object)

	Sub New()
		RichEditFormatRegistry = New Dictionary(Of String, Object)()
		SpreadsheetFormatRegistry = New Dictionary(Of String, Object)()

		RichEditFormatRegistry.Add("doc", DevExpress.XtraRichEdit.DocumentFormat.Doc)
		RichEditFormatRegistry.Add("epub", DevExpress.XtraRichEdit.DocumentFormat.ePub)
		RichEditFormatRegistry.Add("html", DevExpress.XtraRichEdit.DocumentFormat.Html)
		RichEditFormatRegistry.Add("htm", DevExpress.XtraRichEdit.DocumentFormat.Html)
		RichEditFormatRegistry.Add("mht", DevExpress.XtraRichEdit.DocumentFormat.Mht)
		RichEditFormatRegistry.Add("odt", DevExpress.XtraRichEdit.DocumentFormat.OpenDocument)
		RichEditFormatRegistry.Add("docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
		RichEditFormatRegistry.Add("txt", DevExpress.XtraRichEdit.DocumentFormat.PlainText)
		RichEditFormatRegistry.Add("rtf", DevExpress.XtraRichEdit.DocumentFormat.Rtf)
		RichEditFormatRegistry.Add("xml", DevExpress.XtraRichEdit.DocumentFormat.WordML)

		SpreadsheetFormatRegistry.Add("csv", DevExpress.Spreadsheet.DocumentFormat.Csv)
		SpreadsheetFormatRegistry.Add("xls", DevExpress.Spreadsheet.DocumentFormat.Xls)
		SpreadsheetFormatRegistry.Add("xlsm", DevExpress.Spreadsheet.DocumentFormat.Xlsm)
		SpreadsheetFormatRegistry.Add("xlsx", DevExpress.Spreadsheet.DocumentFormat.Xlsx)
		SpreadsheetFormatRegistry.Add("xlt", DevExpress.Spreadsheet.DocumentFormat.Xlt)
	End Sub

	Public Function GetFormat(ByVal path As String) As Object
		Dim extension = System.IO.Path.GetExtension(path).Trim("."c, " "c).ToLower()
		Dim format As Object = Nothing
		If RichEditFormatRegistry.TryGetValue(extension, format) Then
			Return format
		End If
		If SpreadsheetFormatRegistry.TryGetValue(extension, format) Then
			Return format
		End If
		Return Nothing
	End Function

End Module