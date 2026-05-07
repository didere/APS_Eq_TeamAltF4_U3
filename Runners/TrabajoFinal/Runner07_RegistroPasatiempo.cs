using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using APS_Eq_TeamAltF4_U3.Exceptions;
using APS_Eq_TeamAltF4_U3.Models.FinalModels;

namespace APS_Eq_TeamAltF4_U3.Runners.TrabajoFinal
{
    public class Runner07_RegistroPasatiempo
    {
        public Runner07_RegistroPasatiempo()
        {
            string rutaCsv = "pasatiempos.csv";
            string rutaJson = "pasatiempos.json";
            List<Pasatiempo> pasatiempos = new List<Pasatiempo>();

            if (File.Exists(rutaCsv))
                CargarDesdeCSV(pasatiempos, rutaCsv);
            else if (File.Exists(rutaJson))
                CargarDesdeJSON(pasatiempos, rutaJson);
            else
                Console.WriteLine("No existen registros previos.");

            pasatiempos.Sort();

            int opcion = 0;
            do
            {
                Console.WriteLine("\nSistema de registro de pasatiempos:");
                Console.WriteLine("1. Registrar pasatiempo");
                Console.WriteLine("2. Visualizar registros");
                Console.WriteLine("3. Eliminar pasatiempo");
                Console.WriteLine("4. Guardar cambios (CSV)");
                Console.WriteLine("5. Exportar a JSON");
                Console.WriteLine("6. Filtrar por tipo de pasatiempo");
                Console.WriteLine("0. Salir");
                Console.Write("Opción: ");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        try
                        {
                            Console.Write("Ingresa el nombre del pasatiempo: ");
                            string nombre = Console.ReadLine();
                            Console.Write("Ingresa la frecuencia del pasatiempo: ");
                            string frecuencia = Console.ReadLine();
                            Console.Write("Ingresa las horas dedicadas al pasatiempo: ");
                            int horas = Convert.ToInt32(Console.ReadLine());

                            Pasatiempo p = new Pasatiempo(nombre, frecuencia, horas);
                            pasatiempos.Add(p);
                            pasatiempos.Sort();  
                            Contador.TotalRegistros++;
                            Console.WriteLine("Pasatiempo registrado correctamente.");
                            Console.WriteLine("Total de registros en el sistema: " + Contador.TotalRegistros);
                            Console.WriteLine(p.Resumen());
                        }
                        catch (PasatiempoException ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error inesperado: " + ex.Message);
                        }
                        break;
                    case 2:
                        if (pasatiempos.Count == 0)
                        {
                            Console.WriteLine("No hay pasatiempos registrados.");
                            return;
                        }
                        Console.WriteLine("Horas dedicadas: " +
                                          EstadisticasPasatiempo.Horas(pasatiempos));
                        foreach (Pasatiempo p in pasatiempos)
                        {
                            Console.WriteLine(p);
                        }
                        break;
                    case 3:
                        if (pasatiempos.Count == 0)
                        {
                            Console.WriteLine("No hay pasatiempos para eliminar.");
                            return;
                        }
                        Console.Write("Ingresa el nombre del pasatiempo a eliminar: ");
                        string nombreEliminar = Console.ReadLine();
                        Pasatiempo pAEliminar = null;
                        foreach (Pasatiempo p in pasatiempos)
                        {
                            if (p.Nombre.Equals(nombreEliminar, StringComparison.OrdinalIgnoreCase))
                            {
                                pAEliminar = p;
                                break;
                            }
                        }
                        if (pAEliminar != null)
                        {
                            pasatiempos.Remove(pAEliminar);
                            pasatiempos.Sort();
                            Contador.TotalRegistros--;
                            Console.WriteLine("Pasatiempo eliminado.");
                            Console.WriteLine("Total de registros en el sistema: " + Contador.TotalRegistros);
                        }
                        else
                        {
                            Console.WriteLine("No se encontró un pasatiempo con ese nombre.");
                        }
                        break;
                    case 4:
                        StreamWriter sw = new StreamWriter(rutaCsv);
                        foreach (Pasatiempo p in pasatiempos)
                        {
                            sw.WriteLine($"{p.Nombre},{p.Frecuencia},{p.HorasDedicadas}");
                        }
                        sw.Flush();
                        sw.Close();
                        Console.WriteLine("Cambios guardados en CSV.");
                        break;
                    case 5:
                        StreamWriter swJson = new StreamWriter(rutaJson);
                        foreach (Pasatiempo p in pasatiempos)
                        {
                            string json = JsonSerializer.Serialize(p);
                            swJson.WriteLine(json);
                        }
                        swJson.Flush();
                        swJson.Close();
                        Console.WriteLine("Registros exportados a JSON.");
                        break;
                    case 6:
                        if (pasatiempos.Count == 0)
                        {
                            Console.WriteLine("No hay pasatiempos registrados.");
                            break;
                        }
                        Console.Write("Ingresa la frecuencia a filtrar (ej. Diario, Semanal): ");
                        string frecuenciaFiltro = Console.ReadLine();
                        bool encontrado = false;
                        foreach (Pasatiempo p in pasatiempos)
                        {
                            if (p.Frecuencia.Equals(frecuenciaFiltro, StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine(p);
                                encontrado = true;
                            }
                        }
                        if (!encontrado)
                            Console.WriteLine($"No se encontraron pasatiempos con frecuencia {frecuenciaFiltro}.");
                        break;
                    case 0:
                        Console.WriteLine("Gracias por usar el programa.");
                        break;
                }
            } while (opcion != 0);
        }
        /// <summary>
        /// Carga los pasatiempos desde un archivo CSV, donde cada línea tiene el formato:
        /// nombre,frecuencia,horas
        /// </summary>
        /// <param name="pasatiempos">Lista de pasatiempos a cargar</param>
        /// <param name="ruta">Ruta del archivo CSV</param>
        private void CargarDesdeCSV(List<Pasatiempo> pasatiempos, string ruta)
        {
            foreach (string linea in File.ReadLines(ruta))
            {
                string[] datos = linea.Split(',');
                string nombre = datos[0];
                string frecuencia = datos[1];
                int horas = Convert.ToInt32(datos[2]);
                pasatiempos.Add(new Pasatiempo(nombre, frecuencia, horas));
            }
        }
        /// <summary>
        /// Carga los pasatiempos desde un archivo JSON, donde cada línea es un objeto JSON con las propiedades:
        /// nombre, frecuencia, horas
        /// </summary>
        /// <param name="pasatiempos">Lista de pasatiempos a cargar</param>
        /// <param name="ruta">Ruta del archivo JSON</param>
        private void CargarDesdeJSON(List<Pasatiempo> pasatiempos, string ruta)
        {
            foreach (string linea in File.ReadLines(ruta))
            {
                if (!string.IsNullOrWhiteSpace(linea))
                {
                    Pasatiempo p = JsonSerializer.Deserialize<Pasatiempo>(linea);
                    if (p != null)
                        pasatiempos.Add(p);
                }
            }
        }
    }
}