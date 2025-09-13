namespace Web.Models
{
    /// <summary>
    /// 統一的 API 響應模型
    /// </summary>
    /// <typeparam name="T">數據類型</typeparam>
    public class ApiResponse<T>
    {
        /// <summary>
        /// 狀態 (Success/Fail)
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 響應訊息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 響應數據
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 構造函數
        /// </summary>
        public ApiResponse()
        {
            Status = "Success";
        }

        /// <summary>
        /// 成功響應
        /// </summary>
        /// <param name="data">數據</param>
        /// <param name="message">訊息</param>
        /// <returns>API 響應</returns>
        public static ApiResponse<T> Success(T data, string message = "操作成功")
        {
            return new ApiResponse<T>
            {
                Status = "Success",
                Message = message,
                Data = data
            };
        }

        /// <summary>
        /// 失敗響應
        /// </summary>
        /// <param name="message">錯誤訊息</param>
        /// <returns>API 響應</returns>
        public static ApiResponse<T> Fail(string message = "操作失敗")
        {
            return new ApiResponse<T>
            {
                Status = "Fail",
                Message = message,
                Data = default(T)
            };
        }
    }

    /// <summary>
    /// 無數據的統一 API 響應模型
    /// </summary>
    public class ApiResponse : ApiResponse<object>
    {
        /// <summary>
        /// 成功響應
        /// </summary>
        /// <param name="message">訊息</param>
        /// <returns>API 響應</returns>
        public static new ApiResponse Success(string message = "操作成功")
        {
            return new ApiResponse
            {
                Status = "Success",
                Message = message,
                Data = null
            };
        }

        /// <summary>
        /// 失敗響應
        /// </summary>
        /// <param name="message">錯誤訊息</param>
        /// <returns>API 響應</returns>
        public static new ApiResponse Fail(string message = "操作失敗")
        {
            return new ApiResponse
            {
                Status = "Fail",
                Message = message,
                Data = null
            };
        }
    }
}