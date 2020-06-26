using System;
using System.Collections.Generic;
using ProvaAdmissionalApisul.Services;
using ProvaAdmissionalApisul.Model;
using System.IO;
using Newtonsoft.Json;


namespace ProvaAdmissionalApisul
{
    class Program
    {
        static void Main(string[] args)
        {
            var teste = File.ReadAllText(@"C:\ProvaAdmissionalApisul\input.json");
            List<Predio> deserializedJson = JsonConvert.DeserializeObject<List<Predio>>(teste);

            foreach (var item in deserializedJson)
            {
                Console.WriteLine("Andar " + item.Andar + "  Elevador " + item.Elevador + "  Turno " + item.Turno);
            }
        }
      
    }
}
