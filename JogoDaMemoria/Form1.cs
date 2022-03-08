using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoDaMemoria
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AtribuirIconesAosQuadrados();
        }

        // Use este objeto Random para escolher ícones aleatórios para os quadrados
        Random random = new Random();

        // Cada uma dessas letras é um ícone interessante
        // na fonte Webdings,
        // e cada ícone aparece duas vezes nesta lista
        List<string> icones = new List<string>()
        {
            "!", "!", "N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w", "z", "z"
        };
        /// <summary>
        /// Atribui cada ícone da lista de ícones a um quadrado aleatório
        /// </summary>
        private void AtribuirIconesAosQuadrados()
        {
            // O TableLayoutPanel tem 16 rótulos,
            // e a lista de ícones tem 16 ícones,
            // então um ícone é puxado aleatoriamente da lista
            // e adicionado a cada rótulo
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconeLabel = control as Label;
                if(iconeLabel != null)
                {
                    int numeroRandom = random.Next(icones.Count);
                    iconeLabel.Text = icones[numeroRandom];
                    iconeLabel.ForeColor = iconeLabel.BackColor;
                    icones.RemoveAt(numeroRandom);
                }
            }
        }
        /// <summary>
        /// O evento Click de cada rótulo é tratado por este manipulador de eventos
        /// </summary>
        /// <param name="sender">O label que foi clicado</param>
        /// <param name="e"></param>
        private void label1_Click(object sender, EventArgs e)
        {
            Label clickLabel = sender as Label;

            if(clickLabel != null)
            {
                //Se o marcador clicado for preto, o player clicou
                //um ícone que já foi revelado --
                //ignora o clique
                if (clickLabel.ForeColor == Color.Black)
                    return;

                clickLabel.ForeColor = Color.Black;
            }
        }
    }
}
