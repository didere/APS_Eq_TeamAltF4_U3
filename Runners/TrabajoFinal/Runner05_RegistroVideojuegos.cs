using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using APS_Eq_TeamAltF4_U3.Exceptions;
using APS_Eq_TeamAltF4_U3.Models.FinalModels;

namespace APS_Eq_TeamAltF4_U3.Runners.TrabajoFinal
{
    public class Runner05_RegistroVideojuegos
    {
        public Runner05_RegistroVideojuegos()
        {
            string rutaCsv = "videojuegos.csv";
            string rutaJson = "videojuegos.json";
            List<Videojuego> videojuegos = new List<Videojuego>();

            if (File.Exists(rutaCsv))
                CargarDesdeCSV(videojuegos, rutaCsv);
            else if (File.Exists(rutaJson))
                CargarDesdeJSON(videojuegos, rutaJson);
            else
                Console.WriteLine("No existen registros previos.");

            videojuegos.Sort();

            int opcion = 0;
            do
            {
                Console.WriteLine("\nRetroArch - Emulación de juegos antiguos:");
                Console.WriteLine("1. Registrar videojuego");
                Console.WriteLine("2. Visualizar registros");
                Console.WriteLine("3. Eliminar videojuego");
                Console.WriteLine("4. Guardar cambios (CSV)");
                Console.WriteLine("5. Exportar a JSON");
                Console.WriteLine("6. Filtrar por plataforma");
                Console.WriteLine("0. Salir");
                Console.Write("Opción: ");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        try
                        {
                            Console.Write("Ingresa el lugar del videojuego en el catálogo: ");
                            int lugar = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Ingresa el nombre del videojuego: ");
                            string nombre = Console.ReadLine();
                            Console.Write("Ingresa el género del videojuego: ");
                            string genero = Console.ReadLine();
                            Console.Write("Ingresa la plataforma del videojuego: ");
                            string plataforma = Console.ReadLine();

                            Videojuego v = new Videojuego(lugar, nombre, genero, plataforma);
                            videojuegos.Add(v);
                            videojuegos.Sort();
                            Contador.TotalRegistros++;
                            Console.WriteLine("Videojuego registrado correctamente.");
                            Console.WriteLine("Total de registros en el sistema: " + Contador.TotalRegistros);
                            Console.WriteLine(v.Resumen());
                        }
                        catch (VideojuegoException ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error inesperado: " + ex.Message);
                        }
                        break;
                    case 2:
                        if (videojuegos.Count == 0)
                        {
                            Console.WriteLine("No hay videojuegos registrados.");
                            return;
                        }
                        if (videojuegos.Count > 1)
                        {
                            Console.WriteLine("Diferencia entre primer y último lugar del catálogo: " +
                                              EstadisticasVideojuego.DiferenciaCatalogo(videojuegos));
                        }
                        else
                        {
                            Console.WriteLine("Solo hay un videojuego en el catálogo. Diferencia: 0");
                        }
                        foreach (Videojuego v in videojuegos)
                        {
                            Console.WriteLine(v);
                        }
                        break;
                    case 3:
                        if (videojuegos.Count == 0)
                        {
                            Console.WriteLine("No hay videojuegos para eliminar.");
                            return;
                        }
                        Console.Write("Ingresa el lugar en el catálogo del videojuego a eliminar: ");
                        int lugarEliminar = Convert.ToInt32(Console.ReadLine());
                        Videojuego vAEliminar = null;
                        foreach (Videojuego v in videojuegos)
                        {
                            if (v.LugarEnElCatalogo == lugarEliminar)
                            {
                                vAEliminar = v;
                                break;
                            }
                        }
                        if (vAEliminar != null)
                        {
                            videojuegos.Remove(vAEliminar);
                            videojuegos.Sort();
                            Contador.TotalRegistros--;
                            Console.WriteLine("Videojuego eliminado.");
                            Console.WriteLine("Total de registros en el sistema: " + Contador.TotalRegistros);
                        }
                        else
                        {
                            Console.WriteLine("No se encontró un videojuego con ese lugar en el catálogo.");
                        }
                        break;
                    case 4:
                        StreamWriter sw = new StreamWriter(rutaCsv);
                        foreach (Videojuego v in videojuegos)
                        {
                            sw.WriteLine($"{v.LugarEnElCatalogo},{v.Nombre},{v.Genero},{v.Plataforma}");
                        }
                        sw.Flush();
                        sw.Close();
                        Console.WriteLine("Cambios guardados en CSV.");
                        break;
                    case 5:
                        StreamWriter swJson = new StreamWriter(rutaJson);
                        foreach (Videojuego v in videojuegos)
                        {
                            string json = JsonSerializer.Serialize(v);
                            swJson.WriteLine(json);
                        }
                        swJson.Flush();
                        swJson.Close();
                        Console.WriteLine("Registros exportados a JSON.");
                        break;
                    case 6:
                        if (videojuegos.Count == 0)
                        {
                            Console.WriteLine("No hay videojuegos registrados.");
                            break;
                        }
                        Console.Write("Ingresa la plataforma a filtrar (ej. PlayStation, PC): ");
                        string plataformaFiltro = Console.ReadLine();
                        bool encontrado = false;
                        foreach (Videojuego v in videojuegos)
                        {
                            if (v.Plataforma.Equals(plataformaFiltro, StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine(v);
                                encontrado = true;
                            }
                        }
                        if (!encontrado)
                            Console.WriteLine($"No se encontraron videojuegos para la plataforma {plataformaFiltro}.");
                        break;
                    case 0:
                        Console.WriteLine("Gracias por usar el programa.");
                        break;
                }
            } while (opcion != 0);
        }
        /// <summary>
        /// Carga los videojuegos desde un archivo CSV. Cada línea del archivo debe tener el formato:
        /// lugarEnElCatalogo,nombre,genero,plataforma
        /// </summary>
        /// <param name="videojuegos">Lista de videojuegos a cargar</param>
        /// <param name="ruta">Ruta del archivo CSV</param>
        private void CargarDesdeCSV(List<Videojuego> videojuegos, string ruta)
        {
            foreach (string linea in File.ReadLines(ruta))
            {
                string[] datos = linea.Split(',');
                int lugar = Convert.ToInt32(datos[0]);
                string nombre = datos[1];
                string genero = datos[2];
                string plataforma = datos[3];
                videojuegos.Add(new Videojuego(lugar, nombre, genero, plataforma));
            }
        }
        /// <summary>
        /// Carga los videojuegos desde un archivo JSON. Cada línea del archivo debe ser un objeto JSON que represente un videojuego, con las propiedades:
        /// lugarEnElCatalogo, nombre, genero, plataforma
        /// </summary>
        /// <param name="videojuegos">Lista de videojuegos a cargar</param>
        /// <param name="ruta">Ruta del archivo JSON</param>
        private void CargarDesdeJSON(List<Videojuego> videojuegos, string ruta)
        {
            foreach (string linea in File.ReadLines(ruta))
            {
                if (!string.IsNullOrWhiteSpace(linea))
                {
                    Videojuego v = JsonSerializer.Deserialize<Videojuego>(linea);
                    if (v != null)
                        videojuegos.Add(v);
                }
            }
        }
    }
}