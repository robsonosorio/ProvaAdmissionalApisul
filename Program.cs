using System;
using ProvaAdmissionalApisul.Services;

namespace ProvaAdmissionalApisul
{
    class Program
    {
        static void Main(string[] args)
        {
            ElevadorService elevadorService = new ElevadorService();


            foreach (var elevador in elevadorService.andarMenosUtilizado())
            {
                Console.WriteLine($"Andar '{elevador}' menos utilizado\n");
            }

            foreach (var elevador in elevadorService.elevadorMaisFrequentado())
            {
                foreach (var periodo in elevadorService.periodoMaiorFluxoElevadorMaisFrequentado())
                {
                    Console.WriteLine($"Elevador mais frequentado = '{elevador}'. Maior fluxo ocorre no periodo '{periodo}'\n");
                }
            }

            string elevadorMenosFrequentado = "", periodoMenor = "";       
            foreach (var elevador in elevadorService.elevadorMenosFrequentado())
            {
                elevadorMenosFrequentado += "'" + elevador.ToString() + "' ";
            }
            foreach (var periodo in elevadorService.periodoMenorFluxoElevadorMenosFrequentado())
            {
                periodoMenor += "'" + periodo.ToString() + "' ";
            }
            Console.WriteLine($"Elevador menos frequentado = {elevadorMenosFrequentado}.  Menor fluxo ocorre no período {periodoMenor}\n");
            
           

            foreach (var _resposta in elevadorService.periodoMaiorUtilizacaoConjuntoElevadores())
            {
                Console.WriteLine($"Periodo '{_resposta}' tem maior fluxo de utilização dos elevadores. \n");
            }

            Console.WriteLine("Percentual de uso do elevador A = " + elevadorService.percentualDeUsoElevadorA().ToString("F2") + "%" );
            Console.WriteLine("Percentual de uso do elevador B = " + elevadorService.percentualDeUsoElevadorB().ToString("F2") + "%" );
            Console.WriteLine("Percentual de uso do elevador C = " + elevadorService.percentualDeUsoElevadorC().ToString("F2") + "%" );
            Console.WriteLine("Percentual de uso do elevador D = " + elevadorService.percentualDeUsoElevadorD().ToString("F2") + "%" );
            Console.WriteLine("Percentual de uso do elevador E = " + elevadorService.percentualDeUsoElevadorE().ToString("F2") + "%" );
            

            

            Console.ReadKey();
        }

    }
}
