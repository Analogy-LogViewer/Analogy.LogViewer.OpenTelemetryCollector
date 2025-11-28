#if NET
using Analogy.Interfaces.DataTypes;
using OpenTelemetry.Proto.Logs.V1;
using OpenTelemetry.Proto.Metrics.V1;
using System;
using System.Collections.Generic;
using System.Text;

namespace Analogy.LogViewer.OpenTelemetryCollector.Otel
{
    public class LogRecordReporter
    {
        private static Lazy<LogRecordReporter> _instance = new Lazy<LogRecordReporter>(() => new LogRecordReporter());

        public static LogRecordReporter Instance { get; } = _instance.Value;

        public event EventHandler<(ResourceLogs ResourceLog, ScopeLogs ScopeLog, LogRecord LogRecord)>? NewLogRecord;
        public void RaiseNewMetric(ResourceLogs resourceLog, ScopeLogs scopeLog, LogRecord logRecord)
        {
            NewLogRecord?.Invoke(this, (resourceLog, scopeLog, logRecord));
        }
    }
}
#endif