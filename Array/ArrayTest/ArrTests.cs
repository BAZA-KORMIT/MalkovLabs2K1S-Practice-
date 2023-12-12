using MalkovPractOct;
namespace ArrayTest;

[TestClass]
public class ArrTests
{

    [TestMethod]
    public void AddArrTest()
    {
        int[,] values = {
            { 4, 3, 2, 1 },
            { 4, 3, 2, 1 },
            { 4, 3, 2, 1 }
        };
        int[,] arr = {
            { 1, 2, 3, 4 },
            { 1, 2, 3, 4 },
            { 1, 2, 3, 4 }
        };

        int[,] excepted = {
            { 5, 5, 5, 5 },
            { 5, 5, 5, 5 },
            { 5, 5, 5, 5 }
        };

        MalkovPractOct.Array arr1 = new MalkovPractOct.Array(values);
        MalkovPractOct.Array arr2 = new MalkovPractOct.Array(arr);
        MalkovPractOct.Array expected = new MalkovPractOct.Array(excepted);
        MalkovPractOct.Array actul = arr1.ArrAddArr(arr2);

        Assert.AreEqual(expected, actul);
    }

    [TestMethod]
    public void MulNumArrTest()
    {
        int[,] values = {
            { 4, 3, 2, 1 },
            { 4, 3, 2, 1 },
            { 4, 3, 2, 1 }
        };
        int num = 3;

        int[,] excepted = {
            { 3, 6, 9, 12 },
            { 3, 6, 9, 12 },
            { 3, 6, 9, 12 }
        };

        MalkovPractOct.Array arr1 = new MalkovPractOct.Array(values);
        
        MalkovPractOct.Array expected = new MalkovPractOct.Array(excepted);
        MalkovPractOct.Array actul = arr1.ArrMulNum(num);

        Assert.AreEqual(expected, actul);
    }
}
