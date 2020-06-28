using System;
using System.Collections.Generic;
using ProvaAdmissionalApisul.Model;
using Newtonsoft.Json;
using System.IO;
using System.Data;
using System.ComponentModel;
using System.Reflection;
using Microsoft.VisualBasic;
using System.Linq;

namespace ProvaAdmissionalApisul.Services
{
    public class ElevadorService : IElevadorService
    {
        //Métodos para substituir repetições
       
        List<Respostas> respostas = new List<Respostas>();
        
        public ElevadorService()
        {
            var json = File.ReadAllText(@"C:\ProvaAdmissionalApisul\input.json");
            respostas = JsonConvert.DeserializeObject<List<Respostas>>(json);
        }
    
        public int[] contaUtilizacaoElevadores()
        {
            int[] frequenciaElevadores = new int[5];
            
            foreach (var _respostas in respostas)
            {
                switch (_respostas.Elevador)
                {
                    case 'A':
                        frequenciaElevadores[0]++;
                        break;
                    case 'B':
                        frequenciaElevadores[1]++;
                        break;
                    case 'C':
                        frequenciaElevadores[2]++;
                        break;
                    case 'D':
                        frequenciaElevadores[3]++;
                        break;
                    case 'E':
                        frequenciaElevadores[4]++;
                        break;
                }        
            }
            return frequenciaElevadores;

        }

        public int[] contaUtilizacaoAndares()
        {
            int[] frequenciaAndares = new int[16];
            foreach (var _respostas in respostas)
            {
                switch (_respostas.Andar)
                {
                    case 0:
                        frequenciaAndares[0]++;
                        break;
                    case 1:
                        frequenciaAndares[1]++;
                        break;
                    case 2:
                        frequenciaAndares[2]++;
                        break;
                    case 3:
                        frequenciaAndares[3]++;
                        break;
                    case 4:
                        frequenciaAndares[4]++;
                        break;
                    case 5:
                        frequenciaAndares[5]++;
                        break;
                    case 6:
                        frequenciaAndares[6]++;
                        break;
                    case 7:
                        frequenciaAndares[7]++;
                        break;
                    case 8:
                        frequenciaAndares[8]++;
                        break;
                    case 9:
                        frequenciaAndares[9]++;
                        break;
                    case 10:
                        frequenciaAndares[10]++;
                        break;
                    case 11:
                        frequenciaAndares[11]++;
                        break;
                    case 12:
                        frequenciaAndares[12]++;
                        break;
                    case 13:
                        frequenciaAndares[13]++;
                        break;
                    case 14:
                        frequenciaAndares[14]++;
                        break;
                    case 15:
                        frequenciaAndares[15]++;
                        break;
                }
            }
            return frequenciaAndares;
        }

        public float operacaoPercentual()
        {
            throw new NotImplementedException();
        }


        //Métodos de implementação de IElevadorService
        public List<int> andarMenosUtilizado()
        {
            int[] frequenciaAndares = contaUtilizacaoAndares();
            var andarMenosUtilizado = new List<int>();
            int[] andar = {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15};


            var menosUtilizado = frequenciaAndares.Min();

            for (var i = 0; i < frequenciaAndares.Length; i++)
            {
                if (menosUtilizado == frequenciaAndares[i])
                {
                    andarMenosUtilizado.Add(andar[i]);
                }
            }
            return andarMenosUtilizado;
            
        }            // <= [OK]

        public List<char> elevadorMaisFrequentado()
        {
            int[] frequenciaElevadores = contaUtilizacaoElevadores();
            var elevadoresMaisFrequentados = new List<char>();
            char[] elevador = { 'A', 'B', 'C', 'D', 'E' };

            var maiorFrequencia = frequenciaElevadores.Max();
            

            for (var i = 0; i < frequenciaElevadores.Length; i++)
            {
                if (maiorFrequencia == frequenciaElevadores[i])
                {
                    elevadoresMaisFrequentados.Add(elevador[i]);
                }
            }
            return elevadoresMaisFrequentados;
        }      // <= [OK]

        public List<char> periodoMaiorFluxoElevadorMaisFrequentado()
        {



            throw new NotImplementedException();
        } 

        public List<char> elevadorMenosFrequentado()
        {
            int[] frequenciaElevadores = contaUtilizacaoElevadores();
            var elevadoresMenosFrequentados = new List<char>();
            char[] elevador = { 'A', 'B', 'C', 'D', 'E' };

            var menorFrequencia = frequenciaElevadores.Min();


            for (var i = 0; i < frequenciaElevadores.Length; i++)
            {
                if (menorFrequencia == frequenciaElevadores[i])
                {
                    elevadoresMenosFrequentados.Add(elevador[i]);
                }
            }
            return elevadoresMenosFrequentados;

        }      // <= [OK]

        public List<char> periodoMenorFluxoElevadorMenosFrequentado()
        {
            throw new NotImplementedException();
        }

        public List<char> periodoMaiorUtilizacaoConjuntoElevadores()
        {
            throw new NotImplementedException();
        }

        public float percentualDeUsoElevadorA()
        {
            throw new NotImplementedException();
        }

        public float percentualDeUsoElevadorB()
        {
            throw new NotImplementedException();
        }

        public float percentualDeUsoElevadorC()
        {
            throw new NotImplementedException();
        }

        public float percentualDeUsoElevadorD()
        {
            throw new NotImplementedException();
        }

        public float percentualDeUsoElevadorE()
        {

            throw new NotImplementedException();
        }

    }
}
