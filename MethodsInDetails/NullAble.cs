namespace MethodsInDetails
{
    public static class NullAble
    {
        public static bool IsNull<T>(this T t)
        {
            return t == null ? true : false;
        }
    }
}
