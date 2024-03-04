namespace Laba2Matan;

public class GaussMethod
{
   private float[,] _A;
   private float[] _b;

   public GaussMethod(float[,] A, float[] b)
   {
      _A = A;
      _b = b;
   }
   
   public IEnumerable<float> GaussWithoutMainElement()//метод Гаусса без выбора главного элемента
   {
      var n = _A.GetLength(0); // Размерность системы
      var matrix = ExtendedMatrix(_A, _b);//расширенная и заполненная матрица
      
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
      var n = _A.GetLength(0); // Размерность системы
      var matrix = ExtendedMatrix(_A, _b);//расширенная и заполненная матрица
      
      for (var i = 0; i < n; i++)// Прямой ход метода Гаусса с выбором главного элемента
      {
         var maxRow = i; // Выбор главного элемента в столбце i
         for (var k = i + 1; k < n; k++) { if (MathF.Abs(matrix[k, i]) > MathF.Abs(matrix[maxRow, i])) maxRow = k; }
         if (maxRow != i)// Обмен строк, чтобы главный элемент был на диагонали
         {
            for (var k = i; k < n + 1; k++) { (matrix[i, k], matrix[maxRow, k]) = (matrix[maxRow, k], matrix[i, k]); }
         }
         for (var j = i + 1; j < n; j++)
         {
            var factor = matrix[j, i] / matrix[i, i];
            for (var k = i; k < n + 1; k++) { matrix[j, k] -= factor * matrix[i, k]; }
         }
      }
      var x = new float[n]; // Обратный ход метода Гаусса
      for (var i = n - 1; i >= 0; i--)
      {
         x[i] = matrix[i, n] / matrix[i, i];
         for (var j = i - 1; j >= 0; j--) { matrix[j, n] -= matrix[j, i] * x[i]; }
      }
      return x;
   }
   
   
   private float[,] ExtendedMatrix(float[,] A, float[] b)//расширенная матрица
   {
      var n = A.GetLength(0); // Размерность системы
      var matrix = new float[n, n + 1]; // Расширенная матрица
      for (var i = 0; i < n; i++)// Заполнение расширенной матрицы
      {
         for (var j = 0; j < n; j++)
         {
            matrix[i, j] = A[i, j];
         }
         matrix[i, n] = b[i];
      }
      return matrix;
   }
}