using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pragma.AdminCore.Data;
using Pragma.AdminCore.Data.Enums;
using Pragma.AdminCore.Data.Models.Entities;
using Pragma.AdminCore.Data.Repository;
using Pragma.AdminCoreMvc.Helper;
using Pragma.AdminCoreMvc.Helper.Models;
using Pragma.AdminCoreMvc.Models;
using System;
using System.Linq;
using System.Linq.Dynamic;

namespace Pragma.AdminCoreMvc.Controllers
{
    [Authorize]
    [RequestFormLimits(MultipartBodyLengthLimit = 268435456)]
    public class FiltersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UnitOfWork _uow;
        private readonly UploadImageSettings _imageUploadBaseUrl;
        private readonly UploadFileProcessor _uploadFileProcessor;

        public FiltersController(ApplicationDbContext context)
        {
            _context = context;
            _uow = new UnitOfWork(_context);
        }

        #region List

        public IActionResult List()
        {
            return View();
        }

        [HttpGet]
        public JsonResult LoadData()
        {
            try
            {
                var draw = HttpContext.Request.Query["draw"].FirstOrDefault();
                // skip number of rows count  
                var start = Request.Query["start"].FirstOrDefault();
                // page length
                var length = Request.Query["length"].FirstOrDefault();
                // sort column name
                var sortColumn = Request.Query["columns[" + Request.Query["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                // sort column direction  
                var sortColumnDirection = Request.Query["order[0][dir]"].FirstOrDefault();
                // search  
                var searchValue = Request.Query["search[value]"].FirstOrDefault();
                //page size
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;
                // get entity data from context
                var data = (from tempData in _uow.GetRepository<Filter>().GetAvailable()
                            select tempData);

                //sort  
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    data = data.OrderBy(sortColumn + " " + sortColumnDirection);
                }

                //search  
                if (!string.IsNullOrEmpty(searchValue))
                {
                    data = data.Where(x => x.Name.Contains(searchValue));
                }

                //total number of rows count   
                recordsTotal = data.Count();
                //paging   
                var response = data.Skip(skip).Take(pageSize).ToList().Select(x => new FilterListModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Url = x.Url.SafeSubstring(0,50),
                    DateCreated = x.DateCreated.Value.ToString("dd/MM/yyyy HH:mm"),
                }).ToList();
                //sort  
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    response = response.AsQueryable().OrderBy(sortColumn + " " + sortColumnDirection).ToList();
                }
                return new JsonResult(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = response });
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}