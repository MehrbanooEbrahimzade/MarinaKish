using Application.Dtos;
using Aspose.Pdf;
using Aspose.Pdf.Text;
using System;
using System.IO;
namespace Application.Helper
{
    public class PdfOutput
    {
        public Document GeneratePdf(TicketDto ticket)
        {

            #region DirectoryPath


            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","PdfImages");
            var iranYekan = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","Fonts","iranyekan.ttf");

            #endregion

            ///افزودن صفحه به pdf
            Document document = new Document();
            Page page = document.Pages.Add();
            Aspose.Pdf.Drawing.Graph canvas = new Aspose.Pdf.Drawing.Graph(50, 200);



            #region Rectangles


            Aspose.Pdf.Drawing.Rectangle schedule = new Aspose.Pdf.Drawing.Rectangle(105, 100, 240, 120);
            Aspose.Pdf.Drawing.Rectangle userInfo = new Aspose.Pdf.Drawing.Rectangle(105, 45, 240, 52);
            Aspose.Pdf.Drawing.Rectangle totslPrice = new Aspose.Pdf.Drawing.Rectangle(105, 8, 240, 30);


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
            var parasail = Path.Combine(imagePath, "para.png");
            var barcode = Path.Combine(imagePath, "barcode.png");
            var map = Path.Combine(imagePath, "Map.png");

            page.AddImage(imageFileName, new Aspose.Pdf.Rectangle(920, 350, 10, 300));

            page.AddImage(parasail, new Aspose.Pdf.Rectangle(190, 85, 10, 380));

            page.AddImage(barcode, new Aspose.Pdf.Rectangle(50, 125, 10, 500));

            page.AddImage(map, new Aspose.Pdf.Rectangle(190, 55, 10, 180));

            #endregion



            #region TextGraphy


            ///متن نوشتار
            var header = new TextFragment("مارینا کیش");
            var firstMarina = new TextFragment("اولین مارینای کشور");
            var ticketInfo = new TextFragment($"\nمجموعه تفریحات دریایی مارینا کیش\n\n نام تفریح : {ticket.FunType} \n\n {ticket.ScheduleDto.Date} \n\n {ticket.ScheduleDto.StartTime} الی {ticket.ScheduleDto.EndTime}   \n\n کیش -بلوار مرجان-مرجان 7 -ماریناکیش");
            var userInfoText = new TextFragment($"{ticket.UserDto.PhoneNumber}         {ticket.UserDto.NationalCode}         {ticket.UserDto.FullName}  \n\n{ticket.gender}                  ");


            ///نوشتار از سمت راست
            header.HorizontalAlignment = HorizontalAlignment.Right;
            firstMarina.HorizontalAlignment = HorizontalAlignment.Right;
            userInfoText.HorizontalAlignment = HorizontalAlignment.Right;
            ticketInfo.HorizontalAlignment = HorizontalAlignment.Right;


            ///نصب فونت کاستوم 
            var font = FontRepository.OpenFont(iranYekan);



            ///تنطیم فونت کاستوم برای نوشتار 
            header.TextState.Font = font;
            firstMarina.TextState.Font = font;
            ticketInfo.TextState.Font = font;
            userInfoText.TextState.Font = font;

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



            ///تنطیم استایل فونت نوشتار
            header.TextState.FontStyle = (FontStyles)0;
            firstMarina.TextState.FontStyle = (FontStyles)0;
            ticketInfo.TextState.FontStyle = (FontStyles)0;
            userInfoText.TextState.FontStyle = (FontStyles)0;


            ///تنطیم موقعیت قرارگیری متن در صفحه 
            header.Position = new Position(80, 320);
            firstMarina.Position = new Position(150, 305);
            ticketInfo.Position = new Position(150, 290);
            userInfoText.Position = new Position(160, 160);



            ticketInfo.Margin.Right = 0;
            ticketInfo.Margin.Left = 0;


            ticketInfo.TextState.DrawTextRectangleBorder = false;


            ///اضافه کردن متن به صفحه 
            page.Paragraphs.Add(header);
            page.Paragraphs.Add(firstMarina);
            page.Paragraphs.Add(ticketInfo);
            page.Paragraphs.Add(userInfoText);

            #endregion


            ///تنطیم ابعاد pdf
            page.PageInfo.Width = 520;
            page.PageInfo.Height = 350;

            var fileName = "ticket" + GenerateFileNumber() + ".pdf";
            document.Save(path + fileName);


            return document;

        }
        private string GenerateFileNumber()
        {
            int _min = 10000;
            int _max = 99999;
            Random _rdm = new Random();

            var fileCode = _rdm.Next(_min, _max).ToString();
            return fileCode;
        }
    }
}

