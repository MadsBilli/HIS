using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Reflection.Emit;

namespace HIS.Common
{
    public class ObjectCreator
    {
          
            delegate object MethodInvoker();
            MethodInvoker methodHandler = null;

            public ObjectCreator(Type type)
            {
                CreateMethod(type.GetConstructor(Type.EmptyTypes));
            }

            public ObjectCreator(ConstructorInfo target)
            {
                CreateMethod(target);
            }

            public void CreateMethod(ConstructorInfo target)
            {
                DynamicMethod dynamic = new DynamicMethod(string.Empty,
                            typeof(object),
                            new Type[0],
                            target.DeclaringType);
                ILGenerator il = dynamic.GetILGenerator();
                il.DeclareLocal(target.DeclaringType);
                il.Emit(OpCodes.Newobj, target);
                il.Emit(OpCodes.Stloc_0);
                il.Emit(OpCodes.Ldloc_0);
                il.Emit(OpCodes.Ret);

                methodHandler = (MethodInvoker)dynamic.CreateDelegate(typeof(MethodInvoker));
            }

            public object CreateInstance()
            {
                return methodHandler();
            } 
    }
}
