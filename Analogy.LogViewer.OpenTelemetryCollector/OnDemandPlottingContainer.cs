using Analogy.Interfaces;
using Analogy.LogViewer.OpenTelemetryCollector.IAnalogy;
using System;

namespace Analogy.LogViewer.OpenTelemetryCollector
{
    public class OnDemandPlottingContainer
    {
        private static readonly Lazy<OnDemandPlottingContainer> _instance =
            new Lazy<OnDemandPlottingContainer>(() => new OnDemandPlottingContainer());

        public static OnDemandPlottingContainer Instance => _instance.Value;

        private ExampleOnDemandPlottingFactory AnalogyFactory { get; set; }

        public OnDemandPlottingContainer()
        {
        }

        public void SetFactory(ExampleOnDemandPlottingFactory analogyFactory)
        {
            AnalogyFactory = analogyFactory;
        }

        public void AddOnDemandPlotting(IAnalogyOnDemandPlotting plotGenerator)
        {
            AnalogyFactory.AddedOnDemandPlottingGenerator(plotGenerator);
        }
    }
}