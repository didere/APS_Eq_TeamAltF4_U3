using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using APS_Eq_TeamAltF4_U3.Models;
using APS_Eq_TeamAltF4_U3.Exceptions;
using APS_Eq_TeamAltF4_U3.Models.FinalModels;

namespace APS_Eq_TeamAltF4_U3.Runners.TrabajoFinal
{
    public class Runner03_RegistroComida
    {
        public Runner03_RegistroComida()
        {
            string rutaCsv = "comida.csv";
            string rutaJson = "comida.json";
            List<Comida> comidas = new List<Comida>();

            if (File.Exists(rutaCsv))
            {
                CargarDesdeCSV(comidas, rutaCsv);
            }
            else if (File.Exists(rutaJson))
            {
                CargarDesdeJSON(comidas, rutaJson);
            }
            else
            {
                Console.WriteLine("No existen registros previos.");
            }

            // Ordenar la lista al inicio
            comidas.Sort();

            int opcion = 0;
            do
            {
                Console.WriteLine("\nBienvenido al menú digital del restaurante Mr. Worldwide:");
                Console.WriteLine("1. Registrar comida");
                Console.WriteLine("2. Ver el menú");
                Console.WriteLine("3. Eliminar comida");
                Console.WriteLine("4. Guardar cambios (CSV)");
                Console.WriteLine("5. Exportar a JSON");
                Console.WriteLine("6. Filtrar por país de origen");
                Console.WriteLine("0. Salir");
                Console.Write("Opción: ");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        try
                        {
                            Console.Write("Ingresa su lugar en el menú: ");
                            int lugarEnMenu = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Ingresa el nombre de la comida: ");
                            string nombre = Console.ReadLine();
                            Console.Write("Ingresa el país de origen de la comida: ");
                            string paisOrigen = Console.ReadLine();
                            Console.Write("Ingresa el costo de la comida: ");
                            int costo = Convert.ToInt32(Console.ReadLine());

                            Comida comida = new Comida(lugarEnMenu, nombre, paisOrigen, costo);
                            comidas.Add(comida);
                            comidas.Sort();          // mantener orden
                            Contador.TotalRegistros++;
                            Console.WriteLine("Comida registrada correctamente.");
                            Console.WriteLine("Total de registros en el sistema: " + Contador.TotalRegistros);
                            Console.WriteLine(comida.Resumen());
                        }
                        catch (ComidaException ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error inesperado: " + ex.Message);
                        }
                        break;
                    case 2:
                        if (comidas.Count == 0)
                        {
                            Console.WriteLine("No hay comidas registradas.");
                            return;
                        }
                        Console.WriteLine("Costo máximo en el menú: $" + EstadisticasComida.CostoMaximo(comidas));
                        foreach (Comida c in comidas)
                        {
                            Console.WriteLine(c);
                        }
                        break;
                    case 3:
                        if (comidas.Count == 0)
                        {
                            Console.WriteLine("No hay comidas para eliminar.");
                            return;
                        }
                        Console.Write("Ingresa el lugar en el menú de la comida a eliminar: ");
                        int lugarEliminar = Convert.ToInt32(Console.ReadLine());
                        Comida comidaAEliminar = null;
                        foreach (Comida c in comidas)
                        {
                            if (c.LugarEnMenu == lugarEliminar)
                            {
                                comidaAEliminar = c;
                                break;
                            }
                        }
                        if (comidaAEliminar != null)
                        {
                            comidas.Remove(comidaAEliminar);
                            comidas.Sort();
                            Contador.TotalRegistros--;
                            Console.WriteLine("Comida eliminada.");
                            Console.WriteLine("Total de registros en el sistema: " + Contador.TotalRegistros);
                        }
                        else
                        {
                            Console.WriteLine("No se encontró una comida con ese lugar en el menú.");
                        }
                        break;
                    case 4:
                        StreamWriter sw = new StreamWriter(rutaCsv);
                        foreach (Comida c in comidas)
                        {
                            sw.WriteLine($"{c.LugarEnMenu},{c.Nombre},{c.PaisOrigen},{c.Costo}");
                        }
                        sw.Flush();
                        sw.Close();
                        Console.WriteLine("Cambios guardados en CSV.");
                        break;
                    case 5:
                        StreamWriter swJson = new StreamWriter(rutaJson);
                        foreach (Comida c in comidas)
                        {
                            string json = JsonSerializer.Serialize(c);
                            swJson.WriteLine(json);
                        }
                        swJson.Flush();
                        swJson.Close();
                        Console.WriteLine("Registros exportados a JSON.");
                        break;
                    // Dentro del do-while, después del case 5 y antes del case 0
                    case 6:
                        if (comidas.Count == 0)
                        {
                            Console.WriteLine("No hay comidas registradas.");
                            break;
                        }
                        Console.Write("Ingresa el país de origen a filtrar: ");
                        string paisFiltro = Console.ReadLine();
                        bool encontrado = false;
                        foreach (Comida c in comidas)
                        {
                            if (c.PaisOrigen.Equals(paisFiltro, StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine(c);
                                encontrado = true;
                            }
                        }
                        if (!encontrado)
                            Console.WriteLine($"No se encontraron comidas de {paisFiltro}.");
                        break;
                   
                    case 0:
                        Console.WriteLine("Saliendo...");
                        break;
                }
            } while (opcion != 0);
        }
        /// <summary>
        /// Carga los registros de comida desde un archivo CSV. Cada línea del archivo debe tener el formato:
        /// lugarEnMenu,nombre,paisOrigen,costo
        /// </summary>
        /// <param name="comidas">Lista de comidas donde se cargarán los registros.</param>
        /// <param name="ruta">Ruta del archivo CSV.</param>
        private void CargarDesdeCSV(List<Comida> comidas, string ruta)
        {
            foreach (string linea in File.ReadLines(ruta))
            {
                string[] datos = linea.Split(',');
                int lugarEnMenu = Convert.ToInt32(datos[0]);
                string nombre = datos[1];
                string paisOrigen = datos[2];
                int costo = Convert.ToInt32(datos[3]);
                comidas.Add(new Comida(lugarEnMenu, nombre, paisOrigen, costo));
            }
        }
        /// <summary>
        /// Carga los registros de comida desde un archivo JSON. Cada línea del archivo debe ser un objeto JSON que represente una comida, con las propiedades:
        /// lugarEnMenu, nombre, paisOrigen, costo
        /// </summary>
        /// <param name="comidas">Lista de comidas donde se cargarán los registros.</param>
        /// <param name="ruta">Ruta del archivo JSON.</param>
        private void CargarDesdeJSON(List<Comida> comidas, string ruta)
        {
            foreach (string linea in File.ReadLines(ruta))
            {
                if (!string.IsNullOrWhiteSpace(linea))
                {
                    Comida comida = JsonSerializer.Deserialize<Comida>(linea);
                    if (comida != null)
                        comidas.Add(comida);
                }
            }
        }
    }
}
