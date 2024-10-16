<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128564779/15.1.10%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T318308)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# File Manager for ASP.NET Web Forms - How to open a selected text or spreadsheet file

This example demonstrates how to open a selected file in the [ASPxSpreadsheet](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxSpreadsheet.ASPxSpreadsheet) or [ASPxRichEdit](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxRichEdit.ASPxRichEdit) component.

![](file-manager-and-spreadsheet.png)

## Implementation Details

In this example, [ASPxFileManager](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxFileManager) contains files that can be opened in the [ASPxSpreadsheet](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxSpreadsheet.ASPxSpreadsheet) or [ASPxRichEdit](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxRichEdit.ASPxRichEdit) component. When a user clicks a file, the [ASPxClientFileManager.SelectedFileChanged](https://docs.devexpress.com/AspNet/js-ASPxClientFileManager.SelectedFileChanged) event fires. The event handler shows a popup and sends a callback to the server.

```jscript
function OnSelectedFileChanged(s, e) {
    if (e.file != null) {
        PopupWithDocument.Show();
        PopupWithDocument.PerformCallback(e.file.GetFullName());
    }
}
```
On the server, the [WindowCallback](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxPopupControlBase.WindowCallback) event handler determines the format of the selected file and opens the file in the [ASPxSpreadsheet](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxSpreadsheet.ASPxSpreadsheet) component if it is a [spreadsheet format](https://docs.devexpress.com/OfficeFileAPI/DevExpress.Spreadsheet.DocumentFormat._members#fields); otherwise the document is opened in the [ASPxRichEdit](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxRichEdit.ASPxRichEdit) component.

```scharp
protected void PopupWithDocument_WindowCallback(object source, DevExpress.Web.PopupWindowCallbackArgs e) {
String fullFileName = e.Parameter;

object format = DocumentFormatHelper.GetFormat(fullFileName);
if (format == null) return;

Boolean isSpreadsheet = format is DevExpress.Spreadsheet.DocumentFormat;
ASPxSpreadsheet1.Visible = isSpreadsheet;
ASPxRichEdit1.Visible = !isSpreadsheet;

var docId = Guid.NewGuid().ToString();
var docPath =  Server.MapPath(fullFileName);

if (isSpreadsheet)
  ASPxSpreadsheet1.Open(docId, (DevExpress.Spreadsheet.DocumentFormat)format, () => File.ReadAllBytes(docPath));
else
  ASPxRichEdit1.Open(docId, (DevExpress.XtraRichEdit.DocumentFormat)format, () => File.ReadAllBytes(docPath));
}
```

## Files to Review

* [Default.aspx](./CS/Default.aspx) (VB: [Default.aspx](./VB/Default.aspx))
* [Default.aspx.cs](./CS/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/Default.aspx.vb))

## More Examples

* [File Manager for ASP.NET Web Forms - How to implement custom document management for different document types](https://github.com/DevExpress-Examples/asp-net-web-forms-file-manager-custom-document-management)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=asp-net-web-forms-file-manager-open-text-or-spreadsheet-file&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=asp-net-web-forms-file-manager-open-text-or-spreadsheet-file&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
