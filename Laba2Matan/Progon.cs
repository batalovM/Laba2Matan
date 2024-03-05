namespace Laba2Matan;

public class Progon
{
    private float[,] _A;
    private float[] _b;
    public Progon(float[,] A, float[] b)
    {
        _A = A;
        _b = b;
    }
    public float[] Solve()
    {
        var n = _b.Length;
        var alpha = new float[n - 1];
        var beta = new float[n];
        var x = new float[n];

        alpha[0] = _A[0, 1] / _A[0, 0];
        beta[0] = _b[0] / _A[0, 0];

        for (var i = 1; i < n - 1; i++)
        {
            alpha[i] = _A[i, i + 1] / (_A[i, i] - _A[i, i - 1] * alpha[i - 1]);
        }

        for (var i = 1; i < n; i++)
        {
            beta[i] = (_b[i] - _A[i, i - 1] * beta[i - 1]) / (_A[i, i] - _A[i, i - 1] * alpha[i - 1]);
        }

        x[n - 1] = beta[n - 1];
        for (var i = n - 2; i >= 0; i--)
        {
            x[i] = beta[i] - alpha[i] * x[i + 1];
        }

        return x;
    }

}