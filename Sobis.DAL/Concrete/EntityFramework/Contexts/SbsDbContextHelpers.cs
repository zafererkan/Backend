using Microsoft.EntityFrameworkCore;
using Sobis.Core.Entities.Concrete;
using System;
using System.Linq;
using System.Reflection;

internal static class SbsDbContextHelpers
{


    public static void AddAllDbSet(this ModelBuilder modelBuilder)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var entityTypes = assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(EntityBase)) && t.Name.EndsWith("Entity", StringComparison.OrdinalIgnoreCase));

        foreach (var entityType in entityTypes)
        {
            modelBuilder.Entity(entityType);
        }
    }
}