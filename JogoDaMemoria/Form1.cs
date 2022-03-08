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
        Label primeiroClick = null;
        Label segundoClick = null;
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
            // O cronômetro é ativado apenas após dois não correspondentes
            // ícones foram mostrados ao jogador,
            // então ignore qualquer clique se o cronômetro estiver em execução
            if (timer1.Enabled == true)
                return;

            Label clickLabel = sender as Label;

            if(clickLabel != null)
            {
                //Se o marcador clicado for preto, o player clicou
                //um ícone que já foi revelado --
                //ignora o clique
                if (clickLabel.ForeColor == Color.Black)
                    return;

                // Se primeiroClick for null, este é o primeiro ícone
                // no par que o jogador clicou,
                // então defina primeiroClick para o rótulo que o jogador
                // clicado, muda sua cor para preto e retorna
                if (primeiroClick == null)
                {
                    primeiroClick = clickLabel;
                    primeiroClick.ForeColor = Color.Black;

                    return;
                }

                // Se o jogador chegar até aqui, o cronômetro não está
                // correndo e firstClicked não é nulo,
                // então este deve ser o segundo ícone que o jogador clicou
                // Define sua cor para preto
                segundoClick = clickLabel;
                segundoClick.ForeColor = Color.Black;

                // Se o jogador chegar até aqui, o jogador
                // clicou em dois ícones diferentes, então inicie o
                // timer (que vai esperar três quartos de
                // um segundo e, em seguida, ocultar os ícones)
                timer1.Start();

            }
        }
        /// <summary>
        /// Este cronômetro é iniciado quando o jogador clica
        /// dois ícones que não combinam,
        /// então conta três quartos de segundo
        /// e depois se desliga e oculta os dois ícones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            primeiroClick.ForeColor = primeiroClick.BackColor;
            segundoClick.ForeColor = segundoClick.BackColor;

            // Reseta o primeiro e segundo click
            primeiroClick = null;
            segundoClick = null;
        }
    }
}
