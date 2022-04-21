namespace StrandedStringBuilder
{
    /// <summary>
    /// Produces a string when invoked.
    /// </summary>
    /// <remarks>
    /// Make sure that the computation is thread safe.
    /// </remarks>
    /// <returns>The produced string.</returns>
    public delegate string StringProducer();
}
