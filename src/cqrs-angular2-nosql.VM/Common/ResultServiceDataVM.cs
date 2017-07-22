using cqrs_angular2_nosql.Util.MapperUtils;

namespace cqrs_angular2_nosql.VM.Common
{
    public class ResultServiceDataVM<T> : ResultServiceVM
    {
        public ResultServiceDataVM()
            : base()
        {
        }

        public T Data { get; set; }

        public ResultServiceDataVM<T> SetData(object entity)
        {
            Data = Mapper.Map<T>(entity);

            return this;
        }
    }
}
