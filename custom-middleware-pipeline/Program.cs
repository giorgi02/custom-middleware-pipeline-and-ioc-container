using System;

namespace custom_middleware_pipeline
{
    class Program
    {
        static void Main(string[] args)
        {

            Pipeline pipeline = new Pipeline(ExceptionHendler, method1);
            //pipeline.AddMiddleware(ExceptionHendler);
            //pipeline.AddMiddleware(method1);
            pipeline.AddMiddleware(method2);
            pipeline.AddMiddleware(method3);
            pipeline.AddMiddleware(method4);
            pipeline.AddMiddleware(Endpoint);

            pipeline.Start();

            Console.ReadKey();
        }


        static void ExceptionHendler(Pipeline pipeline)
        {
            try
            {
                pipeline.Next();
            }
            catch (Exception ex)
            {
                Console.WriteLine("error: {0}", ex.Message);
            }
        }
        static void method1(Pipeline pipeline)
        {
            //throw new Exception("test exception");
            Console.WriteLine("m1--");
            pipeline.Next();
            Console.WriteLine("--m1");
        }
        static void method2(Pipeline pipeline)
        {
            Console.WriteLine("m2--");
            //throw new Exception("test exception");
            pipeline.Next();
            Console.WriteLine("--m2");
        }
        static void method3(Pipeline pipeline)
        {
            Console.WriteLine("m3--");
            pipeline.Next();
            //throw new Exception("test exception");
            Console.WriteLine("--m3");
        }
        static void method4(Pipeline pipeline)
        {
            Console.WriteLine("m4--");
            pipeline.Next();
            Console.WriteLine("--m4");
            //throw new Exception("test exception");
        }
        static void Endpoint(Pipeline pipeline)
        {
            Console.WriteLine("success: something result");
            //throw new Exception("test exception");
        }
    }
}
