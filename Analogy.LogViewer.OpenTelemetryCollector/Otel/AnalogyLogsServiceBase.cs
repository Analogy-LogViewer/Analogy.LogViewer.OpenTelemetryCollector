#if NET
using Grpc.Core;
using OpenTelemetry.Proto.Collector.Logs.V1;
using OpenTelemetry.Proto.Logs.V1;
using OpenTelemetry.Proto.Metrics.V1;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Analogy.LogViewer.OpenTelemetryCollector.Otel
{
    public class AnalogyLogsServiceBase: LogsService.LogsServiceBase
    {
        public override Task<ExportLogsServiceResponse> Export(ExportLogsServiceRequest request, ServerCallContext context)
        {
            foreach (ResourceLogs? resourceLog in request.ResourceLogs)
            {
                foreach (ScopeLogs? scopeLog in resourceLog.ScopeLogs)
                {
                    foreach (LogRecord logRecord in scopeLog.LogRecords)
                    {
                        LogRecordReporter.Instance.RaiseNewMetric(resourceLog, scopeLog, logRecord);
                    }
                }
            }

            return Task.FromResult(new ExportLogsServiceResponse());
        }
    }
}
#endif