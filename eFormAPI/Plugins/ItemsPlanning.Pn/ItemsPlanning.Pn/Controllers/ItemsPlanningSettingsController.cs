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
    using System.Threading.Tasks;
    using Infrastructure.Models.Settings;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microting.eFormApi.BasePn.Infrastructure.Database.Entities;
    using Microting.eFormApi.BasePn.Infrastructure.Models.API;
    using Services.ItemsPlanningPnSettingsService;

    public class ItemsPlanningSettingsController : Controller
    {
        private readonly IItemsPlanningPnSettingsService _itemsPlanningPnSettingsService;

        public ItemsPlanningSettingsController(IItemsPlanningPnSettingsService itemsPlanningPnSettingsService)
        {
            _itemsPlanningPnSettingsService = itemsPlanningPnSettingsService;
        }

        [HttpGet]
        [Authorize(Roles = EformRole.Admin)]
        [Route("api/items-planning-pn/settings")]
        public async Task<OperationDataResult<ItemsPlanningBaseSettings>> GetSettings()
        {
            return await _itemsPlanningPnSettingsService.GetSettings();
        }
        
        [HttpPost]
        [Authorize(Roles = EformRole.Admin)]
        [Route("api/items-planning-pn/settings")]
        public async Task<OperationResult> UpdateSettings([FromBody] ItemsPlanningBaseSettings itemsPlanningBaseSettings)
        {
            return await _itemsPlanningPnSettingsService.UpdateSettings(itemsPlanningBaseSettings);
        }

    }
}