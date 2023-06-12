using System;

class Program
{
    static void Main(string[] args)
    {
        int inicialEstudiantes = 100; // Número inicial de alumnos en primer año
        int a = 80; // Porcentaje de alumnos que pasan a segundo año
        int b = 10; // Porcentaje de alumnos que abandonan
        int c = 10; // Porcentaje de alumnos que se quedan repitiendo
        int years = 5; // Duración de la carrera en años

        int[] estudiantesInscritos = new int[years]; // Alumnos inscritos por año
        int[] estudiantesQuePasan = new int[years]; // Alumnos que pasan a segundo año por año
        int[] estudiantesQueAbandonan = new int[years]; // Alumnos que abandonan por año
        int[] estudiantesQueRepiten = new int[years]; // Alumnos que se quedan repitiendo por año

        estudiantesInscritos[0] = inicialEstudiantes; // Primer año

        // Simulación de los años restantes
        for (int i = 1; i < years; i++)
        {
            estudiantesQuePasan[i - 1] = (estudiantesInscritos[i - 1] * a) / 100;
            estudiantesQueAbandonan[i - 1] = (estudiantesInscritos[i - 1] * b) / 100;
            estudiantesQueRepiten[i - 1] = (estudiantesInscritos[i - 1] * c) / 100;

            estudiantesInscritos[i] = estudiantesQuePasan[i - 1] + estudiantesQueRepiten[i - 1];
        }

        // Último año (quinto año)
        estudiantesQuePasan[years - 1] = (estudiantesInscritos[years - 1] * a) / 100;
        estudiantesQueAbandonan[years - 1] = (estudiantesInscritos[years - 1] * b) / 100;
        estudiantesQueRepiten[years - 1] = (estudiantesInscritos[years - 1] * c) / 100;

        // Cálculo del total de alumnos por año
        int[] totalEstudiantes = new int[years];
        for (int i = 0; i < years; i++)
        {
            totalEstudiantes[i] = estudiantesInscritos[i] + estudiantesQuePasan[i] + estudiantesQueRepiten[i];
        }

        // Cálculo del número de aulas requeridas
        int maxEstudiantePorSala = 30; // Número máximo de alumnos por sala
        int[] aulasRequeridas = new int[years];
        for (int i = 0; i < years; i++)
        {
            aulasRequeridas[i] = (totalEstudiantes[i] + maxEstudiantePorSala - 1) / maxEstudiantePorSala;
        }

        // Mostrar resultados
        Console.WriteLine("Estadísticas de los estudiantes:");

        for (int i = 0; i < years; i++)
        {
            Console.WriteLine(" ");
            Console.WriteLine("Año {0}:", i + 1);
            Console.WriteLine("Inscritos: {0}", estudiantesInscritos[i]);
            Console.WriteLine("Aprobados: {0}", estudiantesQuePasan[i]);
            Console.WriteLine("Reprobados: {0}", estudiantesQueRepiten[i]);
            Console.WriteLine("Abandonos: {0}", estudiantesQueAbandonan[i]);
            Console.WriteLine(" ");
        }
    }
}

