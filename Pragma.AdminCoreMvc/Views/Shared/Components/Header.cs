using Microsoft.AspNetCore.Mvc;
using Pragma.AdminCore.Data.Repository;

namespace Pragma.AdminCoreMvc.Views.Shared.Components
{
    public class Header : ViewComponent
    {
        private IUnitOfWork _unitOfWork;

        public Header(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
