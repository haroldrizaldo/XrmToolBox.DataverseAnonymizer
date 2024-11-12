using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using XrmToolBox.DataverseAnonymizer.Models;

namespace XrmToolBox.DataverseAnonymizer.Helpers
{
    public static class CrmHelper
    {
        
        public static FieldIdAndValue[] GetAllIdAndValues(IOrganizationService orgService, string entityName, string idField, string[] fieldNames, string fetchXmlFilter)
        {
            QueryExpression query = null;

            if (fetchXmlFilter == null)
            {
                query = new QueryExpression(entityName);
                query.NoLock = true;
            }
            else
            {
                query = GetQueryFromFilter(orgService, fetchXmlFilter);

                if (query.EntityName != entityName)
                {
                    throw new Exception($"FetchXML filter is on the wrong table. Excpected \"{entityName}\", got \"{query.EntityName}\".");
                }
            }

            var columns = new List<string> { idField };
            if (fieldNames != null)
            {
                columns.AddRange(fieldNames);
            }

            query.ColumnSet = new ColumnSet(columns.ToArray());
            query.PageInfo = new PagingInfo
            {
                PageNumber = 1,
                Count = 5000
            };
            query.TopCount = null;

            List<FieldIdAndValue> result = new List<FieldIdAndValue>();

            int pageNr = 1;

            while (true)
            {
                EntityCollection ecoll = orgService.RetrieveMultiple(query);

                result.AddRange(
                    ecoll.Entities.Select(e => new FieldIdAndValue
                    {
                        PrimaryId = e.Id,
                        FieldValues = fieldNames?.ToDictionary(fieldName => fieldName, fieldName => e.Contains(fieldName) ? e[fieldName] : null)
                    })
                );

                if (!ecoll.MoreRecords)
                {
                    break;
                }

                pageNr++;
                query.PageInfo.PageNumber = pageNr;
                query.PageInfo.PagingCookie = ecoll.PagingCookie;
            }

            return result.ToArray();
        }

        private static QueryExpression GetQueryFromFilter(IOrganizationService orgService, string fetchXmlFilter)
        {
            FetchXmlToQueryExpressionRequest convertReq = new FetchXmlToQueryExpressionRequest()
            {
                FetchXml = fetchXmlFilter
            };
            FetchXmlToQueryExpressionResponse convertResp = (FetchXmlToQueryExpressionResponse)orgService.Execute(convertReq);

            return convertResp.Query;
        }
    }
}
