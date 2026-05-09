 using System;
 using System.Collections.Generic;
 using System.Reflection;

 namespace EventSystem
 {
     public static class PredefinedAssemblyUtil
     {
         enum AssemblyType
         {
             AssemblyCSharp,
             AssemblyCSharpEditor,
             AssemblyCSharpEditorFirstPass,
             AssemblyCSharpFirstPass
         }

         static AssemblyType? GetAssemblyType(string assemblyName)
         {
             return assemblyName switch
             {
                 "AssemblyCSharp" => AssemblyType.AssemblyCSharp,
                 "Assembly-CSharp-Editor" => AssemblyType.AssemblyCSharpEditor,
                 "Assembly-CSharp-Editor-FirstPass" => AssemblyType.AssemblyCSharpEditorFirstPass,
                 "Assembly-CSharp-FirstPass" => AssemblyType.AssemblyCSharpFirstPass,
                 _ => null
             };
         }

         public static List<Type> GetTypes(Type interfaceType)
         {
             Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
             Dictionary<AssemblyType, Type[]> assemblyTypes = new Dictionary<AssemblyType, Type[]>();
             List<Type> types = new List<Type>();
             for (int i = 0; i < assemblies.Length; i++)
             {
                 AssemblyType? assemblyType = GetAssemblyType(assemblies[i].GetName().Name);
                 if (assemblyType != null)
                 {
                     assemblyTypes.Add((AssemblyType)assemblyType, assemblies[i].GetTypes());
                 }
             }

             AddTypesFromAssembly(assemblyTypes[AssemblyType.AssemblyCSharp], interfaceType, types);
             AddTypesFromAssembly(assemblyTypes[AssemblyType.AssemblyCSharpFirstPass], interfaceType, types);
             return types;
         }

         private static void AddTypesFromAssembly(Type[] assemblyType, Type interfaceType, ICollection<Type> types)
         {
             if (assemblyType == null)
             {
                 return;
             }

             for (int i = 0; i < assemblyType.Length; i++)
             {
                 Type type = assemblyType[i];
                 if (type != interfaceType && interfaceType.IsAssignableFrom(type))
                 {
                     types.Add(type);
                 }
             }
         }
     }
 }