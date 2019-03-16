using BehavioralPattern.Command;
using BehavioralPattern.Interpreter;
using BehavioralPattern.Iterator;
using BehavioralPattern.Mediator;
using BehavioralPattern.Memento;

namespace BehavioralPattern
{
    class Program
    {


        static void createChain()
        {
        }

        static void createCommand()
        {
            var command = new ClientCommand();
        }

        static void createInterpreter()
        {
            var command = new ClientInterpreter();
        }


        static void createIterator()
        {
            var command = new ClientIterator();
        }


        static void createMediator()
        {
            var command = new ClientMediator();
        }


        static void createMemento()
        {
            var command = new ClientObserver();
        }


        static void createObserver()
        {
            var command = new ClientObserver();
        }



        static void Main(string[] args)
        {
            createObserver();
        }
    }
}
