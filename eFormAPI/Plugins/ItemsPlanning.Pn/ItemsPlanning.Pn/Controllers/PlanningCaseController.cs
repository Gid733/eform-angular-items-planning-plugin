/*
The MIT License (MIT)

Copyright (c) 2007 - 2020 Microting A/S

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

namespace ItemsPlanning.Pn.Controllers
{
    using System;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;
    using Infrastructure.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microting.eFormApi.BasePn.Infrastructure.Helpers;
    using Microting.eFormApi.BasePn.Infrastructure.Models.API;
    using Services.PlanningCaseService;

    [Authorize]
    public class PlanningCaseController : Controller
    {
        private readonly IPlanningCaseService _planningCaseService;

        public PlanningCaseController(IPlanningCaseService planningCaseService)
        {
            _planningCaseService = planningCaseService;
        }


        [HttpGet]
        [Route("api/items-planning-pn/plannings-cases/")]
        public async Task<OperationDataResult<PlanningCasesModel>> GetSinglePlanning(PlanningCasesPnRequestModel requestModel)
        {
            return await _planningCaseService.GetSinglePlanningCase(requestModel);
        }

        [HttpGet]
        [Route("api/items-planning-pn/plannings-case-results")]
        public async Task<OperationDataResult<PlanningCaseResultListModel>> GetSingleListResults(PlanningCasesPnRequestModel requestModel)
        {
            return await _planningCaseService.GetSingleCaseResults(requestModel);
        }

        [HttpGet]
        [Route("api/items-planning-pn/plannings-cases/{id}/{caseId}")]
        public async Task<OperationDataResult<PlanningItemCaseModel>> GetSingleCase(int caseId)
        {
            return await _planningCaseService.GetSingleCase(caseId);
        }

        [HttpGet]
        [Route("api/items-planning-pn/plannings-case-file-report/{caseId}")]
        [AllowAnonymous]
        public async Task<IActionResult> ItemListCaseResult(int caseId, string token, string fileType)
        {
            try {
                string filePath = await _planningCaseService.DownloadEFormPdf(caseId, token, fileType);
                
                if (!System.IO.File.Exists(filePath))
                {
                    return NotFound();
                }
                var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                if (fileType == "pdf")
                {
                    return File(fileStream, "application/pdf", Path.GetFileName(filePath));
                }
                else
                {
                    return File(fileStream, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", Path.GetFileName(filePath));
                }
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid();
            }
            catch (Exception ex)
            {
                Log.LogException($"ItemsListCaseController.ItemListCaseResult: Got exception {ex.Message}");
                return BadRequest();
                
            }
        }
    }
}