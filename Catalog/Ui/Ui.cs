using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Domain;
using Catalog.Service;

namespace Catalog.Ui {
    class Ui {
        Service.Service Service = new Service.Service();

        public void Menu() {
            Console.WriteLine("1. Arata toti studentii.");
            Console.WriteLine("2. Arata toate temele.");
            Console.WriteLine("3. Arata toate notele.");
            Console.WriteLine("4. Adauga o tema de laborator.");
            Console.WriteLine("5. Modifica deadline-ul unei teme de laborator.");
            Console.WriteLine("6. Adauga o nota.");
            Console.WriteLine("0. Exit.");
        }

        public void ShowAllStudents() {
            foreach(KeyValuePair<string, Student> st in Service.GetStudents()) {
                Console.WriteLine(st.Value.ToString());
            }
        }

        public void ShowAllTeme() {
            foreach (KeyValuePair<string, Tema> t in Service.GetTeme()) {
                Console.WriteLine(t.Value.ToString());
            }
        }

        public void ShowAllNote() {
            foreach (KeyValuePair<KeyValuePair<string, string>, Nota> n in Service.GetNote()) {
                Console.WriteLine(n.Value.ToString());
            }
        }

        public void AddTema() {
            Console.Write("Id: ");
            string id = Console.ReadLine();

            Console.Write("Descriere: ");
            string descriere = Console.ReadLine();

            Console.Write("Deadline: ");
            int deadline = Int32.Parse(Console.ReadLine());

            Console.Write("Data primire: ");
            int dateReceived = Int32.Parse(Console.ReadLine());

            Service.AddTema(id, descriere, deadline, dateReceived);
        }

        public void ModifyDeadline() {
            Console.Write("Id tema: ");
            string id = Console.ReadLine();

            Console.Write("Noul deadline: ");
            int deadline = Int32.Parse(Console.ReadLine());

            Service.PrelungireTermen(id, deadline);
        }

        public void AddNota() {
            Console.Write("Id student: ");
            string idStudent = Console.ReadLine();

            Console.Write("Id tema: ");
            string idTema = Console.ReadLine();

            Console.Write("Nota: ");
            int nota = Int32.Parse(Console.ReadLine());

            Console.Write("Feedback: ");
            string feedback = Console.ReadLine();

            Service.AddNota(idStudent, idTema, nota, feedback);
        }

        public void Start() {
            Service.AddValues(20);
            Menu();
            while (true) {
                Console.Write("Comanda: ");
                string comanda = Console.ReadLine();
                switch (comanda) {
                    case "1":
                        ShowAllStudents();
                        break;

                    case "2":
                        ShowAllTeme();
                        break;

                    case "3":
                        ShowAllNote();
                        break;

                    case "4":
                        AddTema();
                        break;

                    case "5":
                        ModifyDeadline();
                        break;

                    case "6":
                        AddNota();
                        break;
             
                    case "0":
                        return;

                    default:
                        Console.WriteLine("Comanda invalida.");
                        break;
                }


            }

        }
    }
}