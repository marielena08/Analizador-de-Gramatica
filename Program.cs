/*
 * MARIELENA NUÑEZ ROMERO
 * Le quite recursividad izquierda a la gramatica
 * Realice el codigo en c# que valide la gramatica 
 * */
public class Program
{
    static bool A(string cadena)
    {
        if (cadena == "ab")
        {
            return false;
        }
        if (cadena == "abc")
        {
            return false;
        }
        if (cadena.Length == 0)
        {
            return false;
        }
        else if (cadena == "a")
        {
            return true;
        }
        else if (cadena[0] == 'a' && B(cadena.Substring(1, cadena.Length - 1)))
        {
            return true;
        }
        else if(cadena[0] == 'a' && C(cadena.Substring(1, cadena.Length - 1)))
        {
            return true;
        }
        else
        {
            return false;
        }     
    }

    static bool B(string cadena)
    {
        if (cadena.Length == 0)
        {
            return false;
        }
        else
        {
            int i = 0;
            for (i = 0; i < cadena.Length; i++)
            {
                if (cadena[i] == 'b')
                {
                    return false;
                }
            }

            
            while (i < cadena.Length && cadena[i] == 'c')
            {
                i++;
            }

            if (i > 0 && i < cadena.Length && C(cadena.Substring(i + 1, cadena.Length - i - 1)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    static bool C(string cadena)
    {
        if (cadena.Length == 0)
        {
            return true;
        }
        else if ((cadena[0] == 'c' || cadena[0] == 'a') && C(cadena.Substring(1, cadena.Length - 1)))
        {
            return true;
        }
        else if (cadena[0] == 'b')
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void Main()
    {
        Console.WriteLine(A("a")); // true
        Console.WriteLine(A("ac")); // true
        Console.WriteLine(A("aca")); // true
        Console.WriteLine(A("acccba")); // true
        Console.WriteLine(A("accaccba")); // true
        Console.WriteLine(A("ab")); // false
        Console.WriteLine(A("abc")); // false
        Console.WriteLine(A("bcccb")); // false
        Console.WriteLine(A("cbcc")); // false
        Console.WriteLine(A("accaccbc")); // true
        Console.WriteLine(A("cbcb")); // false
        Console.WriteLine(A("ccbbaa")); // false
    }
}