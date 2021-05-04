using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPattern.AbstractFactory.Bank
{
   public class Bankamatic
   {
       private ProcessPhases _processPhases;
       private Process _process;

       public Bankamatic(ProcessPhases processPhases)
       {
           _processPhases = processPhases;

           _process = processPhases.BankProcess();

       }


       public void ProcessResult()
       {

      _process.Apply();


       }









   }
}
