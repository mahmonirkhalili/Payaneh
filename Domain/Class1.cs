using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Class1
    {      
        [Display(Name= "شماره منحصر به فرد مالیاتی")]  public string taxid { get; set; }
        [Display(Name = "تاریخ و زمان صدور صورتحساب)میلادی(")] public string indatim { get; set; }
        [Display(Name = "تاریخ و زمان ایجاد صورتحساب)میلادی(")] public string Indati2m { get; set; }
        [Display(Name = "نوع صورتحساب")] public string inty { get; set; }
        [Display(Name = "سریال صورتحساب داخلی حافظه مالیاتی")] public string inno { get; set; }



        [Display(Name = "شماره منحصر به فرد مالیاتی صورتحساب مرجع")] public string irtaxid { get; set; }
        [Display(Name = "الگوی صورتحساب")] public string inp { get; set; }
        [Display(Name = "موضوع صورتحساب")] public string ins { get; set; }
      
        [Display(Name = "شماره اقتصادی فروشنده")] public string tins { get; set; }
       
        [Display(Name = "نوع شخص خریدار")] public int top { get; set; }
        [Display(Name = "کد شعبه فروشنده")] public string sbc { get; set; }
        [Display(Name = "شماره/شناسه ملی/شناسه مشارکت")] public string bid { get; set; }
        [Display(Name = "کد پستی خریدار")] public string bpc { get; set; }
        [Display(Name = "کد شعبه خریدار ")] public string bbc { get; set;}
        [Display(Name = "شماره گذرنامه خریدار")] public string bpn { get; set; }
        [Display(Name = "نوع پرواز")] public int ft { get; set; }
        [Display(Name = "شماره پروانه گمرکی")] public string scln { get; set; }
        [Display(Name = "کد گمرک محل اظهار فروشنده")] public string scc { get; set;}
        [Display(Name = "شناسه یکتای ثبت قرارداد فروشنده")] public string crn { get; set; }




        [Display(Name = "شماره اشتراک/ شناسه قبض بهره بردار")] public string billid { get; set; }
        [Display(Name = "مجموع مبلغ قبل از کسر تخفیف")] public string tprdis { get; set; }

        [Display(Name = "مجموع تخفیفات")] public string tdis { get; set; }
        [Display(Name = "مجموع مبلغ پس از کسر تخفیف")] public string tadis { get; set; }
        [Display(Name = "مجموع مالیات بر ارزش افزوده")] public string tvam { get; set; }
        [Display(Name = "مجموع سایر مالیات، عوارض و وجوه قانونی")] public string todam { get; set; }

        [Display(Name = "مجموع صورتحساب")] public string tbill { get; set; }
        [Display(Name = "مجموع وزن خالص")] public string tonw { get; set; }
        [Display(Name = "مجموع ارزش ریالی")] public string torv { get; set; }
        [Display(Name = "مجموع ارزش ارزی")] public string tocv { get; set; }

        [Display(Name = "روش تسویه")] public string setm { get; set; }
        [Display(Name = "مبلغ پرداختی نقدی")] public string cap { get; set; }
        [Display(Name = "مبلغ نسیه")] public string insp { get; set; }
        [Display(Name = "مجموع سهم مالیات بر ارزش افزوده ازپرداخت")] public string tvop { get; set; }

        [Display(Name = "مالیات موضوع ماده 17")] public string tax17 { get; set; }
        [Display(Name = "شناسه کالا/خدمت")] public string sstid { get; set; }
        [Display(Name = "شرح کالا/خدمت")] public string sstt { get; set; }
        [Display(Name = "تعداد/مقدار")] public string am { get; set; }

        [Display(Name = "واحد اندازه گیری")] public string mu { get; set; }
        [Display(Name = "وزن خالص")] public string nw { get; set; }




        [Display(Name = "مبلغ واحد")] public string fee { get; set; }
        [Display(Name = "میزان ارز")] public string cfee { get; set; }

        [Display(Name = "نوع ارز")] public string cut { get; set; }
        [Display(Name = "نرخ برابری ارز با ریال")] public string exr { get; set; }
        [Display(Name = "ارزش ریالی کالا")] public string ssrv { get; set; }
        [Display(Name = "ارزش ارزی کالا")] public string sscv { get; set; }

        [Display(Name = "مبلغ قبل از تخفیف")] public string prdis { get; set; }
        [Display(Name = "مبلغ تخفیف")] public string dis { get; set; }
        [Display(Name = "مبلغ بعد از تخفیف")] public string adis { get; set; }
        [Display(Name = "نرخ مالیات بر ارزش افزوده")] public string vra { get; set; }

        [Display(Name = "مبلغ مالیات بر ارزش افزوده")] public string vam { get; set; }
        [Display(Name = "موضوع سایرمالیات و عوارض")] public string odt { get; set; }
        [Display(Name = "نرخ سایرمالیات و عوارض")] public string odr { get; set; }
        [Display(Name = "مبلغ سایرمالیات و عوارض")] public string odam { get; set; }

        [Display(Name = "موضوع سایر وجوه قانونی")] public string olt { get; set; }
        [Display(Name = "نرخ سایر وجوه قانونی")] public string olr { get; set; }
        [Display(Name = "مبلغ سایر وجوه قانونی")] public string olam { get; set; }
        [Display(Name = "اجرت ساخت")] public string consfee { get; set; }

        [Display(Name = "سود فروشنده")] public string spro { get; set; }
        [Display(Name = "حق العمل")] public string bros { get; set; }
        [Display(Name = "جمع کل اجرت، حق العمل و سود")] public string tcpbs { get; set; }
        [Display(Name = "سهم نقدی از پرداخت")] public string cop { get; set; }

        [Display(Name = "سهم مالیات بر ارزش افزوده از پرداخت")] public string vop { get; set; }
        [Display(Name = "شناسه یکتای ثبت قرارداد حق العمل کاری")] public string bsrn { get; set; }
        [Display(Name = "مبلغ کل کالا/خدمت")] public string tsstam { get; set; }
        [Display(Name = "شماره سوییچ پرداخت")] public string iinn { get; set; }

        [Display(Name = "شماره پذیرنده فروشگاهی")] public string acn { get; set; }
        [Display(Name = "شماره پایانه")] public string trmn { get; set; }
        [Display(Name = "روش پرداخت")] public string pmt { get; set; }
        [Display(Name = "شماره پیگیری/شماره مرجع")] public string trn { get; set; }

        [Display(Name = "شماره کارت پرداخت کننده صورتحساب")] public string pcn { get; set; }
        [Display(Name = "شماره/شناسه ملی/کد فراگیر اتباع غیر ایرانی پرداخت کننده صورتحساب")] public string pid { get; set; }
        [Display(Name = "تاریخ و زمان پرداخت")] public string pdt { get; set; }
        [Display(Name = "مبلغ پرداختی")] public string pv { get; set; }

       


    }
}
