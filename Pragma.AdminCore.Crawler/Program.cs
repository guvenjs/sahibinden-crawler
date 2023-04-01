using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pragma.AdminCore.Data;
using Pragma.AdminCore.Data.Models.Entities;
using Pragma.AdminCore.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Pragma.AdminCore.Crawler
{
    public class Program
    {

        //private readonly ApplicationDbContext _context;
        //private readonly UnitOfWork _uow;

        //public Program(ApplicationDbContext context)
        //{
        //    _context = context;
        //    _uow = new UnitOfWork(_context);
        //}
        private static ApplicationDbContext _context;

        static void Main(string[] args)
        {
            Console.WriteLine($"Starting at {DateTime.Now.ToString("HH.mm")}");


            while (true)
            {
                Console.WriteLine("Fetching");
                Process();
                Console.WriteLine($"Sleeping for {600000} milliseconds");
                Thread.Sleep(600000);
            }
        }

        static void Process()
        {

            var services = new ServiceCollection();

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("server=DESKTOP-2CU2CT6\\SQLEXPRESS;database=SahibindenCrawler;User Id=sa;Password=1234567890;MultipleActiveResultSets=true;"));

            var serviceProvider = services.BuildServiceProvider();
            _context = serviceProvider.GetService<ApplicationDbContext>();


            UnitOfWork _uow = new UnitOfWork(_context);
            var filter = _uow.GetRepository<Filter>().GetAvailable().FirstOrDefault();

            var pagingOffset = 0;
            while (true)
            {
                var html = string.Format(filter.Url, pagingOffset);

                HtmlWeb web = new HtmlWeb();

                var htmlDoc = web.Load(html);
                var resultTable = htmlDoc?.DocumentNode?.SelectNodes("//table")?.Where(x => x.Id == "searchResultsTable") ?? null;
                if (resultTable == null)
                {
                    break;
                }

                foreach (HtmlNode table in resultTable)
                {
                    Guid processId = Guid.NewGuid();
                    foreach (HtmlNode row in table.SelectNodes("//tr").Where(x => x.HasClass("searchResultsItem")))
                    {
                        string sId = row.GetDataAttribute("id")?.Value?.ToString() ?? string.Empty;
                        if (!string.IsNullOrEmpty(sId))
                        {
                            _uow.GetRepository<TempRecord>().Add(new TempRecord()
                            {
                                SahibindenId = sId,
                                ProcessId = processId,
                                FilterId = filter.Id,
                                ThumbnailImage = (row.SelectNodes("td")?.FirstOrDefault()?.SelectNodes("a")?.FirstOrDefault()?.SelectNodes("img")?.FirstOrDefault()?.GetAttributes("src")?.FirstOrDefault()?.Value ?? string.Empty).Trim(),
                                Brand = (row.SelectNodes("td")?[1]?.InnerText ?? string.Empty).Trim(),
                                Serie = (row.SelectNodes("td")?[2]?.InnerText ?? string.Empty).Trim(),
                                Model = (row.SelectNodes("td")?[3]?.InnerText ?? string.Empty).Trim(),
                                Title = (row.SelectNodes("td")?[4]?.InnerText ?? string.Empty).Trim(),
                                Year = (row.SelectNodes("td")?[5]?.InnerText ?? string.Empty).Trim(),
                                KM = (row.SelectNodes("td")?[6]?.InnerText ?? string.Empty).Trim(),
                                Color = (row.SelectNodes("td")?[7]?.InnerText ?? string.Empty).Trim(),
                                LivePrice = int.Parse((row.SelectNodes("td")?[8]?.InnerText ?? "0").Replace(" TL", "").Replace(".", "").Trim()),
                                ListingDate = (row.SelectNodes("td")?[9]?.InnerText ?? string.Empty).Trim(),
                                District = (row.SelectNodes("td")?[10]?.InnerText ?? string.Empty).Trim(),
                                Url = $"https://www.sahibinden.com/{sId}",
                            });
                        }
                    }
                }
                pagingOffset += 50;
            }


            var tempRecords = _uow.GetRepository<TempRecord>().GetAvailable().ToList();

            foreach (var temp in tempRecords)
            {
                var findRecord = _uow.GetRepository<Record>().GetAvailable().Where(x => x.SahibindenId == temp.SahibindenId).FirstOrDefault();
                if (findRecord == null)
                {
                    _uow.GetRepository<Record>().Add(new Record()
                    {
                        SahibindenId = temp.SahibindenId,
                        Brand = temp.Brand,
                        Serie = temp.Serie,
                        Model = temp.Model,
                        Title = temp.Title,
                        Year = temp.Year,
                        KM = temp.KM,
                        Color = temp.Color,
                        LivePrice = temp.LivePrice,
                        FirstPrice = temp.LivePrice,
                        ListingDate = temp.ListingDate,
                        District = temp.District,
                        Url = temp.Url,
                        FilterId = temp.FilterId,
                        IsActive = true,
                        LastCheckDate = DateTime.Now,
                        ThumbnailImage = temp.ThumbnailImage,
                    });
                }
                else
                {
                    if (findRecord.LivePrice != temp.LivePrice)
                    {
                        _uow.GetRepository<RecordPriceChanges>().Add(new RecordPriceChanges()
                        {
                            Price = temp.LivePrice,
                            RecordId = findRecord.Id,
                        });
                        findRecord.LivePrice = temp.LivePrice;
                    }
                    findRecord.LastCheckDate = DateTime.Now;
                    _uow.GetRepository<Record>().Update(findRecord);
                }
            }

            var findDeletedRecords = _uow.GetRepository<Record>().GetAvailable().Where(x => x.LastCheckDate < DateTime.Now.AddMinutes(-6)).ToList();

            foreach (var item in findDeletedRecords)
            {
                item.IsActive = false;
                _uow.GetRepository<Record>().Update(item);
            }

            var temps = _uow.GetRepository<TempRecord>().GetAvailable().Where(x => x.FilterId == filter.Id).ToList();
            _uow.GetRepository<TempRecord>().DeleteMultiplePermanently(temps);

            Console.WriteLine("--Finished--");
        }
    }
}
