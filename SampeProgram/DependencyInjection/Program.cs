using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    //Interface Injection

    //public interface IService
    //{
    //    void Serve();
    //}

    //public class Service : IService
    //{
    //    public void Serve()
    //    {
    //        Console.WriteLine("Service Called");
    //        //To Do: Some Stuff
    //    }
    //}

    //public class Client
    //{
    //    private IService _service;

    //    public Client(IService service)
    //    {
    //        this._service = service;
    //    }

    //    public void Start()
    //    {
    //        Console.WriteLine("Service Started");
    //        this._service.Serve();
    //        //To Do: Some Stuff
    //    }
    //}
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Client client = new Client(new Service());
    //        client.Start();
    //        Console.ReadKey();
    //    }
    //}


    //Constructor Inejection

    public class Program
    {
        static void Main(string[] args)
        {
            FirstObject ft = new FirstObject();

            Console.Write(ft.GetData());
            Console.ReadKey();
        }
    }


    public class FirstObject : Program
    {
        public string GetData()
        {
            using(var helper = new BusinessHelper(this))
            {
                return helper.GetName();
            }
        }
    }

    public class BusinessHelper : IDisposable
    {
        public BusinessHelper(Program p1)
        {

        }

        public string GetName()
        {
            return "Hello World";
        }

        public void Dispose()
        {

        }
    }
}
