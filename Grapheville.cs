using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projetfinalec_
{
    public class Graphville
    {
        private int V; // Nombre de villes dans le graphe
        private List<(int, int)>[] adj; // Liste d'adjacence du graphe (tuple de (voisin, distance))

        public Graphville(int v)
        {
            V = v;
            adj = new List<(int, int)>[V];
            for (int i = 0; i < V; i++)
            {
                adj[i] = new List<(int, int)>();
            }
        }

        public void Ajoutersommet(int u, int v, int distance)
        {
            adj[u].Add((v, distance));
            // Si le graphe est non dirigé, décommentez la ligne suivante pour ajouter la route inverse
            adj[v].Add((u, distance));
        }

        public int[] Dijkstra(int source)
        {
            int[] dist = new int[V];
            bool[] visited = new bool[V];

            // Initialiser toutes les distances à l'infini et marquer tous les sommets comme non visités
            for (int i = 0; i < V; i++)
            {
                dist[i] = int.MaxValue;
                visited[i] = false;
            }

            // La distance de la source à elle-même est toujours 0
            dist[source] = 0;

            // File de priorité pour extraire le sommet avec la distance minimale
            SortedSet<(int, int)> priorityQueue = new SortedSet<(int, int)>();
            priorityQueue.Add((0, source));

            while (priorityQueue.Count > 0)
            {
                // Extraire le sommet avec la distance minimale
                int u = priorityQueue.Min.Item2;
                priorityQueue.Remove(priorityQueue.Min);

                // Marquer le sommet comme visité
                visited[u] = true;
                // Parcourir tous les voisins de u
                foreach (var road in adj[u])
                {
                    int v = road.Item1;
                    int distance = road.Item2;

                    // Mettre à jour la distance si un chemin plus court est trouvé
                    if (visited[v] != true && dist[u] != int.MaxValue && dist[u] + distance < dist[v])
                    {
                        dist[v] = dist[u] + distance;
                        priorityQueue.Add((dist[v], v));
                    }
                }
            }

            return dist;
        }
    }
}
