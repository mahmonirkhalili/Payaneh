using Domain;
using IApplication.Interfaces;
using Microsoft.VisualBasic.ApplicationServices;
using NPOI.OpenXmlFormats.Dml.Diagram;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaxCollectData.Library.Business;
using TaxCollectData.Library.Dto.Config;
using TaxCollectData.Library.Dto.Content;

namespace EndPoint.WinApp.Forms
{
    public partial class FrmGetExcelSoHs : Form
    {
        private readonly IInvoice _Service;
        public FrmGetExcelSoHs()
        {
            _Service = (IInvoice)Program.serviceProvider.GetService(typeof(IInvoice));
            InitializeComponent();
        }
        DataTable dt1, dt2, dt3;
        private void button1_Click(object sender, EventArgs e)
        {
           
            string[] ColName1 = { "شماره صورتحساب(داخلی)", "تاریخ صورتحساب", "شناسه کالا / خدمت","شرح کالا/خدمت", "واحد اندازه گیري و سنجش", "مقدار / تعداد",
                "نوع ارز", "نرخ برابری ارز به ریال", "مبلغ واحد (فی)", "مبلغ تخفیف", "نرخ مالیات برارزش افزوده", "مبلغ مالیات بر ارزش افزوده",
                "نرخ سایر عوارض و مالیات", "مبلغ سایر عوارض و مالیات", "موضوع سایر عوارض و مالیات", "نرخ سایر وجوهات قانونی", 
                "مبلغ سایر وجوهات قانونی", "موضوع سایر وجوهات قانونی", "شناسه یکتای ثبت قرارداد حق العملکاری", "شماره قرارداد بورس", "تاریخ قرارداد بورس" };
            string[] ColName0 = { "شماره صورتحساب(داخلی)", "تاریخ صورتحساب", "نوع صورتحساب", "الگوی صورتحساب", "موضوع صورتحساب", 
                "نوع انجام معامله", "شماره منحصر به فرد مالیاتی صورتحساب مرجع ", "نوع خریدار",
                "شناسه ملی/ کد ملی / کد اتباع/ شناسه مشارکت مدنی خریدار", "کد اقتصادی خريدار",
                "کد پستی خریدار", "روش تسویه", "مبلغ نسیه*", "ساعت صورت حساب", "شماره پروانه گمرکی فروشنده", "کد گمرک محل اظهار فروشنده",
                "شناسه یکتای ثبت قرارداد فروشنده", "کد شعبه فروشنده", "کد شعبه خریدار", "موضوع ماده ۱۷", "توضیحات" };
            string[] ColName2 = { "شماره صورتحساب(داخلی)", "تاریخ صورتحساب", "روش پرداخت", "مبلغ پرداخت", "تاريخ پرداخت", 
                "شماره سوییچ", "شماره پذیرنده", "شماره ترمینال", "کد رهگیری", "شماره کارت پرداخت کننده",
                "شماره ملی/کد فراگیر پرداخت کننده" };

           

            var key =  openFileDialog1.ShowDialog();
            if (key == DialogResult.OK)
            {

                string FileName = openFileDialog1.FileName;
               var ExFile= Common.XlsAndData.XlsxToDataSet(FileName);

                if (ExFile.Tables.Count<3)
                { MessageBox.Show("فایل اکسل باید حداقل سه کاربرگ داشته باشد."); return; }
                string ErrorMsg = "";
                ErrorMsg= CheckExcelFile(ExFile.Tables[0], ColName0);
                if (ErrorMsg != "") { MessageBox.Show(ErrorMsg,"اقلام اطلاعاتی نادرست شیت اول"); return; }
                ErrorMsg = CheckExcelFile(ExFile.Tables[1], ColName1);
                if (ErrorMsg != "") { MessageBox.Show(ErrorMsg, "اقلام اطلاعاتی نادرست شیت دوم"); return; }
                ErrorMsg = CheckExcelFile(ExFile.Tables[2], ColName2);
                if (ErrorMsg!="") { MessageBox.Show(ErrorMsg, "اقلام اطلاعاتی نادرست شیت سوم"); return; }
                dt1= ExFile.Tables[0];
                dt2= ExFile.Tables[1];
                dt3= ExFile.Tables[2];

                bindingSource1.DataSource = ExFile.Tables[0];
                bindingSource2.DataSource = ExFile.Tables[1];
                bindingSource3.DataSource = ExFile.Tables[2];

                dataGridView1.DataSource = bindingSource1;
                dataGridView2.DataSource= bindingSource2 ;
                dataGridView3.DataSource= bindingSource3 ;
            }
        }

        public string CheckExcelFile(DataTable dt, string[] ColName)
        {
            string result = "";
            var c = dt.Columns;
            foreach (string s in ColName)
            {
                bool flag = false;
                foreach (var a in c)
                {
                    if (a.ToString() == s)
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag == false)
                {
                    if (result == "")
                        result += "\n" + "فایل اکسل شامل ستون روبرو نمی باشد" + s;
                    else result += " ، " + s;
                }
            }          
                return result;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            List< Invoice > invoices= new List< Invoice >();
            List<InvoiceDet> invoicedets = new List<InvoiceDet>();
            List<InvoicePay> invoicepays = new List<InvoicePay>();


            foreach (DataRow r in dt1.Rows)
            {
                Invoice invoice = new Invoice
                {
                    bbc =int.Parse( r["کد شعبه خریدار"].ToString()),
                    bid= (r["شناسه ملی/ کد ملی / کد اتباع/ شناسه مشارکت مدنی خریدار"].ToString()),
                    bpc= (r["کد پستی خریدار"].ToString()),
                    inp= int.Parse(r["الگوی صورتحساب"].ToString()),
                    ins= int.Parse(r["موضوع صورتحساب"].ToString()),
                    inty= int.Parse(r["نوع صورتحساب"].ToString()),
                    InvoiceNo= int.Parse(r["شماره صورتحساب(داخلی)"].ToString()),
                    sbc= int.Parse(r["کد شعبه فروشنده"].ToString()),
                    tax17= double.Parse(r["موضوع ماده ۱۷"].ToString()),
                    top= int.Parse(r["نوع خریدار"].ToString()),
                };
                invoices.Add(invoice);
            }

          
       
            foreach (Invoice inn in invoices)
            foreach (DataRow r in dt2.AsEnumerable().Where(z => z.Field<object>("شماره صورتحساب(داخلی)").ToString()==inn.InvoiceNo.ToString())  )
            {
                InvoiceDet invoiceDet = new InvoiceDet
                {am= (r["مقدار / تعداد"].ToString()),
                InvoiceNo= (r["شماره صورتحساب(داخلی)"].ToString()),
                BoorsDate= (r["تاریخ قرارداد بورس"].ToString()),
                BoorsNo= (r["شماره قرارداد بورس"].ToString()),
                bsrn= (r["شناسه یکتای ثبت قرارداد حق العملکاری"].ToString()),
                cut= (r["نوع ارز"].ToString()),
                dis=double.Parse (r["مبلغ تخفیف"].ToString()),
                exr= (r["نرخ برابری ارز به ریال"].ToString()),
                fee= (r["مبلغ واحد (فی)"].ToString()),
                InvoiceDate= (r["تاریخ صورتحساب"].ToString()),
                mu= (r["واحد اندازه گیري و سنجش"].ToString()),

                odam= double.Parse(r["مبلغ سایر عوارض و مالیات"].ToString()),

                odr= double.Parse(r["نرخ سایر عوارض و مالیات"].ToString()),

                odt= (r["موضوع سایر عوارض و مالیات"].ToString()),

                olam= double.Parse(r["مبلغ سایر وجوهات قانونی"].ToString()),

                olr= double.Parse(r["نرخ سایر وجوهات قانونی"].ToString()),

                olt= (r["موضوع سایر وجوهات قانونی"].ToString()),
                sstid= (r["شناسه کالا / خدمت"].ToString()),
                sstt= (r["شرح کالا/خدمت"].ToString()),
                vam= double.Parse(r["مبلغ مالیات بر ارزش افزوده"].ToString()),
                vra= double.Parse(r["نرخ مالیات برارزش افزوده"].ToString()),


                Invoice= inn,



                   
                };
                    invoicedets.Add(invoiceDet);

                }

          
            foreach (DataRow r in dt3.Rows)
            {
                InvoicePay invoicePay = new InvoicePay {
                    acn = (r["شماره پذیرنده"].ToString()),
                    iinn = (r["شماره سوییچ"].ToString()),
                    InvoiceDate = (r["تاریخ صورتحساب"].ToString()),
                    InvoiceNo = (r["شماره صورتحساب(داخلی)"].ToString()),
                    pcn = (r["شماره کارت پرداخت کننده"].ToString()),
                    pdt = (r["تاريخ پرداخت"].ToString()),
                    pid = (r["شماره ملی/کد فراگیر پرداخت کننده"].ToString()),
                    pmt = (r["روش پرداخت"].ToString()),
                    pv = double.Parse(r["مبلغ پرداخت"].ToString()),
                    trmn = (r["شماره ترمینال"].ToString()),
                    trn = (r["کد رهگیری"].ToString()),


                    Invoice = invoices.Where(c => c.InvoiceNo.ToString() == r["شماره صورتحساب(داخلی)"].ToString()).SingleOrDefault()



                };
                invoicepays.Add(invoicePay);
            }

            _Service.InsertInvoice(invoices, invoicedets, invoicepays);
            MessageBox.Show("اطلاعات با موفقیت ذخیره شد");
          
        }

        public void send()
        {
            //TaxApiService.Instance.Init(CLIENT_ID, new SignatoryConfig(PRIVATE_KEY, null));
            //TaxApiService.Instance.TaxApis.GetServerInformation();
            //TaxApiService.Instance.TaxApis.RequestToken();
            //InvoiceDto invoiceDto = new InvoiceDto();
            //invoiceDto.
            //var invoices = new List<InvoiceDto> { 
            //    invoiceDto
            //    };
            //TaxApiService.Instance.TaxApis.SendInvoices(invoices);



        }

        public void get()
        {

            var searchDto = new SearchDto(1,10);
           
            var serviceStuffList = TaxApiService.Instance.TaxApis.GetServiceStuffList(searchDto).Result;
        }
    }
}
