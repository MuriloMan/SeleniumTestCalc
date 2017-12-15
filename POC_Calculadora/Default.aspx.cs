using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POC_Calculadora
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnCalcular_Click(object sender, EventArgs e)
        {
            Calculadora oCalculadora = new Calculadora();
            oCalculadora.Numero1 = Convert.ToDouble(txtNumero1.Text);
            oCalculadora.Numero2 = Convert.ToDouble(txtNumero2.Text);

            txtResultado.Text = oCalculadora.Calcular((Calculadora.Operacao)Convert.ToInt32(ddlOperacao.SelectedValue)).ToString();

        }

        protected void BtnLimpar_Click(object sender, EventArgs e)
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            txtResultado.Text = "";
            ddlOperacao.SelectedIndex = 0;
        }
    }
}