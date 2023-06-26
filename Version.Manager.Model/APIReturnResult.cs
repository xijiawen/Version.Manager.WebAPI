namespace Version.Manager.Model
{
    public class APIReturnResult<T>
    {
        /// <summary>
        /// 返回码 0正常  1 出错
        /// </summary>
        public int Code { get; set; } = 0;

        /// <summary>
        /// 返回信息
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// 返回数据
        /// </summary>
        public T Datas { get; set; }


        /// <summary>
        /// 隐式将返回的数据转换为ResponseResult
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator APIReturnResult<T>(T value)
        {
            return new APIReturnResult<T> { Datas = value };
        }
    }
}
