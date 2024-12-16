// Clase que representa un Círculo
using System;

public class Circulo
{
    // Atributo que almacena el radio del círculo
    private double radio;

    // Constructor para inicializar el radio
    public Circulo(double radio)
    {
        this.radio = radio;
    }

    // Método para calcular el área del círculo
    // Devuelve un valor double que es el área calculada
    public double CalcularArea()
    {
        return Math.PI * radio * radio;
    }

    // Método para calcular el perímetro (circunferencia) del círculo
    // Devuelve un valor double que es el perímetro calculado
    public double CalcularPerimetro()
    {
        return 2 * Math.PI * radio;
    }

    // Método para imprimir los resultados del cálculo
    public void ImprimirCalculos()
    {
        Console.WriteLine("Círculo:");
        Console.WriteLine(" - Radio: " + radio);
        Console.WriteLine(" - Área: " + CalcularArea());
        Console.WriteLine(" - Perímetro: " + CalcularPerimetro());
    }
}

// Clase que representa un Rectángulo
public class Rectangulo
{
    // Atributos que almacenan la base y la altura del rectángulo
    private double baseRectangulo;
    private double altura;

    // Constructor para inicializar la base y la altura
    public Rectangulo(double baseRectangulo, double altura)
    {
        this.baseRectangulo = baseRectangulo;
        this.altura = altura;
    }

    // Método para calcular el área del rectángulo
    // Devuelve un valor double que es el área calculada
    public double CalcularArea()
    {
        return baseRectangulo * altura;
    }

    // Método para calcular el perímetro del rectángulo
    // Devuelve un valor double que es el perímetro calculado
    public double CalcularPerimetro()
    {
        return 2 * (baseRectangulo + altura);
    }

    // Método para imprimir los resultados del cálculo
    public void ImprimirCalculos()
    {
        Console.WriteLine("Rectángulo:");
        Console.WriteLine(" - Base: " + baseRectangulo);
        Console.WriteLine(" - Altura: " + altura);
        Console.WriteLine(" - Área: " + CalcularArea());
        Console.WriteLine(" - Perímetro: " + CalcularPerimetro());
    }
}

// Ejemplo de uso
class Program
{
    static void Main(string[] args)
    {
        // Crear un círculo con radio 5
        Circulo circulo = new Circulo(5);
        circulo.ImprimirCalculos();

        // Crear un rectángulo con base 4 y altura 7
        Rectangulo rectangulo = new Rectangulo(4, 7);
        rectangulo.ImprimirCalculos();
    }
}
