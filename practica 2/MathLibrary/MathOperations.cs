namespace MathLibrary
{
    public class MathOperations
    {
        public double Sumar(double a, double b)
        {
            return a + b;
        }

          public double Sumar(double a, double b, double c)
        {
            return a + b + c;
        }

        public double Restar(double a, double b)
        {
            return a - b;
        }

        public double Multiplicar(double a, double b)
        {
            return a * b;
        }

        public double Dividir(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("División por cero no permitida.");
            }
                return a / b;
        }
    }
}
