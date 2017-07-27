namespace cqrs_angular2_nosql.Infra.ContainerHandler
{
    /// <summary>
    /// Singleton do container para ser usado no Bus
    /// </summary>
    public class ContainerHandler
    {
        public static SimpleInjector.Container container { get; set; }
    }
}
