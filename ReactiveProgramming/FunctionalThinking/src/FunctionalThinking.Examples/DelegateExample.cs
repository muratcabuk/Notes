
namespace FunctionalThinking
{


    public class DelegateStringComparators
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

    public class DelegateComparator
    {


       public delegate bool ComparisonTest (string first, string second);
        string s1 = "Hello";
        string s2 = "World";

        public void Compare()
        {

            var comparators = new DelegateStringComparators();
          var ContentResul = new ComparisonTest(comparators.CompareContent)(s1,s2);


            var LenghtResult = new ComparisonTest(DelegateStringComparators.CompareLength)(s1,s2);

        }



    }



}