using System;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using DAL;
using Dtx.Enums;
using Dtx.Security;
using ViewModels.General;
using ViewModels.Home;

namespace MyMVCApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly UnitOfWork UnitOfWork = new UnitOfWork();

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public JsonResult GetPost([FromBody] GetPostViewModel.Request request)
        {
            var response = new JsonResultViewModel();

            var limit = 1413;
            var passage =
                "Waking up to an email from your bank is never fun. I’m used to receiving emails about my bank balance or recent transfers. I read them with bored, glazed-over eyes, and then archive them. However, I recently received an email that caused me to lose faith in a bank that I used to trust.\r\nNobody wants to hear that their bank PIN code may have been compromised. On August 5, 2019, me and 479,999 other customers of Monzo, a British app-based bank, found out that unauthorized staff had access to to our PIN numbers for six months. While many use Monzo and other app-based banks as a secondary account, I am all in. I made this decision after being frustrated with slow payment notifications and exorbitant fees from mainstream banks while traveling internationally.\r\nWith Monzo, I had so far enjoyed fee-free international credit-card payments. I liked the instant payment notifications and the way the app automatically filed my spending into categories like “Eating Out” and “Bills.” Opening an account was also quick and easy, as was transferring funds from my previous account. I was so happy with my user experience that I recommended it to my partner who, as a new arrival to the UK, had struggled to open a bank account with one of the Big Four banking corporations here.\r\nAll this made the news of the exposed PIN numbers even harder to take. (Monzo responded to the situation in a blog post on August 9.)\r\nWhile not yet prevalent in the United States, digital banks are becoming increasingly popular with the millennial crowd across Europe. In the wake of the 2008 financial crisis, the U.K. passed the Financial Services Act 2012 in order to open up the market to new banks. This facilitated the rise of Monzo, Revolut, and other digital-only banks that undercut traditional banking costs by doing away with physical-branch locations and serving customers purely through an app. Also, because these companies don’t currently offer a full suite of services like mortgages and loans, they’re less hampered by regulation, according to the major accounting firm KPMG. These benefits, along with unique features such as fee-free international spending, have allowed banks such as Monzo to attract worldwide attention from investors and a £2 billion ($2.4 billion) valuation, despite being founded only in 2015.\r\nInitially, I thought this was a good thing. However, news such as the fact that my PIN number was possibly visible to 110 unauthorized engineers has caused me to question that. With relatively little experience compared to legacy banks, perhaps Monzo and other fintech unicorns are not yet qualified to hold our money.\r\nThere’s more evidence to suggest that this may be the case. For example, recent Monzo technical problems resulted in transactions and card payments being declined because of a technical glitch.\r\nCompared to other fintech startups however, Monzo has seen fewer scandals. The U.K. FCA (Financial Conduct Authority) has been investigating Revolut, one of Monzo’s biggest competitors, for an alleged compliance lapse that may have resulted in illegal transactions via its app. (A Revolut spokesperson told Bloomberg in response to the investigation that “at no point did we fail to meet our legal and regulatory sanctions.”)\r\nThat’s not to mention, Revolut’s reportedly toxic work culture and also its usage of advertisements that many found to be single-shaming and which reportedly used fake data. (Revolut apologized for the advertisements.)\r\nIt’s not just British app-based banks that have landed themselves in legal hot water. Berlin-based N26 has been ordered by the German government to improve its ability to prevent money laundering and terrorist financing. A tweet responding to this inquiry prompted many to share their stories of how they had been unable to access their funds.";

            try
            {
                string email;
                if (JWT.ValidateToken(request.token ?? Request?.Headers?.Get("token"), out email))
                {
                    if (UnitOfWork.UserRepository.FindUserByEmail(email).Role.Permissions.Any(permission =>
                        permission.PermissionId == (int) Permission.ReadFullPassage))
                        response.data = new GetPostViewModel.Response
                        {
                            passage = passage,
                            is_complete_passage = true
                        };
                }
                else
                {
                    response.data = new GetPostViewModel.Response
                    {
                        passage = passage.Substring(0, limit) + "...",
                        is_complete_passage = false
                    };
                }

                response.is_successful = true;
            }
            catch (Exception ex)
            {
                response = new JsonResultViewModel
                {
                    error_message = ex.Message,
                    error_type = ResponseErrorType.UnexpectedError
                };
            }

            return Json(response);
        }
    }
}