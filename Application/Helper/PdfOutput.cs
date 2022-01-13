using Application.Dtos;
using Aspose.Pdf;
using Aspose.Pdf.Text;
using Infrastructure.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Document = Aspose.Pdf.Document;
using Page = Aspose.Pdf.Page;

namespace Application.Helper
{
    public static class PdfOutput
    {
        public async static Task<FileContentResult> GeneratePdf(TicketDto ticket)
        {

            #region DirectoryPath

            var fileName = "ticket" + GenerateFileNumber() + ".pdf";

            var path = Path.Combine(Directory.GetCurrentDirectory());
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "PdfImages");
            var iranYekan = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Fonts", "iranyekan.ttf");
            var Yekan = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","Fonts","Yekan.ttf");

            #endregion


            ///افزودن صفحه به pdf
            

            Document document = new Document();

            Page page = document.Pages.Add();
            Aspose.Pdf.Drawing.Graph canvas = new Aspose.Pdf.Drawing.Graph(50, 200);



            #region Rectangles


            Aspose.Pdf.Drawing.Rectangle schedule   =  new Aspose.Pdf.Drawing.Rectangle(-50, 160, 400, 60);
            Aspose.Pdf.Drawing.Rectangle userInfo = new Aspose.Pdf.Drawing.Rectangle(-50, 110, 400, 45);
            Aspose.Pdf.Drawing.Rectangle totslPrice =  new Aspose.Pdf.Drawing.Rectangle(-50, 77, 400, 30);


            ///summery
            ///زاویه ی گوشه ی مستطیل ها 
            ///summery

            schedule.RoundedCornerRadius = 8;
            userInfo.RoundedCornerRadius = 8;
            totslPrice.RoundedCornerRadius = 8;


            ///summery
            ///ضخامت خط خارجی مستطیل
            ///summery
            schedule.GraphInfo.LineWidth = 0.1f;
            userInfo.GraphInfo.LineWidth = 0.1f;
            totslPrice.GraphInfo.LineWidth = 0.1f;



            ///summery
            ///رنگ خط خارجی مستطیل 
            ///summery
            schedule.GraphInfo.Color = Aspose.Pdf.Color.LightGray;
            userInfo.GraphInfo.Color = Aspose.Pdf.Color.LightGray;
            totslPrice.GraphInfo.Color = Aspose.Pdf.Color.LightGray;
            ///totslPrice.GraphInfo.FillColor = Aspose.Pdf.Color.DarkBlue;


            canvas.Shapes.Add(schedule);
            canvas.Shapes.Add(userInfo);
            canvas.Shapes.Add(totslPrice);
            page.Paragraphs.Add(canvas);

            #endregion




            #region Adding Image

            var imageFileName = System.IO.Path.Combine(imagePath, "logo.png");
            var barcode = Path.Combine(imagePath, "barcode.png");

            page.AddImage(imageFileName, new Aspose.Pdf.Rectangle(920, 230, 6, 270));

            page.AddImage(barcode, new Aspose.Pdf.Rectangle(50, 125, 10, 370));


            #endregion



            #region TextGraphy


            ///متن نوشتار
            var header = new TextFragment("مارینا کیش");
            var firstMarina = new TextFragment("اولین مارینای کشور");
            var ticketInfo = new TextFragment($"\nمجموعه تفریحات دریایی مارینا کیش\n\n\n {ticket.FunType}                                  {ticket.ScheduleDto.Date.Date}                         {ticket.ScheduleDto.StartTime} الی  {ticket.ScheduleDto.EndTime}");
            var userInfoText = new TextFragment($"{ticket.UserDto.FullName}                         کدملی : {ticket.UserDto.NationalCode}                         {ticket.UserDto.PhoneNumber}\n\n شماره بلیط : ٥٦٨٩٥                                                                   جنسیت : {ticket.gender} ");
            var priceInfo = new TextFragment("\n\nمبلغ : ٦٥٠.٠٠٠ هزارتومان");
            var address = new TextFragment("آدرس  : کیش  -  بلوار مرجان  -  مرجان 7  -  مارینا کیش ");





            




            ///نوشتار از سمت راست
            header.HorizontalAlignment = HorizontalAlignment.Right;
            firstMarina.HorizontalAlignment = HorizontalAlignment.Right;
            userInfoText.HorizontalAlignment = HorizontalAlignment.Right;
            ticketInfo.HorizontalAlignment = HorizontalAlignment.Right;
            priceInfo.HorizontalAlignment = HorizontalAlignment.Right;


            ///نصب فونت کاستوم 
            var font = FontRepository.OpenFont(iranYekan);
            var yekan = FontRepository.OpenFont(Yekan);



            ///تنطیم فونت کاستوم برای نوشتار 
            header.TextState.Font = font;
            firstMarina.TextState.Font = font;
            ticketInfo.TextState.Font = font;
            userInfoText.TextState.Font = font;
            priceInfo.TextState.Font = font;

            ///تنطیم اندازه فونت 
            header.TextState.FontSize = 11;
            firstMarina.TextState.FontSize = 10;
            ticketInfo.TextState.FontSize = 8;
            userInfoText.TextState.FontSize = 8;


            ///تنطیم رنگ نوشتار
            header.TextState.ForegroundColor = Aspose.Pdf.Color.DarkSlateBlue;
            firstMarina.TextState.ForegroundColor = Aspose.Pdf.Color.DarkSlateBlue;
            ticketInfo.TextState.ForegroundColor = Aspose.Pdf.Color.Navy;
            userInfoText.TextState.ForegroundColor = Aspose.Pdf.Color.Navy;
            priceInfo.TextState.ForegroundColor = Aspose.Pdf.Color.Navy;



            ///تنطیم استایل فونت نوشتار
            header.TextState.FontStyle = (FontStyles)0;
            firstMarina.TextState.FontStyle = (FontStyles)0;
            ticketInfo.TextState.FontStyle = (FontStyles)0;
            userInfoText.TextState.FontStyle = (FontStyles)0;
            priceInfo.TextState.FontStyle = (FontStyles)0;


            ///تنطیم موقعیت قرارگیری متن در صفحه 
            header.Position =  new Position(150, 245);
            firstMarina.Position = new Position(150, 230);
            ticketInfo.Position = new Position(90, 222);
            userInfoText.Position = new Position(90, 145);
            priceInfo.Position = new Position(160, 114);




            address.TextState.Font = yekan;
            address.TextState.FontSize = 10;
            address.TextState.ForegroundColor = Aspose.Pdf.Color.DarkSlateGray;
            address.TextState.FontStyle = (FontStyles)0;
            address.Position = new Position(90, 72);
            address.HorizontalAlignment = HorizontalAlignment.Center;





            ticketInfo.Margin.Right = 0;
            ticketInfo.Margin.Left = 0;



            priceInfo.Margin.Right = 0;
            priceInfo.Margin.Left = 0;



            ticketInfo.TextState.DrawTextRectangleBorder = false;


            ///اضافه کردن متن به صفحه 
            page.Paragraphs.Add(header);
            page.Paragraphs.Add(firstMarina);
            page.Paragraphs.Add(ticketInfo);
            page.Paragraphs.Add(userInfoText);
            page.Paragraphs.Add(priceInfo);
            page.Paragraphs.Add(address);

            #endregion


            ///تنطیم ابعاد pdf
            page.PageInfo.Width = 520;
            page.PageInfo.Height = 280;

            using (var streamOut = new MemoryStream())
            {
                document.Save(streamOut);
                return new FileContentResult(streamOut.ToArray(), "application/pdf")
                {
                    FileDownloadName = "ticket.pdf"
                };
            }
           
        }
        private static  string GenerateFileNumber()
        {
            int _min = 10000;
            int _max = 99999;
            Random _rdm = new Random();

            var fileCode = _rdm.Next(_min, _max).ToString();
            return fileCode;
        }
    }
}

