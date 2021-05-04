
namespace FunctionalThinking
{


    public class DelegateAnonymousStringComparators
    {
        public static bool CompareLength(string first, string second)
        {
            return first.Length == second.Length;
        }
        public bool CompareContent(string first, string second)
        {
            return first == second;
        }
    }

    public class Comparator
    {


        public delegate bool ComparisonTest(string first, string second);
        string[] cities = new[] { "Istanbul", "Ankara", "Izmir" };
        string[] friends = new[] { "Murat", "Ahmet", "Mehmet" };


        ComparisonTest lengthComparer = delegate (string first, string second)
        {
            return first.Length == second.Length;
        };


        ComparisonTest contentComparer = delegate (string first, string second)
        {
            return first == second;
        };



        bool AreSimilar(string[] first, string[] second, ComparisonTest tester)
        {

            if (first.Length != second.Length)
                return false;
            for (int i = 0; i < first.Length; i++)
            {
                if (tester(first[i], second[i]) == false)
                {
                    return false;
                }
            }
            return true;

        }

        //Using Anonymous in closure
        // teo types: method and class clousure
        // method closure is used in this example
        public void Compare()
        {

int moduloBase = 2;
            var areSimilar = AreSimilar(friends, cities,  delegate(string s1, string s2){
return ((s1.Length % moduloBase) == (s2.Length % moduloBase));


            }





        }




    }



}