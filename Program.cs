using System;

namespace BuildDepInj
{
    class Program
    {

        static void Main(string[] args)
        {
            if (args.Length == 0)
                throw new Exception("No argument has been provided. Please, type dotnet run 1 to run test 1.");

            if (args.Length > 1)
                throw new Exception("Too many arguments.");

            switch (args[0])
            {
                case "1":
                    Test1(); // You should see the same guid
                    break;
                case "2":
                    Test2(); // You should see the same guid
                    break;
                case "3":
                    Test3(); // You should see different guid
                    break;
                case "4":
                    Test4(); // You should see the same guid
                    break;
                case "5":
                    Test5(); // You should see different guid
                    break;
                case "6":
                    Test6(); // You should see the same guid
                    break;
                case "7":
                    Test7(); // You should see different guid
                    break;
                default:
                    throw new Exception($"Test {args[0]} does not exist!");
            }

        }

        static void Test1()
        {
            var services = new DIServiceCollection();

            services.RegisterSingleton(new BasicClass());

            DIContainer container = services.GenerateContainer();

            var service1 = container.GetService<BasicClass>();
            var service2 = container.GetService<BasicClass>();

            service1.PrintGuid();
            service2.PrintGuid();
        }

        static void Test2()
        {
            var services = new DIServiceCollection();

            services.RegisterSingleton<BasicClass>();

            DIContainer container = services.GenerateContainer();

            var service1 = container.GetService<BasicClass>();
            var service2 = container.GetService<BasicClass>();

            service1.PrintGuid();
            service2.PrintGuid();
        }

        static void Test3()
        {
            var services = new DIServiceCollection();

            services.RegisterTransient<BasicClass>();

            DIContainer container = services.GenerateContainer();

            var service1 = container.GetService<BasicClass>();
            var service2 = container.GetService<BasicClass>();

            service1.PrintGuid();
            service2.PrintGuid();
        }

        static void Test4()
        {
            var services = new DIServiceCollection();

            services.RegisterSingleton<DISamplesIntermediate.IGuiderService, DISamplesIntermediate.GuiderServiceA>();

            DIContainer container = services.GenerateContainer();

            var service1 = container.GetService<DISamplesIntermediate.IGuiderService>();
            var service2 = container.GetService<DISamplesIntermediate.IGuiderService>();

            service1.PrintGuid();
            service2.PrintGuid();
        }

        static void Test5()
        {
            var services = new DIServiceCollection();

            services.RegisterTransient<DISamplesIntermediate.IGuiderService, DISamplesIntermediate.GuiderServiceA>();

            DIContainer container = services.GenerateContainer();

            var service1 = container.GetService<DISamplesIntermediate.IGuiderService>();
            var service2 = container.GetService<DISamplesIntermediate.IGuiderService>();

            service1.PrintGuid();
            service2.PrintGuid();
        }


        static void Test6()
        {
            var services = new DIServiceCollection();

            services.RegisterSingleton<DISamplesAdvanced.IService, DISamplesAdvanced.ServiceA>();
            services.RegisterSingleton<DISamplesAdvanced.IRandomGuidProvider, DISamplesAdvanced.RandomGuidProviderA>();

            DIContainer container = services.GenerateContainer();

            var service1 = container.GetService<DISamplesAdvanced.IService>();
            var service2 = container.GetService<DISamplesAdvanced.IService>();

            service1.PrintGuid();
            service2.PrintGuid();
        }

        static void Test7()
        {
            var services = new DIServiceCollection();

            services.RegisterTransient<DISamplesAdvanced.IService, DISamplesAdvanced.ServiceA>();
            services.RegisterTransient<DISamplesAdvanced.IRandomGuidProvider, DISamplesAdvanced.RandomGuidProviderA>();

            DIContainer container = services.GenerateContainer();

            var service1 = container.GetService<DISamplesAdvanced.IService>();
            var service2 = container.GetService<DISamplesAdvanced.IService>();

            service1.PrintGuid();
            service2.PrintGuid();
        }


    }
}
