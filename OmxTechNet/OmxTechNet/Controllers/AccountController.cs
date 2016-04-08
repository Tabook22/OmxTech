using OmxTechNet.Models.DB;
using OmxTechNet.Security;
using OmxTechNet.Models.ViewModel;
using System.Web.Mvc;
using OmxTechNet.Models.ManageModel;

namespace OmxTechNet.Controllers
{
    public class AccountController : Controller
    {
        
        private OmxtechDbContext db = new OmxtechDbContext();
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AccountViewModel avm)
        {
            AccountModel am = new AccountModel();
            //here we are going to check to see if the username is null and password is null inside the tbl_Account
            if (string.IsNullOrEmpty(avm.tbl_account.Username) || string.IsNullOrEmpty(avm.tbl_account.Password) || am.login(avm.tbl_account.Username, avm.tbl_account.Password) == null)
            {
                ViewBag.Error = "Account's Invalid";
                return View("Login");
            }
            //if there is username and password then add the username to the session, and redirect to success view
            SessionPersister.Username = avm.tbl_account.Username;
            //SessionPersister.BranchID =Convert.ToString(avm.tbl_account.Branch);
            //to get branch name
            return RedirectToAction("Index","AdminHome");
        }

        public ActionResult Logout()
        {
            SessionPersister.Username = string.Empty;
            return RedirectToAction("Login");
            // Code disables caching by browser.
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            //Response.Cache.SetNoStore();


        }
    }
}