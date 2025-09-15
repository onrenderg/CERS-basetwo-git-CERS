using CERS.Models;
using CERS.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace CERS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewExpenditureDetailsPage : ContentPage
    {
        string query;
        string expensestype;
        string expensesvalue;
        ExpenditureDetailsDatabase expenditureDetailsDatabase = new ExpenditureDetailsDatabase();
        List<ExpenditureDetails> expenditureDetailslist;
        UserDetailsDatabase userDetailsDatabase = new UserDetailsDatabase();
        List<UserDetails> userDetails;
        string expdatetodisplayvalue;
        string expenseid;
      //  string ExpenseObserverRemId;

        ViewAllRemarksDatabase viewAllRemarksDatabase = new ViewAllRemarksDatabase();
        List<ViewAllRemarks> viewAllRemarkslist;
        string ObserverRemarksId;
        string expensesid;

        public ViewExpenditureDetailsPage(string expendselected, string expvalue, string expdatetodispvalue)
        {
            InitializeComponent();
            expensestype = expendselected;
            expensesvalue = expvalue;
            expdatetodisplayvalue = expdatetodispvalue;
            if (expensestype.Equals("type"))
            {
                loadtypewisedata(expensesvalue);
            }
            else if (expensestype.Equals("date"))
            {
                loaddatewisedata(expensesvalue);
            }
            userDetails = userDetailsDatabase.GetUserDetails("Select * from UserDetails").ToList();
            lbl_heading0.Text = App.setselfagentuserheading();
            searchbar_expendituredetails.Placeholder = App.GetLabelByKey("Search");
        }

        void loadtypewisedata(string expvalue)
        {
            query = $"Select *" +
                    $",case  when amount <> '' then ('₹ ' || amount) else ('₹ 0') end amounttodisplay" +
                    $",case  when amountoutstanding <> '' then ('₹ ' || amountoutstanding) else ('₹ 0') end amountoutstandingtodisplay" +
                    $", (case  when {App.Language} =0 then ExpTypeName else ExpTypeNameLocal end)ExpTypeName " +
                    $", (case  when {App.Language} =0 then PayModeName else PayModeNameLocal end)PayModeName " +
                    $",'{App.GetLabelByKey("lbl_expdate")}' as lblexpDate" +
                    $",'{App.GetLabelByKey("lbl_exptype")}' as lblexptype" +
                    $",'{App.GetLabelByKey("lbl_amounttype")}' as lblamtType" +
                    $",'{App.GetLabelByKey("lbl_amount")}' as lblAmount" +
                    $",'{App.GetLabelByKey("lblObserverRemarks")}' as lblObserverRemarks" +
                    $",'{App.GetLabelByKey("lbl_amountoutstanding")}' as lbl_amountoutstanding" +
                    $",'{App.GetLabelByKey("lbl_paymentdate")}' as lblpaymentDate" +
                    $",'{App.GetLabelByKey("lbl_voucherBillNumber")}' as lblvoucherBillNumber" +
                    $",'{App.GetLabelByKey("lbl_payMode")}' as lblpayMode" +
                    $",'{App.GetLabelByKey("lbl_payeeName")}' as lblpayeeName" +
                    $",'{App.GetLabelByKey("lbl_payeeAddress")}' as lblpayeeAddress" +
                    $",'{App.GetLabelByKey("lbl_sourceMoney")}' as lblsourceMoney" +
                    $",'{App.GetLabelByKey("lblRemarks")}' as lblremarks" +
                    $",'{App.GetLabelByKey("EnteredOn")}' as lblEnteredOn" +
                    $", (case when ExpStatus='P' then 'true' else 'false' end)btnEditVisibility" +
                    $",'{App.GetLabelByKey("Edit")}' as lbledit" +
                    $",'{App.GetLabelByKey("Reply")}' as lblReplyToObserverRemarks" +
                    $", (case when ObserverRemarks <> '' then 'true' else 'false' end)btnrplyobserverremarksvisibility" +
                    $",'false' as exptypevisibility" +
                    $",'true' as expdatevisibility" +
                    $" from ExpenditureDetails " +
                    $" where expcode='{expvalue}'";
            expenditureDetailslist = expenditureDetailsDatabase.GetExpenditureDetails(query).ToList();
            listView_expendituredetails.ItemsSource = expenditureDetailslist;
            if (App.Language == 0)
            {
                lbl_heading.Text = App.GetLabelByKey("lbl_exptype") + " - "  + expenditureDetailslist.ElementAt(0).ExpTypeName;
            }
            else
            {
                lbl_heading.Text = App.GetLabelByKey("lbl_exptype") + " - " + expenditureDetailslist.ElementAt(0).ExpTypeNameLocal;
            }
        }

        void loaddatewisedata(string expvalue)
        {
            query = $"Select *" +
                    $",case  when amount <> '' then ('₹ ' || amount) else ('₹ 0') end amounttodisplay" +
                    $",case  when amountoutstanding <> '' then ('₹ ' || amountoutstanding) else ('₹ 0') end amountoutstandingtodisplay" +
                    $", (case  when {App.Language} =0 then ExpTypeName else ExpTypeNameLocal end)ExpTypeName " +
                    $", (case  when {App.Language} =0 then PayModeName else PayModeNameLocal end)PayModeName " +
                    $",'{App.GetLabelByKey("lbl_expdate")}' as lblexpDate" +
                    $",'{App.GetLabelByKey("lbl_exptype")}' as lblexptype" +
                    $",'{App.GetLabelByKey("lbl_amounttype")}' as lblamtType" +
                    $",'{App.GetLabelByKey("lblObserverRemarks")}' as lblObserverRemarks" +
                    $",'{App.GetLabelByKey("lbl_amountoutstanding")}' as lbl_amountoutstanding" +
                    $",'{App.GetLabelByKey("lbl_amount")}' as lblAmount" +
                    $",'{App.GetLabelByKey("lbl_paymentdate")}' as lblpaymentDate" +
                    $",'{App.GetLabelByKey("lbl_voucherBillNumber")}' as lblvoucherBillNumber" +
                    $",'{App.GetLabelByKey("lbl_payMode")}' as lblpayMode" +
                    $",'{App.GetLabelByKey("lbl_payeeName")}' as lblpayeeName" +
                    $",'{App.GetLabelByKey("lbl_payeeAddress")}' as lblpayeeAddress" +
                    $",'{App.GetLabelByKey("lbl_sourceMoney")}' as lblsourceMoney" +
                    $",'{App.GetLabelByKey("lblRemarks")}' as lblremarks" +
                    $",'{App.GetLabelByKey("EnteredOn")}' as lblEnteredOn" +
                    $",'{App.GetLabelByKey("Edit")}' as lbledit" +
                    $", (case when ExpStatus='P' then 'true' else 'false' end)btnEditVisibility" +
                    $",'{App.GetLabelByKey("Reply")}' as lblReplyToObserverRemarks" +
                    $", (case when ObserverRemarks <> '' then 'true' else 'false' end)btnrplyobserverremarksvisibility" +
                    $",'true' as exptypevisibility" +
                    $",'false' as expdatevisibility" +
                    $" from ExpenditureDetails " +
                    $" where expDate='{expvalue}'";
            expenditureDetailslist = expenditureDetailsDatabase.GetExpenditureDetails(query).ToList();
            lbl_heading.Text = App.GetLabelByKey("lbl_expdate") + " - " + expdatetodisplayvalue;
            listView_expendituredetails.ItemsSource = expenditureDetailslist;
        }

        private void searchbar_expendituredetails_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(searchbar_expendituredetails.Text))
            {
                string texttosearch = searchbar_expendituredetails.Text.ToLower().Trim();

                listView_expendituredetails.ItemsSource = expenditureDetailslist.Where(t =>
                                    t.ExpenseID.ToLower().Contains(texttosearch)
                                 || t.expDate.ToLower().Contains(texttosearch)
                                 //|| t.expCode.ToLower().Contains(texttosearch)
                                 || t.amtType.ToLower().Contains(texttosearch)
                                 || t.amount.ToLower().Contains(texttosearch)
                                 || t.paymentDate.ToLower().Contains(texttosearch)
                                 || t.voucherBillNumber.ToLower().Contains(texttosearch)
                                 || t.payMode.ToLower().Contains(texttosearch)
                                 || t.payeeName.ToLower().Contains(texttosearch)
                                 // || t.EnteredOn.ToLower().Contains(texttosearch)
                                 || t.payeeAddress.ToLower().Contains(texttosearch)
                                 || t.sourceMoney.ToLower().Contains(texttosearch)
                                 || t.remarks.ToLower().Contains(texttosearch)
                                 || t.DtTm.ToLower().Contains(texttosearch)
                                 || t.ExpStatus.ToLower().Contains(texttosearch)
                                 || t.ExpTypeName.ToLower().Contains(texttosearch)
                                 || t.ExpTypeNameLocal.ToLower().Contains(texttosearch)
                                 || t.PayModeName.ToLower().Contains(texttosearch)
                                 || t.PayModeNameLocal.ToLower().Contains(texttosearch)
                                ).ToList();

            }
            else
            {
                if (expensestype.Equals("type"))
                {
                    loadtypewisedata(expensesvalue);
                }
                else if (expensestype.Equals("date"))
                {
                    loaddatewisedata(expensesvalue);
                }
            }
        }

        private void btn_edit_Clicked(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            string id = b.CommandParameter.ToString();
            Navigation.PushAsync(new EditExpenditureDetailsPage(id));
        }

        private async void btn_ReplyToObserverRemarks_Clicked(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            string id = b.CommandParameter.ToString();
            expenseid = id;
            Loading_activity.IsVisible = true;
            var service = new HitServices();
            int response_remarks = await service.Remarks_Get(expenseid);
            Loading_activity.IsVisible = false;

            string query = $"Select *,(ExpenseId ||'$'||ObserverRemarksId)ExpenseObserverRemId" +
                $", (case when UserRemarks <> '' then 'false' else 'true' end ) imgreplyvisibility" +
                $", (case when UserRemarksDtTm <> '' then UserRemarksDtTm else ObserverRemarksDtTm end ) RepliedDatetime" +
                $", '{App.GetLabelByKey("lblObserverRemarks")}'||' '||(case when UserRemarksDtTm <> '' then '' else ObserverRemarksDtTm end)  as lblObserverRemarks" +
                $", '{App.GetLabelByKey("UserResponse")}' ||' '||(case when UserRemarksDtTm <> '' then UserRemarksDtTm else '' end) as lblUserRemarks" +
              //  $", (case when UserRemarksDtTm <> '' then '{App.GetLabelByKey("UserResponseDatetime")}' else '{App.GetLabelByKey("ObserverResponseDatetime")}' end ) lblRepliedDatetime" +
               // $", (case when UserRemarksDtTm <> '' then '{App.GetLabelByKey("UserResponseDatetime")}'||' '|| UserRemarksDtTm else '{App.GetLabelByKey("ObserverResponseDatetime")}' ||' '||ObserverRemarksDtTm end ) lblRepliedDatetime" +
                $" from viewAllRemarks order by UserRemarksDtTm desc";
            viewAllRemarkslist = viewAllRemarksDatabase.GetViewAllRemarks(query).ToList();
            if (viewAllRemarkslist.Any())
            {
                listview_Remarks.ItemsSource = viewAllRemarkslist;
                popupRemarksCancel.Text = App.GetLabelByKey("Cancel");
                popupRemarks.IsVisible = true;
            }
            lbl_popupRemarks.Text = App.GetLabelByKey("UserResponse");
            lbl_remarks.Text = App.GetLabelByKey("UserResponse") + "*";
            entry_remarks.Placeholder = App.GetLabelByKey("Remarks");
            PopupreplyremarkscancelBtn.Text = App.GetLabelByKey("Cancel");
            PopupreplyremarksyesBtn.Text = App.GetLabelByKey("submit1");
            /* 
                         popupremarks.IsVisible = true;*/
        }

        private void img_viewimage_Clicked(object sender, EventArgs e)
        {
            ImageButton b = (ImageButton)sender;
            string str = b.CommandParameter.ToString();
            string[] a = str.Split(new char[] { '$' });
            expensesid = a[0];
            ObserverRemarksId = a[1];

            PopupreplyremarkscancelBtn.Text = App.GetLabelByKey("Cancel");

            popupreplyremarks.IsVisible = true;
        }

        private void popupRemarksCancel_Clicked(object sender, EventArgs e)
        {
            popupRemarks.IsVisible = false;
        }

        private async void PopupreplyremarksyesBtn_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(entry_remarks.Text))
            {
                await DisplayAlert(App.GetLabelByKey("AppName"), App.GetLabelByKey("Remarks"), App.GetLabelByKey("Close"));
                return;
            }
            if (entry_remarks.Text.Length == 0)
            {
                await DisplayAlert(App.GetLabelByKey("AppName"), App.GetLabelByKey("Remarks"), App.GetLabelByKey("Close"));
                return;
            }
            else
            {
                Loading_activity.IsVisible = true;
                var service = new HitServices();
                int response_saveobsrem = await service.SaveUserRemarks_Post(expensesid, entry_remarks.Text, ObserverRemarksId);
                if (response_saveobsrem == 200)
                {
                    await service.ExpenditureDetails_Get();
                    Loading_activity.IsVisible = false;
                    await Navigation.PopAsync();
                }
                Loading_activity.IsVisible = false;
            }
        }
       
        private void PopupreplyremarkscancelBtn_Clicked(object sender, EventArgs e)
        {
            popupreplyremarks.IsVisible = false;
        }


    }
}