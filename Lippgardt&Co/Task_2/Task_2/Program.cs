using System;
using System.Collections.Generic;
using System.Linq;
using Task_2.Models;

namespace Task_2
{
    class Program
    {
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            List<Patient> _patients = new List<Patient>()
            {
                new Patient("Alex","Mitchel",21,"critical"),
                new Patient("Kate","Pupsvel",18,"critical"),
                new Patient("Georgy","Robbinson",42,"normal"),
                new Patient("LG","Company",120,"normal"),
                new Patient("Mikky","Mouse",30,"critical")
            };

            while (true)
            {
                Console.WriteLine("Нажмите:");
                Console.WriteLine("1-что бы найти пациента по имени.");
                Console.WriteLine("2-что бы найти пациента по фамилии.");
                Console.WriteLine("3-что бы найти критических пациентов.");
                Console.WriteLine("4-что бы всех пациентов младше критерия");
                Console.WriteLine("0-что бы закончить поиск");
                string number = Console.ReadLine();

                if (number == "1")
                {
                    Console.WriteLine("Введите имя");
                    string name = Console.ReadLine();
                    var patients = FindByName(name,_patients);

                    if (patients.Any())
                    {
                        foreach (var item in patients)
                        {
                            Console.WriteLine($"Имя:{item.name} Фамилия:{item.surname} Возраст:{item.age}  Состояние:{item.status}");
                        }
                    }
                    else
                        Console.WriteLine("Ничего не найдено:(");
                  
                }

                if (number == "2")
                {
                    Console.WriteLine("Введите фамилию");
                    string surname = Console.ReadLine();
                    var patients = FindBySurname(surname, _patients);
                    if (patients.Any())
                    {
                        foreach (var item in patients)
                        {
                            Console.WriteLine($"Имя:{item.name} Фамилия:{item.surname} Возраст:{item.age}  Состояние:{item.status}");
                        }
                    }
                    else
                        Console.WriteLine("Ничего не найдено:(");               
                }

                if (number == "3")
                {
                    var patients = FindCriticalPatient(_patients);
                    if (patients.Any())
                    {
                        foreach (var item in patients)
                        {
                            Console.WriteLine($"Имя:{item.name} Фамилия:{item.surname} Возраст:{item.age}  Состояние:{item.status}");
                        }
                    }
                    else
                        Console.WriteLine("Ничего не найдено:(");
                }

                if (number == "4")
                {
                    Console.WriteLine("Введите критерий поиска по возрасту");
                    int age = Convert.ToInt32(Console.ReadLine());
                    var patients = FindByAge(_patients,age);
                    if (patients.Any())
                    {
                        foreach (var item in patients)
                        {
                            Console.WriteLine($"Имя:{item.name} Фамилия:{item.surname} Возраст:{item.age}  Состояние:{item.status}");
                        }
                    }
                    else
                        Console.WriteLine("Ничего не найдено:(");
                }

                if (number == "0")
                    break;
            }
        }

        static public IEnumerable<Patient> FindByName(string name,List<Patient> _patients)
        {
            var patients = _patients.Where(p => p.name == name).ToList();
            return patients;
        }

        static public IEnumerable<Patient> FindBySurname(string surname, List<Patient> _patients)
        {
            var patients = _patients.Where(p => p.surname == surname).ToList();
            return patients;
        }

        static public IEnumerable<Patient> FindCriticalPatient(List<Patient> _patients)
        {
            var patients = _patients.Where(p => p.status == "critical").ToList();
            return patients;
        }

        static public IEnumerable<Patient> FindByAge(List<Patient> _patients,int age)
        {
            var patients = _patients.Where(p => p.age < age).ToList();
            return patients;
        }
    }
}
