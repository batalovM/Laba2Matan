

using Laba2Matan;

class Program
{
    public static void Main(string[] args)
    {
        float[,] A = { 
            {5f, 3f, 1f},
            {3f,1.79999f, 7f},
            {1f, 8f, 1f} };
        
        float[] b = { 
            12f,
            13.59998f, 
            18f };
        var result1 = new GaussMethod(A, b).GaussWithoutMainElement();
        var result2 = new GaussMethod(A, b).GaussWithMainElement();
        Console.WriteLine("Решение методом Гаусса без выбора главного элемента:");
        foreach (var x in result1)
        {
            Console.WriteLine(x);
        }
        Console.WriteLine("Решение методом Гаусса с выбором главного элемента:");
        foreach (var x in result2)
        {
            Console.WriteLine(x);
        }
    }
    
}