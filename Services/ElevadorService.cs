using System.Collections.Generic;
using ProvaAdmissionalApisul.Model;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace ProvaAdmissionalApisul.Services
{
    public class ElevadorService : IElevadorService
    {
        //Métodos para substituir algumas repetições
        public List<Respostas> respostas = new List<Respostas>();

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

        public int[] contaUtilizacaoPeriodo()
        {
            int[] frequenciaPeriodo = new int[3];

            foreach (var _respostas in respostas)
            {
                switch (_respostas.Turno)
                {
                    case 'M':
                        frequenciaPeriodo[0]++;
                        break;
                    case 'V':
                        frequenciaPeriodo[1]++;
                        break;
                    case 'N':
                        frequenciaPeriodo[2]++;
                        break;
                }
            }
            return frequenciaPeriodo;

        }

      
        //Métodos de implementação de IElevadorService
        public List<int> andarMenosUtilizado()
        {
            var frequenciaAndares = contaUtilizacaoAndares();
            var andarMenosUtilizado = new List<int>();
            int[] andar = {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15};

            for (var i = 0; i < frequenciaAndares.Length; i++)
            {
                if (frequenciaAndares.Min() == frequenciaAndares[i])
                {
                    andarMenosUtilizado.Add(andar[i]);
                }
            }
            return andarMenosUtilizado;        
        }            

        public List<char> elevadorMaisFrequentado()
        {
            var frequenciaElevadores = contaUtilizacaoElevadores();
            var elevadoresMaisFrequentados = new List<char>();
            char[] elevador = { 'A', 'B', 'C', 'D', 'E' };

            for (var i = 0; i < frequenciaElevadores.Length; i++)
            {
                if (frequenciaElevadores.Max() == frequenciaElevadores[i])
                {
                    elevadoresMaisFrequentados.Add(elevador[i]);
                }
            }
            return elevadoresMaisFrequentados;
        }      

        public List<char> periodoMaiorFluxoElevadorMaisFrequentado()
        {          
            var maiorPeriodoUtilizado = new List<char>();
            char[] turno = { 'M', 'V', 'N' };
            int[] quantidade = new int[3];

            foreach (var periodo in respostas)
            {
                foreach (var elevador in elevadorMaisFrequentado())
                {
                    if (elevador == periodo.Elevador)
                    {
                        switch (periodo.Turno)
                        {
                            case 'M':
                                quantidade[0]++;
                                break;
                            case 'V':
                                quantidade[1]++;
                                break;
                            case 'N':
                                quantidade[2]++;
                                break;

                        }  
                    }
                }
            }

            for (var i = 0; i < quantidade.Length; i++)
            {
                if (quantidade.Max() == quantidade[i])
                {
                    maiorPeriodoUtilizado.Add(turno[i]);
                }
            }

            return maiorPeriodoUtilizado;
        }         

        public List<char> elevadorMenosFrequentado()
        {
            var frequenciaElevadores = contaUtilizacaoElevadores();
            var elevadoresMenosFrequentados = new List<char>();
            char[] elevador = { 'A', 'B', 'C', 'D', 'E' };

            for (var i = 0; i < frequenciaElevadores.Length; i++)
            {
                if (frequenciaElevadores.Min() == frequenciaElevadores[i])
                {
                    elevadoresMenosFrequentados.Add(elevador[i]);
                }
            }
            return elevadoresMenosFrequentados;
        }      

        public List<char> periodoMenorFluxoElevadorMenosFrequentado()
        {
            var menorPeriodoUtilizado = new List<char>();
            char[] turno = { 'M', 'V', 'N' };
            int[] quantidade = new int[3];

            foreach (var periodo in respostas)
            {
                foreach (var elevador in elevadorMenosFrequentado())
                {
                    if (elevador == periodo.Elevador)
                    {
                        switch (periodo.Turno)
                        {
                            case 'M':
                                quantidade[0]++;
                                break;
                            case 'V':
                                quantidade[1]++;
                                break;
                            case 'N':
                                quantidade[2]++;
                                break;

                        }
                    }
                }
            }

            for (var i = 0; i < quantidade.Length; i++)
            {
                if (quantidade.Min() == quantidade[i])
                {
                    menorPeriodoUtilizado.Add(turno[i]);
                }
            }
            return menorPeriodoUtilizado;
        }         

        public List<char> periodoMaiorUtilizacaoConjuntoElevadores()
        {
            var frequenciaTurno = contaUtilizacaoPeriodo();
            var maiorPeriodoUtilizado = new List<char>();
            char[] turno = { 'M', 'V', 'N' };

            for (var i = 0; i < frequenciaTurno.Length; i++)
            {
                if (frequenciaTurno.Max() == frequenciaTurno[i])
                {
                     maiorPeriodoUtilizado.Add(turno[i]);
                }
            }
            return maiorPeriodoUtilizado;
        }          

        public float percentualDeUsoElevadorA()
        {
            var numeroElevadores = contaUtilizacaoElevadores();
            var operacaoPercentual = ((float)numeroElevadores[0] / respostas.Count) * 100;
            return operacaoPercentual;
        }          

        public float percentualDeUsoElevadorB()
        {
            var numeroElevadores = contaUtilizacaoElevadores();
            var operacaoPercentual = ((float)numeroElevadores[1] / respostas.Count) * 100;
            return operacaoPercentual;
        }        

        public float percentualDeUsoElevadorC()
        {
            var numeroElevadores = contaUtilizacaoElevadores();
            var operacaoPercentual = ((float)numeroElevadores[2] / respostas.Count) * 100;
            return operacaoPercentual;
        }         

        public float percentualDeUsoElevadorD()
        {
            var numeroElevadores = contaUtilizacaoElevadores();
            var operacaoPercentual = ((float)numeroElevadores[3] / respostas.Count) * 100;
            return operacaoPercentual;
        }          

        public float percentualDeUsoElevadorE()
        {
            var numeroElevadores = contaUtilizacaoElevadores();
            var operacaoPercentual = ((float)numeroElevadores[4] / respostas.Count) * 100;
            return operacaoPercentual;
        }          
    }
}
