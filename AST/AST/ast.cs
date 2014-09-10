using System;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Security.Cryptography;//引入密码术名字空间
using System.Text;
using System.Windows.Forms;


namespace AST
{
    public partial class ast : Form
    {
        public ast()
        {
            InitializeComponent();
        }
        /* Autor：Chias
         * Site:http://www.chias.me
         * Github:https://github.com/ChIaSg/AST
         * Project:AST
         */
        public static string Encrypt(string key_32, string toEncrypt) // 传入一个待加密的字符串，返回加密后的字符串
        {

            byte[] keyArray = ASCIIEncoding.ASCII.GetBytes(key_32);
            byte[] toEncryptArray = ASCIIEncoding.ASCII.GetBytes(toEncrypt);
            RijndaelManaged a = new RijndaelManaged();
            a.Key = keyArray;
            a.Mode = CipherMode.ECB;
            a.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = a.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        public static string Decrypt(string key_32, string toDecrypt)
        {
            byte[] keyArray = ASCIIEncoding.ASCII.GetBytes(key_32);
            byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);
            RijndaelManaged a = new RijndaelManaged();
            a.Key = keyArray;
            a.Mode = CipherMode.ECB;
            a.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = a.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        public static int i = 0;
        public static int x = 0;
        private void hide_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void show_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void Chias_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.chias.me/");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            string targetFolder = ".\\" + textBox1.Text;
            string desktoppath = targetFolder + "\\" + "desktop.ini";
            string wzh = @".\回收站.{645ff040-5081-101b-9f08-00aa002f954e}";
            string user = "Users";
            string pw = targetFolder + "\\" + "astSetting.ini";
            if (textBox1.Text == "")
            {
                MessageBox.Show("你貌似忘了戴套了？", "出错！");
            }
            else if (Directory.Exists(wzh))
            {
                MessageBox.Show("此目录下已存在隐藏文件夹！", "警告！");
            }
            else if (Directory.Exists(targetFolder))
            {
                label1.Text = "程序执行中，请稍后......\r\n执行过程中请不要操作本程序以及强制停止本程序！\r\n花费的时间和文件数量成正比，零散文件越多，花费时间将会越长。";
                var key = "=9bn&2g=4By3^GrCsP;oVQat/*6o%l#R";//定义使用的密匙
                var jmh = Encrypt(key, textBox1.Text); //加密textBox1的文本
                if (File.Exists(pw))
                {
                    File.Delete(pw);
                }
                if (File.Exists(desktoppath))
                {
                    File.Delete(desktoppath);
                }
                try
                {
                    //写入desktop.ini文件
                    StreamWriter desktop = new StreamWriter(desktoppath, false, Encoding.Default);
                    desktop.WriteLine("[.ShellClassInfo]");
                    desktop.WriteLine("CLSID={645FF040-5081-101B-9F08-00AA002F954E}");
                    desktop.WriteLine("LocalizedResourceName=@%SystemRoot%\\system32\\shell32.dll,-8964");
                    desktop.Close();
                    //写入程序配置astSetting.ini文件
                    StreamWriter spw = new StreamWriter(pw, false, Encoding.UTF8);
                    spw.WriteLine(jmh);
                    spw.Close();
                    //设置文件夹所有者
                    DirectoryInfo ad = new DirectoryInfo(targetFolder);
                    DirectorySecurity adm = ad.GetAccessControl();
                    NTAccount admin = new NTAccount("Administrators");//管理员组
                    adm.SetOwner(admin);
                    //<--设置文件夹权限
                    System.Security.AccessControl.DirectorySecurity tf;
                    tf = new System.Security.AccessControl.DirectorySecurity();
                    tf.AddAccessRule(new FileSystemAccessRule(user, FileSystemRights.Read, AccessControlType.Deny));
                    System.IO.Directory.SetAccessControl(targetFolder, tf);
                    //设置权限是为了防止被第三方文件浏览器查看到-->
                    DirectoryInfo wz = new DirectoryInfo(targetFolder);
                    wz.MoveTo(wzh);                                                        //重命名文件夹以伪装成回收站
                    File.SetAttributes(wzh, FileAttributes.System | FileAttributes.Hidden); //隐藏为受保护的系统文件  
                    x = 1;
                }
                catch
                {
                    if (Directory.Exists(targetFolder))
                    {
                        File.SetAttributes(targetFolder, FileAttributes.Normal);    //恢复文件夹访问权限
                        System.Security.AccessControl.DirectorySecurity tf;
                        tf = new System.Security.AccessControl.DirectorySecurity();
                        tf.RemoveAccessRule(new FileSystemAccessRule(user, FileSystemRights.Read, AccessControlType.Deny));
                        System.IO.Directory.SetAccessControl(targetFolder, tf);
                    }
                    MessageBox.Show("出现几率极低的未知错误，未能完美执行！程序将自动执行回滚操作。", "注意！");
                    label1.Text = "操作错误，失败！";
                }
                if (x == 1)
                {   
                    MessageBox.Show("操作成功！", "恭喜！");
                    label1.Text = "注意：\r\n本工具采用的是“密码=文件夹名”的方式，建议文件夹名包含数字、符号或字母。";
                }
                else
                {
                    if (File.Exists(pw))
                    {
                        File.Delete(pw);
                    }
                    if (File.Exists(desktoppath))
                    {
                        File.Delete(desktoppath);
                    } 
                    MessageBox.Show("操作失败！\n请确定你是该文件夹的所有者，你拥有足够的权限且此文件夹没有被其他进程占用！", "失败了！");
                    label1.Text = "一般情况下本程序都能够完美成功执行任务，只有极少数特殊情况下才会失败。";
                }
            }
            else
            {
                MessageBox.Show("文件夹不存在！", "文件夹名错误！");
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            string targetFolder = ".\\" + textBox1.Text;
            string desktoppath = targetFolder + "\\" + "desktop.ini";
            string wzh = @".\回收站.{645ff040-5081-101b-9f08-00aa002f954e}";
            string user = "Users";
            string pw = @".\回收站.{645ff040-5081-101b-9f08-00aa002f954e}\astSetting.ini";
            string pw2 = targetFolder + "\\" + "astSetting.ini";
            var key = "=9bn&2g=4By3^GrCsP;oVQat/*6o%l#R";//定义使用的密匙
            var jmh = Encrypt(key, textBox1.Text); //加密textBox1的文本            
            if (File.Exists(pw) && Directory.Exists(wzh))
            {
                StreamReader rpw = new StreamReader(pw);
                var tv = rpw.ReadLine();
                rpw.Close();
                if (tv == jmh)
                {
                    try
                    {
                        label1.Text = "程序执行中，请稍后......\r\n执行过程中请不要操作本程序以及强制停止本程序！\r\n花费的时间和文件数量成正比，零散文件越多，花费时间将会越长。";
                        DirectoryInfo hf = new DirectoryInfo(wzh);
                        hf.MoveTo(targetFolder);                                    //重命名文件夹，恢复源文件夹
                        File.SetAttributes(targetFolder, FileAttributes.Normal);    //恢复文件夹访问权限   
                        System.Security.AccessControl.DirectorySecurity tf;
                        tf = new System.Security.AccessControl.DirectorySecurity();
                        tf.RemoveAccessRule(new FileSystemAccessRule(user, FileSystemRights.Read, AccessControlType.Deny));
                        System.IO.Directory.SetAccessControl(targetFolder, tf);
                        File.Delete(pw2);
                        File.Delete(desktoppath);
                        MessageBox.Show("显示成功！", "恭喜！");     
                        label1.Text = "友情提示：\r\n小撸怡情，大撸伤身，强撸灰飞烟灭，猛撸惊天动地。";
                    }
                    catch
                    {
                        MessageBox.Show("发生几率极低的未知错误，显示无法正常执行！", "注意！");
                    }
                }
                else
                {
                    MessageBox.Show("你输入的指令有误！", "出错啦！");
                    label1.Text = "显示失败！\r\n如无法自行解决，可以联系本程序作者Chias（www.chias.me）解决。";
                }
            }
            else if (textBox1.Text == "")
            {
                label1.Text = "你妹！能随便操..弄的吗？！";
            }
            else
            {
                MessageBox.Show("你妹！能随便操..弄的吗？！", "警告！");
                label1.Text = "你妹！叫你乱操..弄！这下爽了吧！\r\n这件事告诉我们一个道理：\r\n酒后可以乱伦乱性，但“密码”却是不能乱改乱记的。";
            }
        }      
    }
}
