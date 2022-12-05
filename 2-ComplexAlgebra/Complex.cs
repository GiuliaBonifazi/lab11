using System;
using System.Collections.Generic;

namespace ComplexAlgebra
{
    /// <summary>
    /// A type for representing Complex numbers.
    /// </summary>
    ///
    /// TODO: Model Complex numbers in an object-oriented way and implement this class.
    /// TODO: In other words, you must provide a means for:
    /// TODO: * instantiating complex numbers
    /// TODO: * accessing a complex number's real, and imaginary parts
    /// TODO: * accessing a complex number's modulus, and phase
    /// TODO: * complementing a complex number
    /// TODO: * summing up or subtracting two complex numbers
    /// TODO: * representing a complex number as a string or the form Re +/- iIm
    /// TODO:     - e.g. via the ToString() method
    /// TODO: * checking whether two complex numbers are equal or not
    /// TODO:     - e.g. via the Equals(object) method
    public class Complex
    {
        public Complex (double re, double im) 
        {
            Real = re;
            Imaginary = im;
        }

        public double Real {get; }

        public double Imaginary {get; }

        public double Modulus 
        {
            get => Math.Sqrt(Real * Real + Imaginary * Imaginary);
        } 

        public double Phase 
        {
            get => Math.Atan2(Imaginary , Real);
        }

        public Complex Complement 
        {
            get => new Complex( Real, - Imaginary);
        } 
        public Complex Plus(Complex other) => new Complex(Real + other.Real, Imaginary + other.Imaginary);

        public Complex Minus(Complex other) => new Complex(Real - other.Real, Imaginary - other.Imaginary);

        public override string ToString() 
        {
            string ImString;
            if(Math.Abs(Imaginary) == 1) 
            {
                ImString = "i";
            } else
            {
                ImString = (Imaginary == 0 ) ? Imaginary.ToString() : "i" + Math.Abs(Imaginary);
            }

            
            if(Real == 0) 
            {
                return (Imaginary >= 0) ? ImString : " - " + ImString;
            }
            else if (Imaginary == 0) 
            {
                return Real.ToString();
            }
            else
            {
                return (Imaginary > 0) ? Real + " + " + ImString : Real + " - " + ImString;
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Complex complex &&
                   Real == complex.Real &&
                   Imaginary == complex.Imaginary;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Real, Imaginary, Real, Imaginary, Modulus, Phase, Complement);
        }
    }
}