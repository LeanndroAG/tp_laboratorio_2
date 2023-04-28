using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Evento para cargar en limpio el form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.Limpiar();
            btnConvertirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = false;
        }
        /// <summary>
        /// Evento para advertir en caso de querer salir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult resultado = MessageBox.Show("¿Está seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }
        /// <summary>
        /// Evento button para limpiar 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }
        /// <summary>
        /// Evento button para realizar opercion aritmetica
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            if ((txtNumero1.Text == "") || (txtNumero2.Text == ""))
            {
                MessageBox.Show("Ingresar un numero!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (double.TryParse(txtNumero1.Text, out double resultado) || !double.TryParse(txtNumero2.Text, out resultado))
                {
                    if (cmbOperador.SelectedIndex == 0)
                    {
                        cmbOperador.SelectedIndex = 1;
                    }
                    string auxLblResultado = Convert.ToString(Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text));
                    lblResultado.Text = auxLblResultado;

                    lstOperaciones.Items.Add($"{txtNumero1.Text}{cmbOperador.Text}{txtNumero2.Text}={lblResultado.Text}");
                    if (double.TryParse(lblResultado.Text, out double resultadoOperacion))
                    {
                        if (resultadoOperacion != double.MinValue)
                        {
                            btnConvertirABinario.Enabled = true;
                            btnConvertirADecimal.Enabled = true;
                        }
                        else
                        {
                            lblResultado.Text = "No se puede dividir por 0";

                        }
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese un dato numerico!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        /// <summary>
        /// Evento button para cerrar el form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Evento button para convertir resultado en decimal, en caso que sea binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Operando numeroDecimal = new Operando();
            lblResultado.Text = numeroDecimal.BinarioDecimal(lblResultado.Text);
            if (lblResultado.Text == "Valor invalido!")
            {
                btnConvertirABinario.Enabled = false;
                btnConvertirADecimal.Enabled = false;
            }
            else
            { 
                btnConvertirABinario.Enabled = true;
                btnConvertirADecimal.Enabled = false;
            }
        }
        /// <summary>
        /// Evento button para convertir el resultado decimal a binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Operando numeroBinario = new Operando();
            lblResultado.Text = numeroBinario.DecimalBinario(lblResultado.Text);
            if (lblResultado.Text == "Valor invalido!")
            {
                btnConvertirABinario.Enabled = false;
                btnConvertirADecimal.Enabled = false;
            }
            else
            {
                btnConvertirABinario.Enabled = false;
                btnConvertirADecimal.Enabled = true;
            }
        }
        /// <summary>
        /// Metodo para limpiar el form
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            lblResultado.Text = "";
            cmbOperador.SelectedIndex = 0;
            lstOperaciones.Items.Clear();
        }
        /// <summary>
        /// Metodo para operar y retonar el resultado double, para luego ser usado en button operar
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Operando operador1 = new Operando(numero1);
            Operando operador2 = new Operando(numero2);
            char auxOperdor = char.Parse(operador);
            double resultado = Calculadora.Operar(operador1, operador2, auxOperdor);
            return resultado;
        }
    }
}
