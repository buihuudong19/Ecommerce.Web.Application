﻿namespace Solid.Ecommerce.Application.Mappings;
public class MappingProfile:Profile
{
    public MappingProfile()
    {
        ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
    }

    private void ApplyMappingsFromAssembly(Assembly assembly)
    {
        //Mapping tat ca cac thuoc tinh cua Doi tuong A sang Doi tuong B (Dto)
        var types = assembly.GetExportedTypes()
          .Where(t => t.GetInterfaces().Any(i =>
            i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
          .ToList();

        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type);
            var methodInfo = type.GetMethod("Mapping")
                             ?? type.GetInterface("IMapFrom`1").GetMethod("Mapping");
            methodInfo?.Invoke(instance, new object[] { this });
        }
    }
}
