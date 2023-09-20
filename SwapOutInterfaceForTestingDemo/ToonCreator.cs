
using SwapOutInterfaceForTestingDemo.Enums;
using SwapOutInterfaceForTestingDemo.Interfaces;
using SwapOutInterfaceForTestingDemo.Models;
using System;
using System.Security.Cryptography.X509Certificates;

namespace SwapOutInterfaceForTestingDemo
{
    public class ToonCreator
    {
        public ILogger<ToonCreator> Logger { get; }
        public ToonCreator(ILogger<ToonCreator> logger)
        {
            Logger = logger;
        }

        public List<Toon> GenerateNewToons(int quantity)
        {
            CasterType[] casters = (CasterType[])Enum.GetValues(typeof(CasterType));
            Random random = new Random();
            var result = new List<Toon>();
            

            for (int i = 0; i < quantity; i++)
            {
                var caster = random.Next(0, casters.Length);

                result.Add(
                    new Toon()
                    {

                    });

            }

            return result;

        }
    }
}
