using System.Text;

namespace MethodsInDetails
{
    public class DoubleHelper
    {
        static public string Convert(double num)
        {
            StringBuilder str = new StringBuilder(65, 65);
            long bitsLong = UnSafeDoubleToLong(num);

            for (int i = 0; i < sizeof(long) * 8; i++)
            {
                str.Insert(0, (bitsLong & 1) == 0? "0":"1");
                bitsLong >>= 1;
            }
           
            return str.ToString();
        }

        static unsafe private long UnSafeDoubleToLong(double num)
        {
            return *((long*)&num);
        }
    }
}
