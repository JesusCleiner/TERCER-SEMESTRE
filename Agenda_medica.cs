using System;
using System.Collections.Generic;

namespace AgendaTurnosClinica
{
    // Define una estructura para representar un turno de paciente
    public struct Turno
    {
        public int IdTurno; // Identificador único del turno
        public string NombrePaciente; // Nombre del paciente
        public string FechaTurno; // Fecha del turno en formato dd/mm/aaaa
        public string HoraTurno; // Hora del turno en formato HH:mm
        public string Especialidad; // Especialidad médica del turno

        // Constructor para inicializar un turno
        public Turno(int idTurno, string nombrePaciente, string fechaTurno, string horaTurno, string especialidad)
        {
            IdTurno = idTurno;
            NombrePaciente = nombrePaciente;
            FechaTurno = fechaTurno;
            HoraTurno = horaTurno;
            Especialidad = especialidad;
        }

        // Sobrescribe el método ToString para mostrar los detalles del turno
        public override string ToString()
        {
            return $"ID: {IdTurno}, Paciente: {NombrePaciente}, Fecha: {FechaTurno}, Hora: {HoraTurno}, Especialidad: {Especialidad}";
        }
    }

    class Program
    {
        // Lista para almacenar los turnos
        static List<Turno> turnos = new List<Turno>();
        static int nextId = 1; // Variable para generar IDs únicos para los turnos

        static void Main(string[] args)
        {
            int opcion; // Variable para capturar la opción seleccionada por el usuario

            do
            {
                // Mostrar el menú principal
                Console.Clear();
                Console.WriteLine("Sistema de Agenda de Turnos de la Clínica\n");
                Console.WriteLine("1. Agregar Turno");
                Console.WriteLine("2. Ver Turnos");
                Console.WriteLine("3. Consultar Turno por Paciente");
                Console.WriteLine("4. Eliminar Turno");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");

                // Leer la opción seleccionada
                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            AgregarTurno(); // Llamar al método para agregar un turno
                            break;
                        case 2:
                            VerTurnos(); // Llamar al método para ver los turnos
                            break;
                        case 3:
                            ConsultarTurnoPorPaciente(); // Llamar al método para consultar turnos por paciente
                            break;
                        case 4:
                            EliminarTurno(); // Llamar al método para eliminar un turno
                            break;
                        case 5:
                            Console.WriteLine("Saliendo del sistema..."); // Mensaje de salida
                            break;
                        default:
                            Console.WriteLine("Opción inválida. Intente nuevamente."); // Manejo de opción no válida
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Intente nuevamente."); // Manejo de entrada no válida
                }

                // Pausa antes de volver al menú
                if (opcion != 5)
                {
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 5); // Repetir hasta que el usuario elija salir
        }

        // Método para agregar un turno
        static void AgregarTurno()
        {
            Console.Clear();
            Console.WriteLine("Agregar Turno\n");

            // Solicitar los datos del turno al usuario
            Console.Write("Nombre del Paciente: ");
            string nombre = Console.ReadLine();

            Console.Write("Fecha del Turno (dd/mm/aaaa): ");
            string fecha = Console.ReadLine();

            Console.Write("Hora del Turno (HH:mm): ");
            string hora = Console.ReadLine();

            Console.WriteLine("Seleccione la Especialidad:");
            Console.WriteLine("1. Medicina General");
            Console.WriteLine("2. Cardiología");
            Console.WriteLine("3. Urología");
            Console.WriteLine("4. Pediatría");
            Console.WriteLine("5. Ginecología");
            Console.Write("Opción: ");

            string especialidad = "";
            if (int.TryParse(Console.ReadLine(), out int especialidadOpcion))
            {
                switch (especialidadOpcion)
                {
                    case 1:
                        especialidad = "Medicina General";
                        break;
                    case 2:
                        especialidad = "Cardiología";
                        break;
                    case 3:
                        especialidad = "Urología";
                        break;
                    case 4:
                        especialidad = "Pediatría";
                        break;
                    case 5:
                        especialidad = "Ginecología";
                        break;
                    default:
                        Console.WriteLine("Opción inválida, se asignará Medicina General por defecto.");
                        especialidad = "Medicina General";
                        break;
                }
            }

            // Crear un nuevo turno y agregarlo a la lista
            turnos.Add(new Turno(nextId++, nombre, fecha, hora, especialidad));
            Console.WriteLine("Turno agregado exitosamente.");
        }

        // Método para ver todos los turnos registrados
        static void VerTurnos()
        {
            Console.Clear();
            Console.WriteLine("Lista de Turnos\n");

            // Verificar si hay turnos registrados
            if (turnos.Count == 0)
            {
                Console.WriteLine("No hay turnos registrados.");
            }
            else
            {
                // Mostrar los detalles de cada turno
                foreach (var turno in turnos)
                {
                    Console.WriteLine(turno);
                }
            }
        }

        // Método para consultar turnos por nombre de paciente
        static void ConsultarTurnoPorPaciente()
        {
            Console.Clear();
            Console.WriteLine("Consultar Turno por Paciente\n");

            // Solicitar el nombre del paciente al usuario
            Console.Write("Ingrese el nombre del paciente: ");
            string nombre = Console.ReadLine();

            // Buscar turnos que coincidan con el nombre del paciente
            var resultados = turnos.FindAll(t => t.NombrePaciente.Equals(nombre, StringComparison.OrdinalIgnoreCase));

            // Verificar si se encontraron resultados
            if (resultados.Count == 0)
            {
                Console.WriteLine("No se encontraron turnos para el paciente.");
            }
            else
            {
                // Mostrar los turnos encontrados
                foreach (var turno in resultados)
                {
                    Console.WriteLine(turno);
                }
            }
        }

        // Método para eliminar un turno
        static void EliminarTurno()
        {
            Console.Clear();
            Console.WriteLine("Eliminar Turno\n");

            // Solicitar el ID del turno a eliminar
            Console.Write("Ingrese el ID del turno a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int idTurno))
            {
                // Buscar el turno por ID
                var turno = turnos.Find(t => t.IdTurno == idTurno);

                if (turno.IdTurno != 0)
                {
                    turnos.Remove(turno);
                    Console.WriteLine("Turno eliminado exitosamente.");
                }
                else
                {
                    Console.WriteLine("No se encontró un turno con el ID especificado.");
                }
            }
            else
            {
                Console.WriteLine("ID inválido. Intente nuevamente.");
            }
        }
    }
}
