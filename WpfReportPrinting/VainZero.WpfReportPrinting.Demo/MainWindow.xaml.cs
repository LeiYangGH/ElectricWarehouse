using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VainZero.Windows.Documents;
using VainZero.WpfReportPrinting.Demo.Reports;

namespace VainZero.WpfReportPrinting.Demo
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        OrderForm orderForm;
        private Size a4size;
        public MainWindow()
        {
            InitializeComponent();
            this.orderForm = new OrderForm();
            this.a4size = this.A4Size();
        }


        private Size A4Size()
        {
            var dpi = 96.0;
            var dpmm = 0.03937 * dpi;
            var width = 210 * dpmm;
            var height = 297 * dpmm;
            var size = new Size(width, height);
            return size;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            this.lbpages.ItemsSource = this.orderForm.Paginate(this.a4size);
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            var document = this.orderForm.ToFixedDocument(this.a4size);

            var printServer = new LocalPrintServer();
            var queue = printServer.DefaultPrintQueue;
            queue.DefaultPrintTicket.PageMediaSize =
                new PageMediaSize(this.a4size.Width, this.a4size.Height);

            var writer = PrintQueue.CreateXpsDocumentWriter(queue);
            writer.Write(document);
        }
    }
}
