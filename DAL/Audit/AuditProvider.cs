using System;
using System.Collections.Generic;
using Core.Entities;
using KellermanSoftware.CompareNetObjects;
using Newtonsoft.Json;

namespace DAL.Audit
{
    public class AuditProvider : IAuditProvider
    {
        public AuditData Get<T>(T oldObj, T newObj)
        {
            var compObject = new CompareLogic();
            compObject.Config.MaxDifferences = 99;

            var compResult = compObject.Compare(oldObj, newObj);
            var deltaList = new List<AuditDelta>();

            foreach (var difference in compResult.Differences)
            {
                var delta = new AuditDelta()
                {
                    FieldName = difference.PropertyName,
                    ValueBefore = difference.Object1Value,
                    ValueAfter = difference.Object2Value
                };
                deltaList.Add(delta);
            }
            var auditData = new AuditData()
            {
                Action = "Update",
                DataModel = typeof(T).Name,
                ChangeDate = DateTime.Now,
                ValueBefore = JsonConvert.SerializeObject(oldObj),
                ValueAfter = JsonConvert.SerializeObject(newObj),
                Changes = JsonConvert.SerializeObject(deltaList)
            };
            return auditData;
        }
    }

    public interface IAuditProvider
    {
        AuditData Get<T>(T oldObj, T newObj);
    }
}