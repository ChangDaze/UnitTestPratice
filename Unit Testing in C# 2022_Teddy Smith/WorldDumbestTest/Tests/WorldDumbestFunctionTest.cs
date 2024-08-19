using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldDumbestTest.Tests
{
    public static class WorldDumbestFunctionTest
    {
        //Naming Convetion - ClassName_MethodName_ExpectedResult
        public static void WorldDumbestFunction_ReturnPikachuIfZero_ReturnString()
        {
            try
            {
                //Triple A (AAA)
                //Arragne - Go get your variables, whatever you need, your classes, go get functions
                int num = 0;
                WorldDumbestFunction worldDumbestFunction = new WorldDumbestFunction();

                //Act - Execute this function
                string result = worldDumbestFunction.ReturnPikachuIfZero(num);

                //Assert - Whatever is returned is it what you want
                if (result == "PIKACHU!")
                {
                    Console.WriteLine("PASSED: WorldDumbestFunction_ReturnPikachuIfZero_ReturnString");
                }
                else
                {
                    Console.WriteLine("FAILED: WorldDumbestFunction_ReturnPikachuIfZero_ReturnString");
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
