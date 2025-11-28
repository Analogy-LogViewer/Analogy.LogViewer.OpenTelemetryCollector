using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Analogy.LogViewer.OpenTelemetryCollector.Properties;
using Analogy.LogViewer.Template.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Analogy.LogViewer.OpenTelemetryCollector.IAnalogy
{
    public class OtelpPrimaryFactory : PrimaryFactoryWinForms
    {
        internal static readonly Guid Id = new Guid("1F3CF785-D4E0-4F1D-BEEB-0457EB25A43E");
        public override Guid FactoryId { get; set; } = Id;

        public override string Title { get; set; } = "Otel Collector";
        public override Image? SmallImage { get; set; } = Resources.Analogy_image_16x16;
        public override Image? LargeImage { get; set; } = Resources.Analogy_image_32x32;

        public override IEnumerable<IAnalogyChangeLog> ChangeLog { get; set; } = new List<AnalogyChangeLog>
        {
            new AnalogyChangeLog("New Data provider", AnalogChangeLogType.None, "Lior Banai", new DateTime(2025, 11, 28), ""),
        };
        public override IEnumerable<string> Contributors { get; set; } = new List<string> { "Lior Banai" };
        public override string About { get; set; } = "Analogy Otel Collector Data Source";
    }
}