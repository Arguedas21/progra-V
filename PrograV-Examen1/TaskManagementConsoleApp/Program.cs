using TaskManagementLibrary;

class Program
{
    static bool confirme(string accion)
    {
        Console.WriteLine("Confirme " + accion + " s/n");
        return Console.ReadLine() == "s";
    } 

    static void Main(string[] args)
    {
        var taskService = new TaskService();

        while (true)
        {
            Console.WriteLine("1. Agregar tarea");
            Console.WriteLine("2. Ver tareas");
            Console.WriteLine("3. Actualizar tarea");
            Console.WriteLine("4. Eliminar tarea");
            Console.WriteLine("5. Completar tarea");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
    string title, description;
    do
    {
        Console.Write("Titulo: ");
        title = Console.ReadLine();
        Console.Write("Descripcion: ");
        description = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(description))
        {
            Console.WriteLine("Error: El título y la descripción no pueden estar en blanco. Inténtelo de nuevo.");
        }
    } while (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(description));

    var task = taskService.AddTask(title, description);
    Console.WriteLine($"Tarea agregada con Id: {task.Id}");
    break;




                case "2":
                    var tasks = taskService.GetAllTasks();
                    Console.WriteLine("-------------------------------------------------");
                    foreach (var t in tasks)
                    {
                        Console.WriteLine($"ID: {t.Id}, Titulo: {t.Title}, Descripcion: {t.Description}, Completada: {t.IsCompleted}");
                    }
                    Console.WriteLine("-------------------------------------------------");
                    break;



               case "3":
    int updateId;
    do
    {
        Console.Write("Introduzca el Id de la tarea por actualizar: ");
    } while (!int.TryParse(Console.ReadLine(), out updateId));

    var task2 = taskService.GetTaskById(updateId);

    if (task2 == null)
    {
        Console.WriteLine("Tarea no encontrada.");
        break;
    }

    Console.WriteLine($"Titulo actual: {task2.Title}");
    Console.Write("-> Nuevo titulo(deje en blanco para mantener el actual)): ");
    var newTitle = Console.ReadLine();

    Console.WriteLine($"Descripcion actual: {task2.Description}");
    Console.Write("-> Nueva Descripcion(deje en blanco para mantener el actual): ");
    var newDescription = Console.ReadLine();

    Console.Write("Completada (true/false)(deje en blanco para mantener el actual): ");
    bool? isCompleted = null;
    var isCompletedInput = Console.ReadLine();

    if (!string.IsNullOrWhiteSpace(isCompletedInput))
    {
        if (!bool.TryParse(isCompletedInput, out var parsedIsCompleted))
        {
            Console.WriteLine("Entrada no válida para el estado completado. La tarea no se actualizará.");
            break;
        }
        isCompleted = parsedIsCompleted;
    }

    // Verificar si se proporcionaron nuevos datos
    if (!string.IsNullOrWhiteSpace(newTitle))
    {
        task2.Title = newTitle;
    }
    if (!string.IsNullOrWhiteSpace(newDescription))
    {
        task2.Description = newDescription;
    }
    if (isCompleted.HasValue)
    {
        task2.IsCompleted = isCompleted.Value;
    }

    if (taskService.UpdateTask(updateId, task2.Title, task2.Description, task2.IsCompleted))
    {
        Console.WriteLine("Tarea actualizada exitosamente.");
    }
    else
    {
        Console.WriteLine("Tarea no encontrada o no se realizaron cambios.");
    }
    break;





                case "4":
    Console.Write("Introduzca el Id de la tarea a eliminar: ");
    if (!int.TryParse(Console.ReadLine(), out int deleteId))
    {
        Console.WriteLine("ID de tarea no válido.");
        break;
    }

    var taskToDelete = taskService.GetTaskById(deleteId);
    if (taskToDelete == null)
    {
        Console.WriteLine("Tarea no encontrada.");
        break;
    }

    Console.WriteLine("Tarea encontrada:");
    Console.WriteLine($"     - ID: {taskToDelete.Id}");
    Console.WriteLine($"     - Titulo: {taskToDelete.Title}");
    Console.WriteLine($"     - Descripcion: {taskToDelete.Description}");

    Console.Write("¿Desea eliminar esta tarea? (si/no): ");
    var confirmacion = Console.ReadLine();

    if (confirmacion?.Trim().ToLower() == "si")
    {
        if (taskService.DeleteTask(deleteId))
        {
            Console.WriteLine("Tarea eliminada exitosamente.");
        }
        else
        {
            Console.WriteLine("No se pudo eliminar la tarea.");
        }
    }
    else
    {
        Console.WriteLine("Operación de eliminación cancelada.");
    }
    break;




               case "5":
    int completeId;
    do
    {
        Console.Write("Introduzca el Id de la tarea a completar: ");
    } while (!int.TryParse(Console.ReadLine(), out completeId));

    var taskToComplete = taskService.GetTaskById(completeId);
    if (taskToComplete == null)
    {
        Console.WriteLine("Tarea no encontrada. Intente con un ID válido.");
        break;
    }

    Console.WriteLine($"Titulo: {taskToComplete.Title}");
    taskToComplete.IsCompleted = true;
    Console.WriteLine("Tarea completada exitosamente.");
    break;





                    
                case "6":
                    return;
                default:
                    Console.WriteLine("Opcion invalida, intente de nuevo.");
                    break;
            }
        }
    }
}
