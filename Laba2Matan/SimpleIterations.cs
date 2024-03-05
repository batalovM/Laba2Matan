namespace Laba2Matan;

public class SimpleIterations
{
    private float[,] _A;
    private float[] _b;
    private float _eps;
    
    public SimpleIterations(float[,] A, float[] b, float eps)
    {
        _A = A;
        _b = b;
        _eps = eps;
    }

    public IEnumerable<float> SimpleSolution()
    {
        var n = _b.Length;
        var x = new float[n];
        var B = new float[n];
        const int maxIter = 100;

        MakeMatrixDiagonallyDominant();

        Array.Copy(_b, x, n); 

        for (var iter = 0; iter < maxIter; iter++)
        {
            for (var i = 0; i < n; i++)
            {
                B[i] = _b[i] / _A[i, i]; // Вычисляем Bi = bi/aii
                for (var j = 0; j < n; j++)
                {
                    if (j != i )
                    {
                        B[j] -= (_A[i, j] / _A[i, i]); // Вычисляем aij = aij/aii
                    }
                    
                }
            }
            if (Norm(x, B) <= _eps)
            {
                break;
            }

            Array.Copy(B, x, n);
        }

        return x;
    }
    private float Norm(float[] x, float[] y)
    {
        var norm = x.Select((t, i) => (float)Math.Pow(t - y[i], 2)).Sum();
        return (float)Math.Sqrt(norm);
    }

    private void MakeMatrixDiagonallyDominant()
    {
        var n = _A.Length;
        
        for (var i = 0; i < _A.GetLength(0); i++)
        {
            float sum = 0;
            for (var j = 0; j < _A.GetLength(1); j++)
            {
                if (j != i)
                {
                    sum += Math.Abs(_A[i, j]);
                }
            }
        
            _A[i, i] += sum + 1;
        }
    }
    
 
}
    
    