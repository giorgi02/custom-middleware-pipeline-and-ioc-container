using System;
using System.Collections.Generic;
using System.Text;

namespace custom_middleware_pipeline
{
    public delegate void Middleware(Pipeline pipeline);

    public class Pipeline
    {
        private List<Middleware> _middlewares;
        private int _counter = -1;

        public Pipeline() =>
            _middlewares = new List<Middleware>();

        public Pipeline(params Middleware[] middlewares)
        {
            _middlewares = new List<Middleware>();
            _middlewares.AddRange(middlewares);
        }




        public void AddMiddleware(Middleware middleware) =>
            _middlewares.Add(middleware);


        public void Start() => this.Next();


        public void Next() =>
            _middlewares[++_counter].Invoke(this);


    }
}
