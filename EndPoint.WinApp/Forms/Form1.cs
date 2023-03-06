using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Common.EncryptionClass;
using static Common.Validation;

namespace EndPoint.WinApp.Forms
{
    public partial class Form1 : Form
    {
        private const string PublicKey = "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCiiTx4F35eWP10AFMAo8MLhCKq2ryKFG9PKKWeMLQuwMSdiQq347BkMYA + Q + YscScf7weUSTk9BHVNNfTchDwzjQrIoz6TZGggqD + ufin1Ccy0Sp6QeBMnIB89JsdzQGpVcsoTxk53grW0nYY8D + rlFvBwFicKe / tmVPVMYsEyFwIDAQAB";
        UnicodeEncoding ByteConverter = new UnicodeEncoding();
        RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
        byte[] plaintext;
        byte[] encryptedtext;
        public Form1()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            //شناسه یکتای حافظه مالیاتی
            string s_str = "DEF5GH";
            string s_str2 = MakeINT(s_str);

            DateTime dt = DateTime.Parse(tarikhshamsi.Text, new CultureInfo("fa-IR"));
            //تبدیل تاریخ روز به timestamp صورت HEX
            string c3 = ConvertToUnixTime(dt);
            c3 = c3.PadLeft(5, '0');
            //شماره صورتحساب 
            long c7 = long.Parse(shomare.Text);
            string c8 = c7.ToString("X");
            c8 = c8.PadLeft(10, '0');
            //کنترل الگوریتم verhoeff

            //int c = CheckSum(hafeze.Text.Substring(0, 8));//83001001000000150
            //int c2 = CheckSum(hafeze.Text.Substring(0, 2) + hafeze.Text.Substring(8, 7));
            //hafeze_result.Text = c.ToString() + c2.ToString();
            //
            string c10 = ConvertToUnixTimeDecimal(dt);
            c10 = c10.PadLeft(6, '0');
            string c9 = shomare.Text.PadLeft(12, '0');
            string s_v = s_str2 + c10 + c9;
            int c11 = CheckSum(s_v);
            Maliati.Text = s_str + c3 + c8 + c11;
        }
        public static string MakeINT(string number)
        {
            string c = "";
            int len = number.Length;
            char ch;
            for (int i = 0; i < len; ++i)
            {
                ch = number[i];
                if (ch == 'A')
                    c = c + "65";
                else if (ch == 'D')
                    c = c + "68";
                else if (ch == 'E')
                    c = c + "69";
                else if (ch == 'F')
                    c = c + "70";
                else if (ch == 'G')
                    c = c + "71";
                else if (ch == 'H')
                    c = c + "72";
                else if (ch == 'K')
                    c = c + "75";
                else if (ch == 'M')
                    c = c + "77";
                else if (ch == 'N')
                    c = c + "78";
                else if (ch == 'O')
                    c = c + "79";
                else if (ch == 'P')
                    c = c + "80";
                else if (ch == 'R')
                    c = c + "82";
                else if (ch == 'T')
                    c = c + "84";
                else if (ch == 'W')
                    c = c + "87";
                else if (ch == 'X')
                    c = c + "88";
                else if (ch == 'Y')
                    c = c + "89";
                else if (ch == 'Z')
                    c = c + "90";
                else
                    c = c + ch;

            }

            return c;
        }



        public static string ConvertToUnixTime(DateTime datetime)
        {
            DateTime sTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            long a = (long)(datetime - sTime).Days;
            return (datetime - sTime).Days.ToString("X");
        }

        public static string ConvertToUnixTimeDecimal(DateTime datetime)
        {
            DateTime sTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            long a = (long)(datetime - sTime).Days;
            return a.ToString();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            string s;
            //s = Maliati.Text + "@" + tejari.Text + "@" + tarikhshamsi.Text.Replace("/", "").Substring(2) + "@" + tedad.Text + "@" + mab.Text + "@" + maliat.Text;
            //RSATXT.Text = Encrypt(PublicKey, s);
        }


        private string Encrypt(string pPublicKey, string pInputString)
        {
            //Create a new instance of the RSACryptoServiceProvider class.
            RSACryptoServiceProvider lRSA = new RSACryptoServiceProvider();

            //Import key parameters into RSA.
            lRSA.ImportParameters(GetRSAParameters(pPublicKey));

            return Convert.ToBase64String(lRSA.Encrypt(Encoding.UTF8.GetBytes(pInputString), false));
        }

        private static RSAParameters GetRSAParameters(string pPublicKey)
        {
            byte[] lDer;

            //Set RSAKeyInfo to the public key values. 
            //	int lBeginStart = "-----BEGIN PUBLIC KEY-----".Length;
            //	int lEndLenght = "-----END PUBLIC KEY-----".Length;
            string KeyString = pPublicKey;//.Substring(lBeginStart, (pPublicKey.Length - lBeginStart - lEndLenght));
            lDer = Convert.FromBase64String(KeyString);


            //Create a new instance of the RSAParameters structure.
            RSAParameters lRSAKeyInfo = new RSAParameters();

            lRSAKeyInfo.Modulus = GetModulus(lDer);
            lRSAKeyInfo.Exponent = GetExponent(lDer);

            return lRSAKeyInfo;
        }

        private static byte[] GetModulus(byte[] pDer)
        {
            //Size header is 29 bits
            //The key size modulus is 128 bits, but in hexa string the size is 2 digits => 256 
            string lModulus = BitConverter.ToString(pDer).Replace("-", "").Substring(58, 256);

            return StringHexToByteArray(lModulus);
        }

        private static byte[] GetExponent(byte[] pDer)
        {
            int lExponentLenght = pDer[pDer.Length - 3];
            string lExponent = BitConverter.ToString(pDer).Replace("-", "").Substring((pDer.Length * 2) - lExponentLenght * 2, lExponentLenght * 2);

            return StringHexToByteArray(lExponent);
        }

        public static byte[] StringHexToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
    }
}
