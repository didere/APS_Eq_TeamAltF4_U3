using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using APS_Eq_TeamAltF4_U3.Exceptions;
using APS_Eq_TeamAltF4_U3.Models.FinalModels;

namespace APS_Eq_TeamAltF4_U3.Runners.TrabajoFinal
{
    public class Runner06_RegistroDeportes
    {
        public Runner06_RegistroDeportes()
        {
            string rutaCsv = "deportes.csv";
            string rutaJson = "deportes.json";
            List<Deporte> deportes = new List<Deporte>();

            if (File.Exists(rutaCsv))
                CargarDesdeCSV(deportes, rutaCsv);
            else if (File.Exists(rutaJson))
                CargarDesdeJSON(deportes, rutaJson);
            else
                Console.WriteLine("No existen registros previos.");

            deportes.Sort();

            int opcion = 0;
            do
            {
                Console.WriteLine("\nRanking mundial de deportes:");
                Console.WriteLine("1. Registrar deporte");
                Console.WriteLine("2. Visualizar registros");
                Console.WriteLine("3. Eliminar deporte");
                Console.WriteLine("4. Guardar cambios (CSV)");
                Console.WriteLine("5. Exportar a JSON");
                Console.WriteLine("6. Filtrar por tipo de deporte");
                Console.WriteLine("0. Salir");
                Console.Write("Opción: ");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        try
                        {
                            Console.Write("Ingresa el lugar del deporte en el ranking mundial: ");
                            int lugar = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Ingresa el nombre del deporte: ");
                            string nombre = Console.ReadLine();
                            Console.Write("Ingresa el tipo de deporte: ");
                            string tipo = Console.ReadLine();
                            Console.Write("Ingresa la cantidad de jugadores: ");
                            int jugadores = Convert.ToInt32(Console.ReadLine());

                            Deporte d = new Deporte(lugar, nombre, tipo, jugadores);
                            deportes.Add(d);
                            deportes.Sort();
                            Contador.TotalRegistros++;
                            Console.WriteLine("Deporte registrado correctamente.");
                            Console.WriteLine("Total de registros en el sistema: " + Contador.TotalRegistros);
                            Console.WriteLine(d.Resumen());
                        }
                        catch (DeporteException ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error inesperado: " + ex.Message);
                        }
                        break;
                    case 2:
                        if (deportes.Count == 0)
                        {
                            Console.WriteLine("No hay deportes registrados.");
                            return;
                        }
                        Console.WriteLine("Promedio del total de jugadores: " +
                                          EstadisticasDeporte.PromedioJugadores(deportes));
                        foreach (Deporte d in deportes)
                        {
                            Console.WriteLine(d);
                        }
                        break;
                    case 3:
                        if (deportes.Count == 0)
                        {
                            Console.WriteLine("No hay deportes para eliminar.");
                            return;
                        }
                        Console.Write("Ingresa el lugar en el ranking del deporte a eliminar: ");
                        int lugarEliminar = Convert.ToInt32(Console.ReadLine());
                        Deporte dAEliminar = null;
                        foreach (Deporte d in deportes)
                        {
                            if (d.LugarEnElRanking == lugarEliminar)
                            {
                                dAEliminar = d;
                                break;
                            }
                        }
                        if (dAEliminar != null)
                        {
                            deportes.Remove(dAEliminar);
                            deportes.Sort();
                            Contador.TotalRegistros--;
                            Console.WriteLine("Deporte eliminado.");
                            Console.WriteLine("Total de registros en el sistema: " + Contador.TotalRegistros);
                        }
                        else
                        {
                            Console.WriteLine("No se encontró un deporte con ese lugar en el ranking.");
                        }
                        break;
                    case 4:
                        StreamWriter sw = new StreamWriter(rutaCsv);
                        foreach (Deporte d in deportes)
                        {
                            sw.WriteLine($"{d.LugarEnElRanking},{d.Nombre},{d.TipoDeporte},{d.CantidadDeJugadores}");
                        }
                        sw.Flush();
                        sw.Close();
                        Console.WriteLine("Cambios guardados en CSV.");
                        break;
                    case 5:
                        StreamWriter swJson = new StreamWriter(rutaJson);
                        foreach (Deporte d in deportes)
                        {
                            string json = JsonSerializer.Serialize(d);
                            swJson.WriteLine(json);
                        }
                        swJson.Flush();
                        swJson.Close();
                        Console.WriteLine("Registros exportados a JSON.");
                        break;
                    case 6:
                        if (deportes.Count == 0)
                        {
                            Console.WriteLine("No hay deportes registrados.");
                            break;
                        }
                        Console.Write("Ingresa el tipo de deporte a filtrar (ej. Equipo, Individual): ");
                        string tipoFiltro = Console.ReadLine();
                        bool encontrado = false;
                        foreach (Deporte d in deportes)
                        {
                            if (d.TipoDeporte.Equals(tipoFiltro, StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine(d);
                                encontrado = true;
                            }
                        }
                        if (!encontrado)
                            Console.WriteLine($"No se encontraron deportes del tipo {tipoFiltro}.");
                        break;
                    case 0:
                        Console.WriteLine("Gracias por usar el programa.");
                        break;
                }
            } while (opcion != 0);
        }
        /// <summary>
        /// Carga los deportes desde un archivo CSV. Cada línea del archivo debe tener el formato:
        /// lugar,nombre,tipo,jugadores
        /// </summary>
        /// <param name="deportes">Lista de deportes a cargar</param>
        /// <param name="ruta">Ruta del archivo CSV</param>
        private void CargarDesdeCSV(List<Deporte> deportes, string ruta)
        {
            foreach (string linea in File.ReadLines(ruta))
            {
                string[] datos = linea.Split(',');
                int lugar = Convert.ToInt32(datos[0]);
                string nombre = datos[1];
                string tipo = datos[2];
                int jugadores = Convert.ToInt32(datos[3]);
                deportes.Add(new Deporte(lugar, nombre, tipo, jugadores));
            }
        }
        /// <summary>
        /// Carga los deportes desde un archivo JSON. Cada línea del archivo debe ser un objeto JSON con las propiedades:
        /// </summary>
        /// <param name="deportes">Lista de deportes a cargar</param>
        /// <param name="ruta">Ruta del archivo JSON</param>
        private void CargarDesdeJSON(List<Deporte> deportes, string ruta)
        {
            foreach (string linea in File.ReadLines(ruta))
            {
                if (!string.IsNullOrWhiteSpace(linea))
                {
                    Deporte d = JsonSerializer.Deserialize<Deporte>(linea);
                    if (d != null)
                        deportes.Add(d);
                }
            }
        }
    }
}