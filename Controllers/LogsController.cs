using MongoDB.Bson;
using Microsoft.AspNetCore.Mvc;
using DevOpsApp.Models;
using DevOpsApp.Services;
using MongoDB.Driver;
using System;
using System.Linq;

namespace DevOpsApp.Controllers
{
    public class LogsController : Controller
    {
        private readonly MongoDBService _mongoDBService;
        private const int PageSize = 10; // ✅ Show 10 logs per page

        public LogsController(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }

        public IActionResult Index(string query, string sort, DateTime? startDate, DateTime? endDate, int page = 1)
        {
            try
            {
                var logsCollection = _mongoDBService.GetCollection<LogEntry>("logs");

                // ✅ Filter logs by search query
                var filter = Builders<LogEntry>.Filter.Empty;
                if (!string.IsNullOrEmpty(query))
                {
                    filter = Builders<LogEntry>.Filter.Regex("message", new BsonRegularExpression(query, "i"));
                }

                // ✅ Add Date Range Filtering
                if (startDate.HasValue && endDate.HasValue)
                {
                    var dateFilter = Builders<LogEntry>.Filter.And(
                        Builders<LogEntry>.Filter.Gte(log => log.Timestamp, startDate.Value),
                        Builders<LogEntry>.Filter.Lte(log => log.Timestamp, endDate.Value));
                    
                    filter = Builders<LogEntry>.Filter.And(filter, dateFilter);
                }

                // ✅ Count total logs directly in MongoDB (faster than fetching first)
                int totalLogs = (int)logsCollection.CountDocuments(filter);
                int totalPages = (int)Math.Ceiling((double)totalLogs / PageSize);

                var logs = logsCollection.Find(filter)
                    .Sort(sort switch
                    {
                        "Id" => Builders<LogEntry>.Sort.Ascending(l => l.Id),
                        "Message" => Builders<LogEntry>.Sort.Ascending(l => l.Message),
                        _ => Builders<LogEntry>.Sort.Descending(l => l.Timestamp)
                    })
                    .Skip((page - 1) * PageSize)
                    .Limit(PageSize)
                    .ToList();

                // ✅ Send values to the View
                ViewBag.SearchQuery = query;
                ViewBag.Sort = sort;
                ViewBag.StartDate = startDate?.ToString("yyyy-MM-dd");
                ViewBag.EndDate = endDate?.ToString("yyyy-MM-dd");
                ViewBag.CurrentPage = page;
                ViewBag.TotalPages = totalPages;

                return View(logs);
            }
            catch (Exception ex)
            {
                return Content($"MongoDB connection error: {ex.Message}");
            }
        }
    }
}
