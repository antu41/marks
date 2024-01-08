using marks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Net.Sockets;

namespace marks.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyDBContext context;

        public HomeController(MyDBContext context)
        {
            this.context = context;
        }

        private StudentModel BindDDL()
        {
            StudentModel stdModel = new StudentModel();
            stdModel.StudentsList = new List<SelectListItem>();

            var data = context.Stdmrks.ToList();

            stdModel.StudentsList.Add(new SelectListItem
            {
                Text = "Select Name",
                Value = ""

            });

            foreach (var item in data)
            {
                stdModel.StudentsList.Add(new SelectListItem
                {
                    Text = item.Studentname,
                    Value = item.Id.ToString()

                });
            } 
            return stdModel;
        }

        public IActionResult Index()
        {
            var std = BindDDL();
            
            return View(std);
        }


        [HttpPost]
        public IActionResult Index(StudentModel std)
        {
            var student = context.Stdmrks.Where(x => x.Id == std.Id).FirstOrDefault();
            if (student != null) 
            {
                ViewBag.selectedValue = student.Studentname;
            }
            var myStudent = BindDDL();
            return View(myStudent);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
