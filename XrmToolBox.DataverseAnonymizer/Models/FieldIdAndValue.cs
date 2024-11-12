using System;
using System.Collections.Generic;

namespace XrmToolBox.DataverseAnonymizer.Models
{
    public class FieldIdAndValue
    {
        public string TableName { get; set; }
        public Guid PrimaryId { get; set; }

        // Dictionary to store multiple field names and values
        public Dictionary<string, object> FieldValues { get; set; }

        public FieldIdAndValue()
        {
            FieldValues = new Dictionary<string, object>();
        }
    }

}
