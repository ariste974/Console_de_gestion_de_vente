using OfficeOpenXml;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using LicenseContext = OfficeOpenXml.LicenseContext;


namespace Projetfinalec_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ouvrir le fichier xlsx
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            static List<(string, string, int, string)> LireFichierExcel()
            {
                List<(string, string, int, string)> dataList = new List<(string, string, int, string)>();

                // Vérifier si le fichier existe
                if (!File.Exists(@"D:\telechargements\Distances.xlsx"))
                {
                    Console.WriteLine("Le fichier spécifié n'existe pas.");
                    return dataList;
                }

                // Charger le fichier Excel avec EPPlus
                using (var package = new ExcelPackage(new FileInfo(@"D:\telechargements\Distances.xlsx")))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                    // Récupérer le nombre de lignes utilisées dans la feuille
                    int rowCount = worksheet.Dimension.Rows;

                    // Parcourir les lignes pour lire les données
                    for (int row = 1; row <= rowCount; row++)
                    {
                        string vertex1 = worksheet.Cells[row, 1].GetValue<string>();      // Colonne A (sommet 1)
                        string vertex2 = worksheet.Cells[row, 2].GetValue<string>();      // Colonne B (sommet 2)
                        int weight = worksheet.Cells[row, 3].GetValue<int>();       // Colonne C (poids/arête)
                        string temps = worksheet.Cells[row, 1].GetValue<string>();

                        // Ajouter les données à la liste de tuples
                        dataList.Add((vertex1, vertex2, weight, temps));
                    }
                }

                return dataList;
            }

            static int CalculerDistance(int sourceCity,int destination){
                List<(string, string, int, string)> dataList = LireFichierExcel();
                int V = 15;
                Graphville graph = new Graphville(V);
                // Afficher les données lues depuis le fichier Excel
                HashSet<string> listville = new HashSet<string>();
                Dictionary<string, int> ville = new Dictionary<string, int>();
                int a = 0;
                foreach (var nom in dataList)
                {
                    listville.Add(nom.Item1);
                    listville.Add(nom.Item2);
                }
                foreach (var nom in listville)
                {
                    ville[$"{nom}"] = a;
                    a++;
                }

                foreach (var data in dataList)
                {
                    graph.Ajoutersommet(ville[data.Item1], ville[data.Item2], data.Item3);
                }

                

                // Exécuter l'algorithme de Dijkstra à partir de la ville source
                int[] distances = graph.Dijkstra(sourceCity);

                return distances[destination];

            }

            static void AfficherDistances(int sourceCity)
            {
                List<(string, string, int, string)> dataList = LireFichierExcel();
                int V = 15;
                Graphville graph = new Graphville(V);
                // Afficher les données lues depuis le fichier Excel
                SortedSet<string> listville = new SortedSet<string>();
                Dictionary<string, int> ville = new Dictionary<string, int>();
                int a = 0;
                foreach (var nom in dataList)
                {
                    listville.Add(nom.Item1);
                    listville.Add(nom.Item2);
                }
                foreach (var nom in listville)
                {
                    ville[$"{nom}"] = a;
                    a++;
                }

                foreach (var data in dataList)
                {
                    graph.Ajoutersommet(ville[data.Item1], ville[data.Item2], data.Item3);
                }



                // Exécuter l'algorithme de Dijkstra à partir de la ville source
                int[] distances = graph.Dijkstra(sourceCity);

                // Afficher les distances les plus courtes depuis la ville source
                List<string> listeville = listville.ToList();
                Console.WriteLine($"Distances les plus courtes depuis la ville de:" + listeville[sourceCity]);
                for (int i = 0; i < V; i++) 
                {
                    if (distances[i] > 10000)
                    {
                        Console.WriteLine($"Ville {listeville[i]}: Distance = non joignable");
                    }
                    else
                    {
                        Console.WriteLine($"Ville {listeville[i]}: Distance = {distances[i]} km");
                    }
                }

            }

            static string AfficherTrajet(int sourceCity,int destination)
            {
                List<(string, string, int, string)> dataList = LireFichierExcel();
                int V = 15;
                Graphville graph = new Graphville(V);
                // Afficher les données lues depuis le fichier Excel
                SortedSet<string> listville = new SortedSet<string>();
                Dictionary<string, int> ville = new Dictionary<string, int>();
                int a = 0;
                foreach (var nom in dataList)
                {
                    listville.Add(nom.Item1);
                    listville.Add(nom.Item2);
                }
                foreach (var nom in listville)
                {
                    ville[$"{nom}"] = a;
                    a++;
                }

                foreach (var data in dataList)
                {
                    graph.Ajoutersommet(ville[data.Item1], ville[data.Item2], data.Item3);
                }



                // Exécuter l'algorithme de Dijkstra à partir de la ville source
                int[] distances = graph.Dijkstra(sourceCity);

                // Afficher les distances les plus courtes depuis la ville source
                List<string> listeville = listville.ToList();
                return "trajet: " + listeville[sourceCity] + "-" + listeville[destination];

            }

            // Organigramme
            Noeud directeurGeneral = new Noeud("Mr Dupond / Directeur Général");
            Noeud directriceCommerciale = new Noeud("Mme Fiesta / Directrice Commerciale");
            Noeud commercial1 = new Noeud("Mr Forge / Commercial");
            Noeud commercial2 = new Noeud("Mme Fermi / Commercial");
            Noeud directeurOperations = new Noeud("Mr Fetard / Directeur des Opérations");
            Noeud chefEquipe = new Noeud("Mr Royal / Chef Equipe");
            Noeud chauffeur1 = new Noeud("Mr Romu / Chauffeur");
            Noeud chauffeur2 = new Noeud("Mme Romi / Chauffeur");
            Noeud chauffeur3 = new Noeud("Mr Roma / Chauffeur");
            Noeud chefEquipe2 = new Noeud("Mme Prince / Chef Equipe");
            Noeud chauffeur4 = new Noeud("Mme Rome / Chauffeur");
            Noeud chauffeur5 = new Noeud("Mme Rimou / Chauffeur");
            Noeud directriceRH = new Noeud("Mme Joyeuse / Directrice des RH");
            Noeud formation = new Noeud("Mme Couleur / Formation");
            Noeud contrats = new Noeud("Mme ToutleMonde / Contrats");
            Noeud directeurFinancier = new Noeud("Mr GripSous / Directeur Financier");
            Noeud directionComptable = new Noeud("Mr Picsou / Direction Comptable");
            Noeud comptable1 = new Noeud("Mme Fournier / Comptable");
            Noeud comptable2 = new Noeud("Mme Gautier / Comptable");
            Noeud controleurGestion = new Noeud("Mr GrosSous / Contrôleur de Gestion");

            // Attribution des rôles et relations hiérarchiques
            directeurGeneral.AjouterEnfant(directriceCommerciale);
            directeurGeneral.AjouterEnfant(directeurOperations);
            directeurGeneral.AjouterEnfant(directriceRH);
            directeurGeneral.AjouterEnfant(directeurFinancier);

            directriceCommerciale.AjouterEnfant(commercial1);
            directriceCommerciale.AjouterEnfant(commercial2);

            directeurOperations.AjouterEnfant(chefEquipe);
            directeurOperations.AjouterEnfant(chefEquipe2);

            chefEquipe.AjouterEnfant(chauffeur1);
            chefEquipe.AjouterEnfant(chauffeur2);
            chefEquipe.AjouterEnfant(chauffeur3);
            directeurOperations.AjouterEnfant(chefEquipe2);

            chefEquipe2.AjouterEnfant(chauffeur4);
            chefEquipe2.AjouterEnfant(chauffeur5);

            directriceRH.AjouterEnfant(formation);
            directriceRH.AjouterEnfant(contrats);

            directeurFinancier.AjouterEnfant(directionComptable);
            directeurFinancier.AjouterEnfant(controleurGestion);

            directionComptable.AjouterEnfant(comptable1);
            directionComptable.AjouterEnfant(comptable2);

            List<Noeud> listeNoeuds = new List<Noeud>()
            {
                directeurGeneral,
                directriceCommerciale,
                commercial1,
                commercial2,
                directeurOperations,
                chefEquipe,
                chauffeur1,
                chauffeur2,
                chauffeur3,
                chefEquipe2,
                chauffeur4,
                chauffeur5,
                directriceRH,
                formation,
                contrats,
                directeurFinancier,
                directionComptable,
                comptable1,
                comptable2,
                controleurGestion
            };


            static void AfficherArbre(Noeud noeud, string prefix)
            {
                if (noeud == null)
                    return;

                Console.WriteLine($"{prefix}|__ {noeud.Valeur}");

                string childPrefix = $"{prefix}    ";

                foreach (var enfant in noeud.Enfants)
                {
                    AfficherArbre(enfant, childPrefix);
                }
            }
           //AfficherArbre(directeurGeneral,"");


            // Liste de Client

            Personne kebabier = new Clients(5555, "sali", "jean", new DateTime(2002, 5, 3), "22 rue kebab", "meilleur.kebab@sauce.fr", 09099090);
            Personne client1 = new Clients(123456789, "Dupont", "Jean", new DateTime(1980, 5, 15), "123 Rue de Paris", "jean.dupont@example.com", 0123456789);
            Personne client2 = new Clients(987654321, "Martin", "Sophie", new DateTime(1975, 10, 20), "456 Avenue du Soleil", "sophie.martin@example.com", 0987654321);
            Personne client3 = new Clients(456789123, "Durand", "Pierre", new DateTime(1990, 3, 8), "789 Boulevard des Fleurs", "pierre.durand@example.com", 0345678912);
            List<Clients> clientList = new List<Clients>();
            clientList.Add((Clients)client1);
            clientList.Add((Clients)client2);
            clientList.Add((Clients)client3);


            List<Commande> commandes = new List<Commande>();
            
            List<Chauffeur> listechauff = new List<Chauffeur>
            {
            new Chauffeur(123456789, "Romu", "Jean", new DateTime(1985, 5, 10), "1 Rue des Lilas", "romu@example.com", 0612345678, new DateTime(2020, 1, 1), "Chauffeur", 15),
            new Chauffeur(987654321, "Romi", "Pierre", new DateTime(1990, 8, 20), "2 Avenue des Roses", "romi@example.com", 0623456789, new DateTime(2019, 6, 15), "Chauffeur", 16),
            new Chauffeur(456789123, "Roma", "Luc", new DateTime(1988, 3, 5), "3 Boulevard des Tulipes", "roma@example.com", 0634567890, new DateTime(2021, 9, 1), "Chauffeur", 14),
            new Chauffeur(789123456, "Rome", "Marc", new DateTime(1992, 11, 25), "4 Allée des Marguerites", "rome@example.com", 0645678901, new DateTime(2018, 4, 10), "Chauffeur", 17),
            new Chauffeur(321654987, "Rimou", "Sophie", new DateTime(1987, 7, 15), "5 Impasse des Orchidées", "rimou@example.com", 0656789012, new DateTime(2022, 2, 20), "Chauffeur", 15)
            };



            static void SaveToFile(List<Clients> listeclient){
                string fileName = @"listedeclient.txt";

                // Utiliser using pour s'assurer que le StreamWriter est correctement fermé après utilisation
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    foreach (var client in listeclient)
                    {
                        // Ajouter les détails du client sur une nouvelle ligne dans le fichier
                        sw.WriteLine(client.ToString());
                    }
                }
            }
            SaveToFile(clientList);
            static List<Clients> sortNom(List<Clients> clients)
            {
                return clients.OrderBy(client => client.Nom).ToList();
            }

           
            static List<Clients> sortVille(List<Clients> clients)
            {
                return clients.OrderBy(client => client.Adresse_mail).ToList();
            }
            
           
            static List<Clients> sortMontant(List<Clients> clients)
            {
                return clients.OrderBy(client => client.Adresse_mail).ToList();
            }
            
            
            
            static double moyenne_prix_commande(List<Commande> listecomm){
                
               double  b= 0;
                foreach (Commande comm in listecomm)
                {
                    b += comm.Prix;
                }
                return b/listecomm.Count;

            }
           
            
            static double moyenne_compte_client(List<Clients> listeclient)
            {

                double b = 0;
                foreach (Clients cli in listeclient)
                {
                    b += cli.Montant;
                }
                return b / listeclient.Count;

            }
            
            
            
            static Clients trouverclient(List<Clients> clients,string nom)
            {
                foreach (Clients cli in clients)
                {
                    if (cli.Nom == nom)
                    {
                        return cli;
                    }
                }
                return null;
            }
           
            
            
            static void listecommandeclient(List<Commande> listecomm, Clients client)
            {
                foreach (Commande comm in listecomm)
                {
                    if (comm.Client.SSP == client.SSP)
                    {
                        comm.Afficher();
                    }
                    
                }
            }
            
            
            static void Commandeparchauffeur(List<Chauffeur> listechauff, string a)
            {
                foreach (Chauffeur chauff in listechauff)
                {
                    if (chauff.Nom == a)
                    {
                        Console.Write("Le chauffeur a réalisé "+chauff.commandes_realisees+" commande(s)");
                    }
                }
            }

            


            static Clients trouverClient(List<Clients> listeclient)
            {
                foreach (Clients client in listeclient)
                {
                    Console.WriteLine(client.Nom + " " + client.Prenom + " " + client.SSP);
                }
                Console.WriteLine("Quel est le numéro ou le nom du client?");
                string c = Console.ReadLine();
                foreach (Clients cli in listeclient)
                {
                    if (cli.Nom == c)
                    {
                        return cli;
                    }
                    else if (Convert.ToString(cli.SSP) == c)
                    {
                        return cli;
                    }
                }
                return null;
            }

            static Chauffeur trouverChauffeur(List<Chauffeur> listechauffeur)
            {
                foreach (Chauffeur client in listechauffeur)
                {
                    Console.WriteLine(client.Nom + "  " + client.Prenom +"  "+client.SSP+"  tarif au km du chauffeur: " + client.tarifHoraire);
                }
                Console.WriteLine("Quel est le numéro ou le nom du chauffeur ?");
                string c = Console.ReadLine();
                foreach (Chauffeur cli in listechauffeur)
                {
                    if (cli.Nom == c)
                    {
                        return cli;
                    }
                    else if (Convert.ToString(cli.SSP) == c)
                    {
                        return cli;
                    }
                }
                return null;
            }

            static bool nomvalable(string c, List<Clients> listeclient)
            {
                bool a = false;
                foreach(Clients cli in listeclient)
                {
                    if (cli.Nom == c)
                    {
                        a = true;
                    }   
                }
                return a;
            }
            static void Consolemenu1(List<Chauffeur> listechauff, List<Commande> listecomm, List<Clients> listeclient, List<Noeud> listeNoeuds)
            {
                Console.Clear();
                Console.WriteLine("\r\n  _______                     _____                            _   \r\n |__   __|                   / ____|                          | |  \r\n    | |_ __ __ _ _ __  ___  | |     ___  _ __  _ __   ___  ___| |_ \r\n    | | '__/ _` | '_ \\/ __| | |    / _ \\| '_ \\| '_ \\ / _ \\/ __| __|\r\n    | | | | (_| | | | \\__ \\ | |___| (_) | | | | | | |  __/ (__| |_ \r\n    |_|_|  \\__,_|_| |_|___/  \\_____\\___/|_| |_|_| |_|\\___|\\___|\\__|\r\n                                                                   \r\n                                                                   \r\n");
                Console.WriteLine("Veuillez chosir le module:");
                Console.WriteLine("1. Module Client");
                Console.WriteLine("2. Module salarié");
                Console.WriteLine("3. Module commande");
                Console.WriteLine("4. Module Statistiques");
                string a=Convert.ToString(Console.ReadLine());
                
                while(!(a=="1" | a=="2" |a=="3" | a=="4"))
                {
                    Console.WriteLine("Entrée erronnée! Veuillez taper 1,2,3 ou 4");
                    a = Convert.ToString(Console.ReadLine());
                }
                switch (a)
                {
                    case "1":
                        ModuleClient(listechauff, listecomm, listeclient,listeNoeuds);
                        break;
                    case "2":
                         ModuleSalarie(listechauff,listecomm,listeclient, listeNoeuds);
                        break;
                    case "3":
                        ModuleCommande(listechauff, listecomm, listeclient, listeNoeuds);
                        break;
                    case "4":
                        ModuleStatistique( listechauff,  listecomm,listeclient,  listeNoeuds);
                        break;

                }
            }
           
          
            static void ModuleStatistique(List<Chauffeur> listechauff,List <Commande> listecomm, List<Clients> listeclient, List<Noeud> listeNoeuds)
            {
                Console.Clear();
                Console.WriteLine("\r\n  _______                     _____                            _   \r\n |__   __|                   / ____|                          | |  \r\n    | |_ __ __ _ _ __  ___  | |     ___  _ __  _ __   ___  ___| |_ \r\n    | | '__/ _` | '_ \\/ __| | |    / _ \\| '_ \\| '_ \\ / _ \\/ __| __|\r\n    | | | | (_| | | | \\__ \\ | |___| (_) | | | | | | |  __/ (__| |_ \r\n    |_|_|  \\__,_|_| |_|___/  \\_____\\___/|_| |_|_| |_|\\___|\\___|\\__|\r\n                                                                   \r\n                                                                   \r\n");
                Console.WriteLine("Quelle statistique voulez vous voir?");
                Console.WriteLine("1. Le nombre de livraisons effectuées par chauffeur");
                Console.WriteLine("2. La moyenne des prix des commandes");
                Console.WriteLine("3. La moyenne des comptes clients");
                Console.WriteLine("4. La liste des commandes pour un client ");
                string a=Convert.ToString(Console.ReadLine());
                
                while(!(a=="1" | a=="2" |a=="3" | a=="4"))
                {
                    Console.WriteLine("Entrée erronnée! Veuillez taper 1,2,3 ou 4");
                    a = Convert.ToString(Console.ReadLine());
                }
                Console.Clear();
                Console.WriteLine("\r\n  _______                     _____                            _   \r\n |__   __|                   / ____|                          | |  \r\n    | |_ __ __ _ _ __  ___  | |     ___  _ __  _ __   ___  ___| |_ \r\n    | | '__/ _` | '_ \\/ __| | |    / _ \\| '_ \\| '_ \\ / _ \\/ __| __|\r\n    | | | | (_| | | | \\__ \\ | |___| (_) | | | | | | |  __/ (__| |_ \r\n    |_|_|  \\__,_|_| |_|___/  \\_____\\___/|_| |_|_| |_|\\___|\\___|\\__|\r\n                                                                   \r\n                                                                   \r\n");
                switch (a)
                {
                    case "1":
                        foreach(Chauffeur chauffeur in listechauff)
                        {
                            Console.WriteLine(chauffeur.Nom + " " + chauffeur.Prenom + " Tarif:"+ chauffeur.tarifHoraire);
                        }
                        Console.WriteLine("Quel est le nom du chauffeur?");
                       string b=Console.ReadLine();
                        Commandeparchauffeur(listechauff, b);

                        break;
                    case "2":
                      Console.WriteLine( "la moyenne des commandes est " + moyenne_prix_commande(listecomm));
                        break;
                    case "3":
                        Console.WriteLine("la moyenne des comptes client est " + moyenne_compte_client(listeclient));
                        break;
                    case "4":
                        foreach(Clients client in listeclient)
                        {
                            Console.WriteLine(client.Nom + " " + client.Prenom);
                        }
                        Console.WriteLine("Quel est le nom du client?");
                        string c = Console.ReadLine();
                        while (!nomvalable(c,listeclient))
                        {
                            Console.WriteLine("Nom erroné veuillez entrer un bom valable");
                            c = Console.ReadLine();
                        }
                        listecommandeclient(listecomm, trouverclient(listeclient,c));
                        break;
                }
               Console.ReadKey();
                Consolemenu1(listechauff, listecomm, listeclient, listeNoeuds);

            }


            static void ModuleClient(List<Chauffeur> listechauff, List<Commande> listecomm, List<Clients> listeclient, List<Noeud> listeNoeuds)
            {
                Console.Clear();
                Console.WriteLine("\r\n  _______                     _____                            _   \r\n |__   __|                   / ____|                          | |  \r\n    | |_ __ __ _ _ __  ___  | |     ___  _ __  _ __   ___  ___| |_ \r\n    | | '__/ _` | '_ \\/ __| | |    / _ \\| '_ \\| '_ \\ / _ \\/ __| __|\r\n    | | | | (_| | | | \\__ \\ | |___| (_) | | | | | | |  __/ (__| |_ \r\n    |_|_|  \\__,_|_| |_|___/  \\_____\\___/|_| |_|_| |_|\\___|\\___|\\__|\r\n                                                                   \r\n                                                                   \r\n");
                Console.WriteLine("Que voulez vous faire?");
                Console.WriteLine("1. Voir les clients dans l'ordre alphabétique");
                Console.WriteLine("2. Voir les clients par adresse");
                Console.WriteLine("3. Voir les clients par montant");
                Console.WriteLine("4. Supprimer un client");
                Console.WriteLine("5. Ajouter un client");

                string a = Convert.ToString(Console.ReadLine());

                while (!(a == "1" | a == "2" | a == "3" | a == "4" | a == "5" ))
                {
                    Console.WriteLine("Entrée erronnée! Veuillez taper 1,2,3,4 ou 5");
                    a = Convert.ToString(Console.ReadLine());
                }
                Console.Clear();
                Console.WriteLine("\r\n  _______                     _____                            _   \r\n |__   __|                   / ____|                          | |  \r\n    | |_ __ __ _ _ __  ___  | |     ___  _ __  _ __   ___  ___| |_ \r\n    | | '__/ _` | '_ \\/ __| | |    / _ \\| '_ \\| '_ \\ / _ \\/ __| __|\r\n    | | | | (_| | | | \\__ \\ | |___| (_) | | | | | | |  __/ (__| |_ \r\n    |_|_|  \\__,_|_| |_|___/  \\_____\\___/|_| |_|_| |_|\\___|\\___|\\__|\r\n                                                                   \r\n                                                                   \r\n");
                switch (a)
                {
                    case "1":
                        foreach (Clients cli in sortNom(listeclient))
                        {
                            Console.WriteLine(cli.Nom + " " + cli.Prenom + " " + cli.SSP);
                        }

                        break;
                    case "2":
                        foreach (Clients cli in sortVille(listeclient))
                        {
                            Console.WriteLine(cli.Nom + " " + cli.Prenom + " " + cli.Addresse_postale);
                        }
                        break;
                    case "3":
                        foreach (Clients cli in sortMontant(listeclient))
                        {
                            Console.WriteLine(cli.Nom + " " + cli.Prenom + " " + cli.Montant);
                        }
                        break;
                    case "4":
                        foreach (Clients client in listeclient)
                        {
                            Console.WriteLine(client.Nom + " " + client.Prenom+" "+client.SSP);
                        }
                        Console.WriteLine("Quel est le numéro ou le nom du client?");
                        string c = Console.ReadLine();
                        foreach (Clients cli in listeclient)
                        {
                            if (cli.Nom == c)
                            {
                                listeclient.Remove(cli);
                                Console.WriteLine("Client Supprimé!Appuyez sur n'importe quelle touche");
                                break;
                            }
                            if (Convert.ToString(cli.SSP) == c)
                            {
                                listeclient.Remove(cli);
                                Console.WriteLine("Client Supprimé!Appuyez sur n'importe quelle touche");
                                break;
                            }
                        }
                        break;
                    case "5":
                        Console.WriteLine("Quel est le numéro du client?");
                        int numcli = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Quel est le nom du client?");
                        string nom= Console.ReadLine();
                        Console.WriteLine("Quel est son prenom?");
                        string prenom= Console.ReadLine();
                        Console.WriteLine("Année de naissance?");
                        int annee = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Mois de naissance?");
                        int mois = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Jour de naissance?");
                        int jour = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Addresse du client?");
                        string addresse = Console.ReadLine();
                        Console.WriteLine("Addresse mail?");
                        string mail = Console.ReadLine();
                        Console.WriteLine("Numero de téléphone?");
                        int telephone= Convert.ToInt32(Console.ReadLine());
                        listeclient.Add(new Clients(numcli, nom, prenom, new DateTime(annee, mois, jour), addresse, mail, telephone));
                        Console.WriteLine("Client Ajouté!Appuyez sur n'importe quelle touche");
                        break;

                }
                SaveToFile(listeclient);
                Console.ReadKey();
                Consolemenu1(listechauff, listecomm, listeclient,listeNoeuds);
            }

            static void ModuleSalarie(List<Chauffeur> listechauff, List<Commande> listecomm, List<Clients> listeclient, List<Noeud> listeNoeuds)
            {
                Console.Clear();
                Console.WriteLine("\r\n  _______                     _____                            _   \r\n |__   __|                   / ____|                          | |  \r\n    | |_ __ __ _ _ __  ___  | |     ___  _ __  _ __   ___  ___| |_ \r\n    | | '__/ _` | '_ \\/ __| | |    / _ \\| '_ \\| '_ \\ / _ \\/ __| __|\r\n    | | | | (_| | | | \\__ \\ | |___| (_) | | | | | | |  __/ (__| |_ \r\n    |_|_|  \\__,_|_| |_|___/  \\_____\\___/|_| |_|_| |_|\\___|\\___|\\__|\r\n                                                                   \r\n                                                                   \r\n");
                Console.WriteLine("Que voulez vous faire?");
                Console.WriteLine("1. Voir l'arbre des salariés");
                Console.WriteLine("2. Enlever un salarié de l'arbre");
                Console.WriteLine("3. Ajouter un salarié à l'arbre");

                string a = Convert.ToString(Console.ReadLine());

                while (!(a == "1" | a == "2" | a == "3" ))
                {
                    Console.WriteLine("Entrée erronnée! Veuillez taper 1,2 ou 3");
                    a = Convert.ToString(Console.ReadLine());
                }
                Console.Clear();
                Console.WriteLine("\r\n  _______                     _____                            _   \r\n |__   __|                   / ____|                          | |  \r\n    | |_ __ __ _ _ __  ___  | |     ___  _ __  _ __   ___  ___| |_ \r\n    | | '__/ _` | '_ \\/ __| | |    / _ \\| '_ \\| '_ \\ / _ \\/ __| __|\r\n    | | | | (_| | | | \\__ \\ | |___| (_) | | | | | | |  __/ (__| |_ \r\n    |_|_|  \\__,_|_| |_|___/  \\_____\\___/|_| |_|_| |_|\\___|\\___|\\__|\r\n                                                                   \r\n                                                                   \r\n");
                switch (a)
                {
                    case "1":
                        AfficherArbre(listeNoeuds[0],"");
                        break;
                    case "2":
                        AfficherArbre(listeNoeuds[0], "");
                        Console.WriteLine("Nom de l'employé à enlever / Fonction?");
                        string nom =Console.ReadLine();
                        foreach(Noeud cherche in listeNoeuds)
                        {
                            if (nom == cherche.Valeur)
                            {
                                cherche.RechercherParent(listeNoeuds[0],cherche).SupprimerEnfant(cherche);
                                Console.WriteLine("Noeud Supprimé!Appuyez sur n'importe quelle touche");
                                break;
                            }
                        }
                        break;
                    case "3":
                        AfficherArbre(listeNoeuds[0], "");
                        Console.WriteLine("Nom de l'employé à enlever / Fonction?");
                        string nomajouter=Console.ReadLine();
                        Console.WriteLine("Nom / fonction de son supérieur direct?");
                        string superieur=Console.ReadLine();
                        foreach (Noeud cherche in listeNoeuds)
                        {
                            if (superieur == cherche.Valeur)
                            {
                                cherche.AjouterEnfant(new Noeud(nomajouter));
                                Console.WriteLine("Noeud Ajouté!Appuyez sur n'importe quelle touche");
                                break;
                            }
                        }
                                break;




                }
                Console.ReadKey();
                Consolemenu1(listechauff, listecomm, listeclient, listeNoeuds);
            }


            static int choixvilles()
            {
                Console.WriteLine("1. Angers");
                Console.WriteLine("2. Avignon");
                Console.WriteLine("3. Biarritz");
                Console.WriteLine("4. Bordeaux");
                Console.WriteLine("5. La Rochelle");
                Console.WriteLine("6. Lyon");
                Console.WriteLine("7. Marseille");
                Console.WriteLine("8. Monaco");
                Console.WriteLine("9. Montpellier");
                Console.WriteLine("10. Nimes");
                Console.WriteLine("11. Paris");
                Console.WriteLine("12. Pau");
                Console.WriteLine("13. Rouen");
                Console.WriteLine("14. Toulon");
                Console.WriteLine("15. Toulouse");
                int a=Convert.ToInt32(Console.ReadLine());
                while (!(a == 1 || a == 2 || a == 3 || a == 4 || a == 5 ||
                a == 6 || a == 7 || a == 8 || a == 9 || a == 10 ||
                a == 11 || a == 12 || a == 13 || a == 14 || a == 15))
                {
                    Console.WriteLine("Entrée erronnée! Veuillez taperun nombre entre 1 et 15");
                    a = Convert.ToInt32(Console.ReadLine());
                }
                return a-1;
            }







            static void ModuleCommande(List<Chauffeur> listechauff, List<Commande> listecomm, List<Clients> listeclient, List<Noeud> listeNoeuds)
            {
                Console.Clear();
                Console.WriteLine("\r\n  _______                     _____                            _   \r\n |__   __|                   / ____|                          | |  \r\n    | |_ __ __ _ _ __  ___  | |     ___  _ __  _ __   ___  ___| |_ \r\n    | | '__/ _` | '_ \\/ __| | |    / _ \\| '_ \\| '_ \\ / _ \\/ __| __|\r\n    | | | | (_| | | | \\__ \\ | |___| (_) | | | | | | |  __/ (__| |_ \r\n    |_|_|  \\__,_|_| |_|___/  \\_____\\___/|_| |_|_| |_|\\___|\\___|\\__|\r\n                                                                   \r\n                                                                   \r\n");
                Console.WriteLine("Que voulez vous faire?");
                Console.WriteLine("1. Passer une commande");
                Console.WriteLine("2. Afficher les distances a partir d'une ville");
                Console.WriteLine("3. Mettre à jour une commande comme réglée ");
                Console.WriteLine("4. Mettre à jour une commande comme livrée");
                Console.WriteLine("5. Afficher toutes les commandes");
                Console.WriteLine("6. Afficher les commandes non livrées");
                string a = Console.ReadLine();
                while (!(a == "1" | a == "2" | a == "3" | a == "4" | a == "5" | a == "6"))
                {
                    Console.WriteLine("Entrée erronnée! Veuillez taper 1,2,3,4,5 ou 6");
                    a = Convert.ToString(Console.ReadLine());
                }
                Console.Clear();
                Console.WriteLine("\r\n  _______                     _____                            _   \r\n |__   __|                   / ____|                          | |  \r\n    | |_ __ __ _ _ __  ___  | |     ___  _ __  _ __   ___  ___| |_ \r\n    | | '__/ _` | '_ \\/ __| | |    / _ \\| '_ \\| '_ \\ / _ \\/ __| __|\r\n    | | | | (_| | | | \\__ \\ | |___| (_) | | | | | | |  __/ (__| |_ \r\n    |_|_|  \\__,_|_| |_|___/  \\_____\\___/|_| |_|_| |_|\\___|\\___|\\__|\r\n                                                                   \r\n                                                                   \r\n");
                switch (a)
                {
                    case "1":

                        Console.WriteLine("Prix de la commande?");
                       double prix= Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Mois de livraison?");
                        int mois = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Jour de livraison?");
                        int jour = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Camion ou camionette? (1 pour camion, 2 pour camionette)");
                        string b = Console.ReadLine();
                        while (!(b == "1" | b == "2" ))
                        {
                            Console.WriteLine("Entrée erronnée! Veuillez taper 1,2 ou 3");
                            b = Convert.ToString(Console.ReadLine());
                        }
                        Console.WriteLine("Numéro de commande?");
                        int  numc=Convert.ToInt32(Console.ReadLine());
                        if (b =="1")
                        {
                            listecomm.Add(new Commande(trouverClient(listeclient), prix, new DateTime(2024, mois, jour), new Camion(6),numc));
                        }
                        else
                        {
                            listecomm.Add(new Commande(trouverClient(listeclient), prix, new DateTime(2024, mois, jour), new Camionette(7),numc));
                        }


                        while (listecomm.Last().Chauffeurs == null)
                        {

                            listecomm.Last().AssignerChauffeur(trouverChauffeur(listechauff));
                        }
                        Console.WriteLine("choisissez la ville de départ");
                        int villedep = choixvilles();
                        Console.WriteLine("choisissez la ville d'arrivée");
                        int villearr = choixvilles();
                        listecomm.Last().Distance=CalculerDistance(villedep, villearr);
                        listecomm.Last().Trajet=AfficherTrajet(villedep,villearr);
                        listecomm.Last().AssignerPrixLivraison();
                        Console.WriteLine("Commande passée! Il faut maintenant la payer!");
                        break;
                    case "2":
                        Console.WriteLine("Depuis quelle ville?");
                        int ville=choixvilles();
                        AfficherDistances(ville);

                        break;
                    case "3":
                        Console.WriteLine("Commandes non réglées:");
                        foreach(Commande comm in listecomm)
                        {
                            if (comm.PaiementEffectue == false)
                            {
                                Console.WriteLine("Numero de commande: "+comm.Numero+" Client: "+ comm.Client.ToString() + " prix total: " + comm.Prix + " date: " + comm.Date_livraison + " Chauffeur: " + comm.Chauffeurs.Nom);
                            }

                        }
                        Console.WriteLine("Entrez le numéro de la commande à régler");
                        int numaregler = Convert.ToInt32(Console.ReadLine());
                        foreach (Commande comm in listecomm)
                        {
                            if(comm.Numero == numaregler)
                            {
                                comm.EffectuerPaiement();
                                comm.Client.Montant=comm.Prix;
                                Console.WriteLine("Paiement effectué avec succès");
                            }
                            
                            }
                        break;
                    case "4":
                        Console.WriteLine("Commandes réglées non livrées:");
                        foreach (Commande comm in listecomm)
                        {
                            if (comm.PaiementEffectue & comm.Commandefinalisee==false)
                            {
                                Console.WriteLine("Numero de commande: " + comm.Numero + " Client: " + comm.Client.ToString() + " prix total: " + comm.Prix + " date: " + comm.Date_livraison + " Chauffeur: " + comm.Chauffeurs.Nom);
                            }

                        }
                        Console.WriteLine("Entrez le numéro de la commande qui a été livrée");
                        int numlivr = Convert.ToInt32(Console.ReadLine());
                        foreach (Commande comm in listecomm)
                        {
                            if (comm.Numero == numlivr)
                            {
                                comm.FinaiserLivraison();
                                comm.AjouterCommandeChauffeur();
                                Console.WriteLine("Commande finalisée!");
                            }

                        }

                        break;
                    case "5":
                        foreach (Commande comm in listecomm)
                        {
                            comm.Afficher();
                        }
                        break;
                    case "6":
                        foreach(Commande comm in listecomm)
                        {
                            if(comm.Commandefinalisee == false)
                            {
                                comm.Afficher();
                            }
                        }
                        break;
                }
                Console.ReadKey();
                Consolemenu1(listechauff, listecomm, listeclient, listeNoeuds);
            }
         Consolemenu1(listechauff,commandes,clientList, listeNoeuds);


        }
    }
}