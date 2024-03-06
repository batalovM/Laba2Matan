namespace Laba2Matan;

public class GaussMethod
{
   private readonly float[,] _a;
   private readonly float[] _b;

   public GaussMethod(float[,] a, float[] b)
   {
      _a = a;
      _b = b;
   }
   private float[,] ExtendedMatrix(float[,] a, IReadOnlyList<float> b)//расширенная матрица
   {
      var n = a.GetLength(0); // Размерность системы
      var matrix = new float[n, n + 1]; // Расширенная матрица
      for (var i = 0; i < n; i++)// Заполнение расширенной матрицы
      {
         for (var j = 0; j < n; j++)
         {
            matrix[i, j] = a[i, j];
         }
         matrix[i, n] = b[i];
      }
      return matrix;
   }
   public IEnumerable<float> GaussWithoutMainElement()//метод Гаусса без выбора главного элемента
   {
      var n = _a.GetLength(0); // Размерность системы
      var matrix = ExtendedMatrix(_a, _b);//расширенная и заполненная матрица
      
      for (var i = 0; i < n; i++)// Прямой ход метода Гаусса
      {
         for (var j = i + 1; j < n; j++)
         {
            var factor = matrix[j, i] / matrix[i, i];
            for (var k = i; k < n + 1; k++)
            {
               matrix[j, k] -= factor * matrix[i, k];
            }
         }
      }
     
      var x = new float[n]; // Обратный ход метода Гаусса
      for (var i = n - 1; i >= 0; i--)
      {
         x[i] = matrix[i, n] / matrix[i, i];
         for (var j = i - 1; j >= 0; j--)
         {
            matrix[j, n] -= matrix[j, i] * x[i];
         }
      }
      return x;
   }
   public IEnumerable<float> GaussWithMainElement()
   {
      var n = _a.GetLength(0);
      var x = new float[n];
      var matrix = ExtendedMatrix(_a, _b);
      for (var i = 0; i < n; i++)
      {
         // Прямой ход
         for (var j = i + 1; j < n; j++)
         {
            if (!(Math.Abs(matrix[i, i]) < Math.Abs(matrix[j, i]))) continue;
            for (var k = 0; k <= n; k++)
            {
               (matrix[i, k], matrix[j, k]) = (matrix[j, k], matrix[i, k]);
            }
         }
         // Приведение матрицы к треугольному виду
         for (var j = i + 1; j < n; j++)
         {
            var factor = matrix[j, i] / matrix[i, i];
            for (var k = i; k <= n; k++)
            {
               matrix[j, k] -= factor * matrix[i, k];
            }
         }
      }
      // Обратный ход
      for (var i = n - 1; i >= 0; i--)
      {
         x[i] = matrix[i, n];
         for (var j = i + 1; j < n; j++)
         {
            x[i] -= matrix[i, j] * x[j];
         }
         x[i] /= matrix[i, i];
      }

      return x;
   }
}