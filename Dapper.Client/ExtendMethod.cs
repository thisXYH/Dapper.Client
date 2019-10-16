namespace Dapper.Client
{
    public static class ExtendMethod
    {
        /// <summary>
        /// 返回一个表示<strong> Ansi </strong>字符串的<see cref="DbString"/>对象。
        /// </summary>
        /// <param name="source">原字符串。</param>
        /// <param name="length">字符串长度，-1 表示 不限。</param>
        /// <param name="isFixedLength">是否固定长度。</param>
        /// <returns></returns>
        public static DbString AnsiString(this string source, int length = -1, bool isFixedLength = false)
        {
            return new DbString { Value = source, Length = length, IsFixedLength = isFixedLength, IsAnsi = true };
        }
    }
}
