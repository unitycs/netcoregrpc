using extensionMethodLib;
using System;
using extensionMethods.extends;
namespace extensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            var nb = new NumRObject();
            nb.Run();
        }
    }


    class NumRObject
    {
       public void Run()
        {
            var com = new Complex(10, -10);
            var real = com.ToDouble();//调用扩展方法
            Console.WriteLine("复数" + com.ToValue() + "转换为double类型:" + real);
            Console.Read();
        }

    }


}
