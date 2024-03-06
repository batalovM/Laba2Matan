

using Laba2Matan;

class Program
{
    public static void Main(string[] args)
    {
        var eps = 0.001f; // Параметр точности
        float[,] a1 = { 
            {5f, 3f, 1f},
            {3f,1.79999f, 7f},
            {1f, 8f, 1f} };
        
        float[] b1 = { 
            12f,
            13.59998f, 
            18f };
        
        float[,] a2 = { 
            {2f, 15f, -1f},
            {12f, 2f, 3f},
            {1f, 2f, 16f} };
        float[,] a3 = { 
            {12f, 2f, 3f},
            {2f, 15f, -1f},
            {1f, 2f, 16f} };
        float[] b2 = { 
            29f,
            25f, 
            53f };
        var result1 = new GaussMethod(a1, b1).GaussWithoutMainElement();
        
        
        Console.WriteLine("Решение методом Гаусса без выбора главного элемента:");
        foreach (var x in result1)
        {
            Console.WriteLine(x);
        }
        var result2 = new GaussMethod(a1, b1).GaussWithMainElement();
        Console.WriteLine("Решение методом Гаусса с выбором главного элемента:");
        foreach (var x in result2)
        {
            Console.WriteLine(x);
        }
        var result3 = new SimpleIterations(a3, b2, eps).SimpleSolution();
        Console.WriteLine("Решение методом простых итераций:");
        foreach (var x in result3)
        {
            Console.WriteLine(x);
        }

        // var result4 = new Progon(A1, b1).Solve();
        // Console.WriteLine("Решение методом прогонки:");
        // foreach (var x in result4)
        // {
        //     Console.WriteLine(x);
        // }

    }
    
}