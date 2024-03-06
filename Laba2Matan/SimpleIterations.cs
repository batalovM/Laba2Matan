namespace Laba2Matan;

public class SimpleIterations
{
    private readonly float[,] _a;
    private readonly float[] _b;
    private readonly float _eps;
    
    public SimpleIterations(float[,] a, float[] b, float eps)
    {
        _a = a;
        _b = b;
        _eps = eps;
    }

    private bool IsNeedToComplete(IReadOnlyList<float> xOld, IReadOnlyList<float> xNew)
    {
        var sumUp = 0f;
        var sumLow = 0f;
        for (var k = 0; k < xOld.Count; k++)
        {
            sumUp += (float)Math.Pow(xNew[k] - xOld[k], 2);
            sumLow += (float)Math.Pow(xNew[k], 2);
        }

        return Math.Sqrt(sumUp / sumLow) < _eps;
    }
    public IEnumerable<float> SimpleSolution()
    {
        var n = _b.GetLength(0);
        var x = new float[n];
        Array.Copy(_b, x, n);
        var numberOfIter = 0;
        const int maxIter = 100;
       
        while (numberOfIter < maxIter)
        {
            var xPrev = new float[n];
            Array.Copy(x, xPrev, n);
            for (var k = 0; k < n; k++)
            {
                var s = 0f;
                for (var j = 0; j < n; j++)
                {
                    if (j != k) s += _a[k, j] * x[j];
                }

                x[k] = _b[k] / _a[k, k] - s / _a[k, k];
            }

            if (IsNeedToComplete(xPrev, x) || Norm(xPrev, x) < 1) break;
            numberOfIter += 1;
        }
        return x;
    }
    private static float Norm(IEnumerable<float> x, float[] y)
    {
        if (y == null) throw new ArgumentNullException(nameof(y));
        var norm = x.Select((t, i) => (float)Math.Pow(t - y[i], 2)).Sum();
        return (float)Math.Sqrt(norm);
    }
}













// private void MakeMatrixDiagonallyDominant()
// {
//     var n = _A.Length;
//     
//     for (var i = 0; i < _A.GetLength(0); i++)
//     {
//         float sum = 0;
//         for (var j = 0; j < _A.GetLength(1); j++)
//         {
//             if (j != i)
//             {
//                 sum += Math.Abs(_A[i, j]);
//             }
//         }
//     
//         _A[i, i] += sum + 1;
//     }
// }
    
    