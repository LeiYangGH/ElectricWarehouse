using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Windows.Input;
using Reactive.Bindings;
using VainZero.Windows.Documents;
using VainZero.WpfReportPrinting.Demo.Printing;
using VainZero.WpfReportPrinting.Demo.Reports;
using System.Printing;
using System.Windows;

namespace VainZero.WpfReportPrinting.Demo.Previewing
{
    public sealed class Previewer
    {
        public IReadOnlyReactiveProperty<OrderForm> Report { get; }

        public IReadOnlyReactiveProperty<IReadOnlyList<object>> Pages { get; }

        readonly ReactiveCommand printCommand =
            new ReactiveCommand();

        public ICommand PrintCommand => printCommand;

        public MediaSizeSelector MediaSizeSelector { get; } =
            new MediaSizeSelector();

        public void Print()
        {
            var report = Report.Value;
            var pageSize = MediaSizeSelector.SelectedItem.Value.Size;

            this.Print(report, pageSize);

        }

        private void Print(IPaginatable paginatable, Size pageSize)
        {
            var document = paginatable.ToFixedDocument(pageSize);

            var printServer = new LocalPrintServer();
            var queue = printServer.DefaultPrintQueue;
            queue.DefaultPrintTicket.PageMediaSize =
                new PageMediaSize(pageSize.Width, pageSize.Height);

            var writer = PrintQueue.CreateXpsDocumentWriter(queue);
            writer.Write(document);
        }

        public Previewer(IReadOnlyReactiveProperty<OrderForm> report)
        {
            Report = report;

            Pages =
                Report.CombineLatest(
                    MediaSizeSelector.SelectedSize,
                    (r, pageSize) => r.Paginate(pageSize)
                )
                .ToReadOnlyReactiveProperty();

            // 印刷ボタンが押されたら印刷する。
            printCommand.Subscribe(_ => Print());
        }
    }
}
