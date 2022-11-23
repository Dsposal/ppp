
using Microsoft.AspNetCore.Mvc;
using PlasticPackagingPortal.Web.Models;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using AutoMapper;
using PlasticPackagingPortal.Web.Data;
using ClosedXML.Excel;
using PlasticPackagingPortal.Web.Extensions;
using PlasticPackagingPortal.Web.Models.Data;
using PlasticPackagingPortal.Web.Models.Dto;
using PlasticPackagingPortal.Web.Models.Generic;
using Microsoft.EntityFrameworkCore;
using PlasticPackagingPortal.Web.Models.DataTables;

namespace PlasticPackagingPortal.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var model = new HomePageViewModel()
            {
                Filter = HomePageViewModel.ItemFilterType.Validated
            };
            return View(model);
        }

        public IActionResult Staging()
        {
            var model = new HomePageViewModel()
            {
                Filter = HomePageViewModel.ItemFilterType.Staging
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> OnFormLoad(Guid id)
        {
            var item = await _context.StagingItems.FirstOrDefaultAsync(x => x.Id == id);
            if(item == null)
                return NotFound("Item not found");

            try
            {
                var dto = item.ToStagingItemDto(_mapper);

                return Json(dto);
            }
            catch (Exception e)
            {
                return Problem("Item could not be loaded");
            }

        }

        [HttpPost]
        public async Task<IActionResult> OnTableLoad(int? typeId)
        {
            List<DtItem> items = new();
            switch (typeId)
            {
                default:
                case (int)HomePageViewModel.ItemFilterType.Validated:
                    var dbItems = await _context.Items.ToListAsync();
                    items.AddRange(dbItems.Select(x => x.ToDtItem(_mapper)));
                    break;
                case (int)HomePageViewModel.ItemFilterType.Staging:
                    var dbStagingItems = await _context.StagingItems.ToListAsync();
                    items.AddRange(dbStagingItems.Select(x => x.ToDtItem(_mapper)));
                    break;
            }

            var response = new
            {
                recordsTotal = items.Count,
                data = items
            };
            
            return Json(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStagingItem(StagingItemDto dto)
        {
            var item = await _context.StagingItems.FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (item == null)
            {
                return NotFound();
            }

            try
            {
                item.UpdateFromDto(dto);
                await _context.SaveChangesAsync();

                return Json(item.ToDtItem(_mapper));
            }
            catch (Exception e)
            {
                return Problem("Item could not be updated");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStagingItem([FromBody]List<string> ids)
        {
            var stagingItems = await _context.StagingItems.Where(x => ids.Select(Guid.Parse).Contains(x.Id)).ToListAsync();
            if (stagingItems.Count == 0)
            {
                return NotFound();
            }

            try
            {
                _context.StagingItems.RemoveRange(stagingItems);
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            catch (Exception e)
            {
                return Problem("Item could not be deleted");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteItem([FromBody]List<string> ids)
        {
            var items = await _context.Items.Where(x => ids.Select(Guid.Parse).Contains(x.Id)).ToListAsync();
            if (items.Count == 0)
            {
                return NotFound();
            }

            try
            {
                _context.Items.RemoveRange(items);
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            catch (Exception e)
            {
                return Problem("Item could not be deleted");
            }
        }

        [HttpPost]
        public async Task<IActionResult> StagingItemToItem([FromBody]List<string> ids)
        {
            var stagingItems = await _context.StagingItems.Where(x => ids.Select(Guid.Parse).Contains(x.Id)).ToListAsync();
            if (stagingItems.Count == 0)
            {
                return NotFound();
            }

            try
            {
                var items = stagingItems.Select(x => x.ToItem(_mapper)).ToList();

                _context.Items.AddRange(items);
                _context.StagingItems.RemoveRange(stagingItems);
                await _context.SaveChangesAsync();

                return Json(new { redirect = Url.Action("Index") });
            }
            catch (Exception e)
            {
                return Problem("Item could not be deleted");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ImportFile(IFormFile? file)
        {
            if (file == null)
                return Problem("File is null");

            using var workbook = new XLWorkbook(file.OpenReadStream());
            var itemsWorksheet = workbook.Worksheet("Items");
            var tagsWorksheet = workbook.Worksheet("Tags");
            var itemsTable = itemsWorksheet.Table("Items");
            var tagsTable = tagsWorksheet.Table("Tags");

            List<StagingItem> items = new();
            List<StagingTagDto> tags = new();

            try
            {
                //Get all items from the file
                items = itemsTable.DataRange.Rows().Where(x => !x.IsEmpty()).Select(x => x.ToStagingItem(_mapper)).ToList();
                //Get all tags from the file
                tags = tagsTable.DataRange.Rows().Where(x => !x.IsEmpty()).Select(x => x.ToStatingTagDto(_mapper)).ToList();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
            //Group tags by identifier and loop through them
            foreach (var group in tags.GroupBy(x => x.Identifier))
            {
                var item = items.FirstOrDefault(x => x.Identifier == group.Key);
                if (item == null)
                    return Problem($"Item with identifier {group.Key} not found");

                item.Tags.AddRange(group.Select(x => x.ToStagingTag(_mapper)));
            }

            try
            {
                await _context.AddRangeAsync(items);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }

            return RedirectToAction("Staging", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}