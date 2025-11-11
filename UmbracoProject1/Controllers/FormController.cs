using UmbracoProject1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Website.Controllers;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Org.BouncyCastle.Security;
using UmbracoProject1.Services;

namespace UmbracoProject1.Controllers
{
    public class FormController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider, FormSubmissionService formSubmissions) : SurfaceController(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
    {
        private readonly FormSubmissionService _formSubmissions = formSubmissions;

        public IActionResult HandleCallbackForm(CallbackFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }

            var result = _formSubmissions.SaveCallbackRequest(model);

            if (!result)
            {
                TempData["FormError"] = "Something went wrong while submitting your request. Please try again later.";
                return RedirectToCurrentUmbracoPage();
            }

            TempData["FormSuccess"] = "Thank you, your request has been recived and we will get back to you soon.";
            return RedirectToCurrentUmbracoPage();
        }

        [HttpPost]
        public IActionResult QuestionFormSubmit(QuestionFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }

            var result = _formSubmissions.SaveQuestionRequest(model);

            if (!result)
            {
                TempData["FormError"] = "Something went wrong while submitting your request. Please try again later";
                return RedirectToCurrentUmbracoPage();
            }

            TempData["Success"] = "Thank you, your Question has been recived and we will get back to you soon";
            return RedirectToCurrentUmbracoPage();
        }

    }


}

