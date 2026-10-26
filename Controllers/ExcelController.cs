using DailyClientMeet.Models;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace DailyClientMeet.Controllers
{
    public class ExcelController : Controller
    {
        private static List<ServiceRequest> _data =
            new List<ServiceRequest>();

        public IActionResult Upload()
        {
            return View(_data);
        }


     

[HttpPost]
    public IActionResult Upload(IFormFile excelFile)
    {
        if (excelFile != null)
        {
                ExcelPackage.License.SetNonCommercialOrganization("Learning-AZ400");

                using var stream =
                new MemoryStream();

            excelFile.CopyTo(stream);

            using var package =
                new ExcelPackage(stream);

            var sheet =
                package.Workbook.Worksheets[0];

            _data.Clear();

            int row = 2;

            while (sheet.Cells[row, 1].Value != null)
            {
                _data.Add(new ServiceRequest
                {
                    SrNo =
                        Convert.ToInt32(
                        sheet.Cells[row, 1].Text),

                    ICTId =
                        sheet.Cells[row, 2].Text,

                    CreatedDate =
                        Convert.ToDateTime(
                        sheet.Cells[row, 3].Text),

                    BusinessPOC =
                        sheet.Cells[row, 4].Text,

                    Status =
                        sheet.Cells[row, 5].Text,

                    Description =
                        sheet.Cells[row, 6].Text
                });

                row++;
            }
        }

        return View(_data);
    }

    public IActionResult Delete(int id)
        {
            var item =
                _data.FirstOrDefault(x => x.SrNo == id);

            if (item != null)
                _data.Remove(item);

            return RedirectToAction("Upload");
        }
    }
}
