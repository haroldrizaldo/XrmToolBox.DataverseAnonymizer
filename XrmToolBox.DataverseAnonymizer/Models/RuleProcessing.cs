using System;
using XrmToolBox.DataverseAnonymizer.Rules;

namespace XrmToolBox.DataverseAnonymizer.Models
{
    public class RuleProcessing
    {
        public RuleProcessing(string tableLogicalName, string primaryIdFieldLogicalName, string[] tableFieldName, AnonymizationRule[] rules, string fetchXmlFilter)
        {
            this.TableLogicalName = tableLogicalName ?? throw new ArgumentNullException(nameof(tableLogicalName));
            this.PrimaryIdFieldLogicalName = primaryIdFieldLogicalName ?? throw new ArgumentNullException(nameof(primaryIdFieldLogicalName));
            this.TableFieldName = tableFieldName ?? throw new ArgumentNullException(nameof(tableFieldName));
            this.Rules = rules ?? throw new ArgumentNullException(nameof(rules));
            FetchXmlFilter = fetchXmlFilter;

        }


        public string TableLogicalName { get; set; }

        public string PrimaryIdFieldLogicalName { get; set; }

        public string[] TableFieldName { get; set; }

        public AnonymizationRule[] Rules { get; set; }

        public FieldIdAndValue[] FieldIdsAndValues { get; set; }

        public string FetchXmlFilter { get; set; }

    }
}
