public class ApiResponse<T>
{
    /// <summary>
    /// Error Id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Response Title
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Result
    /// </summary>
    public T Result { get; set; }
}