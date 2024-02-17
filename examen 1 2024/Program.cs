


int cant = 0;
int opcion = 0;
int[] cedula = new int[cant];
string[] nombre = new string[cant];
int[] telefono = new int[cant];
string[] tiposangre = new string[cant];
string[] direccion = new string[cant];
int[] edad = new int[cant];
int[] codigoMedi = new int[cant];
string[] nombreMedi = new string[cant];
int[] cantidadMedi = new int[cant];






do
{
    Console.Clear();
    Console.WriteLine("==========Menu Principal==========");
    Console.WriteLine("1-Agregar Paciente");
    Console.WriteLine("2-Agregar medicamento al catalogo");
    Console.WriteLine("3-Asignar tratamiento médico a un paciente");
    Console.WriteLine("4-Consultas");
    Console.WriteLine("=================================");
    opcion = int.Parse(Console.ReadLine());

    switch (opcion)
    {
        case 1:
            do
            {
                Console.Clear();
                Array.Resize(ref cedula, cant + 1);
                Array.Resize(ref nombre, cant + 1);
                Array.Resize(ref telefono, cant + 1);
                Array.Resize(ref tiposangre, cant + 1);
                Array.Resize(ref direccion, cant + 1);
                Array.Resize(ref edad, cant + 1);

                Console.WriteLine($"Digite la cedula del paciente {cant + 1}:");
                cedula[cant] = int.Parse(Console.ReadLine());
                Console.WriteLine($"Digite el Nombre del paciente {cant + 1}:");
                nombre[cant] = Console.ReadLine();
                Console.WriteLine($"Digite el telefono del paciente {cant + 1}:");
                telefono[cant] = int.Parse(Console.ReadLine());
                Console.WriteLine($"Digite el tipo de sangre {cant + 1}:");
                tiposangre[cant] = Console.ReadLine();
                Console.WriteLine($"Digite la direccion {cant + 1}:");
                direccion[cant] = Console.ReadLine();
                Console.WriteLine($"Digite la edad  {cant + 1}:");
                edad[cant] = int.Parse(Console.ReadLine());

                cant++; // suma pacientes

                Console.WriteLine("¿Desea ingresar otro paciente? (S/N)");
            } while (Console.ReadLine().ToUpper() == "S");

            break;



            case 2:
            do
            {
                Console.Clear();
                Array.Resize(ref codigoMedi, cant + 1);
                Array.Resize(ref nombreMedi, cant + 1);
                Array.Resize(ref cantidadMedi, cant + 1);

                Console.WriteLine($"Digite el código del medicamento a agregar al catálogo:");
                codigoMedi[cant] = int.Parse(Console.ReadLine());
                Console.WriteLine($"Digite el nombre del medicamento:");
                nombreMedi[cant] = Console.ReadLine();
                Console.WriteLine($"Digite la cantidad de unidades disponibles:");
                cantidadMedi[cant] = int.Parse(Console.ReadLine());

                cant++; // suma la cantidad de medicamentos

                Console.WriteLine("¿Desea ingresar otro medicamento al catálogo? (S/N)");
            } while (Console.ReadLine().ToUpper() == "S");



            break; 
        


        case 3:
            Console.Clear();
            Console.WriteLine("Asignar tratamiento médico a un paciente");

            Console.WriteLine("Digite la cedula del paciente:");
            int cedulaPaciente = int.Parse(Console.ReadLine());

            // Busca al paciente por cedula
            int indicePaciente = Array.IndexOf(cedula, cedulaPaciente);

            if (indicePaciente == -1)
            {
                Console.WriteLine("Paciente no encontrado");
            }
            else
            {
                //  medicamentos disponibles
                Console.WriteLine("Medicamentos disponibles:");
                for (int i = 0; i < codigoMedi.Length; i++)
                {
                    Console.WriteLine($"Código: {codigoMedi[i]}, Nombre: {nombreMedi[i]}, Cantidad: {cantidadMedi[i]}");
                }

                Console.WriteLine("Digite el código del medicamento a asignar:");
                int codigoMedicamento = int.Parse(Console.ReadLine());

                // Busca el medicamento por código
                int indiceMedicamento = Array.IndexOf(codigoMedi, codigoMedicamento);

                if (indiceMedicamento == -1)
                {
                    Console.WriteLine("Medicamento no encontrado");
                }
                else
                {
                    Console.WriteLine("Digite la cantidad a asignar:");
                    int cantidadAsignar = int.Parse(Console.ReadLine());

                    // Busca si hay  unidades 
                    if (cantidadAsignar > cantidadMedi[indiceMedicamento])
                    {
                        Console.WriteLine("No hay suficientes unidades disponibles");
                    }
                    else
                    {
                    
                        Console.WriteLine("Tratamiento asignado correctamente");
                    }
                }
            }


            break;

        case 4:
            Console.Clear();
            Console.WriteLine("==========Consultas==========");
            Console.WriteLine("1. Cantidad total de pacientes registrados");
            Console.WriteLine("2. Reporte de todos los medicamentos recetados sin repetir");
            Console.WriteLine("3. Reporte de cantidad de pacientes agrupados por edades");
            Console.WriteLine("4. Reporte de pacientes y consultas ordenados por nombre");
            Console.WriteLine("=============================");
            int consulta = int.Parse(Console.ReadLine());

            switch (consulta)
            {
                case 1:
                    Console.WriteLine($"Cantidad total de pacientes registrados: {cant}");
                    break;

                case 2:
                    Console.WriteLine("Reporte de todos los medicamentos recetados sin repetir:");
                    var medicamentosUnicos = nombreMedi.Distinct().ToList();
                    foreach (var medicamento in medicamentosUnicos)
                    {
                        Console.WriteLine(medicamento);
                    }
                    break;

                case 3:
                    Console.WriteLine("Reporte de cantidad de pacientes agrupados por edades:");
                    var pacientesPorEdad = edad.GroupBy(e => e < 11 ? "0-10 años" : e < 31 ? "11-30 años" : e < 51 ? "31-50 años" : "Mayor de 51 años")
                        .Select(g => new { Edad = g.Key, Cantidad = g.Count() });
                    foreach (var grupo in pacientesPorEdad)
                    {
                        Console.WriteLine($"{grupo.Edad}: {grupo.Cantidad}");
                    }
                    break;

                case 4:
                    Console.WriteLine("Reporte de pacientes y consultas ordenados por nombre:");
                    var pacientesOrdenados = nombre.Select((n, i) => new { Nombre = n, Cedula = cedula[i], Telefono = telefono[i], Edad = edad[i] })
                        .OrderBy(p => p.Nombre);
                    foreach (var paciente in pacientesOrdenados)
                    {
                        Console.WriteLine($"Nombre: {paciente.Nombre}, Cédula: {paciente.Cedula}, Teléfono: {paciente.Telefono}, Edad: {paciente.Edad}");
                    }
                    break;

                default:
                    Console.WriteLine("Consulta no válida. Por favor, ingrese una opción válida.");
                    break;
            }
            break;

        

        default:
            Console.WriteLine("Opción no válida. Por favor, ingrese una opción válida.");
            break;
    }





} while (opcion!=5);