using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Exercicio1_prova2
{
    public partial class Form1 : Form
    {
        // declarando os atributos da classe Form
        private string stringEntrada = string.Empty;
        private int quantidadeCaracteresEntrada;
        private char[] charEntrada;

        public Form1()
        {
            InitializeComponent(); // Chamando o método para inicializar os controles
        }

        private void buttonTestar_Click(object sender, EventArgs e)
        {
            // 1. recebe entrada
            stringEntrada = textBoxEntrada.Text;

            // 2. quantidade de caracteres da string de entrada
            quantidadeCaracteresEntrada = stringEntrada.Length;

            // 3. converte string em vetor de caracteres (caso necessite em algum outro lugar)
            charEntrada = stringEntrada.ToCharArray();

            // 4. limpar o log (listBoxLog)
            listBoxLog.Items.Clear();

            // 5. mostrar a fita (entrada) no log
            listBoxLog.Items.Add("*** Fita = " + stringEntrada);

            // 6. limpar o textBox de entrada para próxima leitura
            textBoxEntrada.Text = "";

            // 7. instancia o autômato e processa a entrada
            AutomatoVariavel automato = new AutomatoVariavel();
            //    agora ProcessarEntrada retorna Tuple<List<string>, bool>
            var resultadoAutomato = automato.ProcessarEntrada(stringEntrada);

            // 8. escreve todos os passos no listBoxLog
            List<string> passos = resultadoAutomato.Item1;
            bool aceitou = resultadoAutomato.Item2;

            foreach (string passo in passos)
            {
                listBoxLog.Items.Add(passo);
            }

            // 9. exibe ACEITA ou REJEITA em labelResposta
            labelResposta.Text = aceitou ? "ACEITA" : "REJEITA";
        }

        private void groupBoxCabecalho_Enter(object sender, EventArgs e)
        {
            // (permanece vazio, conforme Designer)
        }

        private void pictureBoxAutomato_Click(object sender, EventArgs e)
        {

        }

        private void listBoxLog_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
