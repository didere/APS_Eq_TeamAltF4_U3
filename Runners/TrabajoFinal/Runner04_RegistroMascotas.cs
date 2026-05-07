using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using APS_Eq_TeamAltF4_U3.Exceptions;
using APS_Eq_TeamAltF4_U3.Models.FinalModels;

namespace APS_Eq_TeamAltF4_U3.Runners.TrabajoFinal
{
    public class Runner04_RegistroMascotas
    {
        public Runner04_RegistroMascotas()
        {
            string rutaCsv = "mascotas.csv";
            string rutaJson = "mascotas.json";
            List<Mascota> mascotas = new List<Mascota>();

            if (File.Exists(rutaCsv))
                CargarDesdeCSV(mascotas, rutaCsv);
            else if (File.Exists(rutaJson))
                CargarDesdeJSON(mascotas, rutaJson);
            else
                Console.WriteLine("No existen registros previos.");

            mascotas.Sort();

            int opcion = 0;
            do
            {
                Console.WriteLine("\nSistema de adopción de mascotas:");
                Console.WriteLine("1. Registrar mascota");
                Console.WriteLine("2. Visualizar registros");
                Console.WriteLine("3. Eliminar mascota");
                Console.WriteLine("4. Guardar cambios (CSV)");
                Console.WriteLine("5. Exportar a JSON");
                Console.WriteLine("6. Filtrar por especie");
                Console.WriteLine("0. Salir");
                Console.Write("Opción: ");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        try
                        {
                            Console.Write("Ingresa el ID del animal: ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Ingresa el nombre del animal: ");
                            string nombre = Console.ReadLine();
                            Console.Write("Ingresa el tipo de mascota: ");
                            string tipoMascota = Console.ReadLine();
                            Console.Write("Ingresa la raza del animal: ");
                            string raza = Console.ReadLine();
                            Console.Write("Ingresa la edad del animal: ");
                            int edad = Convert.ToInt32(Console.ReadLine());

                            Mascota mascota = new Mascota(id, nombre, tipoMascota, raza, edad);
                            mascotas.Add(mascota);
                            mascotas.Sort();
                            Contador.TotalRegistros++;
                            Console.WriteLine("Mascota registrada correctamente.");
                            Console.WriteLine("Total de registros en el sistema: " + Contador.TotalRegistros);
                            Console.WriteLine(mascota.Resumen());
                        }
                        catch (MascotaException ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error inesperado: " + ex.Message);
                        }
                        break;
                    case 2:
                        if (mascotas.Count == 0)
                        {
                            Console.WriteLine("No hay mascotas registradas.");
                            return;
                        }
                        Console.WriteLine("Edad mínima registrada: " + EstadisticasMascota.EdadMinima(mascotas) + " años");
                        foreach (Mascota m in mascotas)
                        {
                            Console.WriteLine(m);
                        }
                        break;
                    case 3:
                        if (mascotas.Count == 0)
                        {
                            Console.WriteLine("No hay mascotas para eliminar.");
                            return;
                        }
                        Console.Write("Ingresa el ID de la mascota a eliminar: ");
                        int idEliminar = Convert.ToInt32(Console.ReadLine());
                        Mascota mascotaAEliminar = null;
                        foreach (Mascota m in mascotas)
                        {
                            if (m.Id == idEliminar)
                            {
                                mascotaAEliminar = m;
                                break;
                            }
                        }
                        if (mascotaAEliminar != null)
                        {
                            mascotas.Remove(mascotaAEliminar);
                            mascotas.Sort();
                            Contador.TotalRegistros--;
                            Console.WriteLine("Mascota eliminada.");
                            Console.WriteLine("Total de registros en el sistema: " + Contador.TotalRegistros);
                        }
                        else
                        {
                            Console.WriteLine("No se encontró una mascota con ese ID.");
                        }
                        break;
                    case 4:
                        StreamWriter sw = new StreamWriter(rutaCsv);
                        foreach (Mascota m in mascotas)
                        {
                            sw.WriteLine($"{m.Id},{m.Nombre},{m.TipoMascota},{m.Raza},{m.Edad}");
                        }
                        sw.Flush();
                        sw.Close();
                        Console.WriteLine("Cambios guardados en CSV.");
                        break;
                    case 5:
                        StreamWriter swJson = new StreamWriter(rutaJson);
                        foreach (Mascota m in mascotas)
                        {
                            string json = JsonSerializer.Serialize(m);
                            swJson.WriteLine(json);
                        }
                        swJson.Flush();
                        swJson.Close();
                        Console.WriteLine("Registros exportados a JSON.");
                        break;
                    case 6:
                        if (mascotas.Count == 0)
                        {
                            Console.WriteLine("No hay mascotas registradas.");
                            break;
                        }
                        Console.Write("Ingresa el tipo de mascota a filtrar (ej. Perro, Gato): ");
                        string tipoFiltro = Console.ReadLine();
                        bool encontrado = false;
                        foreach (Mascota m in mascotas)
                        {
                            if (m.TipoMascota.Equals(tipoFiltro, StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine(m);
                                encontrado = true;
                            }
                        }
                        if (!encontrado)
                            Console.WriteLine($"No se encontraron mascotas del tipo {tipoFiltro}.");
                        break;

                    case 0:
                        Console.WriteLine("Gracias por usar el programa.");
                        break;
                }
            } while (opcion != 0);
        }
        /// <summary>
        /// Carga los registros de mascotas desde un archivo CSV. Cada línea del archivo debe tener el formato:
        /// ID,Nombre,TipoMascota,Raza,Edad
        /// </summary>
        /// <param name="mascotas">Es la lista de las Mascotas donde se cargarán los registros.</param>
        /// <param name="ruta">Es la ruta del archivo CSV desde donde se cargarán los registros.</param>
        private void CargarDesdeCSV(List<Mascota> mascotas, string ruta)
        {
            foreach (string linea in File.ReadLines(ruta))
            {
                string[] datos = linea.Split(',');
                int id = Convert.ToInt32(datos[0]);
                string nombre = datos[1];
                string tipoMascota = datos[2];
                string raza = datos[3];
                int edad = Convert.ToInt32(datos[4]);
                mascotas.Add(new Mascota(id, nombre, tipoMascota, raza, edad));
            }
        }
        /// <summary>
        /// Carga los registros de mascotas desde un archivo JSON. Cada línea del archivo debe ser un objeto JSON que represente una mascota, con las propiedades:
        /// ID, Nombre, TipoMascota, Raza, Edad
        /// </summary>
        /// <param name="mascotas">Es la lista de las Mascotas donde se cargarán los registros.</param>
        /// <param name="ruta">Es la ruta del archivo JSON desde donde se cargarán los registros.</param>
        private void CargarDesdeJSON(List<Mascota> mascotas, string ruta)
        {
            foreach (string linea in File.ReadLines(ruta))
            {
                if (!string.IsNullOrWhiteSpace(linea))
                {
                    Mascota mascota = JsonSerializer.Deserialize<Mascota>(linea);
                    if (mascota != null)
                        mascotas.Add(mascota);
                }
            }
        }
    }
}