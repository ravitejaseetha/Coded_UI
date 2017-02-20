using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    class Program
    {
        private string _FirstName;
        private string _LastName;
        private string _Designation;

        public Program()
        {

        }
        
        public Program(string firstName, string lastName, string designation)
        {
            _FirstName = firstName;
            _LastName = lastName;
            _Designation = designation;
        }

        public string FirstName 
        {
            get
            {
                return _FirstName;
            }
            set
            {
                _FirstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                _LastName = value;
            }
        }

        public string Designation
        {
            get
            {
                return _Designation;
            }
            set
            {
                _Designation = value;
            }
        }

        static void Main(string[] args)
        {
            Program p1 = new Program("Rohan", "Kumar", "Software Engineer");
            Program p2 = new Program("Jeshwanth", "Prasad", "Consultant");
            Program p3 = new Program("Ajay", "Sastri", "HR");
            List<Program> listEmployees = new List<Program> { p1, p2, p3 };
            Program emp = new Program();
            
            emp = listEmployees.Find((e) =>
            {
                return (e.FirstName == "Ajay");
            });
            Console.WriteLine(emp.LastName);
            
            StackTrace stackTrace = new StackTrace();
            StackFrame[] stackFrames = stackTrace.GetFrames();

            foreach(StackFrame st in stackFrames)
            {
                Console.WriteLine(st.GetMethod().Name);
            }
            Console.ReadKey();
        }
    }
}
