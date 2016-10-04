namespace Problem1_StringBuilderSubstring
{
    using System.Text;

    public static class MyStringBuilder
    {

        public static StringBuilder MySubstring(this StringBuilder sb, int index, int length)
        {
            StringBuilder newSb = new StringBuilder();
            newSb.Append(sb.ToString(index, length));
            return newSb;
        }

    }
}


