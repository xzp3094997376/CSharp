using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        CancellationTokenSource _cancellationTokenSource;
        CancellationToken _cancellationToken;
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btn_ProcessClick(object sender,RoutedEventArgs e)
        {
            btnProcess.IsEnabled = false;            
            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSource.Token;
            int completePercent=0;
            for (int i = 0; i < 10; i++)
            {
                if (_cancellationToken.IsCancellationRequested)
                {
                    break;
                }
                try
                {
                    await Task.Delay(500, _cancellationToken);
                    completePercent = (i + 1) * 10;
                }
                catch (TaskCanceledException ex)
                {
                    completePercent = i * 10;                  
                }
                ProcesBar.Value = completePercent;             
            }
            string msg = _cancellationToken.IsCancellationRequested ? string.Format("process was canceld at {0}%.", completePercent) : "process was completed";
            MessageBox.Show(msg, " completetion");
            ProcesBar.Value = 0;
            btnProcess.IsEnabled = true;
            btnCancel.IsCancel = true;
        }
        private void btn_CancelClick(object sender,RoutedEventArgs e)
        {
            if (!btnProcess.IsEnabled)
            {
                btnCancel.IsEnabled = false;
                _cancellationTokenSource.Cancel();
            }
        }
    }
}
