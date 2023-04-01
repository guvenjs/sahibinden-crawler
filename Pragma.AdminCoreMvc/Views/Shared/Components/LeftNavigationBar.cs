using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Pragma.AdminCore.Data.Repository;
using Pragma.AdminCoreMvc.Helper.Models;

namespace Pragma.AdminCoreMvc.Views.Shared.Components
{
    public class LeftNavigationBar : ViewComponent
    {
        private IUnitOfWork _unitOfWork;
        private PanelInfo _panelInfo;

        public LeftNavigationBar(IUnitOfWork unitOfWork, IOptions<PanelInfo> panelInfo)
        {
            _unitOfWork = unitOfWork;
            _panelInfo = panelInfo.Value;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.BrandName = _panelInfo.BrandName;
            return View();
        }

    }
}
