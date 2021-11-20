using System;
using System.Web.Mvc;
using TechnicalTest.ViewModels;

namespace TechnicalTest.Controllers
{
    public class ImportController : Controller
    {
        private readonly Helpers.CsvHelper _csvHelper;
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public ImportController()
        {
            _csvHelper = new Helpers.CsvHelper();
        }

        // GET: Import
        public ActionResult ImportResults()
        {
            var importResultsViewModel = new ImportResultsViewModel();
            return View(importResultsViewModel);
        }

        [HttpPost]
        public ActionResult ImportResults(ImportResultsViewModel model)
        {
            try
            {
                Logger.Info($"Import results post started");

                if (model.File != null && model.File.ContentLength > 0)
                {
                    if (model.File.FileName.EndsWith(".csv"))
                    {
                        var results = _csvHelper.UploadCsvFile(model.File);
                        Session["results"] = results;
                        model.Response = SuccessResponse($"File Uploaded with {results.Count} results");
                    }
                    else
                    {
                        model.Response = FailResponse("File needs to be a csv.");
                    }
                }
                else
                {
                    model.Response = FailResponse("The file is empty.");
                }
            }
            catch (Exception e)
            {
                Logger.Error($"Import failed. Error message is as follows --> {e.Message}");
                model.Response = FailResponse("Unable to import file, please check the format and retry");
            }
            return View(model);
        }

        private FileUploadResponse FailResponse(string message)
        {
            var response = new FileUploadResponse
            {
                Status = FileUploadResponseStatus.Fail,
                Message = message
            };
            return response;
        }

        private FileUploadResponse SuccessResponse(string message)
        {
            FileUploadResponse response = new FileUploadResponse
            {
                Status = FileUploadResponseStatus.Success,
                Message = message
            };
            return response;
        }
    }
}