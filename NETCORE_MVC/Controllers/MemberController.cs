using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETCORE_MVC.Services;

namespace NETCORE_MVC.Controllers
{
    [Route("api/[controller]")]
    public class MemberController : Controller
    {
        private readonly IMemberServices _memberServices;
        public MemberController(IMemberServices memberServices)
        {
            _memberServices = memberServices;
        }
        [HttpGet]
        // GET: MemberController
        public ActionResult Index()
        {
            return View(_memberServices.GetListMember());
        }

        // GET: MemberController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        [HttpGet("Create")]
        // GET: MemberController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MemberController/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateMemberRequest request)
        {
            if(ModelState.IsValid)
            {
                _memberServices.AddMember(request);
                return RedirectToAction(nameof(Index));
            }
            return View(request);
        }

        // POST: MemberController/Edit/5
        [HttpPost("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id)
        {
            if(id >= 0 && id < _memberServices.GetListEdit().Count)
            {
                var member = _memberServices.GetListEdit()[id];
                var model = new EditMemberViewModel
                {
                    FirstName = member.FirstName,
                    LastName = member.LastName,
                    PhoneNumber = member.PhoneNumber,
                    BirthPlace = member.BirthPlace
                };
                ViewData["Index"] = id;
                return View(model);
            }
            return View();  
        }
        [HttpPost("Delete")]
        // GET: MemberController/Delete/5
        public ActionResult Delete(int id)
        {
            if(id >= 0 && id < _memberServices.GetListMember().Count)
            {
                _memberServices.DeleteMember(id);
            }
            return RedirectToAction("Index");
        }
        [HttpPost("Update")]
        public ActionResult Update(int id, EditMemberViewModel model)
        {
            if(ModelState.IsValid)
            {
                _memberServices.UpdateMember(id, model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
