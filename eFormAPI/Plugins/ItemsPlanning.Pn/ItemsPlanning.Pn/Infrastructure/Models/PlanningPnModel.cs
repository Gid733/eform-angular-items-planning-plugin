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

namespace ItemsPlanning.Pn.Infrastructure.Models
{
    using System;
    using System.Collections.Generic;
    using Microting.ItemsPlanningBase.Infrastructure.Enums;

    public class PlanningPnModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public int RepeatEvery { get; set; }
        
        public RepeatType RepeatType { get; set; }
        
        public DateTime? RepeatUntil { get; set; }
        
        public DayOfWeek? DayOfWeek { get; set; }
        
        public int? DayOfMonth { get; set; }
        
        public DateTime? LastExecutedTime { get; set; }
        
        public int RelatedEFormId { get; set; }
        
        public string RelatedEFormName { get; set; }
        
        public bool LabelEnabled { get; set; }
        
        public bool DescriptionEnabled { get; set; }
        
        public bool DeployedAtEnabled { get; set; }

        public bool DoneAtEnabled { get; set; }

        public bool DoneByUserNameEnabled { get; set; }

        public bool UploadedDataEnabled { get; set; }
        
        public bool ItemNumberEnabled { get; set; }
        
        public bool LocationCodeEnabled { get; set; }
        
        public bool BuildYearEnabled { get; set; }
        
        public bool TypeEnabled { get; set; }
        
        public bool NumberOfImagesEnabled { get; set; }

        public string SdkFolderName { get; set; }

        public PlanningItemModel Item { get; set; }
            = new PlanningItemModel();

        public List<PlanningAssignedSitesModel> AssignedSites { get; set; }
            = new List<PlanningAssignedSitesModel>();
    }
}