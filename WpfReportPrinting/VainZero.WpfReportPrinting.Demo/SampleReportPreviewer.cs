using Reactive.Bindings;
using VainZero.WpfReportPrinting.Demo.Previewing;
using VainZero.WpfReportPrinting.Demo.Reports;

namespace VainZero.WpfReportPrinting.Demo
{
    public sealed class SampleReportPreviewer
    {
        public Previewer Previewer { get; }
        public SampleReportPreviewer()
        {
            Previewer = new Previewer(new ReactiveProperty<OrderForm>(new OrderForm()));
        }
    }
}
