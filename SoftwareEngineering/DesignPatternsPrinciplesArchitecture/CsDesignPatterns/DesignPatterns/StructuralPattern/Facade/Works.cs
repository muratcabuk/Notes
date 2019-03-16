using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPattern.Facade
{
    class Works
    {

        private void work1()
        {

            Console.WriteLine("birinci iş yapıldı");

        }
        private void work2()
        {
            Console.WriteLine("ikinci iş yapıldı");

        }

        private void work3()
        {
            Console.WriteLine("ucuncu iş yapıldı");

        }

        public void MainWork()
        {

            //bunların hepsi farklı class lardan da gelebilirdi tabiiki

            work1();
            work2();
            work3();

            Console.WriteLine("Bütün işler yapıldı");


        }


    }
}
