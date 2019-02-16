using System.Text;
using System.Windows;
using System.Windows.Media;
using System.IO;
using System.Net;

namespace ftqq
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();


        }

        private void Bt_send_Click(object sender, RoutedEventArgs e)
        {
            Tb_result_TextChange("wait");
            string result = HttpPost(tb_text.Text, tb_desp.Text);
            Tb_result_TextChange(result);
        }

        private string HttpPost(string tb_text, string tb_desp)
        {
            var request = (HttpWebRequest)WebRequest.Create("https://sc.ftqq.com/" + tb_sckey.Text + ".send");

            var postData = "text=" + tb_text;
            postData += "&desp=" + tb_desp;
            var data = Encoding.UTF8.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded;charset=utf8";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            var responeString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return responeString;
            //throw new NotImplementedException();
        }

        private void Tb_result_TextChange(string text)
        {
            switch (text)
            {
                case "wait":
                    tb_result.Text = "wait...";
                    tb_result.Foreground = new SolidColorBrush(Colors.Black);
                    break;
                case "{\"errno\":0,\"errmsg\":\"success\",\"dataset\":\"done\"}":
                    tb_result.Text = "Success!";
                    tb_result.Foreground = new SolidColorBrush(Colors.Green);
                    break;
                default:
                    tb_result.Text = text;
                    tb_result.Foreground = new SolidColorBrush(Colors.Red);
                    break;
            }

        }

        private void Bt_about_Click(object sender, RoutedEventArgs e)
        {
            AboutBox about = new AboutBox();
            about.Show();
        }
    }
}
