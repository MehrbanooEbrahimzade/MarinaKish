using Application.Dtos;
using Aspose.Pdf;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Application.Helper
{
    public static class ExcelOutput
    {
        public static async Task<FileContentResult> GenerateExcel(List<ReportDto> reports)
        {

            Aspose.Pdf.Table table = new Aspose.Pdf.Table();
            table.Border = new Aspose.Pdf.BorderInfo(Aspose.Pdf.BorderSide.All, .5f, Aspose.Pdf.Color.FromRgb(System.Drawing.Color.LightGray));
            table.DefaultCellBorder = new Aspose.Pdf.BorderInfo(Aspose.Pdf.BorderSide.All, .5f, Aspose.Pdf.Color.FromRgb(System.Drawing.Color.LightGray));
            Aspose.Pdf.Document doc = new Aspose.Pdf.Document();
            Page page = doc.Pages.Add();

            foreach (var report in reports)
            {
                // Add row to table
                Aspose.Pdf.Row row = table.Rows.Add();
                // Add table cells
                row.Cells.Add(report.Date.ToString());
                row.Cells.Add(report.Count.ToString());
                row.Cells.Add(report.TotalAmount.ToString());
            }
            page.Paragraphs.Add(table);


            using (var streamOut = new MemoryStream())
            {
                doc.Save(streamOut, (SaveFormat)0);
                return new FileContentResult(streamOut.ToArray(), "application/pdf")
                {
                    FileDownloadName = "report.pdf"
                };
            }


        }

    }
}
