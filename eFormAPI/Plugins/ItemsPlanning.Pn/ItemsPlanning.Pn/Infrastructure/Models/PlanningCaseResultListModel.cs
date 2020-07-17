using System.Collections.Generic;

namespace ItemsPlanning.Pn.Infrastructure.Models
{
    public class PlanningCaseResultListModel
    {
        public int Total { get; set; }
        
        public List<PlanningCaseResultModel> Items { get; set; }
            = new List<PlanningCaseResultModel>();
        
        public bool FieldEnabled1 { get; set; }

        public bool FieldEnabled2 { get; set; }

        public bool FieldEnabled3 { get; set; }

        public bool FieldEnabled4 { get; set; }

        public bool FieldEnabled5 { get; set; }

        public bool FieldEnabled6 { get; set; }

        public bool FieldEnabled7 { get; set; }

        public bool FieldEnabled8 { get; set; }

        public bool FieldEnabled9 { get; set; }

        public bool FieldEnabled10 { get; set; }
        
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
        
        public string FieldName1 { get; set; }

        public string FieldName2 { get; set; }

        public string FieldName3 { get; set; }

        public string FieldName4 { get; set; }

        public string FieldName5 { get; set; }

        public string FieldName6 { get; set; }

        public string FieldName7 { get; set; }

        public string FieldName8 { get; set; }

        public string FieldName9 { get; set; }

        public string FieldName10 { get; set; }
        
        public int SdkeFormId { get; set; }
    }
}