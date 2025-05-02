namespace VirtualMachineManagement.Core.Commons
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public abstract string TableName { get; }
        public abstract string IdKeyColumnName { get; }


        private static readonly Dictionary<string, BaseEntity> _entities
            = new Dictionary<string, BaseEntity>();

        public static BaseEntity CreateEmptyInstance<T>()
        {
            var key = typeof(T).FullName;
            if (!_entities.ContainsKey(key))
            {
                var obj = Activator.CreateInstance<T>() as BaseEntity;
                _entities.Add(key, obj);
            }
            return _entities[key];
        }
    }
}
