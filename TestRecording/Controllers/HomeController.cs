using System;
using System.IO;
using System.Web.Mvc;

namespace TestRecording.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }




        // ---/RecordRTC/PostRecordedAudioVideo

        // [AllowFileSize(FileSize = 5 * 1024 * 1024, ErrorMessage = "Maximum allowed file size is 5 MB")]
        [HttpPost]
        public ActionResult PostRecordedAudioVideo()
        {

            foreach (string upload in Request.Files)
            {
                var path = AppDomain.CurrentDomain.BaseDirectory + @"uploads\";
                var file = Request.Files[upload];
                if (file == null) continue;
                string fD = Request.Form[0];
                var fullpath = Path.Combine(path, fD);
                file.SaveAs(Path.Combine(path,fD ));
            }
            return Json(Request.Form[0]);
        }

        // ---/RecordRTC/DeleteFile
        [HttpPost]
        public ActionResult DeleteFile()
        {
            var fileUrl = AppDomain.CurrentDomain.BaseDirectory + "uploads/" + Request.Form["delete-file"] + ".webm";
            new FileInfo(fileUrl).Delete();
            return Json(true);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}