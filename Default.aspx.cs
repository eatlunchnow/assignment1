using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string[] percents = { "10%", "15%", "20%", "Other" }; /*percents is an array*/
            TipPercentRadioButtonList.DataSource = percents; /*.DataSource references array*/
            TipPercentRadioButtonList.DataBind();
        }
    }

    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        GetTotals(); /*called method*/
    }

    private void GetTotals()
    {
        double amount;
        Tip tip = null; /*declare but not initial, for scope so method can see it*/
        bool goodAmount = double.TryParse(MealTextBox.Text, out amount); /*returns boolean. If true, 
        assigns value to variable
        this will take text from text box
        will parse to see if it will make amount a double. Adding another other than double
        will crash program*/
        if (goodAmount)
        {
            double percent = 0;
            if (TipPercentRadioButtonList.SelectedItem.Text != "Other")
            {
                if (TipPercentRadioButtonList.SelectedItem.Text.Equals("10%"))
                    percent = .10;
                if (TipPercentRadioButtonList.SelectedItem.Text.Equals("15%"))
                    percent = .15;
                if (TipPercentRadioButtonList.SelectedItem.Text.Equals("20%"))
                    percent = .20;
            }
            else
            {
                percent = double.Parse(OtherTextBox.Text);
                percent /= 100; //percent = percent / 100
            }

            tip = new Tip(amount, percent); /*declare class and pass value*/
        }
        else
        {
            Response.Write("<script>alert('Enter a valid amount');</script>");
        }

        ResultLabel.Text = "Amount: " + amount.ToString("$ #,##0.00") + "<br/>" + "Tax: "
            + tip.CalculateTax().ToString("$ #,##0.00") + "</br>"
            + "tip: " + tip.CalculateTip().ToString("$ #,##0.00") + "<br/>"
            + "Total: " + tip.Total().ToString("$ #,##0.00");
    }
}
