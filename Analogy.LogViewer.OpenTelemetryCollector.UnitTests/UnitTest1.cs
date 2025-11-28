using Analogy.Interfaces.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Analogy.LogViewer.OpenTelemetryCollector.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            TaskCompletionSource<AnalogyLogMessage> taskReceived = new();

            Analogy.LogViewer.OpenTelemetryCollector.Otel.OtelGrpcHosting.InitializeIfNeeded();
            Analogy.LogViewer.OpenTelemetryCollector.Otel.MetricReporter.Instance.NewMetric += (s, e) =>
            {
                AnalogyLogMessage m = new AnalogyLogMessage
                {
                    Text = e.ToString(),
                    Level = AnalogyLogLevel.Information,
                    Class = AnalogyLogClass.General,
                    Source = e.Description,
                    User = Environment.UserName,
                    Module = "",
                    MachineName = Environment.MachineName,
                    ThreadId = Thread.CurrentThread.ManagedThreadId,
                };
                taskReceived.TrySetResult(m);
            };
            var metric = await taskReceived.Task;
            Assert.IsNotNull(metric);
        }
    }
}