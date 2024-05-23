using System;
using System.Linq;
using System.Collections.Generic;

public class HelloWord
{
    public static void Main()
    {
        String line;
        line = Console.ReadLine();
        int n = Convert.ToInt32(line);
        int[][] ratings = new int[n][];
        for (int i_ratings = 0; i_ratings < n; i_ratings++)
        {
            line = Console.ReadLine();
            ratings[i_ratings] = line.Split().Select(str => int.Parse(str)).ToArray();
        }

        int out_ = solution(n, ratings);
        Console.Out.WriteLine(out_);
    }

    static int solution(int n, int[][] ratings)
    {
        // Diccionario para almacenar la suma de valoraciones y la cuenta de valoraciones por plato
        Dictionary<int, (int suma, int count)> platoValoraciones = new Dictionary<int, (int suma, int count)>();

        // Acumular valoraciones por plato
        for (int i = 0; i < n; i++)
        {
            int id = ratings[i][0];
            int valoracion = ratings[i][1];

            if (platoValoraciones.ContainsKey(id))
            {
                platoValoraciones[id] = (platoValoraciones[id].suma + valoracion, platoValoraciones[id].count + 1);
            }
            else
            {
                platoValoraciones[id] = (valoracion, 1);
            }
        }

        // Encontrar el plato con la valoración media más alta
        int mejorPlatoId = -1;
        double mejorValoracionMedia = -1;

        foreach (var kvp in platoValoraciones)
        {
            int id = kvp.Key;
            double valoracionMedia = (double)kvp.Value.suma / kvp.Value.count;

            if (valoracionMedia > mejorValoracionMedia || (valoracionMedia == mejorValoracionMedia && id < mejorPlatoId))
            {
                mejorPlatoId = id;
                mejorValoracionMedia = valoracionMedia;
            }
        }

        return mejorPlatoId;
    }
}