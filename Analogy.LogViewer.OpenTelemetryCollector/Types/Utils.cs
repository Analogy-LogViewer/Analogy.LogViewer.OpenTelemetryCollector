using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Analogy.LogViewer.OpenTelemetryCollector.Types
{
    public static class Utils
    {
#if NET
        public static string GetServiceNameFromMetricResource(OpenTelemetry.Proto.Metrics.V1.ResourceMetrics resourceMetric)
        {
            var service = resourceMetric.Resource.Attributes.FirstOrDefault(a => a.Key.Equals("service.name"));
            var key = service?.Value.StringValue ?? "";
            return key;
        }
#endif
    }
}