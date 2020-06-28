using System;
using System.Collections.Generic;
using ProvaAdmissionalApisul.Services;
using ProvaAdmissionalApisul.Model;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.ComponentModel;

namespace ProvaAdmissionalApisul
{
    class Program
    {
        static void Main(string[] args)
        {
            ElevadorService elevadorService = new ElevadorService();

            var elevadoresMaisFrequentados = elevadorService.elevadorMaisFrequentado();
            var elevadoresMenosFrequentados = elevadorService.elevadorMenosFrequentado();
            var andarMenosUtilizado = elevadorService.andarMenosUtilizado();

            foreach (var _resposta in elevadoresMaisFrequentados)
            {
                Console.WriteLine($"Elevador '{_resposta}' é o mais frequentado. " );
            }
            foreach (var _resposta in elevadoresMenosFrequentados)
            {
                Console.WriteLine($"Elevador '{_resposta}' é o menos frequentado. ");
            }

            foreach (var _resposta in andarMenosUtilizado)
            {
                Console.Write($"Andar '{_resposta}' menos utilizado. ");
            }


            Console.ReadKey();
        }

    }
}
