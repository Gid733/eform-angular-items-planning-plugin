﻿using System.Collections.Generic;

namespace ItemsPlanning.Pn.Infrastructure.Models.Report
{
    public class ReportFormFieldModel
    {
        public int DataItemId { get; set; }
        public string Label { get; set; }
        public List<ReportFormFieldOptionModel> Options { get; set; } =
            new List<ReportFormFieldOptionModel>();
    }
}
