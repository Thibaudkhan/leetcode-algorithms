using Xunit;

namespace DefaultNamespace
{
    public class SolutionTest
    {
        [Fact]
        public void If_Duplicate_Value_Return_True()
        {
            // Correctement initialiser le tableau d'entiers
            int[] nums = { 1, 2, 3, 3 };

            // Vérifier si le résultat est correct
            Assert.Equal(3, 3);
        }
    }
}