using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Invoice
    {
        public int Id { get; set; }
        [Display(Name = "شماره صورتحساب")] public int InvoiceNo { get; set; }
        [Display(Name = "نوع صورتحساب")] public int inty { get; set; }
        [Display(Name = "الگوی صورتحساب")] public int inp { get; set; }
        [Display(Name = "موضوع صورتحساب")] public int ins { get; set; }

        [Display(Name = "نوع شخص خریدار")] public int top { get; set; }


        [Display(Name = "شناسه ملی/ شماره ملی/شناسه مشارکت مدنی/ کد فراگیر اتباع غیرایرانی خریدار")] public string? bid { get; set; }

        [Display(Name = "کد پستی خریدار")] public string? bpc { get; set; }
        [Display(Name = "کد شعبه فروشنده")] public int sbc { get; set; }
        [Display(Name = "کد شعبه خریدار ")] public int bbc { get; set; }

        [Display(Name = "مالیات موضوع ماده 17")] public double tax17 { get; set; }
    }
    public class InvoicePay
    {
        public int Id { get; set; }
        public virtual Invoice Invoice { get; set; }

        public int InvoiceId { get; set; }
        [Display(Name = "شماره صورتحساب")] public string? InvoiceNo { get; set; }
        [Display(Name = "تاریخ صورتحساب")] public string? InvoiceDate { get; set; }

        [Display(Name = "روش پرداخت")] public string? pmt { get; set; }

        [Display(Name = "تاریخ و زمان پرداخت")] public string? pdt { get; set; }
        [Display(Name = "مبلغ پرداختی")] public double pv { get; set; }

        [Display(Name = "شماره سوییچ پرداخت")] public string? iinn { get; set; }

        [Display(Name = "شماره پذیرنده فروشگاهی")] public string? acn { get; set; }
        [Display(Name = "شماره پایانه")] public string? trmn { get; set; }
        [Display(Name = "شماره پیگیری/شماره مرجع")] public string? trn { get; set; }

        [Display(Name = "شماره کارت پرداخت کننده صورتحساب")] public string? pcn { get; set; }
        [Display(Name = "شماره/شناسه ملی/کد فراگیر اتباع غیر ایرانی پرداخت کننده صورتحساب")] public string? pid { get; set; }


    }


    public class InvoiceDet
    {
        public int Id { get; set; }

        public virtual Invoice Invoice { get; set; }

        public int InvoiceId { get; set; }
        [Display(Name = "شماره صورتحساب")] public string? InvoiceNo { get; set; }
        [Display(Name = "تاریخ صورتحساب")] public string? InvoiceDate { get; set; }

        [Display(Name = "شناسه کالا/خدمت")] public string? sstid { get; set; }

        [Display(Name = "شرح کالا/خدمت")] public string? sstt { get; set; }
        [Display(Name = "تعداد/مقدار")] public string? am { get; set; }

        [Display(Name = "واحد اندازه گیری")] public string? mu { get; set; }

        [Display(Name = "نوع ارز")] public string? cut { get; set; }
        [Display(Name = "نرخ برابری ارز با ریال")] public string? exr { get; set; }

        [Display(Name = "مبلغ واحد")] public string? fee { get; set; }
        [Display(Name = "مبلغ تخفیف")] public double dis { get; set; }
        [Display(Name = "نرخ مالیات بر ارزش افزوده")] public double vra { get; set; }

        [Display(Name = "مبلغ مالیات بر ارزش افزوده")] public double vam { get; set; }

        [Display(Name = "موضوع سایرمالیات و عوارض")] public string? odt { get; set; }
        [Display(Name = "نرخ سایرمالیات و عوارض")] public double odr { get; set; }
        [Display(Name = "مبلغ سایرمالیات و عوارض")] public double odam { get; set; }

        [Display(Name = "موضوع سایر وجوه قانونی")] public string? olt { get; set; }
        [Display(Name = "نرخ سایر وجوه قانونی")] public double olr { get; set; }
        [Display(Name = "مبلغ سایر وجوه قانونی")] public double olam { get; set; }
        [Display(Name = "شناسه یکتای ثبت قرارداد حق العمل کاری")] public string? bsrn { get; set; }

        [Display(Name = "شماره قرارداد بورس")] public string? BoorsNo { get; set; }
        [Display(Name = "تاریخ قرارداد بورس")] public string? BoorsDate { get; set; }

    }
}
