namespace Sobis.BlazorWebUI.Client.Extensions
{
    public static class ObjectsExtensions
    {
        public static object ClearEntity(this object entity)
        {
            var obj = entity;

            foreach (var item in obj.GetType().GetProperties())
            {
                item.SetValue(obj, null, null);
            }
            return obj;
        }
    }
}
