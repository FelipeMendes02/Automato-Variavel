using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio1_prova2
{
    internal class AutomatoVariavel
    {
            // Estados do Autômato
            private enum Estado { q0, q1, q_erro }

            // Função de transição
            private Estado Transicao(Estado estadoAtual, char caractereEntrada)
            {
                bool ehLetra = Char.IsLetter(caractereEntrada);
                bool ehDigito = Char.IsDigit(caractereEntrada);
                bool ehSublinhado = caractereEntrada == '_';

                switch (estadoAtual)
                {
                    case Estado.q0:
                        if (ehLetra || ehSublinhado)
                            return Estado.q1;
                        else
                            return Estado.q_erro;

                    case Estado.q1:
                        if (ehLetra || ehDigito || ehSublinhado)
                            return Estado.q1;
                        else
                            return Estado.q_erro;

                    case Estado.q_erro:
                        return Estado.q_erro; // Permanece em erro

                    default:
                        return Estado.q_erro;
                }
            }

            // Processa a palavra de entrada e retorna os passos e o resultado
            public Tuple<List<string>, bool> ProcessarEntrada(string entrada)
            {
                List<string> passos = new List<string>();
                Estado estadoAtual = Estado.q0;
                passos.Add($"Estado Inicial: {estadoAtual}");

                if (string.IsNullOrEmpty(entrada))
                {
                    passos.Add("Entrada vazia.");
                    return Tuple.Create(passos, false); // Variável não pode ser vazia
                }

                foreach (char caractere in entrada)
                {
                    Estado estadoAnterior = estadoAtual;
                    estadoAtual = Transicao(estadoAtual, caractere);
                    passos.Add($"Lido '{caractere}': Transição de {estadoAnterior} para {estadoAtual}");

                    if (estadoAtual == Estado.q_erro)
                    {
                        passos.Add("Caractere inválido encontrado ou sequência inválida.");
                        break; // Interrompe se entrar em estado de erro
                    }
                }

                bool ehVariavel = estadoAtual == Estado.q1;
                passos.Add($"Processamento concluído. Estado Final: {estadoAtual}");
                passos.Add(ehVariavel ? "Resultado: VARIÁVEL" : "Resultado: NÃO É VARIÁVEL");

                return Tuple.Create(passos, ehVariavel);
            }
        }

        // Exemplo de como seria usado em um formulário WinForms (simplificado)
        /*
        public partial class FormularioPrincipal : Form
        {
            private AutomatoVariavel automato = new AutomatoVariavel();
            private TextBox caixaTextoEntrada;
            private Button botaoCompilar;
            private ListBox caixaListaPassos;

            public FormularioPrincipal()
            {
                // Inicialização dos componentes da UI (gerada pelo designer)
                InicializarComponentes();
            }

            private void botaoCompilar_Click(object sender, EventArgs e)
            {
                string entrada = caixaTextoEntrada.Text;
                caixaListaPassos.Items.Clear();

                var resultado = automato.ProcessarEntrada(entrada);
                List<string> passos = resultado.Item1;
                bool ehVariavel = resultado.Item2;

                foreach (string passo in passos)
                {
                    caixaListaPassos.Items.Add(passo);
                }

                MessageBox.Show(ehVariavel ? "VARIÁVEL" : "NÃO É VARIÁVEL", "Resultado da Compilação");
            }

            // ... resto do código do formulário ...
            private void InicializarComponentes()
            {
                // Código gerado pelo designer para criar caixaTextoEntrada, botaoCompilar, caixaListaPassos etc.
                // Exemplo:
                this.caixaTextoEntrada = new System.Windows.Forms.TextBox();
                this.botaoCompilar = new System.Windows.Forms.Button();
                this.caixaListaPassos = new System.Windows.Forms.ListBox();
                // ... configuração de propriedades, posição, etc. ...
                this.botaoCompilar.Click += new System.EventHandler(this.botaoCompilar_Click);
                // ... adicionar controles ao formulário ...
            }
        }
        */

}
