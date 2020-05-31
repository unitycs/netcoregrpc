namespace extensionMethodLib
{
    public class Complex
    {
        //实数 
        protected double real;
        public double Real => real;

        public double Imag { get; }
        public Complex(double real, double imag)
        {
            this.real = real;
            this.Imag = imag;
        }
    }

}
