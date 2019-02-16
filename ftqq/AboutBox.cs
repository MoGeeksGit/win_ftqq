using System;
using System.Reflection;
using System.Windows.Forms;

namespace ftqq
{
    partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
            //this.Text = String.Format("关于1 {0}", AssemblyTitle);
            this.Text = "关于方糖气球";
            //this.labelProductName.Text = AssemblyProduct + "2";
            this.labelProductName.Text = "Server 酱:";
            //this.labelVersion.Text = String.Format("版本3 {0}", AssemblyVersion);
            this.labelVersion.Text = "http://sc.ftqq.com";
            //this.labelCopyright.Text = AssemblyCopyright + "4";
            this.labelCopyright.Text = "";
            //this.labelCompanyName.Text = AssemblyCompany + "5";
            this.labelCompanyName.Text = "";
            //this.textBoxDescription.Text = AssemblyDescription + "6";
            this.textBoxDescription.Text = "在 SCKEY 栏填入对应的参数即可发送信息到微信，\n详细的信息请点击上方网址获取。";
        }

        #region 程序集特性访问器

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private void LabelVersion_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "http://sc.ftqq.com");
            OkButton_Click(sender, e);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
