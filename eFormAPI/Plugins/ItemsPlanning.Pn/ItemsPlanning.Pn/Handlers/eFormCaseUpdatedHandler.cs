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

namespace ItemsPlanning.Pn.Handlers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Messages;
    using Microsoft.EntityFrameworkCore;
    using Microting.eForm.Infrastructure.Constants;
    using Microting.eForm.Infrastructure.Models;
    using Microting.ItemsPlanningBase.Infrastructure.Data;
    using Microting.ItemsPlanningBase.Infrastructure.Data.Entities;
    using Rebus.Handlers;

    // ReSharper disable once InconsistentNaming
    public class eFormCaseUpdatedHandler : IHandleMessages<eFormCaseUpdated>
    {
        private readonly eFormCore.Core _sdkCore;
        private readonly ItemsPlanningPnDbContext _dbContext;

        public eFormCaseUpdatedHandler(eFormCore.Core sdkCore, ItemsPlanningPnDbContext dbContext)
        {
            _dbContext = dbContext;
            _sdkCore = sdkCore;
        }
        
        public async Task Handle(eFormCaseUpdated message)
        {
            PlanningCaseSite planningCaseSite = await _dbContext.PlanningCaseSites.SingleOrDefaultAsync(x => x.MicrotingSdkCaseId == message.caseId);
            
            if (planningCaseSite != null)
            {
                var caseDto = await _sdkCore.CaseReadByCaseId(message.caseId);
                var microtingUId = caseDto.MicrotingUId;
                var microtingCheckUId = caseDto.CheckUId;
                var theCase = await _sdkCore.CaseRead((int)microtingUId, (int)microtingCheckUId);

                planningCaseSite = await SetFieldValue(planningCaseSite, theCase.Id);

                await planningCaseSite.Update(_dbContext);

                PlanningCase planningCase = await _dbContext.PlanningCases.SingleOrDefaultAsync(x => x.Id == planningCaseSite.PlanningCaseId);

                planningCase = await SetFieldValue(planningCase, theCase.Id);
                await planningCase.Update(_dbContext);
            }
        }
        
        private async Task<PlanningCaseSite> SetFieldValue(PlanningCaseSite planningCaseSite, int caseId)
        {
            Item item = _dbContext.Items.SingleOrDefault(x => x.Id == planningCaseSite.ItemId);
            Planning planning = _dbContext.Plannings.SingleOrDefault(x => x.Id == item.PlanningId);
            List<int> caseIds = new List<int>();
            caseIds.Add(planningCaseSite.MicrotingSdkCaseId);
            List<FieldValue> fieldValues = await _sdkCore.Advanced_FieldValueReadList(caseIds);

            if (planning == null) return planningCaseSite;

            if (planning.SdkFieldEnabled1)
            {
                planningCaseSite.SdkFieldValue1 =
                    fieldValues.SingleOrDefault(x => x.FieldId == planning.SdkFieldId1)?.ValueReadable;
            }
            if (planning.SdkFieldEnabled2)
            {
                planningCaseSite.SdkFieldValue2 =
                    fieldValues.SingleOrDefault(x => x.FieldId == planning.SdkFieldId2)?.ValueReadable;
            }
            if (planning.SdkFieldEnabled3)
            {
                planningCaseSite.SdkFieldValue3 =
                    fieldValues.SingleOrDefault(x => x.FieldId == planning.SdkFieldId3)?.ValueReadable;
            }
            if (planning.SdkFieldEnabled4)
            {
                planningCaseSite.SdkFieldValue4 =
                    fieldValues.SingleOrDefault(x => x.FieldId == planning.SdkFieldId4)?.ValueReadable;
            }
            if (planning.SdkFieldEnabled5)
            {
                planningCaseSite.SdkFieldValue5 =
                    fieldValues.SingleOrDefault(x => x.FieldId == planning.SdkFieldId5)?.ValueReadable;
            }
            if (planning.SdkFieldEnabled6)
            {
                planningCaseSite.SdkFieldValue6 =
                    fieldValues.SingleOrDefault(x => x.FieldId == planning.SdkFieldId6)?.ValueReadable;
            }
            if (planning.SdkFieldEnabled7)
            {
                planningCaseSite.SdkFieldValue7 =
                    fieldValues.SingleOrDefault(x => x.FieldId == planning.SdkFieldId7)?.ValueReadable;
            }
            if (planning.SdkFieldEnabled8)
            {
                planningCaseSite.SdkFieldValue8 =
                    fieldValues.SingleOrDefault(x => x.FieldId == planning.SdkFieldId8)?.ValueReadable;
            }
            if (planning.SdkFieldEnabled9)
            {
                planningCaseSite.SdkFieldValue9 =
                    fieldValues.SingleOrDefault(x => x.FieldId == planning.SdkFieldId9)?.ValueReadable;
            }
            if (planning.SdkFieldEnabled10)
            {
                planningCaseSite.SdkFieldValue10 =
                    fieldValues.SingleOrDefault(x => x.FieldId == planning.SdkFieldId10)?.ValueReadable;
            }
            if (planning.NumberOfImagesEnabled)
            {
                planningCaseSite.NumberOfImages = 0;
                foreach (FieldValue fieldValue in fieldValues)
                {
                    if (fieldValue.FieldType == Constants.FieldTypes.Picture)
                    {
                        if (fieldValue.UploadedData != null)
                        {
                            planningCaseSite.NumberOfImages += 1;
                        }
                    }
                }
            }

            return planningCaseSite;
        }

        private async Task<PlanningCase> SetFieldValue(PlanningCase planningCase, int caseId)
        {
            Item item = _dbContext.Items.SingleOrDefault(x => x.Id == planningCase.ItemId);
            Planning planning = _dbContext.Plannings.SingleOrDefault(x => x.Id == item.PlanningId);
            List<int> caseIds = new List<int>
            {
                planningCase.MicrotingSdkCaseId
            };

            List<FieldValue> fieldValues = await _sdkCore.Advanced_FieldValueReadList(caseIds);

            if (planning == null) return planningCase;

            if (planning.SdkFieldEnabled1)
            {
                planningCase.SdkFieldValue1 =
                    fieldValues.SingleOrDefault(x => x.FieldId == planning.SdkFieldId1)?.ValueReadable;
            }
            if (planning.SdkFieldEnabled2)
            {
                planningCase.SdkFieldValue2 =
                    fieldValues.SingleOrDefault(x => x.FieldId == planning.SdkFieldId2)?.ValueReadable;
            }
            if (planning.SdkFieldEnabled3)
            {
                planningCase.SdkFieldValue3 =
                    fieldValues.SingleOrDefault(x => x.FieldId == planning.SdkFieldId3)?.ValueReadable;
            }
            if (planning.SdkFieldEnabled4)
            {
                planningCase.SdkFieldValue4 =
                    fieldValues.SingleOrDefault(x => x.FieldId == planning.SdkFieldId4)?.ValueReadable;
            }
            if (planning.SdkFieldEnabled5)
            {
                planningCase.SdkFieldValue5 =
                    fieldValues.SingleOrDefault(x => x.FieldId == planning.SdkFieldId5)?.ValueReadable;
            }
            if (planning.SdkFieldEnabled6)
            {
                planningCase.SdkFieldValue6 =
                    fieldValues.SingleOrDefault(x => x.FieldId == planning.SdkFieldId6)?.ValueReadable;
            }
            if (planning.SdkFieldEnabled7)
            {
                planningCase.SdkFieldValue7 =
                    fieldValues.SingleOrDefault(x => x.FieldId == planning.SdkFieldId7)?.ValueReadable;
            }
            if (planning.SdkFieldEnabled8)
            {
                planningCase.SdkFieldValue8 =
                    fieldValues.SingleOrDefault(x => x.FieldId == planning.SdkFieldId8)?.ValueReadable;
            }
            if (planning.SdkFieldEnabled9)
            {
                planningCase.SdkFieldValue9 =
                    fieldValues.SingleOrDefault(x => x.FieldId == planning.SdkFieldId9)?.ValueReadable;
            }
            if (planning.SdkFieldEnabled10)
            {
                planningCase.SdkFieldValue10 =
                    fieldValues.SingleOrDefault(x => x.FieldId == planning.SdkFieldId10)?.ValueReadable;
            }
            if (planning.NumberOfImagesEnabled)
            {
                planningCase.NumberOfImages = 0;
                foreach (FieldValue fieldValue in fieldValues)
                {
                    if (fieldValue.FieldType == Constants.FieldTypes.Picture)
                    {
                        if (fieldValue.UploadedData != null)
                        {
                            planningCase.NumberOfImages += 1;
                        }
                    }
                }
            }

            return planningCase;
        }
    }
}