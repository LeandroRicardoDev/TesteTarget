using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Exercício 2");
            Exercicio2();
            Console.WriteLine();
            Console.Write("Aperte enter para exercício 3");
            Console.Read();
            Console.Clear();

            Console.WriteLine("Exercício 3");
            Exercicio3();
            Console.WriteLine();
            Console.Write("Aperte enter para exercício 4");
            Console.Read();
            Console.Clear();

            Console.WriteLine("Exercício 4");
            Exercicio4();
            Console.WriteLine();
            Console.Write("Aperte enter para exercício 5");
            Console.Read();
            Console.Clear();

            Console.Write("Exercício 5");
            Exercicio5();
        }

        public class FaturamentoDiario
        {
            public int Dia { get; set; }
            public double Valor { get; set; }
        }
        public class FaturamentoPorEstado
        {
            public string Estado { get; set; }
            public double Valor { get; set; }
        }

        public static void Exercicio5()
        {
            string texto = "Minha String para Inverter";
            string textoInvertido = "";

            for (int i = texto.Length - 1; i >= 0; i--)
            {
                textoInvertido += texto[i];
            }

            Console.WriteLine(string.Format("Original : {0}", texto));
            Console.WriteLine(string.Format("Invertido: {0}", textoInvertido));
        }

        public static void Exercicio4()
        {
            List<FaturamentoPorEstado> faturamentos = new List<FaturamentoPorEstado>();

            faturamentos.Add(new FaturamentoPorEstado { Estado = "SP", Valor = double.Parse("67836,43") });
            faturamentos.Add(new FaturamentoPorEstado { Estado = "RJ", Valor = double.Parse("36678,66") });
            faturamentos.Add(new FaturamentoPorEstado { Estado = "MG", Valor = double.Parse("29229,88") });
            faturamentos.Add(new FaturamentoPorEstado { Estado = "ES", Valor = double.Parse("27165,48") });
            faturamentos.Add(new FaturamentoPorEstado { Estado = "OUTROS", Valor = double.Parse("19849,53") });

            // Total
            double total = faturamentos.Sum(x => x.Valor);

            // Calcula o percentual por estado
            foreach (var faturamento in faturamentos)
            {
                Console.WriteLine(string.Format("{0}: {1}%", faturamento.Estado, (faturamento.Valor / total) * 100));
            }
        }

        public static void Exercicio3()
        {
            List<FaturamentoDiario> faturamentos = new List<FaturamentoDiario>();

            using (StreamReader r = new StreamReader("dados.json"))
            {
                string json = r.ReadToEnd();
                faturamentos = JsonConvert.DeserializeObject<List<FaturamentoDiario>>(json);
            }

            // Valores
            double menorFaturamento = double.MaxValue;
            double maiorFaturamento = 0;
            double mediaDiaria = 0;
            double totalFaturamento = 0;
            int diasFaturamento = 0;
            int diasAcimaMedia = 0;

            // Roda os calculos
            foreach (var faturamento in faturamentos)
            {
                if (faturamento.Valor > 0)
                {
                    // Define maior e menor
                    if (faturamento.Valor < menorFaturamento) menorFaturamento = faturamento.Valor;
                    if (faturamento.Valor > maiorFaturamento) maiorFaturamento = faturamento.Valor;

                    // Para calcular a média
                    totalFaturamento += faturamento.Valor;
                    diasFaturamento++;
                }
            }

            // Calcula a média
            mediaDiaria = totalFaturamento / (double)diasFaturamento;

            // Conta todos os dias que estão acima da média
            diasAcimaMedia = faturamentos.Where(x => x.Valor > mediaDiaria).Count();

            Console.WriteLine($"Menor valor em um dia do mês: {menorFaturamento}");
            Console.WriteLine($"Maior valor em um dia do mês: {maiorFaturamento}");
            Console.WriteLine($"Número de dias no mês em que o valor de faturamento diário foi superior à média mensal: {diasAcimaMedia}");
        }
        public static void Exercicio2()
        {
            inicio:
            Console.Write("Informe um número para a sequência Fibonacci: ");
            string texto = Console.ReadLine();

            if (texto == null || texto == "")
            {
                goto inicio;
            }
            else
            {
                int x = int.Parse(texto);

                int num1 = 0, num2 = 1, aux;

                for (int i = 0; i​​​​​​​ < x; i++)
                {
                    aux = num1;
                    num1 = num2;
                    num2 = num1 + aux;
                    Console.WriteLine("{0}", num2);
                }
            }
        }
    }
}
