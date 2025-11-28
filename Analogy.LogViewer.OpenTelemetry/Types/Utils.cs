#if NET
using OpenTelemetry.Proto.Metrics.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Analogy.LogViewer.OpenTelemetry.Types
{
    public static class Utils
    {
        public static string GetServiceNameFromMetricResource(ResourceMetrics resourceMetric)
        {
            var service = resourceMetric.Resource.Attributes.FirstOrDefault(a => a.Key.Equals("service.name"));
            var key = service?.Value.StringValue ?? "";
            return key;
        }
    }
}
#endif