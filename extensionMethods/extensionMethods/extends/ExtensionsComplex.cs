using extensionMethodLib;

namespace extensionMethods.extends
{

    public static class ExtensionsComplex
    {
        /// <summary> 
        /// /// 把复数类型转换为double类型(Complex的扩展方法) 
        /// /// </summary> 
        /// /// <param name="com">复数</param> 
        /// /// <returns>双精度值</returns> 
        public static double ToDouble(this Complex com)
        {
            return com.Real;
        }



        //把复数转换为字符串类型(Complex的扩展方法)
        /// </summary>
        /// /// <param name="com">复数</param>
        /// /// <returns>字符串值</returns>
        public static string ToValue(this Complex com)
        {
            string str = com.Real.ToString();
            if (com.Imag > 0)
                str += "+";
            if (com.Imag != 0)
                str += com.Imag + "i";
            return str;
        }
    }
}
